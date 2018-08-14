<template>
  <div class="customer">
    <v-progress-linear v-if="isLoading" :indeterminate="isLoading"></v-progress-linear>
    <v-container grid-list-xs pa-2 v-if="profile.user">
      <v-layout row wrap>
        <v-flex xs12 md6>
          <h1 class="display-1 primary--text">{{ resx('customerDetail') }}</h1>
        </v-flex>
        <v-flex xs12 md6 fill-height align-center v-if="profile.user.customer">
          <h2 class="green--text darken-3" v-if="profile.user.customer.isFeePayed">{{ resx('feePayed') }}</h2>
          <h2 class="red--text darken-4" v-else>{{ resx('feeNotPayed' )}}</h2>
        </v-flex>
      </v-layout>
      <v-layout row wrap v-if="isLoading === false">
          <v-flex xs12 md6>
            <v-expansion-panel>
              <v-expansion-panel-content>
                <div slot="header"><h2>{{ resx('user') }}: {{ profile.user.userName }}</h2></div>
                <user-detail-component :user="profile.user" />
              </v-expansion-panel-content>
              <v-expansion-panel>
                <v-expansion-panel-content>
                  <div slot="header">
                    <v-badge color="red">
                      <span slot="badge">{{ amount }}</span>
                      <h2>{{ resx('auctions') }}</h2>
                    </v-badge>

                  </div>
                  <auction-summary-component @amount="amount = $event" :user-id="profile.user.id" />
                </v-expansion-panel-content>
              </v-expansion-panel>
            </v-expansion-panel>
          </v-flex>
          <v-flex xs12 md6>
            <v-expansion-panel>
              <v-expansion-panel-content>
                <div slot="header"><h2>{{ resx('customer') }}: {{ customersFullName }}</h2></div>
                <customer-detail-component :customer="profile.user.customer" />
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div slot="header"><h2>{{ resx('address') }}</h2></div>
                <address-component :address="getCustomersAddress" />
              </v-expansion-panel-content>
            </v-expansion-panel>
          </v-flex>
        </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component } from 'vue-property-decorator';
import { Getter, Action, State, namespace } from 'vuex-class';

import { Address } from '@/model';
import BaseView from './BaseView.vue';
import { ProfileState } from '@/store/types';
import {
  UserDetailComponent,
  CustomerDetailComponent,
  AddressComponent,
  AuctionSummaryComponent,
} from '@/components';

const ProfileGetter = namespace('profile', Getter);
const ProfileAction = namespace('profile', Action);

@Component({
  components: {
    UserDetailComponent,
    CustomerDetailComponent,
    AddressComponent,
    AuctionSummaryComponent,
  },
})
export default class Customer extends BaseView {
  @State('profile') public profile: ProfileState;

  @ProfileGetter('getCustomersFullName') public customersFullName: string;
  @ProfileGetter('getCustomersAddress') public getCustomersAddress: Address;
  @ProfileAction('initialState') public initProfile: any;
  @ProfileAction('loadLoggedUser') public load: any;

  private isLoading: boolean = true;
  private amount: number = 0;

  public mounted() {
    this.initProfile().then((response) => {
      this.load().then((responseUser) => {
        this.isLoading = false;
      });
    });
  }
}

</script>