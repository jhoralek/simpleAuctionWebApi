<template>
  <div class="admin-auciton-table">
    <v-container  grid-list-xs pa-0 v-if="formActive">
      <v-layout row wrap>
        <v-flex xs7>
          <h1 v-if="record.current && record.current.id !== undefined">{{ resx('edit') }}: {{ record.current.name }}</h1>
          <h1 v-if="record.current && record.current.id === undefined">{{ resx('new') }}</h1>
        </v-flex>
        <v-flex xs5 justify-end>
          <span v-if="state < 5">{{ state }}/4</span>
          <v-btn @click="backToList" dark>{{ resx('back') }}</v-btn>
        </v-flex>
      </v-layout>
      <v-layout row wrap>
        <v-flex xs12 row wrap>
          <v-form lazy-validation ref="step1" v-if="record.current && state === 1">
            <v-container grid-list-md>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.name"
                    v-validate="'required|max:100|min:5'"
                    :error-messages="errors.collect('name')"
                    data-vv-name="name"
                    couter
                    :label="labelName" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.startingPrice"
                    v-validate="'required|numeric'"
                    :error-messages="errors.collect('startingPrice')"
                    data-vv-name="startingPrice"
                    couter
                    :label="labelStartingPrice" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.minimumBid"
                    v-validate="'required|numeric'"
                    :error-messages="errors.collect('minimumBid')"
                    data-vv-name="minimumBid"
                    couter
                    :label="labelMinimumBid" />
                </v-flex>
              </v-layout>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <date-picker-component
                    :date="newRecord.validFrom"
                    name="validFrom"
                    :validation="{required: true }"
                    :label="labelValidFrom"
                    @date="newRecord.validFrom = $event"/>
                </v-flex>
                <v-flex xs12 md4>
                  <date-picker-component
                    :date="newRecord.validTo"
                    name="validTo"
                    :validation="{required: true }"
                    :label="labelValidTo"
                    @date="newRecord.validTo = $event" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.mileage"
                    v-validate="'numeric'"
                    :error-messages="errors.collect('mileAge')"
                    data-vv-name="mileAge"
                    couter
                    :label="labelMileAge" />
                </v-flex>
              </v-layout>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <v-switch
                    v-model="newRecord.isActive"
                    :label="labelIsActive" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.color"
                    v-validate="'max:30'"
                    :error-messages="errors.collect('color')"
                    data-vv-name="color"
                    couter
                    :label="labelColor" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.fuel"
                    v-validate="'max:10'"
                    :error-messages="errors.collect('fuel')"
                    data-vv-name="fuel"
                    couter
                    :label="labelFuel" />
                </v-flex>
              </v-layout>
            </v-container>
          </v-form>
          <v-form lazy-validation ref="step2" v-if="record.current && state === 2">
            <v-container grid-list-md>
              <v-layout row wrap>
                <v-flex xs12 md2>
                  <v-text-field
                    v-model="newRecord.engineCapacity"
                    v-validate="'max:45'"
                    :error-messages="errors.collect('engineCapacity')"
                    data-vv-name="engineCapacity"
                    couter
                    :label="labelEngineCapacity" />
                </v-flex>
                <v-flex xs12 md2>
                  <v-text-field
                    v-model="newRecord.power"
                    v-validate="'max:45'"
                    :error-messages="errors.collect('power')"
                    data-vv-name="power"
                    couter
                    :label="labelPower" />
                </v-flex>
                <v-flex xs12 md2>
                  <v-text-field
                    v-model="newRecord.doors"
                    v-validate="'numeric'"
                    :error-messages="errors.collect('dors')"
                    data-vv-name="dors"
                    couter
                    :label="labelDoors" />
                </v-flex>
                <v-flex xs12 md2>
                  <v-text-field
                    v-model="newRecord.numberOfSeets"
                    v-validate="'numeric'"
                    :error-messages="errors.collect('numberOfSeets')"
                    data-vv-name="numberOfSeets"
                    couter
                    :label="labelNumberOfSeets" />
                </v-flex>
                <v-flex xs12 md2>
                  <v-text-field
                    v-model="newRecord.axle"
                    v-validate="'max:45'"
                    :error-messages="errors.collect('axle')"
                    data-vv-name="axle"
                    couter
                    :label="labelAxle" />
                </v-flex>
                <v-flex xs12 md2>
                  <v-text-field
                    v-model="newRecord.euroNorm"
                    v-validate="'max:10'"
                    :error-messages="errors.collect('euroNorm')"
                    data-vv-name="euroNorm"
                    couter
                    :label="labelEuroNorm" />
                </v-flex>
              </v-layout>
              <v-layout row wrap>
                <v-flex xs12 md3>
                  <v-text-field
                    v-model="newRecord.vin"
                    v-validate="'max:45'"
                    :error-messages="errors.collect('vin')"
                    data-vv-name="vin"
                    couter
                    :label="labelVin" />
                </v-flex>
                <v-flex xs12 md3>
                  <v-text-field
                    v-model="newRecord.contactToAppointment"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('contactToAppointment')"
                    data-vv-name="contactToAppointment"
                    couter
                    :label="labelContactToAppointment" />
                </v-flex>
                <v-flex xs12 md3>
                  <v-text-field
                    v-model="newRecord.transmission"
                    v-validate="'max:45'"
                    :error-messages="errors.collect('transmission')"
                    data-vv-name="transmission"
                    couter
                    :label="labelTransmission" />
                </v-flex>
                <v-flex xs12 md3>
                  <v-text-field
                    v-model="newRecord.registrationCheck"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('registrationCheck')"
                    data-vv-name="registrationCheck"
                    couter
                    :label="labelRegistrationCheck" />
                </v-flex>
              </v-layout>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.state"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('state')"
                    data-vv-name="state"
                    couter
                    :label="labelState" />
                </v-flex>
                <v-flex xs12 md4>
                  <date-picker-component
                    :date="newRecord.stk"
                    name="stk"
                    :validation="{}"
                    :label="labelStk"
                    @date="newRecord.stk = $event"/>
                </v-flex>
                <v-flex xs12 md4>
                  <date-picker-component
                    :date="newRecord.dateOfFirstRegistration"
                    name="dateOfFirstRegistration"
                    :validation="{}"
                    :label="labelDateOfFirstRegistration"
                    @date="newRecord.dateOfFirstRegistration = $event" />
                </v-flex>
              </v-layout>
            </v-container>
          </v-form>
          <v-form lazy-validation ref="step3" v-if="record.current && state === 3">
            <v-container grid-list-md>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.operationWeight"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('operationWeight')"
                    data-vv-name="operationWeight"
                    couter
                    :label="labelOperationWeight" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.maximumWeight"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('maximumWeight')"
                    data-vv-name="maximumWeight"
                    couter
                    :label="labelMaximumWeight" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.maximumWeightOfRide"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('maximumWeightOfRide')"
                    data-vv-name="maximumWeightOfRide"
                    couter
                    :label="labelMaximumWeightOfRide" />
                </v-flex>
              </v-layout>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.dimensions"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('dimensions')"
                    data-vv-name="dimensions"
                    couter
                    :label="labelDimensions" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.mostTechnicallyWeightOfRide"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('mostTechnicallyWeightOfRide')"
                    data-vv-name="mostTechnicallyWeightOfRide"
                    couter
                    :label="labelMostTechnicallyWeightOfRide" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="newRecord.mostTechnicallyAcceptableWeight"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('mostTechnicallyAcceptableWeight')"
                    data-vv-name="mostTechnicallyAcceptableWeight"
                    couter
                    :label="labelMostTechnicallyAcceptableWeight" />
                </v-flex>
              </v-layout>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <v-textarea
                    v-model="newRecord.equipment"
                    v-validate="'max:250'"
                    :error-messages="errors.collect('equipment')"
                    :label="labelEquipment"
                    data-vv-name="equipment" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-textarea
                    v-model="newRecord.defects"
                    v-validate="'max:250'"
                    :error-messages="errors.collect('defects')"
                    :label="labelDefects"
                    data-vv-name="defects" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-textarea
                    v-model="newRecord.moreDescription"
                    v-validate="'max:250'"
                    :error-messages="errors.collect('moreDescription')"
                    data-vv-name="moreDescription"
                    couter
                    :label="labelMoreDescription" />
                </v-flex>
              </v-layout>
            </v-container>
          </v-form>
          <v-form lazy-validation ref="step4" v-if="record.current && state === 4">
            <v-container grid-list-md>
              <v-layout row wrap>
                <v-flex xs12>
                  <file-upload-component
                    :name="'auction'"
                    :title="labelUploadImages"
                    @files="newFiles($event)" />
                </v-flex>
              </v-layout>
              <v-layout row wrap v-if="record.current.files">
                <v-flex
                  v-for="image in record.current.files"
                  :key="image.name"
                  xs12 md3 >
                  <v-card>
                    <v-card-media
                      :src="tempImagePath(image)"
                      height="150px" />
                  </v-card>
                </v-flex>
              </v-layout>
            </v-container>
          </v-form>
           <v-layout row wrap>
              <v-flex xs12>
                <v-btn
                  v-if="state > 1 && state <= 4"
                  flat
                  color="info"
                  @click="back">
                  <v-icon left dark>keyboard_arrow_left</v-icon>
                  {{ resx('back') }}
                </v-btn>
                <v-btn
                  v-if="state >= 1 && state < 4"
                  flat color="info"
                  @click="next">
                  {{ resx('next') }}
                  <v-icon left dark>keyboard_arrow_right</v-icon>
                </v-btn>
                <v-btn
                  v-if="state === 4"
                  flat color="success"
                  @click="submit">
                    <v-icon left dark>done</v-icon>
                    {{ resx('submit') }}
                </v-btn>
              </v-flex>
            </v-layout>
        </v-flex>
      </v-layout>
    </v-container>
    <v-container  grid-list-xs pa-0 v-else>
      <v-layout row wrap>
        <v-flex xs12>
          <v-toolbar flat color="white">
            <v-spacer></v-spacer>
            <v-btn color="primary" dark class="mb-2" @click="newAuction">{{ resx('new') }}</v-btn>
          </v-toolbar>
          <v-data-table
            :headers="headers"
            :items="auctions"
            :loading="loading"
            :pagination.sync="pagination"
            hide-actions
            class="elevation-1">
            <v-progress-linear slot="progress" color="blue" indeterminate></v-progress-linear>
            <template slot="items" slot-scope="props">
              <td>{{ props.item.name }}</td>
              <td>{{ props.item.state }}</td>
              <td>{{ props.item.validFrom | moment('DD.MM.YYYY HH:mm') }}</td>
              <td>{{ props.item.validTo | moment('DD.MM.YYYY HH:mm') }}</td>
              <td><price-component :price="props.item.startingPrice" /></td>
              <td><price-component :price="props.item.minimumBid" /></td>
              <td><price-component :price="props.item.currentPrice" /></td>
              <td>{{ props.item.numberOfBids }}</td>
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

import { Component, Prop } from 'vue-property-decorator';
import { State, Action, namespace } from 'vuex-class';

import BaseComponent from '../BaseComponent.vue';
import PriceComponent from '@/components/helpers/PriceComponent.vue';
import DatePickerComponent from '@/components/helpers/DatePickerComponent.vue';
import FileUploadComponent from '@/components/helpers/FileUploadComponent.vue';
import { RecordTableDto, AuthUser, FileSimpleDto } from '@/poco';
import { Record } from '@/model';
import { RecordState, AuthState } from '@/store/types';

const RecordAction = namespace('record', Action);

@Component({
  components: {
    PriceComponent,
    DatePickerComponent,
    FileUploadComponent,
  },
})
export default class AdminAuctionTableComponent extends BaseComponent {
  @State('record') private record: RecordState;
  @State('auth') private auth: AuthState;

  @Prop({default: []}) private auctions: RecordTableDto[];
  @Prop({default: true}) private loading: boolean;

  @RecordAction('initialCurrent') private initCurrent: any;
  @RecordAction('getDetail') private getDetail: any;
  @RecordAction('createRecord') private create: any;
  @RecordAction('setCurrent') private setCurrent: any;

  private state: number = 1;
  private formActive: boolean = false;
  private headers: any[] = [];
  private pagination: any = {
      rowsPerPage: 10,
      totalItems: 0,
  };
  private newRecord: Record = {
      isActive: false,
      dateOfFirstRegistration: null,
  } as Record;

  private mounted() {
        this.headers.push({
            text: this.settings.resource.name,
            align: 'left',
            sortable: true,
            value: 'name  ' });
        this.headers.push({
            text: this.settings.resource.state,
            align: 'left',
            sortable: true,
            value: 'state  ' });
        this.headers.push({
            text: this.settings.resource.validFrom,
            align: 'rigth',
            sortable: true,
            value: 'validFrom' });
        this.headers.push({
            text: this.settings.resource.validTo,
            align: 'rigth',
            sortable: true,
            value: 'validTo' });
        this.headers.push({
            text: this.settings.resource.startingPrice,
            align: 'rigth',
            sortable: true,
            value: 'startingPrice' });
        this.headers.push({
            text: this.settings.resource.minimumBid,
            align: 'rigth',
            sortable: true,
            value: 'minimumBid' });
        this.headers.push({
            text: this.settings.resource.currentPrice,
            align: 'rigth',
            sortable: true,
            value: 'currentPrice' });
        this.headers.push({
            text: this.settings.resource.numberOfBids,
            align: 'rigth',
            sortable: false,
            value: 'numberOfBids' });
        this.headers.push({
            text: this.settings.resource.action,
            align: 'center',
            sortable: true,
            value: 'action' });
        this.newRecord.userId = this.auth.userId;
        this.newRecord.customerId = this.auth.customerId;
  }

  get labelUploadImages(): string {
    return this.settings.resource.uploadImages;
  }

  get labelName(): string {
    return this.settings.resource.name;
  }

  get labelStartingPrice(): string {
    return this.settings.resource.startingPrice;
  }

  get labelMinimumBid(): string {
    return this.settings.resource.minimumBid;
  }

  get labelValidFrom(): string {
    return this.settings.resource.validFrom;
  }

  get labelValidTo(): string {
    return this.settings.resource.validTo;
  }

  get labelMileAge(): string {
    return this.settings.resource.mileAge;
  }

  get labelIsActive(): string {
    return this.settings.resource.active;
  }

  get labelColor(): string {
    return this.settings.resource.color;
  }

  get labelFuel(): string {
    return this.settings.resource.fuel;
  }

  get labelPower(): string {
    return this.settings.resource.power;
  }

  get labelEngineCapacity(): string {
    return this.settings.resource.engineCapacity;
  }

  get labelVin(): string {
    return this.settings.resource.vehicleVinNumber;
  }

  get labelDoors(): string {
    return this.settings.resource.doors;
  }

  get labelNumberOfSeets(): string {
    return this.settings.resource.numberOfSeets;
  }

  get labelEuroNorm(): string {
    return this.settings.resource.euroNorm;
  }

  get labelAxle(): string {
    return this.settings.resource.axle;
  }

  get labelTransmission(): string {
    return this.settings.resource.transmission;
  }

  get labelDateOfFirstRegistration(): string {
    return this.settings.resource.dateOfFirstRegistration;
  }

  get labelStk(): string {
    return this.settings.resource.technicalViewOfTheVehicle;
  }

  get labelState(): string {
    return this.settings.resource.state;
  }

  get labelContactToAppointment(): string {
    return this.settings.resource.contactToAppointment;
  }

  get labelOperationWeight(): string {
    return this.settings.resource.operationWeight;
  }

  get labelMaximumWeight(): string {
    return this.settings.resource.maximumWeight;
  }

  get labelMaximumWeightOfRide(): string {
    return this.settings.resource.maximumWeightOfRide;
  }

  get labelDimensions(): string {
    return this.settings.resource.dimensions;
  }

  get labelMostTechnicallyWeightOfRide(): string {
    return this.settings.resource.mostTechnicallyWeightOfRide;
  }

  get labelMostTechnicallyAcceptableWeight(): string {
    return this.settings.resource.mostTechnicallyAcceptableWeight;
  }

  get labelRegistrationCheck(): string {
    return this.settings.resource.registrationCheck;
  }

  get labelEquipment(): string {
    return this.settings.resource.equipment;
  }

  get labelDefects(): string {
    return this.settings.resource.defects;
  }

  get labelMoreDescription(): string {
    return this.settings.resource.moreDescription;
  }

  get pages() {
      if (this.pagination.rowsPerPage == null ||
        this.pagination.totalItems == null) {
            return 0;
      }
      return Math.ceil(this.pagination.totalItems / this.pagination.rowsPerPage);
  }

  private tempImagePath(file: FileSimpleDto): string {
    return `/tempFiles/${file.name}`;
  }

  private backToList(): void {
    this.initCurrent().then((response) => {
      this.state = 1;
      this.formActive = false;
      this.newRecord = this.record.current;
    });

  }

  private edit(item: RecordTableDto): void {
    if (item.id > 0) {
      this.getDetail(item.id).then((response) => {
        this.formActive = response as boolean;
      });
    }
  }

  private newAuction() {
    this.initCurrent().then((response) => {
      this.formActive = response as boolean;
    });
  }

  private newFiles(files: FileSimpleDto[]): void {
    this.initCurrent().then((response) => {
      if (response) {
        this.newRecord.files = files.map((file) => {
          file.path = 'auction';
          file.userId = this.auth.userId;
          return file;
        });
        this.setCurrent(this.newRecord);
      }
    });
  }

  private back(): void {
    this.$validator.validateAll().then((response) => {
      if (response) {
        this.state -= 1;
      }
    });
  }

  private next(): void {
    this.$validator.validateAll().then((response) => {
      if (response) {
        this.state += 1;
      }
    });
  }

  private submit(): void {
    if (this.state === 4) {
      this.$validator.validateAll().then((response) => {
        if (response) {
          this.create(this.newRecord).then((respRecord) => {
            if (respRecord) {
              this.backToList();
            }
          });
        }
      });
    }
  }
}

</script>
