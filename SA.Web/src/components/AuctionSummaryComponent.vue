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
                <td>{{ props.item.validTo | moment('DD.MM.YYYY') }}</td>
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

import { Component, Prop } from 'vue-property-decorator';
import { State, Action, Getter, namespace } from 'vuex-class';

import { Record } from '@/model';
import BaseComponent from './BaseComponent.vue';
import { log } from 'util';

const RecordGetter = namespace('record', Getter);
const RecordAction = namespace('record', Action);

@Component({})
export default class AuctionSummaryComponent extends BaseComponent {
    @Prop({default: undefined}) public userId: number;
    @RecordGetter('getRecords') public records: Record[];
    @RecordAction('getAllActiveWithUsersBids') public loadRecords: any;

    public pagination: any = {
        rowsPerPage: 4,
        totalItems: 0,
    };
    private isLoading: boolean = true;
    private headers: any[] = [];

    public mounted() {
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

    private goToDetal(item: Record): void {
        log(`${item.name}`);
    }
}

</script>
