<template>
  <div class="auction-grid-list">
    <loading-component :open="isLoading" />
    <v-container grid-list-xs fluid v-if="auctions">
      <v-layout row wrap v-if="auctions" class="auctions-container">
        <v-flex xs12 v-for="(auction, index) in auctions.slice(0, limitList)" :key="index" class="auction-list">
          <v-card>
            <v-card-title>
              <v-layout row wrap>
                <v-flex xs12 md6 class="text-xs-left">
                  <h1>{{ resx('auctions') }} {{ auction.name }}</h1>
                  <v-btn color="black">
                    {{ auction.records.length }}
                    <span class="car-text">{{ btnCarsText(auction.records.length) }}</span>
                  </v-btn>
                </v-flex>
                <v-flex xs12 md6 class="text-xs-right">
                  <h3>{{ resx('from').toLowerCase() }} {{ auction.validFrom | moment('DD.MM.YYYY') }} {{ resx('to').toLowerCase() }} {{ auction.validTo | moment('DD.MM.YYYY') }}</h3>
                </v-flex>
              </v-layout>
            </v-card-title>
            <v-layout row wrap>
              <lory class="js_multislides" :options="{ enableMouseEvents: true, slidesToScroll: 4, slideSpeed: 1000 }">
                <prev slot="actions" color="#ffffff"></prev>
                <item v-for="(item, i2) in auction.records" :key="i2" style="padding-left: 20px">
                  <v-flex xs12 sm3 class="auction-item">
                    <v-card>
                      <v-card-media :src="firstImagePath(item)" @click="detail(item)"></v-card-media>
                      <v-layout row wrap>
                        <v-flex xs12 class="text-xs-center">
                          <h4>{{ item.name }}</h4>
                        </v-flex>
                      </v-layout>
                      <v-layout row wrap class="auction-item-info">
                        <v-flex xs4 class="text-xs-center">
                          <span>{{ item.registrationYear }}</span>
                        </v-flex>
                        <v-flex xs4 class="text-xs-center">
                          <span>{{ item.fuel }}</span>
                        </v-flex>
                        <v-flex xs4 class="text-xs-center">
                          <span>{{ item.mileage }}</span>
                        </v-flex>
                      </v-layout>
                      <v-layout row wrap>
                        <v-flex xs12 class="text-xs-center">
                          <span class="auction-item-price-text">{{ resx('actualPrice') }}</span>
                          <span class="price-with-dph" v-if="item.withVat">{{ resx('withVat') }}</span>
                          <span class="price-with-dph" v-else>{{ resx('withoutVat') }}</span>
                        </v-flex>
                      </v-layout>
                      <v-layout row wrap>
                        <v-flex xs12 class="text-xs-center item-price">
                          <h4>
                            <price-component :price="item.currentPrice" />
                          </h4>
                        </v-flex>
                      </v-layout>
                    </v-card>
                  </v-flex>
                </item>
                <next slot="actions" color="#ffffff"></next>
              </lory>
            </v-layout>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Lory, Item, Prev, Next } from 'vue-lory';
import { Component, Prop } from 'vue-property-decorator';
import { State, Action, Getter, namespace } from 'vuex-class';

import { Record } from '@/model';
import BaseComponent from './BaseComponent.vue';
import CountdownComponent from './helpers/CountdownComponent.vue';
import PriceComponent from './helpers/PriceComponent.vue';
import LoadingComponent from './helpers/LoadingComponent.vue';
import { RecordTableDto, AuctionDto } from '@/poco';


const AuctionGetter = namespace('auction', Getter);
const AuctionAction = namespace('auction', Action);
const RecordAction = namespace('record', Action);

@Component({
    components: {
        CountdownComponent,
        PriceComponent,
        LoadingComponent,
        Lory,
        Item,
        Prev,
        Next,
    },
})
export default class AuctionFeatureListComponent extends BaseComponent {
  @Prop({default: undefined}) private take: number;
  @AuctionGetter('getAuctions') private auctions: AuctionDto[];

  @AuctionAction('getFutureAutions') private featuredAcutions: any;
  @RecordAction('getDetail') private loadRecord: any;

  private isLoading: boolean = false;

  private mounted() {
    this.isLoading = true;
    this.featuredAcutions().then(() => {
        this.isLoading = false;
    });
  }

  get limitList(): number {
      return this.take !== undefined
        ? this.take
        : this.auctions.length;
  }

  private firstImagePath(record: Record): string {
    const { files } = record;
    if (files.length === 0) {
      return '';
    }
    const rf = files[0];
    return `/${rf.path}/${rf.recordId}/images/${rf.name}`;
  }


  private detail(record: RecordTableDto): void {
    this.isLoading = true;
    this.loadRecord(record.id).then((response) => {
      const result = response as boolean;
      this.isLoading = false;
      if (result) {
        this.$router.push({ path: `/auctionDetail?id=${record.id}` });
      }
    });
  }

  private btnCarsText(count: number): string {
    switch (count) {
      case 1:
        return `${this.settings.resource.car.toLowerCase()}`;
      case 2:
      case 3:
        return `${this.settings.resource.fewCars.toLowerCase()}`;
      default:
        return `${this.settings.resource.cars.toLowerCase()}`;
    }
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

.auctions-container .items {
  padding-left: 30px !important;
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

.auctions-container .auction-item {
  width: 280px !important;
  padding-left: 12px !important;
  padding-right: 12px !important;
}

.auctions-container .auction-item .auction-item-info {
  font-family: Roboto;
  font-size: 10px !important;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0.8px;
  color: #929292 !important;
}

.auctions-container .auction-item .auction-item-price-text {
  text-transform: uppercase !important;
  font-family: Roboto;
  font-size: 10px !important;
  font-weight: bold;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0.8px;
  color: #030303 !important;
}



.auctions-container .slides li {
  width: 280px !important;
}

.auctions-container .auction-item .item-price h4 div {
  line-height: 1.2 !important;
}

.auctions-container .auction-list .slider {
  width: 100% !important;
}

.auctions-container .auction-list .flex {
  max-width: 100% !important;
}

.auctions-container .slider svg {
  background-color: black !important;
  border-radius: 5px !important;
}

.auctions-container .auction-item .v-card {
    border-radius: 5px !important;
    border: 1px solid #d1d2d1 !important;
}

.auctions-container .auction-item h4 {
  font-family: Roboto;
  font-size: 20px;
  font-weight: 500 !important;
  font-style: normal;
  font-stretch: normal;
  line-height: 2.12;
  letter-spacing: 0px;
  color: #000000;
  white-space: normal !important;
}

.auction-grid-list .list-item-price span {
  font-size: 18px !important;
  color: white !important;
}

.auctions-container .auction-item .v-card__media__content {
  max-height: 210px !important;
}

.auction-list .v-btn {
  color: white !important;
  border-radius: 5px !important;
  text-transform: lowercase;
}

.auction-list .v-btn .car-text {
  font-size: 10px !important;
  padding-left: 5px !important;
}

.auction-list .v-card__title {
  padding: 0px !important;
}

.auction-list .v-card__title .v-btn {
  padding-left: 15px !important;
  height: 23px !important;
  min-width: 50px !important;
}

.auction-list .v-card__title .v-btn .v-btn__content {
  height: 23px !important;
}

.auction-list .v-card__title h1, .auction-list .v-card__title .v-btn {
  display: inline !important;
}

.auction-list .v-card__title h1 {
  font-family: Roboto;
  font-size: 30px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  color: #000000;
  padding-top: 0px !important;
  padding-bottom: 0px !important;
}

.auction-list .v-card__title h3 {
  font-family: Roboto;
  font-size: 16px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  color: #000000;
  line-height: 4 !important;
}

.auction-list .v-card {
  border-radius: 0px !important;
  background-color: #ffffff !important;
  border: 0px !important;
  padding-bottom: 20px !important;
}

.auctions-container {
  padding-top: 50px !important;
}

.auction-item .price-with-dph {
  padding-left: 2px;
  text-transform: uppercase;
  font-weight: bold;
  font-size: 10px;
  color: #030303;
}

</style>
