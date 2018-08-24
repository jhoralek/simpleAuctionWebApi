<template>
    <div class="gdpr-form">
        <v-form lazy-validation ref="step" v-if="countries && newGdprRecord && !sent">
            <v-layout row wrap>
                <v-flex xs12>
                    <p>
                        {{ resx('gdprAnnouncment') }}
                    </p>
                </v-flex>
            </v-layout>
            <v-layout row wrap>
                <v-flex xs12 md6>
                    <v-text-field
                        v-model="newGdprRecord.firstName"
                        v-validate="'required'"
                        :error-messages="errors.collect('firstName')"
                        data-vv-name="firstName"
                        couter
                        :label="labelFirstName" />
                </v-flex>
                <v-flex xs12 md6>
                    <v-text-field
                        v-model="newGdprRecord.lastName"
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
                        v-model="newGdprRecord.email"
                        v-validate="'email|required'"
                        :error-messages="errors.collect('email')"
                        data-vv-name="email"
                        couter
                        :label="labelEmail" />
                </v-flex>
                <v-flex xs12 md6>
                        <v-text-field
                            v-model="newGdprRecord.phoneNumber"
                            v-validate="{ required: true, regex: /^([0-9 ]+)$/, max: 15, min: 9}"
                            :error-messages="errors.collect('phoneNumber')"
                            data-vv-name="phoneNumber"
                            couter
                            :label="labelPhoneNumber" />
                </v-flex>
            </v-layout>
            <v-layout row wrap>
                <v-flex xs12>
                    <v-text-field
                        v-model="newGdprRecord.companyName"
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
                        v-model="newGdprRecord.birthNumber"
                        v-validate="{ min:9, max:15, regex: /^([0-9\/]+)$/ }"
                        :error-messages="errors.collect('birthNumber')"
                        data-vv-name="birthNumber"
                        couter
                        :label="labelBirthNumber" />
                </v-flex>
                <v-flex xs12 md6>
                    <v-text-field
                        v-model="newGdprRecord.companyNumber"
                        v-validate="'max:20'"
                        :error-messages="errors.collect('companyNumber')"
                        data-vv-name="companyNumber"
                        couter
                        :label="labelCompanyNumber" />
                </v-flex>
            </v-layout>
            <v-layout row wrap>
                <v-flex xs12 md6>
                    <v-text-field
                        v-model="newGdprRecord.street"
                        v-validate="'required|max:30'"
                        :error-messages="errors.collect('stret')"
                        data-vv-name="stret"
                        :label="labelStreet" />
                </v-flex>
                <v-flex xs12 md6>
                    <v-select
                        v-model="newGdprRecord.countryId"
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
                <v-flex xs12 md8>
                    <v-text-field
                        v-model="newGdprRecord.city"
                        v-validate="'required|max:30'"
                        :error-messages="errors.collect('city')"
                        data-vv-name="city"
                        :label="labelCity" />
                </v-flex>
                <v-flex xs12 md4>
                    <v-text-field
                        v-model="newGdprRecord.postCode"
                        v-validate="'required|max:10'"
                        :error-messages="errors.collect('postCode')"
                        data-vv-name="postCode"
                        :label="labelPostCode" />
                </v-flex>
            </v-layout>
            <v-layout row wrap>
                <v-flex xs12>
                    <v-select
                        v-model="newGdprRecord.type"
                        v-validate="'required'"
                        data-vv-name="applicationType"
                        :error-messages="errors.collect('applicationType')"
                        item-value="id"
                        item-text="name"
                        single-line
                        :label="labelApplicationType"
                        :items="applicationTypes" />
                </v-flex>
            </v-layout>
            <v-layout row wrap>
                <v-flex xs12>
                    <v-textarea
                        v-model="newGdprRecord.description"
                        v-validate="'max:250'"
                        :error-messages="errors.collect('moreDescription')"
                        data-vv-name="moreDescription"
                        couter
                        :label="labelDescription" />
                </v-flex>
            </v-layout>
            <v-layout row wrap>
            <v-flex xs12>
                <v-btn
                    color="black"
                    @click="submit">
                    {{ resx('submit') }}
                </v-btn>
            </v-flex>
            </v-layout>
        </v-form>
        <v-layout row wrap v-if="sent">
            <v-flex xs12 justify-center align-center>
                <h2>{{ resx('gdprThanks') }}</h2>
            </v-flex>
        </v-layout>
    </div>
</template>

<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { Action, Getter, namespace } from 'vuex-class';

import FormBaseComponent from '../FormBaseComponent.vue';
import {
    GdprApplicationType,
    GdprRecord,
    Country,
} from '@/model';

const ProfileAction = namespace('profile', Action);
const SettingsGetter = namespace('settings', Getter);

@Component({})
export default class GdprFromComponent extends FormBaseComponent {
    @SettingsGetter('getCountries') private countries: Country[];
    @SettingsGetter('getLanguage') private language: string;
    @ProfileAction('createGdprRequest') private sendGdpr: any;

    private newGdprRecord: GdprRecord = {} as GdprRecord;
    private applicationTypes: any[] = [];
    private sent: boolean = false;

    public mounted() {
        this.applicationTypes = [{
            id: GdprApplicationType.correctionPersonalInformation,
            name: this.settings.resource.correctionPersonalInformation,
        },
        {
            id: GdprApplicationType.deletingPersonalInformation,
            name: this.settings.resource.deletingPersonalInformation,
        },
        {
            id: GdprApplicationType.reportPersonalInformation,
            name: this.settings.resource.reportPersonalInformation,
        },
        {
            id: GdprApplicationType.newObjection,
            name: this.settings.resource.newObjection,
        }];
    }

    get labelFirstName(): string {
        return this.settings.resource.firstName;
    }

    get labelLastName(): string {
        return this.settings.resource.lastName;
    }

    get labelEmail(): string {
        return this.settings.resource.email;
    }

    get labelPhoneNumber(): string {
        return this.settings.resource.phoneNumber;
    }

    get labelStreet(): string {
        return this.settings.resource.street;
    }

    get labelCity(): string {
        return this.settings.resource.city;
    }

    get labelPostCode(): string {
        return this.settings.resource.postCode;
    }

    get labelCountry(): string {
        return this.settings.resource.country;
    }

    get labelCompanyName(): string {
        return this.settings.resource.companyName;
    }

    get labelCompanyNumber(): string {
        return this.settings.resource.companyNumber;
    }

    get labelBirthNumber(): string {
        return this.settings.resource.birthNumber;
    }

    get labelDescription(): string {
        return this.settings.resource.moreDescription;
    }

    get labelApplicationType(): string {
        return this.settings.resource.applicationType;
    }

    private submit(): void {
        this.$validator.validateAll().then((response) => {
            if (response) {
                this.sendGdpr(this.newGdprRecord).then((resp1) => {
                    this.sent = resp1;
                });
            }
        });
    }
}

</script>

<style>

.gdpr-form p {
  font-size: 16px;
  font-weight: normal;
  font-style: normal;
  font-stretch: normal;
  line-height: 2.06;
  letter-spacing: 0.5px;
  text-align: justify;
  padding-right: 10%;
  padding-bottom: 10px;
}

.gdpr-form h2 {
  font-size: 25px;
  font-weight: normal;
  font-style: normal;
  font-stretch: normal;
  line-height: 1.15;
  letter-spacing: 0.3px;
  text-align: left;
  color: #1a1a2e;
}

.gdpr-form .v-btn {
    color: white !important;
    border-radius: 5px !important;
}

</style>