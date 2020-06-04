<template>
    <v-layout row wrap class="actual-random" v-if="record && record !== null">
        <v-flex xs12>
            <v-container grid-list-md class="acutal-random-wrapper">
                <v-layout row wrap>
                    <v-flex xs12>
                        <div class="big-box">
                            <v-layout row wrap class="big-data">
                                <v-flex xs12 md6 class="big-img-wrapper">
                                    <v-card>
                                        <v-card-media :src="firstImagePath(record)" @click="detail(record)">
                                        </v-card-media>
                                    </v-card>
                                </v-flex>
                                <v-flex xs12 md6>
                                    <div class="big-box-info">
                                        <div class="record-info">
                                            <v-layout row wrap>
                                                <v-flex xs12><h1>{{ record.name }}</h1></v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs3>{{ resx('registration') }}</v-flex>
                                                <v-flex xs3>{{ resx('fuel') }}</v-flex>
                                                <v-flex xs3>{{ resx('power') }}</v-flex>
                                                <v-flex xs3>{{ resx('mileAge') }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs3>{{ record.dateOfFirstRegistration | moment('YYYY') }}</v-flex>
                                                <v-flex xs3>{{ record.fuel }}</v-flex>
                                                <v-flex xs3>{{ record.power }}</v-flex>
                                                <v-flex xs3>{{ record.mileage }}</v-flex>
                                            </v-layout>
                                        </div>
                                        <v-layout row wrap>
                                            <v-flex xs12>
                                                <bids-list-component :bids="record.bids" :pageRows="4"></bids-list-component>
                                            </v-flex>
                                        </v-layout>
                                        <v-layout row wrap v-if="currentUser.isFeePayed">
                                            <v-flex md4></v-flex>
                                            <v-flex xs12 md8 class="text-xs-right">
                                                <bid-component :bid="minimumBid" />
                                            </v-flex>
                                        </v-layout>
                                    </div>
                                </v-flex>
                            </v-layout>
                        </div>
                        <div class="header-box">
                            <v-container grid-list-md>
                                <v-layout row wrap>
                                    <v-flex xs12>
                                        <h1>{{ resx('actualAuction') }}</h1>
                                    </v-flex>
                                </v-layout>
                            </v-container>
                        </div>
                        <div class="small-box">
                            <v-container grid-list-md>
                                <v-layout row wrap>
                                    <v-flex xs6>
                                        <span>{{ resx('endOfAuction') }}</span>
                                    </v-flex>
                                    <v-flex xs6 class="text-xs-right">
                                        <span>{{ resx('actualPrice') }}</span>
                                    </v-flex>
                                </v-layout>
                                <v-layout row wrap class="small-box-data">
                                    <v-flex xs6>
                                        <countdown-component
                                        :id="recordIdToString(record)"
                                        :date="validTo(record.validTo)" />
                                    </v-flex>
                                    <v-flex xs6 class="text-xs-right">
                                        <price-component
                                        :price="record.currentPrice" />
                                    </v-flex>
                                </v-layout>
                            </v-container>
                        </div>
                    </v-flex>
                </v-layout>
            </v-container>
        </v-flex>
    </v-layout>
</template>

<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { Action, Getter, namespace } from 'vuex-class';

import FormBaseComponent from '@/components/FormBaseComponent.vue';
import BidsListComponent from '@/components/helpers/BidsListComponent.vue';

import { PriceComponent, CountdownComponent, BidComponent } from './../../components';
import { Record } from './../../model';
import { AuthUser } from './../../poco';

const RecordAction = namespace('record', Action);
const RecordGetter = namespace('record', Getter);
const AuthGetter = namespace('auth', Getter);

@Component({
    components: {
        PriceComponent,
        CountdownComponent,
        BidComponent,
        BidsListComponent,
    },
})
export default class ActualRandomComponent extends FormBaseComponent {
    @RecordAction('getActualRandom')
    private randomRecord: any;

    @RecordGetter('getCurrent')
    private record: Record;

    @AuthGetter('getCurrentLoggedUser')
    private currentUser: AuthUser;

    public mounted() {
        this.randomRecord();
    }

    private firstImagePath(record: Record): string {
        const { files } = record;
        if (files.length === 0) {
            return '';
        }
        const rf = files[0];
        return `/${rf.path}/${rf.recordId}/images/${rf.name}`;
    }

    private recordIdToString(record: Record): string {
      return record.id.toString();
    }

    private validTo(validTo: Date): string {
        return validTo.toString();
    }

    private detail(record: Record): void {
        if (record) {
            this.$router.push({ path: `/auctionDetail?id=${record.id}` });
        }
    }

    get minimumBid(): number {
        return this.record.currentPrice + this.record.minimumBid;
    }
}

</script>

<style>

.big-box-info .elevation-1 {
    -webkit-box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0) !important;
    box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0)!important;
}

.big-box-info table.v-table tbody td, table.v-table tbody th {
    height: 34px !important;
}

.big-box-info table.v-table tbody td {
    font-size: 12px !important;
}

.big-box-info table.v-table thead tr {
    height: 0px !important;
}

.actual-random {
    margin-top: 80px;
    background-color: #f8f8f8;
}

.actual-random .acutal-random-wrapper {
    max-width: 1150px;
    margin-top: 80px;
    margin-bottom: 100px;
    position: relative;
}

.small-box {
  max-width: 550px !important;
  height: 185px !important;
  border-radius: 15px;
  color: #fff;
  background-color: #000000 !important;
  border: solid 1px #979797 !important;
  position: absolute !important;
  top: 0px;
  right: 0px;
  z-index: 1;
}

 .big-box {
  margin-top: 50px;
  border-radius: 20px;
  background-color: #ffffff;
  border: solid 1px #dbdbdb;
  /* height: 300px !important; */
  position: relative;
  z-index: 2;
}

.small-box .container {
  font-family: Roboto;
  font-size: 10px !important;
  font-weight: bold;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0.8px;
  text-align: left;
  color: #929292;
  padding-top: 10px !important;
}

.small-box .small-box-data {
  font-size: 25px !important;
  color: white !important;
}

.big-box h1 {
  font-family: Roboto;
  font-size: 35px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  line-height: 1.15;
  letter-spacing: 0.3px;
  text-align: left;
  color: #000000;
}

.big-box .v-card {
    height: 100% !important;
}

.big-box .v-card__media {
    width: 100% !important;
}

.big-data {
    height: 100% !important;
    padding: 0px !important;
    margin: 0px !important;
    border-radius: 20px;
}

.big-box .big-img {
    width: 100%;
    height: 100%;
    cursor: pointer;
}

.big-img-wrapper {
    padding: 0px !important;
    margin: 0px !important;
    min-height: 300px !important;
}

.big-img-wrapper .v-card {
    --webkit-box-shadow: 0 0px 0px 0px rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0) !important;
    box-shadow: 0 0px 0px 0px rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0) !important;
    border-radius: 20px;
}

.big-img-wrapper .v-card__media {
    height: 100% !important;
}

.big-box .big-box-info {
    padding-left: 20px;
    padding-top: 10px;
}

.acutal-random-wrapper .header-box {
    position: absolute !important;
    top: 0px;
    left: 140px;
}

.acutal-random-wrapper .header-box h1 {
  color: black !important;
  font-family: Roboto;
  font-size: 35px;
  font-weight: normal;
  font-style: normal;
  font-stretch: normal;
  line-height: 1.15;
  letter-spacing: 0.3px;
  text-align: left;
}

.big-box-info .record-info {
    border-bottom: 1px solid #d1d1d1;
}

.big-box table.v-table tbody td {
    padding: 5px !important;
}

</style>