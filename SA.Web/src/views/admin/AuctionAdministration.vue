<template>
  <div class="record-administration">
    <v-container grid-list-xs pa-2>
      <v-layout row wrap>
        <v-flex xs12>
          <h1 class="display-1 primary--text">{{ resx('auctionsAdministration') }}</h1>
        </v-flex>
      </v-layout>
      <v-layout row wrap>
        <v-flex xs12>
          <admin-auction-table-component :auctions="records" :loading="isLodading" />
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import Component from 'vue-class-component';
import { Action, Getter, namespace } from 'vuex-class';

import BaseView from '../BaseView.vue';
import AdminAuctionTableComponent from '@/components/auction/AdminAuctionTableComponent.vue';
import { RecordTableDto } from '@/poco';

const RecordAction = namespace('record', Action);
const RecordGetter = namespace('record', Getter);

@Component({
  components: {
    AdminAuctionTableComponent,
  },
})
export default class AuctionAdministration extends BaseView {
  @RecordGetter('getRecords') private records: RecordTableDto[];
  @RecordAction('getAllForAdmin') private loadRecords: any;

  private isLodading: boolean = true;

  private mounted() {
    this.loadRecords().then((response) => {
      if (response) {
        this.isLodading = false;
      }
    });
  }
}

</script>
