<template>
  <div class="record-administration">
    <v-container grid-list-xs pa-2>
      <v-layout row wrap>
        <v-flex xs12>
          <h1>{{ resx('auctionsAdministration') }}</h1>
        </v-flex>
      </v-layout>
      <v-layout row wrap>
        <v-flex xs12>
          <admin-auction-table-component :auctions="auctions" :loading="isLodading" />
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
import { AuctionTableDto } from './../../poco';

const AuctionAction = namespace('auction', Action);
const AuctionGetter = namespace('auction', Getter);

@Component({
  components: {
    AdminAuctionTableComponent,
  },
})
export default class AuctionAdministration extends BaseView {
  @AuctionGetter('getTableAuctions')
  private auctions: AuctionTableDto[];

  @AuctionAction('getAllForAdmin')
  private loadAuctions: any;

  private isLodading: boolean = true;

  public mounted() {
    this.loadAuctions().then((response) => {
      if (response) {
        this.isLodading = false;
      }
    });
  }
}

</script>

<style>

.record-administration h1 {
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