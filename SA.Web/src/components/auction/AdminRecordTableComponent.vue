<template>
  <div class="admin-auciton-table">
    <loading-component :open="loading" />
    <question-dialog-component
      :header="questionWarning"
      :question="questionMessage"
      :dialog="questionDialog"
      @result="deleteRecord($event)" />
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
              <v-layout row wrap v-if="auctionsCombo">
                <v-flex xs12>
                  <v-select
                    v-model="record.current.auctionId"
                    v-validate="'required'"
                    data-vv-name="auctionId"
                    :error-messages="errors.collect('auctionId')"
                    item-value="id"
                    item-text="name"
                    single-line
                    :label="labelAuction"
                    :items="auctionsCombo"
                    @change="auctionChange" />
                </v-flex>
              </v-layout>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="record.current.name"
                    v-validate="'required|max:100|min:5'"
                    :error-messages="errors.collect('name')"
                    data-vv-name="name"
                    couter
                    :label="labelName" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="record.current.startingPrice"
                    v-validate="'required|numeric'"
                    :error-messages="errors.collect('startingPrice')"
                    data-vv-name="startingPrice"
                    couter
                    :label="labelStartingPrice" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="record.current.minimumBid"
                    v-validate="'required|numeric'"
                    :error-messages="errors.collect('minimumBid')"
                    data-vv-name="minimumBid"
                    couter
                    :label="labelMinimumBid" />
                </v-flex>
              </v-layout>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <time-picker-component
                    :time="timeFrom"
                    name="timeFrom"
                    :label="labelTimeFrom"
                    :validation="{ required: true}"
                    @time="setTime($event, 'from')" />
                </v-flex>
                <v-flex xs12 md4>
                  <time-picker-component
                    :time="timeTo"
                    name="timeTo"
                    :label="labelTimeTo"
                    @time="setTime($event, 'to')" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="record.current.mileage"
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
                    v-model="record.current.isActive"
                    :label="labelIsActive" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="record.current.color"
                    v-validate="'max:30'"
                    :error-messages="errors.collect('color')"
                    data-vv-name="color"
                    couter
                    :label="labelColor" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="record.current.fuel"
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
                    v-model="record.current.engineCapacity"
                    v-validate="'max:45'"
                    :error-messages="errors.collect('engineCapacity')"
                    data-vv-name="engineCapacity"
                    couter
                    :label="labelEngineCapacity" />
                </v-flex>
                <v-flex xs12 md2>
                  <v-text-field
                    v-model="record.current.power"
                    v-validate="'max:45'"
                    :error-messages="errors.collect('power')"
                    data-vv-name="power"
                    couter
                    :label="labelPower" />
                </v-flex>
                <v-flex xs12 md2>
                  <v-text-field
                    v-model="record.current.doors"
                    v-validate="'numeric'"
                    :error-messages="errors.collect('dors')"
                    data-vv-name="dors"
                    couter
                    :label="labelDoors" />
                </v-flex>
                <v-flex xs12 md2>
                  <v-text-field
                    v-model="record.current.numberOfSeets"
                    v-validate="'numeric'"
                    :error-messages="errors.collect('numberOfSeets')"
                    data-vv-name="numberOfSeets"
                    couter
                    :label="labelNumberOfSeets" />
                </v-flex>
                <v-flex xs12 md2>
                  <v-text-field
                    v-model="record.current.axle"
                    v-validate="'max:45'"
                    :error-messages="errors.collect('axle')"
                    data-vv-name="axle"
                    couter
                    :label="labelAxle" />
                </v-flex>
                <v-flex xs12 md2>
                  <v-text-field
                    v-model="record.current.euroNorm"
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
                    v-model="record.current.vin"
                    v-validate="'max:45'"
                    :error-messages="errors.collect('vin')"
                    data-vv-name="vin"
                    couter
                    :label="labelVin" />
                </v-flex>
                <v-flex xs12 md3>
                  <v-text-field
                    v-model="record.current.contactToAppointment"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('contactToAppointment')"
                    data-vv-name="contactToAppointment"
                    couter
                    :label="labelContactToAppointment" />
                </v-flex>
                <v-flex xs12 md3>
                  <v-text-field
                    v-model="record.current.transmission"
                    v-validate="'max:45'"
                    :error-messages="errors.collect('transmission')"
                    data-vv-name="transmission"
                    couter
                    :label="labelTransmission" />
                </v-flex>
                <v-flex xs12 md3>
                  <v-text-field
                    v-model="record.current.registrationCheck"
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
                    v-model="record.current.state"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('state')"
                    data-vv-name="state"
                    couter
                    :label="labelState" />
                </v-flex>
                <v-flex xs12 md4>
                  <date-picker-component
                    :date="record.current.stk"
                    name="stk"
                    :validation="{}"
                    :label="labelStk"
                    @date="record.current.stk = $event"/>
                </v-flex>
                <v-flex xs12 md4>
                  <date-picker-component
                    :date="record.current.dateOfFirstRegistration"
                    name="dateOfFirstRegistration"
                    :validation="{}"
                    :label="labelDateOfFirstRegistration"
                    @date="record.current.dateOfFirstRegistration = $event" />
                </v-flex>
              </v-layout>
            </v-container>
          </v-form>
          <v-form lazy-validation ref="step3" v-if="record.current && state === 3">
            <v-container grid-list-md>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="record.current.operationWeight"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('operationWeight')"
                    data-vv-name="operationWeight"
                    couter
                    :label="labelOperationWeight" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="record.current.maximumWeight"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('maximumWeight')"
                    data-vv-name="maximumWeight"
                    couter
                    :label="labelMaximumWeight" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="record.current.maximumWeightOfRide"
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
                    v-model="record.current.dimensions"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('dimensions')"
                    data-vv-name="dimensions"
                    couter
                    :label="labelDimensions" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="record.current.mostTechnicallyWeightOfRide"
                    v-validate="'max:100'"
                    :error-messages="errors.collect('mostTechnicallyWeightOfRide')"
                    data-vv-name="mostTechnicallyWeightOfRide"
                    couter
                    :label="labelMostTechnicallyWeightOfRide" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="record.current.mostTechnicallyAcceptableWeight"
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
                    v-model="record.current.equipment"
                    v-validate="'max:1000'"
                    :error-messages="errors.collect('equipment')"
                    :label="labelEquipment"
                    data-vv-name="equipment" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-textarea
                    v-model="record.current.defects"
                    v-validate="'max:1000'"
                    :error-messages="errors.collect('defects')"
                    :label="labelDefects"
                    data-vv-name="defects" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-textarea
                    v-model="record.current.moreDescription"
                    v-validate="'max:1000'"
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
              <v-layout row wrap>
                <v-flex
                  v-for="image in record.current.files"
                  :key="image.name"
                  xs12 md3 >
                  <v-card>
                    <v-card-media :src="imagePath(image)" height="150px">
                      <v-tooltip bottom>
                        <v-btn
                          fab
                          dark
                          small
                          color="black"
                          slot="activator"
                          @click.native="deleteImage(image)">
                          <v-icon dark>remove</v-icon>
                        </v-btn>
                        <span>{{ resx('delete') }}</span>
                      </v-tooltip>
                    </v-card-media>
                  </v-card>
                </v-flex>
              </v-layout>
            </v-container>
          </v-form>
           <v-layout row wrap>
              <v-flex xs12>
                <v-btn
                  v-if="state > 1 && state <= 4"
                  color="black"
                  @click="back">
                  <v-icon left dark>keyboard_arrow_left</v-icon>
                  {{ resx('back') }}
                </v-btn>
                <v-btn
                  v-if="state >= 1 && state < 4"
                  color="black"
                  @click="next">
                  {{ resx('next') }}
                  <v-icon left dark>keyboard_arrow_right</v-icon>
                </v-btn>
                <v-btn
                  v-if="state === 4"
                  color="black"
                  @click="submit">
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
          <v-layout>
            <v-flex xs12 class="text-xs-right">
              <v-btn color="black" dark class="mb-2" @click="newRecord">{{ resx('new') }}</v-btn>
            </v-flex>
          </v-layout>
          <v-data-table
            :headers="headers"
            :items="records"
            :pagination.sync="pagination"
            hide-actions
            class="elevation-1">
            <template slot="items" slot-scope="props">
              <td>{{ props.item.name }}</td>
              <td>{{ props.item.auctionName }}</td>
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
                  <v-icon
                      style="cursor: pointer"
                      small
                      class="mr-2"
                      @click="wantToDeleteRecord(props.item)">
                      delete
                  </v-icon>
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

import { Component, Prop, Watch } from 'vue-property-decorator';
import { State, Getter, Action, namespace } from 'vuex-class';

import BaseComponent from '../BaseComponent.vue';
import PriceComponent from '@/components/helpers/PriceComponent.vue';
import DatePickerComponent from '@/components/helpers/DatePickerComponent.vue';
import TimePickerComponent from '@/components/helpers/TimePickerComponent.vue';
import FileUploadComponent from '@/components/helpers/FileUploadComponent.vue';
import QuestionDialogComponent from '@/components/helpers/QuestionDialogComponent.vue';
import LoadingComponent from '@/components/helpers/LoadingComponent.vue';

import { RecordTableDto, AuthUser, FileSimpleDto, AuctionLookupDto } from '@/poco';
import { Record, File } from '@/model';
import { RecordState, AuthState } from '@/store/types';
import moment from 'moment';

const RecordAction = namespace('record', Action);
const RecordGetter = namespace('record', Getter);
const AuctionGetter = namespace('auction', Getter);
const AuctionAction = namespace('auction', Action);

@Component({
  components: {
    PriceComponent,
    DatePickerComponent,
    FileUploadComponent,
    QuestionDialogComponent,
    LoadingComponent,
    TimePickerComponent,
  },
})
export default class AdminRecordTableComponent extends BaseComponent {
  @State('record') private record: RecordState;
  @State('auth') private auth: AuthState;

  @RecordGetter('getRecords') private records: RecordTableDto[];
  @RecordAction('getAllForAdmin') private loadRecords: any;

  @RecordAction('initialCurrent') private initCurrent: any;
  @RecordAction('getDetail') private getDetail: any;
  @RecordAction('createRecord') private create: any;

  @RecordAction('deleteRecord') private delete: any;
  @RecordAction('updateRecord') private updateRecord: any;
  @RecordAction('setFiles') private setFiles: any;
  @RecordAction('addFiles') private addFiles: any;
  @RecordAction('setCurrentUserId') private setCurrentUserId: any;
  @RecordAction('setValidDates') private setDates: any;
  @RecordAction('setValidTimes') private setTimes: any;

  @AuctionAction('getAllLookup') private loadAuctionsCombo: any;
  @AuctionGetter('getLookupList') private auctionsCombo: AuctionLookupDto[];

  private timeTo: string = null;
  private timeFrom: string = null;
  private loading: boolean = false;
  private questionDialog: boolean = false;
  private objectToDelete: RecordTableDto = undefined;
  private state: number = 1;
  private formActive: boolean = false;
  private headers: any[] = [];
  private pagination: any = {
      rowsPerPage: 10,
      totalItems: 0,
  };

  @Watch('records') private changeUsers(records) {
      if (records !== undefined && records.length > 0) {
          this.pagination.totalItems = records.length;
      }
  }

  private mounted() {
      this.loading = true;
      this.loadRecords().then((response) => {
        if (response) {
          this.loading = false;
        }
      });
      this.headers.push({
          text: this.settings.resource.name,
          align: 'left',
          sortable: true,
          value: 'name' });
      this.headers.push({
          text: this.settings.resource.auctions,
          align: 'left',
          sortable: true,
          value: 'auctionName' });
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
      this.loadAuctionsCombo();
  }

  get labelTimeFrom(): string {
    return this.settings.resource.timeFrom;
  }

  get labelTimeTo(): string {
    return this.settings.resource.timeTo;
  }

  get questionWarning(): string {
    return this.settings.resource.warning;
  }

  get questionMessage(): string {
    return this.settings.resource.messageDeleteItem;
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

  get labelAuction(): string {
    return this.settings.resource.auctions;
  }

  get pages() {
      if (this.pagination.rowsPerPage == null ||
        this.pagination.totalItems == null) {
            return 0;
      }
      return Math.ceil(this.pagination.totalItems / this.pagination.rowsPerPage);
  }

  private auctionChange(): void {
    if (this.record.current !== undefined) {
      if (this.record.current.auctionId !== undefined) {
        const auction: AuctionLookupDto = this.auctionsCombo
          .find((x) => x.id === this.record.current.auctionId);

        if (auction) {
          const datesString: string[] = auction.name.substring(
              auction.name.indexOf('[') + 1,
              auction.name.lastIndexOf(']')).split('-');
          const fromDate = moment(datesString[0].trim(), 'DD.MM.YYYY HH:mm');
          const toDate = moment(datesString[1].trim(), 'DD.MM.YYYY HH:mm');

          this.record.current.validFrom = fromDate.toDate();
          this.record.current.validTo = toDate.toDate();
          this.setDates(this.record.current);
        }
      }
    }
  }

  private setTime($event, time: string): void {
    switch (time) {
      case 'from':
        this.setTimes({ from: $event, to: undefined });
        break;
      case 'to':
        this.setTimes({ from: undefined, to: $event });
        break;
    }
  }

  private deleteImage(file: FileSimpleDto): void {
    if (this.record.current !== undefined) {
      const filesToRemain: FileSimpleDto[] = this.record.current.files
        .filter((x) => x.id !== file.id && x.name !== file.name);

      this.setFiles(filesToRemain.map((x) => {
          const item: File = {
            path: x.path,
            userId: x.userId,
            recordId: x.recordId,
            created: new Date(),
            user: null,
            record: null,
            name: x.name,
            id: x.id,
          } as File;

          return item;
        }));
    }
  }

  private imagePath(file: FileSimpleDto): string {
    const path: string = file.id > 0
      ? `/${file.path}/${file.recordId}/images`
      : `/tempFiles`;

    return `${path}/${file.name}`;
  }

  private backToList(): void {
    this.initCurrent().then((response) => {
      this.state = 1;
      this.formActive = false;
    });

  }

  private edit(item: RecordTableDto): void {
    if (item.id > 0) {
      this.loading = true;
      this.getDetail(item.id).then((response) => {
        this.formActive = response as boolean;
        const { current } = this.record;
        const fromHours: string = current.validFrom.getHours().toString();
        const fromMinutes: string = current.validFrom.getMinutes().toString();

        const toHours: string = current.validTo.getHours().toString();
        const toMinutes: string = current.validTo.getMinutes().toString();

        const fH: string = '00'.substring(fromHours.length) + fromHours;
        const fM: string = '00'.substring(fromMinutes.length) + fromMinutes;

        const tH: string = '00'.substring(toHours.length) + toHours;
        const tM: string = '00'.substring(toMinutes.length) + toMinutes;

        this.timeFrom = `${fH}:${fM}`;
        this.timeTo = `${tH}:${tM}`;
        this.loading = false;
      });
    }
  }

  private wantToDeleteRecord(item: RecordTableDto): void {
    this.questionDialog = true;
    this.objectToDelete = item;
  }

  private deleteRecord(decision: boolean): void {
    if (this.objectToDelete.id > 0 && decision) {
      this.delete(this.objectToDelete.id).then((response) => {
        if (response) {
          this.questionDialog = false;
        }
      });
    } else {
      this.questionDialog = false;
      this.objectToDelete = undefined;
    }
  }

  private newRecord() {
    this.initCurrent().then((response) => {
      this.formActive = response as boolean;
      this.setCurrentUserId(this.auth.userId);
    });
  }

  private newFiles(files: File[]): void {
      this.addFiles(files.map((file) => {
          const item: File = {
            path: 'auction',
            userId: this.auth.userId,
            recordId: this.record.current.id,
            created: new Date(file.created),
            user: null,
            record: null,
            name: file.name,
            id: file.id,
          } as File;

          return item;
        }));
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
          if (this.record.current.id === undefined ||
              this.record.current.id <= 0) {
              this.create(this.record.current).then((respRecord) => {
                if (respRecord) {
                  this.backToList();
                }
              });
          } else {
            this.updateRecord(this.record.current).then((respRecord) => {
              if (respRecord) {
                this.backToList();
              }
            });
          }
        }
      });
    }
  }
}

</script>

<style>

.record-administration h1 {
  padding-bottom: 0px !important;
}

.admin-auciton-table .elevation-1 {
    -webkit-box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0) !important;
    box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0)!important;
}

.admin-auciton-table .v-pagination .v-pagination__item--active {
    background-color: #546E7A !important;
}

.admin-auciton-table .v-btn {
    color: white !important;
    border-radius: 5px !important;
}

.admin-auction-table .v-toolbar {
  height: 10px !important;
}

</style>
