<template>
  <div class="customerDetail" v-if="isLoaded">
    <h2>{{ resx('address') }}</h2>
    <v-container>
        <v-text-field
          v-model="address.street"
          :label="labelStreet" />
        <v-text-field
          v-model="address.city"
          :label="labelCity" />
        <v-text-field
          v-model="address.postCode"
          :label="labelPostCode" />
         <v-select
          v-model="address.country"
          item-value="id"
          item-text="name"
          single-line
          :label="labelCountry"
          persistent-hint
          :items="countries" />
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component } from 'vue-property-decorator';
import { State, Getter } from 'vuex-class';
import { SettingsState } from '@/store/types';

import { Address, Country} from '@/model';
import BaseComponent from './BaseComponent.vue';

const namespaceProfile: string = 'profile';
const namespaceSettings: string = 'settings';

@Component({})
export default class CustomerDetailComponent extends BaseComponent {

  @Getter('getCustomersAddress', { namespace: namespaceProfile }) public address: Address;
  @Getter('isCustomerLoaded', { namespace: namespaceProfile }) public isLoaded: boolean;
  @Getter('getCountries', { namespace: namespaceSettings }) public countries: Country[];

  private dateModal: boolean = false;

  get labelStreet(): string {
    return super.settings.resource.street;
  }
  get labelCity(): string {
    return super.settings.resource.city;
  }
  get labelPostCode(): string {
    return super.settings.resource.postCode;
  }
  get labelCountry(): string {
    return super.settings.resource.country;
  }
}

</script>
