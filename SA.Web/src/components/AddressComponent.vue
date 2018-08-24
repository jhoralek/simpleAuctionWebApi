<template>
  <div id="address-form">
    <v-progress-linear v-if="isLoading" indeterminate></v-progress-linear>
    <v-container  grid-list-md>
      <v-form lazy-validation ref="address" v-if="address">
        <v-layout row wrap>
          <v-flex xs12>
            <v-text-field
              v-model="address.street"
              v-validate="'required|max:30'"
              :error-messages="errors.collect('street')"
              data-vv-name="street"
              :label="labelStreet" />
          </v-flex>
        </v-layout>
        <v-layout row wrap>
          <v-flex xs12 md8>
            <v-text-field
              v-model="address.city"
              v-validate="'required|max:30'"
              :error-messages="errors.collect('city')"
              data-vv-name="city"
              :label="labelCity" />
          </v-flex>
            <v-flex xs12 md4>
              <v-text-field
                v-model="address.postCode"
                v-validate="'required|max:10'"
                :error-messages="errors.collect('postCode')"
                data-vv-name="postCode"
                :label="labelPostCode" />
          </v-flex>
        </v-layout>
        <v-layout row wrap>
          <v-flex xs12>
            <v-select
              v-model="address.countryId"
              v-validate="'required'"
              data-vv-name="countryId"
              :error-messages="errors.collect('countryId')"
              item-value="id"
              item-text="name"
              single-line
              :label="labelCountry"
              :items="countries" />
          </v-flex>
        </v-layout>
        <v-layout row wrap>
          <v-flex xs12 justify-end align-center>
            <v-btn color="black" @click="submitAddress">{{ resx('submit') }}</v-btn>
          </v-flex>
        </v-layout>
      </v-form>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import { Action, Getter, namespace } from 'vuex-class';

import { Address, Country } from '@/model';
import BaseComponent from './BaseComponent.vue';

const SettingsGetter = namespace('settings', Getter);
const ProfileAction = namespace('profile', Action);

@Component({})
export default class CustomerDetailComponent extends BaseComponent {
  @Prop({default: undefined}) private address: Address;
  @SettingsGetter('getCountries') private countries: Country[];
  @ProfileAction('updateAddress')  private update: any;

  private isLoading: boolean = false;

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

  private submitAddress(): void {
    this.$validator.validateAll().then((response) => {
      if (response) {
        this.isLoading = true;
        this.update(this.address).then((responseAddres) => {
          if (responseAddres) {
            this.isLoading = false;
          }
        });
      }
    });
  }
}

</script>

<style>

#address-form .v-btn {
  color: white !important;
  border-radius: 5px !important;
}

</style>