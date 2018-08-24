<template>
    <div class="auction-summary-table">
        <v-progress-linear v-if="isLoading" :indeterminate="isLoading"></v-progress-linear>
        <v-data-table
            :headers="headers"
            :items="records"
            :pagination.sync="pagination"
            hide-actions
            class="elevation-1">
            <template slot="items" slot-scope="props">
                <td>{{ props.item.name }}</td>
                <td>{{ props.item.validTo | moment('DD.MM.YYYY HH:mm') }}</td>
                <td>{{ props.item.currentPrice }}</td>
                <td>
                    <v-icon
                        style="cursor: pointer"
                        small
                        class="mr-2"
                        @click="goToDetal(props.item)">
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

import { Component, Prop, Watch } from 'vue-property-decorator';
import { Action, Getter, namespace } from 'vuex-class';

import BaseComponent from './BaseComponent.vue';
import { RecordTableDto } from '@/poco';

const RecordAction = namespace('record', Action);
const RecordGetter = namespace('record', Getter);

@Component({})
export default class AuctionSummaryComponent extends BaseComponent {
    @Prop({default: undefined}) public userId: number;
    @RecordAction('getAllActiveWithUsersBids') public loadRecords: any;
    @RecordGetter('getRecords') public records: RecordTableDto[];
    @RecordAction('getDetail') public loadRecord: any;

    public pagination: any = {
        rowsPerPage: 5,
        totalItems: 0,
    };
    private isLoading: boolean = true;
    private headers: any[] = [];

    @Watch('records') private changeUsers(records) {
        if (records !== undefined && records.length > 0) {
            this.pagination.totalItems = records.length;
        }
    }

    private mounted() {
        this.headers.push({
            text: this.settings.resource.name,
            align: 'left',
            sortable: true,
            value: 'name' });
        this.headers.push({
            text: this.settings.resource.end,
            align: 'left',
            sortable: true,
            value: 'validTo' });
        this.headers.push({
            text: this.settings.resource.actualPrice,
            align: 'left',
            sortable: true,
            value: 'currentPrice' });
        this.headers.push({
            text: this.settings.resource.action,
            align: 'left',
            sortable: true,
            value: 'action' });

        this.loadRecords(this.userId).then((response) => {
            if (response) {
                this.pagination.totalItems = this.records.length;
                this.$emit('amount', this.records.length);
            }
            this.isLoading = false;
        });
    }

    get pages() {
        if (this.pagination.rowsPerPage == null ||
          this.pagination.totalItems == null) {
              return 0;
        }

        return Math.ceil(this.pagination.totalItems / this.pagination.rowsPerPage);
    }

    private goToDetal(item: RecordTableDto): void {
        this.isLoading = true;
        this.loadRecord(item.id).then((response) => {
            const result = response as boolean;
            this.isLoading = false;
            if (result) {
                this.$router.push({ name: 'auctionDetail' });
            }
        });
    }
}

</script>

<style>

.auction-summary-table .elevation-1 {
    -webkit-box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0) !important;
    box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0)!important;
}

.auction-summary-table .v-pagination .v-pagination__item--active {
    background-color: #546E7A !important;
}

</style>
