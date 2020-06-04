<template>
    <div class="gdpr-admministration-table">
        <v-container  grid-list-xs pa-0>
          <v-layout row wrap>
              <v-flex xs12>
                <v-data-table
                    :headers="headers"
                    :items="gdprRecords"
                    :loading="loading"
                    :pagination.sync="pagination"
                    hide-actions
                    class="elevation-1">
                    <v-progress-linear slot="progress" color="blue" indeterminate></v-progress-linear>
                    <template slot="items" slot-scope="props">
                        <td>{{ props.item.fullName }}</td>
                        <td>{{ props.item.email }}</td>
                        <td>{{ props.item.phoneNumber }}</td>
                        <td>{{ props.item.city }}</td>
                        <td>{{ props.item.type }}</td>
                        <td>
                            <v-checkbox
                                v-model="props.item.isProcessed"
                                :disabled="true"
                                hide-details
                                class="shrink mr-2" />
                        </td>
                        <td>{{ props.item.created | moment('DD.MM.YYYY HH:mm:ss') }}</td>
                        <td>
                            <v-icon
                                style="cursor: pointer"
                                small
                                class="mr-2"
                                @click="edit(props.item)">
                                edit
                            </v-icon>
                        </td>
                    </template>
                </v-data-table>
                <div class="text-xs-center pt-2">
                    <v-pagination v-model="pagination.page" :length="pages"></v-pagination>
                </div>
              </v-flex>
          </v-layout>
      </v-container>
    </div>
</template>

<script lang="ts">

import { Component, Prop, Watch } from 'vue-property-decorator';
import { State, Action, namespace } from 'vuex-class';

import { GdprRecordTableDto } from './../../poco';
import { ProfileState } from './../../store/types';
import BaseComponent from '../BaseComponent.vue';

const ProfileAction = namespace('profile', Action);

@Component({})
export default class GdprTableComponent extends BaseComponent {
    @Prop({default: []})
    private gdprRecords: GdprRecordTableDto[];
    @Prop({default: true})
    private loading: boolean;

    private actionInProgress: boolean = false;
    private dialog: boolean = false;
    private headers: any[] = [];
    private pagination: any = {
        rowsPerPage: 10,
        totalItems: 0,
    };

    @Watch('gdprRecords')
    private changeUsers(gdprRecords) {
        if (gdprRecords !== undefined && gdprRecords.length > 0) {
            this.pagination.totalItems = gdprRecords.length;
        }
    }

    private edit(item: GdprRecordTableDto): void {
        // this.setUser(item).then((response) => {
        //     this.dialog = response;
        // });
    }

    private saveEdit(): void {
        this.actionInProgress = true;
    }

    private closeDialog(): void {
        this.dialog = false;
    }

    private mounted() {
        this.headers.push({
            text: this.settings.resource.fullName,
            align: 'left',
            sortable: true,
            value: 'fullName' });
        this.headers.push({
            text: this.settings.resource.email,
            align: 'left',
            sortable: true,
            value: 'email' });
        this.headers.push({
            text: this.settings.resource.phoneNumber,
            align: 'left',
            sortable: true,
            value: 'phoneNUmber' });
        this.headers.push({
            text: this.settings.resource.city,
            align: 'left',
            sortable: true,
            value: 'city' });
        this.headers.push({
            text: this.settings.resource.applicationType,
            align: 'left',
            sortable: true,
            value: 'type' });
        this.headers.push({
            text: this.settings.resource.processed,
            align: 'center',
            sortable: true,
            value: 'isProcessed' });
        this.headers.push({
            text: this.settings.resource.created,
            align: 'right',
            sortable: true,
            value: 'created' });
        this.headers.push({
            text: this.settings.resource.action,
            align: 'center',
            sortable: true,
            value: 'action' });
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

.gdpr-admministration-table .elevation-1 {
    -webkit-box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0) !important;
    box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0)!important;
}

.gdpr-admministration-table .v-pagination .v-pagination__item--active {
    background-color: #546E7A !important;
}

</style>