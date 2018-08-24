<template>
  <div id="customer-form">
    <v-progress-linear v-if="isLoading" indeterminate></v-progress-linear>
    <v-container  grid-list-md>
      <v-form lazy-validation ref="customer" v-if="customer">
        <v-layout row wrap>
          <v-flex xs12 md6>
            <v-text-field
              v-model="customer.firstName"
              v-validate="'required'"
              :error-messages="errors.collect('firstName')"
              data-vv-name="firstName"
              couter
              :label="labelFirstName" />
          </v-flex>
          <v-flex xs12 md6>
            <v-text-field
              v-model="customer.lastName"
              v-validate="'required'"
              :error-messages="errors.collect('lastName')"
              data-vv-name="lastName"
              couter
              :label="labelLastName" />
          </v-flex>
        </v-layout>
        <v-layout row wrap>
          <v-flex xs12 md6>
            <v-text-field
              v-model="customer.titleBefore"
              :label="labelTitleBefore" />
          </v-flex>
          <v-flex xs12 md6>
            <v-text-field
              v-model="customer.titleAfter"
              :label="labelTitleAfter" />
          </v-flex>
        </v-layout>
        <v-layout row wrap>
          <v-flex xs12 md6>
            <v-text-field
              v-model="customer.email"
              v-validate="'email|required'"
              :error-messages="errors.collect('email')"
              data-vv-name="email"
              couter
              :label="labelEmail" />
          </v-flex>
          <v-flex xs12 md6>
            <v-text-field
              v-model="customer.phoneNumber"
              v-validate="{ required: true, regex: /^([0-9 ]+)$/, max: 15, min: 9}"
              :error-messages="errors.collect('phoneNumber')"
              data-vv-name="phoneNumber"
              couter
              :label="labelPhoneNumber" />
          </v-flex>
        </v-layout>
        <v-layout row wrap>
          <v-flex xs12 md6>
            <v-text-field
              v-model="customer.birthNumber"
              v-validate="{ min:9, max:15, regex: /^([0-9\/]+)$/ }"
              :error-messages="errors.collect('birthNumber')"
              data-vv-name="birthNumber"
              couter
              :label="labelBirthNumber" />
          </v-flex>
          <v-flex xs12 md6>
            <v-text-field
              v-model="customer.webPageUrl"
              v-validate="'url'"
              :error-messages="errors.collect('webPageUrl')"
              data-vv-name="webPageUrl"
              couter
              :label="labelWebPageUrl" />
          </v-flex>
        </v-layout>
        <v-layout row wrap>
          <v-flex xs12>
            <v-text-field
              v-model="customer.companyName"
              v-validate="'max:100'"
              :error-messages="errors.collect('companyName')"
              data-vv-name="companyName"
              couter
              :label="labelCompanyName" />
          </v-flex>
        </v-layout>
        <v-layout row wrap>
          <v-flex xs12 md6>
            <v-text-field
              v-model="customer.companyNumber"
              v-validate="'max:20'"
              :error-messages="errors.collect('companyNumber')"
              data-vv-name="companyNumber"
              couter
              :label="labelCompanyNumber" />
          </v-flex>
          <v-flex xs12 md6>
            <v-text-field
              v-model="customer.companyLegalNumber"
              v-validate="'max:20'"
              :error-messages="errors.collect('companyLegalNumber')"
              data-vv-name="companyLegalNumber"
              couter
              :label="labelCompanyLegalNumber" />
          </v-flex>
        </v-layout>
        <v-layout row wrap>
          <v-flex xs12 justify-end align-center>
            <v-btn color="black" @click="submitCustomer">{{ resx('submit') }}</v-btn>
          </v-flex>
        </v-layout>
      </v-form>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import { State, Action, namespace } from 'vuex-class';

import BaseComponent from './BaseComponent.vue';
import { Customer } from '@/model';

const ProfileAction = namespace('profile', Action);

@Component({})
export default class CustomerDetailComponent extends BaseComponent {
  @Prop({default: undefined}) public customer: Customer;
  @ProfileAction('updateCustomer')  private update: any;

  private isLoading: boolean = false;

  get labelFirstName(): string {
    return this.settings.resource.firstName;
  }

  get labelLastName(): string {
    return this.settings.resource.lastName;
  }

  get labelTitleBefore(): string {
    return this.settings.resource.titleBefore;
  }

  get labelTitleAfter(): string {
    return this.settings.resource.titleAfter;
  }

  get labelBirthNumber(): string {
    return this.settings.resource.birthNumber;
  }

  get labelEmail(): string {
    return this.settings.resource.email;
  }

  get labelPhoneNumber(): string {
    return this.settings.resource.phoneNumber;
  }

  get labelWebPageUrl(): string {
    return this.settings.resource.webPageUrl;
  }

  get labelCompanyNumber(): string {
    return this.settings.resource.companyNumber;
  }

  get labelCompanyName(): string {
    return this.settings.resource.companyName;
  }

  get labelCompanyLegalNumber(): string {
    return this.settings.resource.companyLegalNumber;
  }

  private submitCustomer(): void {
    this.$validator.validateAll().then((response) => {
      if (response) {
        this.isLoading = true;
        this.update(this.customer).then((responseCustomer) => {
          if (responseCustomer) {
            this.isLoading = false;
          }
        });
      }
    });
  }
}

</script>

<style>

#customer-form .v-btn {
  color: white !important;
  border-radius: 5px !important;
}

</style>
