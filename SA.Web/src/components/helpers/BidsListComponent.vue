<template>
  <div class="bids-table">
    <v-data-table
        :headers="headers"
        :items="bids"
        :pagination.sync="pagination"
        hide-actions
        class="elevation-1">
        <template slot="items" slot-scope="props">
        <td class="text-xs-left">{{ props.item.created | moment('DD.MM.YYYY HH:mm:ss') }}</td>
        <td v-if="anonymizeUser" class="text-xs-left">{{ anonymize(props.item.userName) }}</td>
        <td v-if="!anonymizeUser" class="text-xs-left">{{ props.item.userName }}</td>
        <td v-if="anonymizeUser" class="text-xs-left">{{ resx('bidedBy') }}</td>
        <td class="text-xs-right">
            <price-component :price="props.item.price" />
        </td>
        </template>
    </v-data-table>
    <div class="text-xs-center pt-2">
      <v-pagination v-model="pagination.page" :length="pages"></v-pagination>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Watch } from 'vue-property-decorator';
import { Getter, namespace } from 'vuex-class';

import BaseComponent from '../BaseComponent.vue';
import PriceComponent from './PriceComponent.vue';

import { BidDto } from './../../poco';
import Helpers from './../../helpers';

@Component({
      components: {
        PriceComponent,
    },
})
export default class BidsListComponent extends BaseComponent {
  @Prop({ default: undefined }) private bids: BidDto[];
  @Prop({ default: true }) private anonymizeUser: boolean;
  @Prop({ default: 10 }) private pageRows: number;
  @Prop({ default: false }) private withHeaders: boolean;

  private headers: any[] = [];
  private pagination: any = {
      rowsPerPage: this.pageRows,
      totalItems: 0,
  };

  private mounted() {
    if (this.withHeaders) {
      this.headers.push({
          text: this.settings.resource.date,
          align: 'left',
          sortable: true,
          value: 'created' });
      this.headers.push({
          text: this.settings.resource.userName,
          align: 'left',
          sortable: true,
          value: 'userName' });
      if (this.anonymizeUser) {
        this.headers.push({
            text: '',
            align: 'right',
            sortable: true,
            value: 'bidedBy' });
        }
      this.headers.push({
          text: this.settings.resource.currentPrice,
          align: 'right',
          sortable: true,
          value: 'currentPrice' });
    }
  }

  private anonymize(str: string): string {
        return Helpers.anonymizeString(str, 1, str.length);
  }

  @Watch('bids') private changeUsers(bids) {
      if (bids !== undefined && bids.length > 0) {
          this.pagination.totalItems = bids.length;
      }
  }

  get pages() {
    if (this.pagination.rowsPerPage == null ||
      this.pagination.totalItems == null) {
          return 0;
    }
    return Math.ceil(this.pagination.totalItems / this.pagination.rowsPerPage);
  }

}
</script>

<style>

.bids-table .v-pagination .v-pagination__item--active {
    background-color: #546E7A !important;
}

</style>
