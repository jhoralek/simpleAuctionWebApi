<template>
  <div class="user-admin-table">
      <v-dialog v-model="dialog" max-width="500px" v-if="profile.user" persistent>
        <v-card>
          <v-progress-linear v-if="actionInProgress" indeterminate></v-progress-linear>
          <v-card-title>
            <span class="headline">{{ resx('user') }}: {{ profile.user.userName }}</span>
          </v-card-title>
          <v-card-text>
            <v-container  grid-list-xs pa-0>
              <v-layout row wrap>
                <v-flex xs12 md6>
                    <v-switch
                        v-model="profile.user.isFeePayed"
                        :label="labelIsFeePayed" />
                </v-flex>
                <v-flex xs12 md6>
                    <v-switch
                        v-model="profile.user.isActive"
                        :label="labelIsActive" />
                </v-flex>
              </v-layout>
              <v-layout row wrap v-if="currentCustomer">
                  <v-flex xs12 md6>{{ resx('fullName') }}</v-flex>
                  <v-flex xs12 md6>{{ currentCustomer.firstName }} {{ currentCustomer.lastName }}</v-flex>
              </v-layout>
              <v-layout row wrap v-if="currentCustomer">
                  <v-flex xs12 md6>{{ resx('email') }}</v-flex>
                  <v-flex xs12 md6>{{ currentCustomer.email }}</v-flex>
              </v-layout>
              <v-layout row wrap v-if="currentCustomer">
                  <v-flex xs12 md6>{{ resx('companyName') }}</v-flex>
                  <v-flex xs12 md6>{{ currentCustomer.companyName }}</v-flex>
              </v-layout>
              <v-layout row wrap v-if="currentCustomer">
                  <v-flex xs12 md6>{{ resx('companyNumber') }}</v-flex>
                  <v-flex xs12 md6>{{ currentCustomer.companyNumber }}</v-flex>
              </v-layout>
              <v-layout row wrap v-if="currentCustomer">
                  <v-flex xs12 md6>{{ resx('phoneNumber') }}</v-flex>
                  <v-flex xs12 md6>{{ currentCustomer.phoneNumber }}</v-flex>
              </v-layout>
            </v-container>
          </v-card-text>

          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="info" flat @click.native="closeDialog">{{ resx('cancel') }}</v-btn>
            <v-btn color="success" flat @click.native="saveEdit">{{ resx('submit') }}</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <v-container  grid-list-xs pa-0>
          <v-layout>
            <v-flex xs3>
                <v-chip
                    class="ma-2"
                    color="red"
                    text-color="white">
                      {{ resx('notActivated' )}}
                </v-chip>
                <v-chip
                    class="ma-2"
                    color="green"
                    text-color="white">
                      {{ resx('feePayed' )}}
                </v-chip>
                <v-chip
                    class="ma-2"
                    color="blue"
                    text-color="white">
                      {{ resx('active' )}}
                </v-chip>
            </v-flex>
            <v-flex xs2 class="text-xs-left">
                <v-text-field
                    filled
                    v-model="searchText"
                    :label="labelSearch"
                    prepend-inner-icon="mdi-magnify">
                </v-text-field>
            </v-flex>
            <v-flex xs2>
                <v-select
                    v-model="searchType"
                    item-value="id"
                    item-text="name"
                    single-line
                    :label="labelSearchTypes"
                    :items="searchTypeItems" />
            </v-flex>
            <v-flex xs2>
            </v-flex>
            <v-flex xs1 class="text-xs-right">
                <v-switch
                    v-model="isActive"
                    :label="labelIsActive" />
            </v-flex>
            <v-flex xs2 class="text-xs-right">
                <v-switch
                    v-model="isFeePayed"
                    :label="labelIsFeePayed " />
            </v-flex>
          </v-layout>
          <v-layout row wrap>
              <v-flex xs12>
                <v-data-table
                    :headers="headers"
                    :items="users"
                    :loading="loading"
                    :pagination.sync="pagination"
                    hide-actions
                    class="elevation-1">
                    <v-progress-linear slot="progress" color="blue" indeterminate></v-progress-linear>
                    <template slot="items" slot-scope="props">
                        <tr :class="{
                            row_color_active: activeColor(props.item),
                            row_color_feePayed: feePayedColor(props.item),
                            row_color_noActive: notActiveColor(props.item)
                        }">
                            <td>{{ props.item.userName }}</td>
                            <td>{{ props.item.email }}</td>
                            <td>{{ props.item.phoneNumber }}</td>
                            <td>{{ props.item.companyNumber }}</td>
                            <td>{{ props.item.birthNumber }}</td>
                            <td>
                                <v-checkbox
                                    v-model="props.item.isActive"
                                    :disabled="true"
                                    hide-details
                                    class="shrink mr-2" />
                            </td>
                            <td>
                                <v-checkbox
                                    v-model="props.item.sendingNews"
                                    :disabled="true"
                                    hide-details
                                    class="shrink mr-2" />
                            </td>
                            <td>{{ props.item.created | moment('DD.MM.YYYY') }}</td>
                            <td>
                                <v-checkbox
                                    v-model="props.item.isFeePayed"
                                    :disabled="true"
                                    hide-details
                                    class="shrink mr-2" />
                            </td>
                            <td>
                                <v-icon
                                    style="cursor: pointer"
                                    small
                                    class="mr-2"
                                    @click="edit(props.item)">
                                    edit
                                </v-icon>
                            </td>
                        </tr>
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
import { State, Action, Getter, namespace } from 'vuex-class';

import { Customer } from './../../model';
import { UserSimpleDto } from './../../poco';
import { ProfileState } from './../../store/types';
import BaseComponent from '../BaseComponent.vue';

const ProfileAction = namespace('profile', Action);
const ProfileGetter = namespace('profile', Getter);

@Component({})
export default class UserTableComponent extends BaseComponent {
    @State('profile')
    private profile: ProfileState;

    @Prop({default: []})
    private users: UserSimpleDto[];
    @Prop({default: true})
    private loading: boolean;

    @ProfileAction('setCurrentUser')
    private setUser: any;
    @ProfileAction('updateUserAdmin')
    private updateUser: any;
    @ProfileAction('filterUsers')
    private filterUsers: any;

    @ProfileGetter('getCurrentCustomer')
    private currentCustomer: Customer;

    private actionInProgress: boolean = false;
    private dialog: boolean = false;
    private headers: any[] = [];
    private pagination: any = {
        rowsPerPage: 10,
        totalItems: 0,
    };

    private searchType: string = '';
    private searchCompanyNumber: string = '';
    private searchTypeItems: any = [];
    private isActive: boolean = false;
    private isFeePayed: boolean = false;
    private searchText: string = '';
    private filterSorceUserList: UserSimpleDto[] = [];

    @Watch('users')
    private changeUsers(users) {
        if (users !== undefined && users.length > 0) {
            this.pagination.totalItems = users.length;
        }

        if (this.filterSorceUserList.length <= 0) {
            Object.assign(this.filterSorceUserList, this.users);
        }
    }

    @Watch('searchText')
    private searchTextFnc(text) {
        let filteredUsers: UserSimpleDto[] = [];
        Object.assign(filteredUsers, this.filterSorceUserList);

        if (text.length > 0) {
            filteredUsers = this.filterByType(filteredUsers, this.searchType, text);
        }

        if (this.isActive) {
            filteredUsers = this.filterIsActive(filteredUsers);
        }

        if (this.isFeePayed) {
            filteredUsers = this.filterIsFeePayed(filteredUsers);
        }

        this.filterUsers(filteredUsers);
    }

    @Watch('isActive')
    private changeFilterIsActive(isActive) {
        let filteredUsers: UserSimpleDto[] = [];
        Object.assign(filteredUsers, this.filterSorceUserList);

        if (this.searchText.length > 0) {
            filteredUsers = this.filterByType(filteredUsers, this.searchType, this.searchText);
        }

        if (isActive) {
            filteredUsers = this.filterIsActive(filteredUsers);
        }

        if (this.isFeePayed) {
            filteredUsers = this.filterIsFeePayed(filteredUsers);
        }

        this.filterUsers(filteredUsers);
    }

    @Watch('isFeePayed')
    private changeFilterIsEnded(isFeePayed) {
        let filteredUsers: UserSimpleDto[] = [];
        Object.assign(filteredUsers, this.filterSorceUserList);

        if (this.searchText.length > 0) {
            filteredUsers = this.filterByType(filteredUsers, this.searchType, this.searchText);
        }

        if (this.isActive) {
            filteredUsers = this.filterIsActive(filteredUsers);
        }

        if (isFeePayed) {
            filteredUsers = this.filterIsFeePayed(filteredUsers);
        }

        this.filterUsers(filteredUsers);
    }

    private edit(item: UserSimpleDto): void {
        this.setUser(item).then((response) => {
            this.dialog = response;
        });
    }

    private closeDialog(): void {
        this.dialog = false;
    }

    private saveEdit(): void {
        this.actionInProgress = true;
        this.updateUser(this.profile.user).then((response) => {
            this.actionInProgress = false;
            this.closeDialog();
        });
    }

    private filterByType(source: UserSimpleDto[], type: string, text: string): UserSimpleDto[] {
        switch (type) {
            case 'userName':
                return source.filter((item) =>
                    item.userName.toLowerCase().includes(text.toLowerCase()));
                break;
            case 'email':
                return source.filter((item) =>
                    item.email.toLowerCase().includes(text.toLowerCase()));
                break;
            case 'phoneNumber':
                return source.filter((item) =>
                    item.phoneNumber.toLowerCase().includes(text.toLowerCase()));
                break;
            case 'birthNumber':
                return source.filter((item) => item.birthNumber != null
                    && text != null
                    && item.birthNumber.toLowerCase().includes(text.toLowerCase()));
                break;
            case 'companyNumber':
                return source.filter((item) => item.companyNumber != null
                    && text != null
                    && item.companyNumber.toLowerCase().includes(text.toLowerCase()));
                break;
            default:
                return source;
                break;
        }
    }

    private filterIsActive(source: UserSimpleDto[]): UserSimpleDto[] {
        return source.filter((item) => item.isActive);
    }

    private filterIsFeePayed(source: UserSimpleDto[]): UserSimpleDto[] {
        return source.filter((item) => item.isFeePayed);
    }

    private mounted() {
        this.headers.push({
            text: this.settings.resource.userName,
            align: 'left',
            sortable: true,
            value: 'userName' });
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
            text: this.settings.resource.companyNumber,
            align: 'left',
            sortable: true,
            value: 'companyNumber' });
        this.headers.push({
            text: this.settings.resource.birthNumber,
            align: 'left',
            sortable: true,
            value: 'birthNumber' });
        this.headers.push({
            text: this.settings.resource.active,
            align: 'center',
            sortable: true,
            value: 'isActive' });
        this.headers.push({
            text: this.settings.resource.news,
            align: 'center',
            sortable: false,
            value: 'sendingNews' });
        this.headers.push({
            text: this.settings.resource.created,
            align: 'left',
            sortable: true,
            value: 'created' });
        this.headers.push({
            text: this.settings.resource.feePayed,
            align: 'center',
            sortable: true,
            value: 'isFeePayed' });
        this.headers.push({
            text: this.settings.resource.action,
            align: 'center',
            sortable: true,
            value: 'action' });

        this.searchTypeItems.push(
            {id: 'userName', name: this.settings.resource.userName},
            {id: 'email', name: this.settings.resource.email},
            {id: 'phoneNumber', name: this.settings.resource.phoneNumber},
            {id: 'birthNumber', name: this.settings.resource.birthNumber},
            {id: 'companyNumber', name: this.settings.resource.companyNumber},
        );

        this.searchType = this.searchTypeItems[0].id;
    }

    private activeColor(item: UserSimpleDto): boolean {
        return item.isActive && !item.isFeePayed;
    }

    private notActiveColor(item: UserSimpleDto): boolean {
        return !item.isActive;
    }

    private feePayedColor(item: UserSimpleDto): boolean {
        return item.isFeePayed && item.isActive;
    }

    get labelIsActive(): string {
        return this.settings.resource.active;
    }

    get labelIsFeePayed(): string {
        return this.settings.resource.feePayed;
    }

    get labelSearch(): string {
        return this.settings.resource.search;
    }

    get labelSearchTypes(): string {
        return this.settings.resource.accordingTo;
    }

    get labelCompanyNumber(): string {
        return this.settings.resource.companyNumber;
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

.user-admin-table .v-pagination .v-pagination__item--active {
    background-color: #546E7A !important;
}

.user-admin-table .theme--light.v-table, .theme--light .v-table .row_color_noActive {
  color: red !important;
}

.user-admin-table .theme--light.v-table, .theme--light .v-table .row_color_feePayed {
  color: green !important;
}

.user-admin-table .theme--light.v-table, .theme--light .v-table .row_color_active {
  color: lightskyblue !important;
}

</style>