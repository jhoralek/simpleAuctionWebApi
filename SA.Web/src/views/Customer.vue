<template>
  <div class="customer">
    <v-container fluid>
      <v-progress-linear v-if="isLoading" :indeterminate="isLoading"></v-progress-linear>
      <h1>{{ resx('customerDetail') }}</h1>
      <v-layout row v-if="isLoading === false">
          <v-flex xs6 order-lg2>
            <v-card tile flat>
              <v-card-text>
                <v-expansion-panel>
                  <v-expansion-panel-content>
                    <div slot="header"><h2>{{ resx('user') }}: {{ profile.user.userName }}</h2></div>
                    <UserDetailComponent :user="profile.user" />
                  </v-expansion-panel-content>
                  <v-expansion-panel>
                    <v-expansion-panel-content>
                      <div slot="header">
                        <v-badge color="red">
                          <span slot="badge">{{ amount }}</span>
                          <h2>{{ resx('auctions') }}</h2>
                        </v-badge>

                      </div>
                      <AuctionSummaryComponent @amount="amount = $event" :user-id="profile.user.id" />
                    </v-expansion-panel-content>
                  </v-expansion-panel>
                </v-expansion-panel>
              </v-card-text>
            </v-card>
          </v-flex>
          <v-flex xs6>
            <v-card tile flat>
              <v-card-text>
                <v-expansion-panel>
                  <v-expansion-panel-content>
                    <div slot="header"><h2>{{ resx('customer') }}: {{ customersFullName }}</h2></div>
                    <CustomerDetailComponent :customer="profile.user.customer" />
                  </v-expansion-panel-content>
                  <v-expansion-panel-content>
                    <div slot="header"><h2>{{ resx('address') }}</h2></div>
                    <AddressComponent :address="getCustomersAddress" />
                  </v-expansion-panel-content>
                </v-expansion-panel>
              </v-card-text>
            </v-card>
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