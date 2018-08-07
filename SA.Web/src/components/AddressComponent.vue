<template>
  <div class="address" v-if="address">
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

import { Component, Prop } from 'vue-property-decorator';
import { Getter, namespace } from 'vuex-class';

import { Address, Country } from '@/model';
import BaseComponent from './BaseComponent.vue';

const SettingsGetter = namespace('settings', Getter);

@Component({})
export default class CustomerDetailComponent extends BaseComponent {
  @Prop({default: undefined}) public address: Address;
  @SettingsGetter('getCountries') public countries: Country[];

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
