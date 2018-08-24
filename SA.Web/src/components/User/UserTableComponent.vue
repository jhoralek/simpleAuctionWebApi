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
              <v-layout wrap>
                <v-flex xs12 md6>
                    <v-switch
                        v-model="profile.user.isFeePayed"
                        :label="lableIsFeePayed" />
                </v-flex>
                <v-flex xs12 md6>
                    <v-switch
                        v-model="profile.user.isActive"
                        :label="lableIsActive" />
                </v-flex>
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
                        <td>{{ props.item.userName }}</td>
                        <td>{{ props.item.email }}</td>
                        <td>{{ props.item.phoneNumber }}</td>
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
                            <!-- <v-icon
                                style="cursor: pointer"
                                small
                                class="mr-2"
                                @click="delete(props.item)">
                                delete
                            </v-icon> -->
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

import { UserSimpleDto } from '@/poco';
import { ProfileState } from '@/store/types';
import BaseComponent from '../BaseComponent.vue';

const ProfileAction = namespace('profile', Action);

@Component({})
export default class UserTableComponent extends BaseComponent {
    @State('profile') private profile: ProfileState;

    @Prop({default: []}) private users: UserSimpleDto[];
    @Prop({default: true}) private loading: boolean;
    @ProfileAction('setCurrentUser') private setUser: any;
    @ProfileAction('updateUserAdmin') private updateUser: any;

    private actionInProgress: boolean = false;
    private dialog: boolean = false;
    private headers: any[] = [];
    private pagination: any = {
        rowsPerPage: 10,
        totalItems: 0,
    };

    @Watch('users') private changeUsers(users) {
        if (users !== undefined && users.length > 0) {
            this.pagination.totalItems = users.length;
        }
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
    }

    get lableIsActive(): string {
        return this.settings.resource.active;
    }

    get lableIsFeePayed(): string {
        return this.settings.resource.feePayed;
    }

    get pages() {
        if (this.pagination.rowsPerPage == null ||
          this.pagination.totalItems == null) {
              return 0;
        }
        return Math.ceil(this.pagination.totalItems / this.pagination.rowsPerPage);
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
}

</script>

<style>

.user-admin-table .v-pagination .v-pagination__item--active {
    background-color: #546E7A !important;
}

</style>