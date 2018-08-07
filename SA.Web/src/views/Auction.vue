<template>
  <div class="auction">
    <v-progress-linear v-if="isLoading && records === undefined" :indeterminate="isLoading"></v-progress-linear>
    <v-container v-if="records">
      <v-layout>
        <v-flex xs12>
          <section grid-list-md class="page-head">
            <v-flex xs8 md6>
              <h1 class="display-1 primary--text">{{ resx('auctions') }}</h1>
            </v-flex>
            <v-flex xs4 md6>
              <v-switch
                v-model="viewType"
                :label="`${getViewType ? resx('table'): resx('grid')}`" />
            </v-flex>
          </section>
          <section>
            <v-layout mb-5 row wrap>
              <v-flex xs12>
                <v-container pa-0 fluid grid-list-md>
                  <auction-table-component :records="records" v-if="getViewType" />
                  <auction-grid-component :records="records" v-if="getViewType === false" />
                </v-container>
              </v-flex>
            </v-layout>
          </section>
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
} from '@/components';

const RecordAction = namespace('record', Action);
const RecordGetter = namespace('record', Getter);
const SettingsAction = namespace('settings', Action);
const SettingsGetter = namespace('settings', Getter);

@Component({
  components: {
    AuctionTableComponent,
    AuctionGridComponent,
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
