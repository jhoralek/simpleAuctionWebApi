<template>
    <div class="auction-summary-table">
        <loading-component :open="loading" />
        <v-layout row wrap>
            <v-flex xs12>
                <h4>{{ resx('active') }}</h4>
            </v-flex>
        </v-layout>
        <v-layout row wrap>
            <v-flex xs12>
                <v-data-table
                    :headers="headers"
                    :items="actualRecords"
                    :pagination.sync="paginationActual"
                    hide-actions
                    class="elevation-1">
                    <template slot="items" slot-scope="props">
                        <td class="text-xs-left">
                            <v-tooltip top v-if="winning(props.item.winningUserId)">
                                <v-icon small color="green" slot="activator" style="cursor: pointer">thumb_up</v-icon>
                                <span>{{ resx('winning') }} </span>
                            </v-tooltip>
                            <v-tooltip top v-else>
                                <v-icon small color="red" slot="activator" style="cursor: pointer">thumb_down</v-icon>
                                <span>{{ resx('notWinning') }} </span>
                            </v-tooltip>
                        </td>
                        <td class="text-xs-left">{{ props.item.name }}</td>
                        <td class="text-xs-left">{{ props.item.validTo | moment('DD.MM.YYYY HH:mm') }}</td>
                        <td class="text-xs-right"><price-component :price="props.item.currentPrice" /></td>
                        <td class="text-xs-center">{{ props.item.numberOfBids }}</td>
                        <td>
                            <v-tooltip right>
                                <v-icon
                                    slot="activator"
                                    style="cursor: pointer"
                                    small
                                    class="mr-2"
                                    @click="goToDetal(props.item)">
                                    arrow_forward
                                </v-icon>
                                <span>{{ resx('detailOfAuction') }}</span>
                            </v-tooltip>
                        </td>
                    </template>
                </v-data-table>
                <div class="text-xs-center pt-2">
                    <v-pagination v-model="paginationActual.page" :length="pagesActual" :total-visible="3"></v-pagination>
                </div>
            </v-flex>
        </v-layout>
        <v-layout row wrap>
            <v-flex xs12>
                <h4>{{ resx('ended') }}</h4>
            </v-flex>
        </v-layout>
        <v-layout row wrap>
            <v-flex xs12>
                <v-data-table
                    :headers="headers"
                    :items="endedRecords"
                    :pagination.sync="paginationEnded"
                    hide-actions
                    class="elevation-1">
                    <template slot="items" slot-scope="props">
                        <td class="text-xs-left">
                            <v-tooltip top v-if="winning(props.item.winningUserId)">
                                <v-icon small color="green" slot="activator" style="cursor: pointer">thumb_up</v-icon>
                                <span>{{ resx('won') }} </span>
                            </v-tooltip>
                            <v-tooltip top v-else>
                                <v-icon small color="red" slot="activator" style="cursor: pointer">thumb_down</v-icon>
                                <span>{{ resx('didntWon') }} </span>
                            </v-tooltip>
                        </td>
                        <td class="text-xs-left">{{ props.item.name }}</td>
                        <td class="text-xs-left">{{ props.item.validTo | moment('DD.MM.YYYY HH:mm') }}</td>
                        <td class="text-xs-right"><price-component :price="props.item.currentPrice" /></td>
                        <td class="text-xs-center">{{ props.item.numberOfBids }}</td>
                        <td>
                            <v-tooltip right>
                                <v-icon
                                    slot="activator"
                                    style="cursor: pointer"
                                    small
                                    class="mr-2"
                                    @click="goToDetal(props.item)">
                                    arrow_forward
                                </v-icon>
                                <span>{{ resx('detailOfAuction') }}</span>
                            </v-tooltip>
                        </td>
                    </template>
                </v-data-table>
                <div class="text-xs-center pt-2">
                    <v-pagination v-model="paginationEnded.page" :length="pagesEnded" :total-visible="3"></v-pagination>
                </div>
            </v-flex>
        </v-layout>
    </div>
</template>

<script lang="ts">

import { Component, Prop, Watch } from 'vue-property-decorator';
import { State, Action, Getter, namespace } from 'vuex-class';

import { AuthState } from '@/store/types';
import PriceComponent from '@/components/helpers/PriceComponent.vue';
import LoadingComponent from '@/components/helpers/LoadingComponent.vue';
import BaseComponent from './BaseComponent.vue';
import { RecordTableDto } from '@/poco';

const ProfileGetter = namespace('profile', Getter);
const RecordAction = namespace('record', Action);

@Component({
    components: {
        LoadingComponent,
        PriceComponent,
    },
})
export default class AuctionSummaryComponent extends BaseComponent {
    @State('auth') private auth: AuthState;
    @ProfileGetter('getCurrentAuctions') private actualRecords: RecordTableDto[];
    @ProfileGetter('getEndedAuctions') private endedRecords: RecordTableDto[];
    @RecordAction('getDetail') private loadRecord: any;

    private paginationActual: any = {
      rowsPerPage: 5,
      totalItems: 0,
    };
    private paginationEnded: any = {
      rowsPerPage: 5,
      totalItems: 0,
    };
    private loading: boolean = false;
    private headers: any[] = [];

    @Watch('actualRecords') private changeActualRecords(actualRecords) {
        if (actualRecords !== undefined && actualRecords.length > 0) {
            this.paginationActual.totalItems = actualRecords.length;
        }
    }

    @Watch('endedRecords') private changeEndedRecords(endedRecords) {
        if (endedRecords !== undefined && endedRecords.length > 0) {
            this.paginationEnded.totalItems = endedRecords.length;
        }
    }

    private mounted() {
        this.headers.push({
            text: '',
            align: 'left',
            sortable: false,
            value: 'info' });
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
            align: 'right',
            sortable: true,
            value: 'currentPrice' });
        this.headers.push({
            text: this.settings.resource.bids,
            align: 'right',
            sortable: true,
            value: 'numberOfBids' });
        this.headers.push({
            text: this.settings.resource.action,
            align: 'left',
            sortable: true,
            value: 'action' });
    }

    get pagesActual() {
        if (this.paginationActual.rowsPerPage == null ||
          this.paginationActual.totalItems == null) {
              return 0;
        }

        return Math.ceil(this.paginationActual.totalItems
            / this.paginationActual.rowsPerPage);
    }

        get pagesEnded() {
        if (this.paginationEnded.rowsPerPage == null ||
          this.paginationEnded.totalItems == null) {
              return 0;
        }

        return Math.ceil(this.paginationEnded.totalItems
            / this.paginationEnded.rowsPerPage);
    }

    private winning(winningUserId: number): boolean {
        return winningUserId === this.auth.userId;
    }

    private goToDetal(item: RecordTableDto): void {
        this.loading = true;
        this.loadRecord(item.id).then((response) => {
            const result = response as boolean;
            this.loading = false;
            if (result) {
                this.$router.push({ path: `/auctionDetail?id=${item.id}` });
            }
        });
    }
}

</script>

<style>

table.v-table tbody td:first-child, table.v-table tbody td:not(:first-child), table.v-table tbody th:first-child, table.v-table tbody th:not(:first-child), table.v-table thead td:first-child, table.v-table thead td:not(:first-child), table.v-table thead th:first-child, table.v-table thead th:not(:first-child) {
    padding-left: 20px !important;
    font-size: 11px !important;
}

.auction-summary-table h4 {
    padding-left: 20px !important;
    padding-top: 4px !important;
    font-size: 16px !important;
}

.auction-summary-table .elevation-1 {
    -webkit-box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0) !important;
    box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0)!important;
}

.auction-summary-table .v-pagination .v-pagination__item--active {
    background-color: #546E7A !important;
}

</style>
