<template>
  <div class="customer">
    <loading-component :open="isLoading" />
    <v-container grid-list-xs pa-2 v-if="profile.user">
      <v-layout row wrap>
        <v-flex xs12 md6>
          <h1>{{ resx('customerDetail') }}</h1>
        </v-flex>
        <v-flex xs12 md6 v-if="profile.user.customer">
          <h1 class="green--text darken-3" v-if="profile.user.customer.isFeePayed">{{ resx('feePayed') }}</h1>
          <h1 class="red--text darken-4" v-else>{{ resx('feeNotPayed' )}}</h1>
        </v-flex>
      </v-layout>
      <v-layout row wrap v-if="isLoading === false">
          <v-flex xs12 md6>
            <v-expansion-panel>
              <v-expansion-panel-content>
                <div slot="header">
                  <h3>{{ resx('user') }}: {{ profile.user.userName }}</h3>
                </div>
                <user-detail-component :user="profile.user" />
              </v-expansion-panel-content>
              <v-expansion-panel>
                <v-expansion-panel-content>
                  <div slot="header">
                    <v-layout row wrap>
                      <v-flex xs6>
                        <v-badge color="green">
                          <span slot="badge">{{ actualRecords.length }}</span>
                          <h3>{{ resx('bidding') }}</h3>
                        </v-badge>
                      </v-flex>
                      <v-flex xs6>
                        <v-badge color="red">
                          <span slot="badge">{{ endedRecords.length }}</span>
                          <h3>{{ resx('ended') }}</h3>
                        </v-badge>
                      </v-flex>
                    </v-layout>
                  </div>
                  <auction-summary-component />
                </v-expansion-panel-content>
              </v-expansion-panel>
            </v-expansion-panel>
          </v-flex>
          <v-flex xs12 md6>
            <v-expansion-panel>
              <v-expansion-panel-content>
                <div slot="header">
                  <h3>{{ resx('customer') }}: {{ customersFullName }}</h3>
                </div>
                <customer-detail-component :customer="profile.user.customer" />
              </v-expansion-panel-content>
              <v-expansion-panel-content>
                <div slot="header">
                  <h3>{{ resx('address') }}</h3>
                </div>
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

import LoadingComponent from '@/components/helpers/LoadingComponent.vue';
import { Address } from '@/model';
import { RecordTableDto } from '@/poco';
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
    LoadingComponent,
  },
})
export default class Customer extends BaseView {
  @State('profile') public profile: ProfileState;
  @ProfileGetter('getCurrentAuctions') private actualRecords: RecordTableDto[];
  @ProfileGetter('getEndedAuctions') private endedRecords: RecordTableDto[];
  @ProfileGetter('getCustomersFullName') private customersFullName: string;
  @ProfileGetter('getCustomersAddress') private getCustomersAddress: Address;
  @ProfileAction('initialState') private initProfile: any;
  @ProfileAction('loadLoggedUser') private load: any;
  @ProfileAction('loadUsersEndedAuctions') private loadEnded: any;
  @ProfileAction('loadUsersCurrentAuctions') private loadCurrent: any;

  private isLoading: boolean = true;

  private mounted() {
    this.initProfile().then((response) => {
      this.load().then((responseUser) => {
        this.isLoading = false;
        this.loadEnded();
        this.loadCurrent();
      });
    });
  }
}

</script>

<style>

.customer .v-expansion-panel__header h3 {
    font-size: 15px !important;
    font-weight: bold !important;
    font-style: normal;
    font-stretch: normal;
    line-height: 1.5;
    letter-spacing: 1.2px;
    text-align: left;
    color: #000000;
    text-transform: uppercase;
}

.customer .v-expansion-panel__body {
    background-color: #ffffff !important;
}

.customer .v-expansion-panel {
    border-radius: 5px !important;
    --webkit-box-shadow: 0 0px 0px 0px rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0) !important;
    box-shadow: 0 0px 0px 0px rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0) !important;
    border: 1px solid #e6e6e6 !important;
}

.customer .v-expansion-panel__header {
    background-color: #ededed !important;
}

.customer .v-expansion-panel__container {
    border: 1px solid #e6e6e6 !important;
}

.customer h1 {
  font-family: Roboto;
  font-size: 35px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  text-align: left;
  color: #000000;
  padding-bottom: 30px;
  padding-top: 30px;
}

</style>