<template>
  <div class="auction-table" v-if="records">
      <v-data-table
        :headers="headers"
        :items="records"
        :loading="isLoading"
        :pagination.sync="pagination"
        hide-actions
        class="elevation-1">
        <v-progress-linear slot="progress" color="blue" indeterminate></v-progress-linear>
        <template slot="items" slot-scope="props">
            <td>{{ props.item.name }}</td>
            <td>{{ props.item.state }}</td>
            <td class="text-xs-right">{{ props.item.currentPrice }} CZK</td>
            <td class="text-xs-right">{{ props.item.minimumBid }} CZK</td>
            <td class="text-xs-right">
                <v-avatar color="teal" :size="30">
                    <span class="white--text" headline>{{ props.item.numberOfBids }}</span>
                </v-avatar>
            </td>
            <td>
                <v-chip color="red lighten-1" text-color="white">
                    <countdown-component
                        :id="recordIdToString(props.item)"
                        :date="props.item.validTo" />
                </v-chip>
            </td>
            <td class="text-xs-center">
              <v-tooltip top>
                <v-btn icon slot="activator" @click="detail(props.item)">
                  <v-icon>desktop_windows</v-icon>
                </v-btn>
                <span>{{ resx('detailOfAuction') }}</span>
              </v-tooltip>
              <v-tooltip top>
                <v-btn icon slot="activator">
                  <v-icon>favorite</v-icon>
                </v-btn>
                <span>{{ resx('intoFavorites') }}</span>
              </v-tooltip>
              <v-tooltip top>
                <v-btn icon slot="activator">
                  <v-icon>share</v-icon>
                </v-btn>
                <span>{{ resx('share') }}</span>
              </v-tooltip>
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
import { Action, namespace } from 'vuex-class';

import { Record } from './../model';

import BaseComponent from './BaseComponent.vue';
import CountdownComponent from './helpers/CountdownComponent.vue';

const RecordAction = namespace('record', Action);

@Component({
    components: {
        CountdownComponent,
    },
})
export default class AuctionTableComponent extends BaseComponent {
    @Prop({default: undefined})
    public records: Record[];

    @RecordAction('getDetail')
    public loadRecord: any;

    private isLoading: boolean = false;
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
            align: 'center',
            sortable: true,
            value: 'action' });
    }

    private countDownId(id: number): string {
        return `count-down-${id}`;
    }

    private recordIdToString(record: Record): string {
        return record.id.toString();
    }

    private detail(record: Record): void {
        this.isLoading = true;
        this.loadRecord(record.id).then((response) => {
        const result = response as boolean;
        this.isLoading = false;
        if (result) {
            this.$router.push({ name: 'auctionDetail' });
        }
        });
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
