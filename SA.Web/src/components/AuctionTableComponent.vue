<template>
  <div class="aution-table">
      <v-data-table
        :headers="headers"
        :items="records"
        :pagination.sync="pagination"
        hide-actions
        class="elevation-1">
        <template slot="items" slot-scope="props">
            <td>{{ props.item.name }}</td>
            <td>{{ props.item.state }}</td>
            <td class="text-xs-right">{{ props.item.currentPrice }} CZK</td>
            <td class="text-xs-right">{{ props.item.minimumBid }} CZK</td>
            <td class="text-xs-right">
                <v-avatar class="teal" :size="30">
                    <span white--text headline>{{ props.item.numberOfBids }}</span>
                </v-avatar>
            </td>
            <td>
                <v-chip color="red lighten-1" text-color="white">
                    {{ countDown(props.item) }}<span id="count-down"></span>
                </v-chip>
            </td>
            <td>
                <v-icon
                    style="cursor: pointer"
                    small
                    class="mr-2"
                    >
                    arrow_forward
                </v-icon>
            </td>
        </template>
    </v-data-table>
    <div class="text-xs-center pt-2">
        <v-pagination v-model="pagination.page" :length="pages"></v-pagination>
    </div>
  </div>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import { Getter, namespace } from 'vuex-class';

import { Record } from '@/model';
import BaseComponent from './BaseComponent.vue';
import Helpers from '@/helpers';

@Component({})
export default class AuctionTableComponent extends BaseComponent {
    @Prop({default: undefined}) private records: Record[];

    private headers: any[] = [];
    private pagination: any = {
        rowsPerPage: 10,
        totalItems: 0,
    };

    public mounted() {
        this.headers.push({
            text: this.settings.resource.name,
            align: 'left',
            sortable: true,
            value: 'name' });
        this.headers.push({
            text: this.settings.resource.state,
            align: 'left',
            sortable: false,
            value: 'state' });
        this.headers.push({
            text: this.settings.resource.currentPrice,
            align: 'right',
            sortable: true,
            value: 'currentPrice' });
        this.headers.push({
            text: this.settings.resource.minimumBid,
            align: 'right',
            sortable: true,
            value: 'minimumBid' });
        this.headers.push({
            text: this.settings.resource.numberOfBids,
            align: 'right',
            sortable: true,
            value: 'numberOfBids' });
        this.headers.push({
            text: this.settings.resource.endOfAuction,
            align: 'left',
            sortable: true,
            value: 'validTo' });
        this.headers.push({
            text: this.settings.resource.action,
            align: 'left',
            sortable: true,
            value: 'action' });
    }

    private countDown(record: Record): void {
        const x = setInterval(() => {
            const thick = Helpers.countDown(record.validTo);
            document.getElementById('count-down')
            .innerHTML = thick;
        }, 1000);
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
#count-down {
  margin-left: 5px;
}
</style>
