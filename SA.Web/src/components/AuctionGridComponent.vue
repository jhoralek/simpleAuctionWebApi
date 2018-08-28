<template>
  <div class="auction-grid-list">
    <v-container v-bind="{ [`grid-list-xs`]: true }" fluid v-if="records">
      <v-layout row wrap>
        <v-flex xs12 sm4 v-for="(record, index) in records" :key="index" class="auction-box">
          <v-card>
              <v-card-media :src="randomImagePath(record)" @click="detail(record)"></v-card-media>
              <v-card-title>
                <v-layout row wrap>
                  <v-flex xs8>{{ record.name }}</v-flex>
                  <v-flex xs2 class="text-xs-right">
                    <span v-if="record.registrationYear">{{ record.registrationYear }}</span>
                  </v-flex>
                  <v-flex xs2 class="text-xs-right">
                    <span  v-if="record.fuel">{{ record.fuel }}</span>
                  </v-flex>
                </v-layout>
              </v-card-title>
              <v-card-text>
                <v-layout row wrap>
                  <v-flex xs6>
                    <span>{{ resx('endOfAuction') }}</span>
                  </v-flex>
                  <v-flex xs6 class="text-xs-right">
                    <span>{{ resx('actualPrice') }}</span>
                  </v-flex>
                </v-layout>
                <v-layout row wrap>
                  <v-flex xs6>
                    <countdown-component
                      :id="recordIdToString(record)"
                      :date="record.validTo" />
                  </v-flex>
                  <v-flex xs6 class="text-xs-right">
                    <price-component
                      :price="record.currentPrice" />
                  </v-flex>
                </v-layout>
              </v-card-text>
              <v-card-actions>
                <v-layout row wrap>
                  <v-flex xs12 class="text-xs-center">
                    <v-btn @click="detail(record)" flat color="black">
                      {{ resx('detailOfAuction') }}
                    </v-btn>
                  </v-flex>
                </v-layout>
              </v-card-actions>
            </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import { Action, namespace } from 'vuex-class';

import { Record } from '@/model';
import BaseComponent from './BaseComponent.vue';
import CountdownComponent from './helpers/CountdownComponent.vue';
import PriceComponent from './helpers/PriceComponent.vue';
import { RecordTableDto } from '@/poco';

const RecordAction = namespace('record', Action);

@Component({
    components: {
        CountdownComponent,
        PriceComponent,
    },
})
export default class AuctionGridComponent extends BaseComponent {
  @Prop({default: undefined}) public records: RecordTableDto[];
  @RecordAction('getDetail') public loadRecord: any;

  private isLoading: boolean = false;

  private randomImagePath(record: Record): string {
    const { files } = record;
    const rf = files[Math.floor(Math.random() * files.length)];
    return `/${rf.path}/${rf.recordId}/images/${rf.name}`;
  }

  private recordIdToString(record: RecordTableDto): string {
      return record.id.toString();
  }

  private detail(record: RecordTableDto): void {
    this.isLoading = true;
    this.loadRecord(record.id).then((response) => {
      const result = response as boolean;
      this.isLoading = false;
      if (result) {
        this.$router.push({ path: `/auctionDetail?id=${record.id}`  });
      }
    });
  }
}

</script>

<style>

.auction-grid-list .item {
  cursor: pointer;
}

.auction-grid-list h3 {
  font-family: Roboto;
  font-size: 20px;
  color: black;
  line-height: 1.4;
  width: 100% !important;
  max-width: 100% !important;
}

.auction-grid-list .v-card {
    --webkit-box-shadow: 0 0px 0px 0px rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0) !important;
    box-shadow: 0 0px 0px 0px rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0) !important;
    border-radius: 5px !important;
    background-color: #ffffff !important;
    border: solid 1px #979797 !important;
}

.auction-grid-list .v-card__media__content {
  width: 347px !important;
  height: 279px !important;
}

.auction-grid-list .v-card__title {
  font-family: Roboto;
  font-size: 25px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  line-height: 2.12;
  letter-spacing: 0px;
  text-align: left;
  color: #000000;
  padding-bottom: 10px !important;
}

.auction-grid-list .v-card__title span {
  font-size: 10px !important;
  font-weight: bold !important;
  color: #929292 !important;
  text-align: right;
}

.auction-grid-list .auction-box {
  padding: 25px !important;
}

.auction-grid-list .v-card__text {
  background-color: #000000 !important;
  font-family: Roboto !important;
  font-size: 18px !important;
  font-weight: bold !important;
  font-style: normal !important;
  font-stretch: normal !important;
  letter-spacing: 0px !important;
  text-align: left !important;
  color: #ffffff !important;
  padding-top: 0px;
}

.auction-grid-list .v-card__text span {
  font-size: 10px !important;
  letter-spacing: 0.8px !important;
  color: #929292 !important;
}

.auction-grid-list .v-card__media {
  cursor: pointer;
}

</style>
