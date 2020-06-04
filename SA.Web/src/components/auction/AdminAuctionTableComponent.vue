<template>
  <div class="admin-auciton-table">
     <question-dialog-component
            :header="questionWarning"
            :question="questionMessage"
            :dialog="questionDialog"
            @result="deleteAuction($event)" />
    <v-container  grid-list-xs pa-0 v-if="formActive">
      <v-layout row wrap>
        <v-flex xs7>
          <h1 v-if="auction.current && auction.current.id !== undefined">{{ resx('edit') }}: {{ auction.current.name }}</h1>
          <h1 v-if="auction.current && auction.current.id === undefined">{{ resx('new') }}</h1>
        </v-flex>
        <v-flex xs5 justify-end>
          <v-btn @click="backToList" dark>{{ resx('back') }}</v-btn>
        </v-flex>
      </v-layout>
      <v-layout row wrap>
        <v-flex xs12 row wrap>
          <v-form lazy-validation v-if="auction.current">
            <v-container grid-list-md>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <v-text-field
                    v-model="auction.current.name"
                    v-validate="'required|max:100|min:5'"
                    :error-messages="errors.collect('name')"
                    data-vv-name="name"
                    couter
                    :label="labelName" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-switch
                    v-model="auction.current.isActive"
                    :label="labelIsActive" />
                </v-flex>
                <v-flex xs12 md4>
                  <v-switch
                    v-model="auction.current.isEnded"
                    :label="labelIsEnded" />
                </v-flex>
              </v-layout>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <date-picker-component
                    :date="auction.current.validFrom"
                    name="validFrom"
                    :validation="{required: true }"
                    :label="labelValidFrom"
                    @date="auction.current.validFrom = $event"/>
                </v-flex>
                <v-flex xs12 md4>
                  <date-picker-component
                    :date="auction.current.validTo"
                    name="validTo"
                    :validation="{required: true }"
                    :label="labelValidTo"
                    @date="auction.current.validTo = $event" />
                </v-flex>
              </v-layout>
              <v-layout row wrap>
                <v-flex xs12 md4>
                  <time-picker-component
                    :time="timeFrom"
                    name="timeFrom"
                    :label="labelTimeFrom"
                    :validation="{ required: true}"
                    @time="timeFrom = $event" />
                </v-flex>
                <v-flex xs12 md4>
                  <time-picker-component
                    :time="timeTo"
                    name="timeTo"
                    :label="labelTimeTo"
                    @time="timeTo = $event" />
                </v-flex>
              </v-layout>
            </v-container>
          </v-form>
           <v-layout row wrap>
              <v-flex xs12>
                <v-btn
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
        <v-flex xs12 v-if="itemLoaded">
          <v-layout row wrap>
            <v-flex xs10>
              <h2>{{ resx('auctions') }}:
                [{{  selecteAuction.name }}:
                {{ selecteAuction.validFrom | moment('DD.MM.YYYY HH:mm') }} -
                {{ selecteAuction.validTo | moment('DD.MM.YYYY HH:mm') }}]
              </h2>
            </v-flex>
            <v-flex xs2 class="text-xs-right">
              <v-btn color="black" dark class="mb-2" @click="backToList">{{ resx('back') }}</v-btn>
            </v-flex>
          </v-layout>
          <v-layout row wrap>
            <v-flex xs12>
              <h3>{{ resx('recordAdministration') }}</h3>
            </v-flex>
          </v-layout>
          <v-layout row wrap>
            <v-flex xs12>
              <admin-record-table-component :auction="selecteAuction" :records="records" :loading="editLoading" />
            </v-flex>
          </v-layout>
        </v-flex>
        <v-flex xs12 v-else>
          <v-layout>
            <v-flex xs7>
                  <v-chip
                    class="ma-2"
                    color="red"
                    text-color="white">
                      {{ resx('auctionInErrorState' )}}
                    </v-chip>
                  <v-chip
                    class="ma-2"
                    color="green"
                    text-color="white">
                      {{ resx('auctionIsActive' )}}
                    </v-chip>
                  <v-chip
                    class="ma-2"
                    color="blue"
                    text-color="white">
                      {{ resx('featureAuction' )}}
                    </v-chip>
            </v-flex>
            <v-flex xs2 class="text-xs-right">
                <v-switch
                    v-model="isActive"
                    :label="labelIsActive" />
            </v-flex>
            <v-flex xs2 class="text-xs-right">
                <v-switch
                    v-model="isEnded"
                    :label="labelIsEnded" />
            </v-flex>
            <v-flex xs1 class="text-xs-right">
              <v-btn color="black" dark class="mb-2" @click="newAuction">{{ resx('new') }}</v-btn>
            </v-flex>
          </v-layout>
          <v-progress-linear v-if="editLoading" color="blue" indeterminate></v-progress-linear>
          <v-data-table
            :headers="headers"
            :items="auctions"
            :loading="loading"
            :pagination.sync="pagination"
            hide-actions
            class="elevation-1">
            <v-progress-linear slot="progress" color="blue" indeterminate></v-progress-linear>
            <template slot="items" slot-scope="props">
              <tr :class="{
                    row_color_warning: notValidAndNotEnded(props.item),
                    row_color_feature: validAndNotActive(props.item),
                    row_color_ok: validAndActive(props.item)
                  }">
                <td>{{ props.item.name }}</td>
                <td>{{ props.item.validFrom | moment('DD.MM.YYYY HH:mm') }}</td>
                <td>{{ props.item.validTo | moment('DD.MM.YYYY HH:mm') }}</td>
                <td>
                  <v-checkbox
                    v-model="props.item.isActive"
                    :disabled="true"
                    hide-details
                    class="shrink mr-2" />
                </td>
                <td>
                  <v-checkbox
                    v-model="props.item.isEnded"
                    :disabled="true"
                    hide-details
                    class="shrink mr-2" />
                </td>
                <td>{{ props.item.numberOfRecords }}</td>
                <td>
                    <v-icon
                        style="cursor: pointer"
                        small
                        class="mr-2"
                        @click="items(props.item)">
                        list
                    </v-icon>
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
              </tr>
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
import { State, Action, Getter, namespace } from 'vuex-class';

import BaseComponent from '../BaseComponent.vue';
import DatePickerComponent from '@/components/helpers/DatePickerComponent.vue';
import QuestionDialogComponent from '@/components/helpers/QuestionDialogComponent.vue';
import TimePickerComponent from '@/components/helpers/TimePickerComponent.vue';
import AdminRecordTableComponent from '@/components/auction/AdminRecordTableComponent.vue';

import { AuctionTableDto, RecordTableDto } from './../../poco';
import { Auction, Record } from './../../model';
import { AuctionState } from './../../store/types';

const AuctionAction = namespace('auction', Action);
const RecordAction = namespace('record', Action);
const RecordGetter = namespace('record', Getter);

@Component({
  components: {
    DatePickerComponent,
    QuestionDialogComponent,
    TimePickerComponent,
    AdminRecordTableComponent,
  },
})
export default class AdminAuctionTableComponent extends BaseComponent {
  @State('auction')
  private auction: AuctionState;

  @Prop({default: []})
  private auctions: AuctionTableDto[];
  @Prop({default: true})
  private loading: boolean;

  @AuctionAction('initialCurrent')
  private initCurrent: any;
  @AuctionAction('getDetail')
  private getDetail: any;
  @AuctionAction('create')
  private create: any;

  @AuctionAction('delete')
  private delete: any;
  @AuctionAction('update')
  private update: any;

  @RecordGetter('getRecords')
  private records: RecordTableDto[];
  @RecordAction('getAuctionRecordsForAdmin')
  private loadRecords: any;
  @RecordAction('updateRecordDatesByAuctionId')
  private updateRecordDatesByAuctionId: any;

  private timeTo: string = null;
  private timeFrom: string = null;
  private editLoading: boolean = false;
  private itemLoaded: boolean = false;
  private questionDialog: boolean = false;
  private objectToDelete: AuctionTableDto = undefined;
  private state: number = 1;
  private formActive: boolean = false;
  private headers: any[] = [];
  private isActive: boolean = false;
  private isEnded: boolean = false;
  private pagination: any = {
      rowsPerPage: 10,
      totalItems: 0,
  };
  private selecteAuction: AuctionTableDto = undefined;

  private tempAuctions: AuctionTableDto[] = [];

  @Watch('isActive') private changeFilterIsActive(isActive) {
    if (isActive) {
      if (this.tempAuctions.length <= 0) {
        Object.assign(this.tempAuctions, this.auctions);
      }

      if (this.isEnded) {
        this.auctions = this.tempAuctions.filter((item) => item.isActive || item.isEnded);
      } else {
        this.auctions = this.tempAuctions.filter((item) => item.isActive);
      }
    } else {
      if (this.isEnded) {
        this.auctions = this.tempAuctions.filter((item) => item.isEnded);
      } else {
        this.auctions = this.tempAuctions;
      }
    }
  }

  @Watch('isEnded') private changeFilterIsEnded(isEnded) {
    if (isEnded) {
      if (this.tempAuctions.length <= 0) {
        Object.assign(this.tempAuctions, this.auctions);
      }

      if (this.isActive) {
        this.auctions = this.tempAuctions.filter((item) => item.isActive || item.isEnded);
      } else {
        this.auctions = this.tempAuctions.filter((item) => item.isEnded);
      }
    } else {
      if (this.isActive) {
        this.auctions = this.tempAuctions.filter((item) => item.isActive);
      } else {
        this.auctions = this.tempAuctions;
      }
    }
  }

  @Watch('auctions') private changeUsers(auctions) {
      if (auctions !== undefined && auctions.length > 0) {
          this.pagination.totalItems = auctions.length;
      }
  }

  private mounted() {
        this.headers.push({
            text: this.settings.resource.name,
            align: 'left',
            sortable: true,
            value: 'name' });
        this.headers.push({
            text: this.settings.resource.validFrom,
            align: 'right',
            sortable: true,
            value: 'validFrom' });
        this.headers.push({
            text: this.settings.resource.validTo,
            align: 'left',
            sortable: true,
            value: 'validTo' });
        this.headers.push({
            text: this.settings.resource.active,
            align: 'center',
            sortable: true,
            value: 'isActive' });
        this.headers.push({
            text: this.settings.resource.ended,
            align: 'center',
            sortable: true,
            value: 'isEnded' });
        this.headers.push({
            text: this.settings.resource.numberOfRecords,
            align: 'rigth',
            sortable: false,
            value: 'numberOfRecords' });
        this.headers.push({
            text: this.settings.resource.action,
            align: 'center',
            sortable: true,
            value: 'action' });
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

  get labelName(): string {
    return this.settings.resource.name;
  }

  get labelValidFrom(): string {
    return this.settings.resource.validFrom;
  }

  get labelValidTo(): string {
    return this.settings.resource.validTo;
  }

  get labelIsActive(): string {
    return this.settings.resource.active;
  }

  get labelIsEnded(): string {
    return this.settings.resource.ended;
  }

  get pages() {
      if (this.pagination.rowsPerPage == null ||
        this.pagination.totalItems == null) {
            return 0;
      }
      return Math.ceil(this.pagination.totalItems / this.pagination.rowsPerPage);
  }

  private notValidAndNotEnded(item: AuctionTableDto): boolean {
    const currentDate = new Date();
    const itemDate = new Date(item.validTo);
    return itemDate <= currentDate
      && (item.isActive || !item.isEnded);
  }

  private validAndActive(item: AuctionTableDto): boolean {
    const currentDate = new Date();
    const dateTo = new Date(item.validTo);
    const dateFrom = new Date(item.validFrom);

    return dateTo >= currentDate
      && dateFrom <= currentDate
      && item.isActive
      && !item.isEnded;
  }

  private validAndNotActive(item: AuctionTableDto): boolean {
    const currentDate = new Date();
    const dateTo = new Date(item.validTo);
    const dateFrom = new Date(item.validFrom);

    return dateFrom >= currentDate
      && !item.isEnded;
  }

  private backToList(): void {
    this.initCurrent().then((response) => {
      this.formActive = false;
      this.itemLoaded = false;
      this.selecteAuction = undefined;
    });
  }

  private edit(item: AuctionTableDto): void {
    if (item.id > 0) {
      this.editLoading = true;
      this.getDetail(item.id).then((response) => {
        this.formActive = response as boolean;
        const { current } = this.auction;
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
        this.editLoading = false;
      });
    }
  }

    private items(item: AuctionTableDto): void {
      if (item.id > 0) {
        this.editLoading = true;
        this.selecteAuction = item;
        this.loadRecords(item.id).then((response) => {
          this.itemLoaded = true;
          if (response) {
            this.editLoading = false;
          }
        });
      }
    }

  private wantToDeleteRecord(item: AuctionTableDto): void {
    this.questionDialog = true;
    this.objectToDelete = item;
  }

  private deleteAuction(decision: boolean): void {
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

  private newAuction() {
    this.initCurrent().then((response) => {
      this.timeFrom = undefined;
      this.timeTo = undefined;
      this.formActive = response as boolean;
    });
  }

  private submit(): void {
    this.$validator.validateAll().then((response) => {
      if (response) {
        const fromHours: number = this.timeFrom === undefined
            ? 0
            : parseInt((this.timeFrom as string).split(':')[0], 0);
        const fromMinutes: number = this.timeFrom === undefined
            ? 0
            : parseInt((this.timeFrom as string).split(':')[1], 0);
        const toHours: number = this.timeTo === undefined
            ? 0
            : parseInt((this.timeTo as string).split(':')[0], 0);
        const toMinutes: number = this.timeTo === undefined
            ? 0
            : parseInt((this.timeTo as string).split(':')[1], 0);

        const fromDate: Date = new Date(Date.UTC(
            this.auction.current.validFrom.getFullYear(),
            this.auction.current.validFrom.getMonth(),
            this.auction.current.validFrom.getDate(),
            fromHours,
            fromMinutes,
            0,
            0,
        ));

        const toDate: Date = new Date(Date.UTC(
              this.auction.current.validTo.getFullYear(),
              this.auction.current.validTo.getMonth(),
              this.auction.current.validTo.getDate(),
              toHours,
              toMinutes,
              0,
              0,
          ));

        this.auction.current.validFrom = fromDate;
        this.auction.current.validTo = toDate;

        if (this.auction.current.id === undefined ||
            this.auction.current.id <= 0) {
            this.create(this.auction.current).then((respRecord) => {
              if (respRecord) {
                this.backToList();
              }
            });
        } else {
          const auctionId = this.auction.current.id;
          this.update(this.auction.current).then((respRecord) => {
            if (respRecord) {
              this.updateRecordDatesByAuctionId(auctionId).then((resp) => {
                this.backToList();
              });
            }
          });
        }
      }
    });
  }
}

</script>

<style>

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

.application .theme--light.v-table, .theme--light .v-table .row_color_warning {
  color: red !important;
}

.application .theme--light.v-table, .theme--light .v-table .row_color_ok {
  color: green !important;
}

.application .theme--light.v-table, .theme--light .v-table .row_color_feature {
  color: lightskyblue !important;
}

</style>
