<template>
  <div class="auction">
    <loading-component :open="isLoading"/>
    <v-container grid-list-xs pa-0>
      <v-layout row wrap>
        <v-flex xs12>
          <auction-grid-component :records="records" />
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import { Action, Getter, namespace } from 'vuex-class';
import { log } from 'util';

import { Record } from '@/model';
import BaseView from '@/views/BaseView.vue';
import {
  AuctionTableComponent,
  AuctionGridComponent,
  LoadingComponent,
} from '@/components';

const RecordAction = namespace('record', Action);
const RecordGetter = namespace('record', Getter);
const SettingsAction = namespace('settings', Action);
const SettingsGetter = namespace('settings', Getter);

@Component({
  components: {
    AuctionTableComponent,
    AuctionGridComponent,
    LoadingComponent,
  },
})
export default class Auction extends BaseView {

  @RecordGetter('getRecords') private records: Record[];
  @RecordAction('loadAllPublished') private loadRecords: any;
  @SettingsAction('changeDataViewType') private changeViewType: any;
  @SettingsGetter('getDataViewType') private getViewType: boolean;

  private isLoading: boolean = true;

  private mounted() {
    this.loadRecords().then((response) => {
      this.isLoading = false;
    });
  }

  get viewType(): boolean {
    return this.getViewType;
  }

  set viewType(type: boolean) {
    this.changeViewType(type);
  }
}

</script>

<style>

.auction h1 {
  font-family: Roboto;
  font-size: 35px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  text-align: left;
  color: #000000;
  padding-bottom: 30px;
  padding-top: 30px;
}

</style>