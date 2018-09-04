<template>
    <v-container grid-list-xs pa-0 v-if="record" class="auction-detail">
        <v-layout row wrap>
            <v-flex xs12 md6 class="left-side">
                <v-container  grid-list-xs pa-0>
                    <v-layout column>
                        <v-flex xs12>
                            <v-carousel hide-delimiters :cycle="false">
                                <v-carousel-item
                                    v-for="(item,i) in record.files"
                                    :key="i"
                                    :src="filePath(item)"
                                ></v-carousel-item>
                            </v-carousel>
                        </v-flex>
                        <v-flex xs12>
                            <v-expansion-panel expand>
                                <v-expansion-panel-content :value="expander1">
                                    <div slot="header">
                                        <h3>{{ resx('auctionDetailInformation') }}</h3>
                                    </div>
                                    <v-layout row wrap>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('startingPrice') }}</v-flex>
                                                <v-flex xs6 class="info-value"><price-component :price="record.startingPrice" /></v-flex>
                                            </v-layout>
                                        </v-flex>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('beginningOfTheAuction') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.validFrom | moment('DD.MM.YYYY HH:mm') }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                    <v-layout row wrap>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('minimumBid') }}</v-flex>
                                                <v-flex xs6 class="info-value"><price-component :price="record.minimumBid" /></v-flex>
                                            </v-layout>
                                        </v-flex>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('endOfAuction') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.validTo | moment('DD.MM.YYYY HH:mm') }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                    <v-layout row wrap>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('numberOfBids') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.numberOfBids }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('contactToAppointment') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.contactToAppointment }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                </v-expansion-panel-content>
                            </v-expansion-panel>
                            <v-expansion-panel expand>
                                <v-expansion-panel-content :value="expander">
                                    <div slot="header">
                                        <h3>{{ resx('specification') }}</h3>
                                    </div>
                                    <v-layout row wrap>
                                        <v-flex xs12>
                                            <v-layout row wrap>
                                                <v-flex xs8 class="info-text">{{ resx('dimensions') }}</v-flex>
                                                <v-flex xs4 class="info-value text-xs-right">{{ record.dimensions}}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                        <v-flex xs12>
                                            <v-layout row wrap>
                                                <v-flex xs8 class="info-text">{{ resx('maximumWeight') }}</v-flex>
                                                <v-flex xs4 class="info-value text-xs-right">{{ record.maximumWeight }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                    <v-layout row wrap>
                                        <v-flex xs12>
                                            <v-layout row wrap>
                                                <v-flex xs8 class="info-text">{{ resx('operationWeight') }}</v-flex>
                                                <v-flex xs4 class="info-value text-xs-right">{{ record.operationWeight}}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                        <v-flex xs12>
                                            <v-layout row wrap>
                                                <v-flex xs8 class="info-text">{{ resx('maximumWeightOfRide') }}</v-flex>
                                                <v-flex xs4 class="info-value text-xs-right">{{ record.maximumWeightOfRide }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                    <v-layout row wrap>
                                        <v-flex xs12>
                                            <v-layout row wrap>
                                                <v-flex xs8 class="info-text">{{ resx('mostTechnicallyWeightOfRide') }}</v-flex>
                                                <v-flex xs4 class="info-value text-xs-right">{{ record.mostTechnicallyAcceptableWeight }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                        <v-flex xs12>
                                            <v-layout row wrap>
                                                <v-flex xs8 class="info-text">{{ resx('mostTechnicallyAcceptableWeight') }}</v-flex>
                                                <v-flex xs4 class="info-value text-xs-right">{{ record.mostTechnicallyAcceptableWeight }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                </v-expansion-panel-content>
                            </v-expansion-panel>
                        </v-flex>
                    </v-layout>
                </v-container>
            </v-flex>
            <v-flex xs12 md6 class="right-side">
                <v-container  grid-list-xs pa-0>
                    <v-layout column fill-height>
                        <v-flex xs12 >
                            <v-layout row wrap class="item-header">
                                <v-flex xs12 md6><h1>{{ record.name }}</h1></v-flex>
                                <v-flex xs12 md6>
                                    <v-layout row wrap class="header-info">
                                        <v-flex xs4>{{ resx('buildDate') }} {{ record.dateOfFirstRegistration | moment('YYYY') }}</v-flex>
                                        <v-flex xs4>{{ record.fuel }}</v-flex>
                                        <v-flex xs4>{{ record.state }}</v-flex>
                                    </v-layout>
                                </v-flex>
                            </v-layout>
                            <v-layout row wrap class="header-info2">
                                <v-flex xs12 md6 class="info-text">{{ resx('toTheEndOfAuction') }}</v-flex>
                                <v-flex xs12 md6 class="info-text text-xs-right">{{ resx('actualPrice') }} </v-flex>
                            </v-layout>
                            <v-layout row wrap class="header-info2">
                                <v-flex xs12 md6 class="info2">
                                    <countdown-component
                                        :id="recordIdToString(record)"
                                        :date="dateToString(record.validTo)"
                                        :startDate="dateToString(record.validFrom)" />
                                </v-flex>
                                <v-flex xs12 md6 class="text-xs-right info2">
                                    <price-component :price="record.currentPrice" />
                                </v-flex>
                            </v-layout>
                            <v-layout row wrap class="info3">
                                <v-flex xs12 class="text-xs-center">
                                    <bid-component :bid="minimumBid" v-if="currentUser.isFeePayed && canBid(record.validFrom)" />
                                </v-flex>
                            </v-layout>
                            <v-expansion-panel expand>
                                <v-expansion-panel-content :value="expander">
                                    <div slot="header">
                                        <h3>{{ resx('carInformation') }}</h3>
                                    </div>
                                    <v-layout row wrap>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('doors') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.doors}}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('mileAge') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.mileage }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                    <v-layout row wrap>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('power') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.power }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('color') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.color }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                    <v-layout row wrap>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('transmission') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.transmission }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('numberOfSeets') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.numberOfSeets }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                    <v-layout row wrap>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('axle') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.axle }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('euroNorm') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.euroNorm }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                    <v-layout row wrap>
                                       <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('technicalViewOfTheVehicle') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.technicalViewOfTheVehicle | moment('DD.MM.YYYY') }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                        <v-flex xs12 md6>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('vehicleVinNumber') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.vin }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                    <v-layout row wrap>
                                        <v-flex xs12>
                                            <v-layout row wrap>
                                                <v-flex xs6 class="info-text">{{ resx('auditControlIsProvidedBy') }}</v-flex>
                                                <v-flex xs6 class="info-value">{{ record.registrationCheck  }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-layout>
                                </v-expansion-panel-content>
                            </v-expansion-panel>
                            <v-expansion-panel expand>
                                <v-expansion-panel-content :value="expander">
                                    <div slot="header">
                                        <h3>{{ resx('equipment') }}</h3>
                                    </div>
                                    <v-layout row wrap>
                                        <v-flex xs12 class="info-value text-xs-left extra-padding">
                                            {{ record.equipment }}
                                        </v-flex>
                                    </v-layout>
                                </v-expansion-panel-content>
                            </v-expansion-panel>
                            <v-expansion-panel expand>
                                <v-expansion-panel-content :value="expander">
                                    <div slot="header">
                                        <h3>{{ resx('defects') }}</h3>
                                    </div>
                                    <v-layout row wrap>
                                        <v-flex xs12 class="info-value text-xs-left extra-padding">
                                            {{ record.defects }}
                                        </v-flex>
                                    </v-layout>
                                </v-expansion-panel-content>
                            </v-expansion-panel>
                            <v-expansion-panel expand>
                                <v-expansion-panel-content :value="expander">
                                    <div slot="header">
                                        <h3>{{ resx('moreDescription') }}</h3>
                                    </div>
                                    <v-layout row wrap>
                                        <v-flex xs12 class="info-value text-xs-left extra-padding">
                                            {{ record.moreDescription }}
                                        </v-flex>
                                    </v-layout>
                                </v-expansion-panel-content>
                            </v-expansion-panel>
                        </v-flex>
                    </v-layout>
                </v-container>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import { Getter, Action, namespace } from 'vuex-class';

import BaseComponent from './BaseComponent.vue';
import { PriceComponent, BidComponent, CountdownComponent } from '@/components';
import {
    Record,
    Bid,
    User,
} from '@/model';
import { FileSimpleDto, AuthUser, RecordTableDto } from '@/poco';

const RecordGetter = namespace('record', Getter);
const AuthGetter = namespace('auth', Getter);
const RecordAction = namespace('record', Action);

@Component({
    components: {
        PriceComponent,
        BidComponent,
        CountdownComponent,
    },
})
export default class AuctionDetalComponent extends BaseComponent {
    @RecordGetter('getCurrent') private record: Record;
    @RecordAction('getDetail') private detail: any;
    @AuthGetter('getCurrentLoggedUser') private currentUser: AuthUser;

    private expander: boolean[] = [true, true, true, true, true, true];
    private expander1: boolean[] = [true];

    private mounted() {
        if (this.record === undefined) {
            this.detail(this.$route.query.id);
        }
    }

    private recordIdToString(record: RecordTableDto): string {
        return record.id.toString();
    }

    private filePath(file: FileSimpleDto): string {
        return `${this.settings.apiUrl.replace('/api', '')}/${file.path}/${file.recordId}/images/${file.name}`;
    }

    private sellerInfo(user: User): string {
        return `${user.customer.companyName}`;
    }

    private dateToString(date: Date): string {
        return date.toString();
    }

    private canBid(validFrom: Date): boolean {
        return new Date(validFrom) <= new Date();
    }

    get minimumBid(): number {
        return this.record.currentPrice + this.record.minimumBid;
    }
}

</script>

<style>

.auction-detail .header-info2 {
    background-color: black !important;
    max-height: 100px !important;
    color: white !important;
}

.auction-detail .info3 {
    background-color: #ededed !important;
    border-bottom-left-radius: 5px !important;
    border-bottom-right-radius: 5px !important;
    margin: 0 auto !important;
}

.auction-detail .bid-component {
    padding-top: 20px !important;
    max-width: 80% !important;
    margin: auto !important;
    position: relative !important;
}

.auction-detail .header-info2 .info2 {
  font-size: 29px !important;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  text-align: left;
  padding-right: 15px !important;
  padding-left: 15px !important;
}

.auction-detail .item-header {
    padding-top: 30px !important;
}

.auction-detail .header-info .flex {
  line-height: 6 !important;
  text-align: center !important;
  font-size: 12px;
  font-weight: normal;
  font-style: normal;
  font-stretch: normal;
  line-height: normal;
  letter-spacing: 0.9px;
  text-align: left;
  color: #929292;
}

.auction-detail h1 {
  font-size: 40px !important;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  line-height: 1.33;
  letter-spacing: 0px;
  text-align: left;
  color: #000000;
}

.auction-detail .left-side {
    padding-left: 10px !important;
    padding-right: 10px !important;
}

.auction-detail .right-side {
    padding-left: 10px !important;
    padding-right: 10px !important;
}

.auction-detail .info-text {
  font-size: 10px !important;
  font-weight: bold;
  font-style: normal;
  font-stretch: normal;
  line-height: 3;
  letter-spacing: 0.8px;
  text-align: left;
  color: #929292;
  padding-left: 15px !important;
  text-transform: uppercase;
  padding-right: 15px !important;
}

.auction-detail {
    font-family: Roboto !important;
}

.auction-detail .info-value {
  font-size: 13px !important;
  font-weight: bold;
  font-style: normal;
  font-stretch: normal;
  line-height: 2;
  letter-spacing: 0.8px;
  text-align: right;
  padding-right: 15px !important;
  color: #000000;
}

.auction-detail .extra-padding {
    padding-left: 15px !important;
}

.auction-detail .v-carousel {
    --webkit-box-shadow: 0 0px 0px 0px rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0) !important;
    box-shadow: 0 0px 0px 0px rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0) !important;
    max-width: 600px;
    max-height: 430px;
    border-radius: 5px !important;
    border: 1px solid #e6e6e6 !important;
}

.auction-detail .v-expansion-panel {
    border-radius: 5px !important;
    margin-top: 25px !important;
    --webkit-box-shadow: 0 0px 0px 0px rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0) !important;
    box-shadow: 0 0px 0px 0px rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0), 0 0px 0px 0 rgba(0,0,0,0) !important;
    border: 1px solid #e6e6e6 !important;
}

.auction-detail .v-expansion-panel__header {
    background-color: #ededed !important;
}

.auction-detail .v-expansion-panel__container {
    border: 1px solid #e6e6e6 !important;
}

.auction-detail .v-expansion-panel__header h3 {
    font-size: 15px !important;
    font-weight: bold !important;
    font-style: normal;
    font-stretch: normal;
    line-height: 3.87;
    letter-spacing: 1.2px;
    text-align: left;
    color: #000000;
    text-transform: uppercase;
}

.auction-detail .v-expansion-panel__body {
    background-color: #ffffff !important;
}

</style>