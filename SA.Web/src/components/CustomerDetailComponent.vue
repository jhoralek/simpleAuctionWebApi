<template>
  <div class="customerDetail" v-if="customer">
    <v-container>
      <v-form lazy-validation>
        <v-text-field
          v-model="customer.titleBefore"
          :label="labelPrefix" />
        <v-text-field
          v-model="customer.firstName"
          required
          :label="labelFirstName" />
        <v-text-field
          v-model="customer.lastName"
          required
          :label="labelLastName" />
        <v-text-field
          v-model="customer.titleAfter"
          :label="labelPostfix" />
        <v-text-field
          v-model="customer.birthNumber"
          required
          :label="labelBirthNumber" />
        <v-text-field
          v-model="customer.email"
          required
          :label="labelEmail" />
        <v-text-field
          v-model="customer.phoneNumber"
          :label="labelPhoneNumber" />
        <v-text-field
          v-model="customer.companyNumber"
          :label="labelCompanyNumber" />
        <v-text-field
          v-model="customer.companyLegalNumber"
          :label="labelCompanyLegalNumber" />
        <v-text-field
          v-model="customer.webPageUrl"
          :label="labelwebPageUrl" />
        <v-layout>
          <v-checkbox
            v-model="customer.isDealer"
            :disabled="true"
            hide-details
            class="shrink mr-2" />
          <v-text-field :label="labelDealer" disabled />
        </v-layout>
        <v-flex>
          <v-dialog
            ref="dialog"
            disabled
            v-model="modal"
            :return-value.sync="customer.feeExpiration"
            persistent
            lazy
            full-width
            width="290px"
          >
            <v-text-field
              slot="activator"
              v-model="date"
              :label="lableFeeExpiration"
              prepend-icon="event"
              disabled
            ></v-text-field>
            <v-date-picker
              v-model="date"
              scrollable
              readonly
              :locale="datePickerLocale">
              <v-spacer></v-spacer>
              <v-btn flat color="primary" @click="modal = false">{{ resx('cancel') }}</v-btn>
              <v-btn flat color="primary" @click="$refs.dialog.save(date)">{{ resx('ok') }}</v-btn>
            </v-date-picker>
          </v-dialog>
        </v-flex>
      </v-form>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import { State, Getter } from 'vuex-class';

import BaseComponent from './BaseComponent.vue';
import { Customer } from '@/model';

@Component({})
export default class CustomerDetailComponent extends BaseComponent {
  @Prop({default: undefined}) public customer: Customer;

  private dateModal: boolean = false;

  get modal(): boolean {
    return this.dateModal;
  }
  set modal(value: boolean) {
    this.dateModal = value;
  }

  get date(): string {
    const date = new Date(this.customer.feeExpiration);
    return `${date.getUTCFullYear()}-${date.getMonth()}-${date.getDate()}`;
  }

  set date(value: string) {
    this.customer.feeExpiration = new Date(value);
  }

  get labelFirstName(): string {
    return this.settings.resource.firstName;
  }

  get labelLastName(): string {
    return this.settings.resource.lastName;
  }

  get labelPrefix(): string {
    return this.settings.resource.titleBefore;
  }

  get labelPostfix(): string {
    return this.settings.resource.titleAfter;
  }

  get labelBirthNumber(): string {
    return this.settings.resource.birthNumber;
  }

  get labelEmail(): string {
    return this.settings.resource.email;
  }

  get labelDealer(): string {
    return this.settings.resource.dealer;
  }

  get labelPhoneNumber(): string {
    return this.settings.resource.phoneNumber;
  }

  get labelwebPageUrl(): string {
    return this.settings.resource.webPageUrl;
  }

  get labelCompanyNumber(): string {
    return this.settings.resource.companyNumber;
  }

  get labelCompanyLegalNumber(): string {
    return this.settings.resource.companyLegalNumber;
  }

  get lableFeeExpiration(): string {
    return this.settings.resource.feeExpirationDate;
  }

  get datePickerLocale(): string {
    return this.settings.language;
  }
}

</script>
