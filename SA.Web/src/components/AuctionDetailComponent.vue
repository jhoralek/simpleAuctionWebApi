<template>
    <v-container grid-list-xs v-if="record">
        <v-layout row wrap>
            <v-flex xs12 lg6>
                <v-container grid-list-xs>
                    <v-layout column fill-height>
                        <v-flex xs12 md12>
                            <v-carousel>
                                <v-carousel-item
                                    v-for="(item,i) in record.files"
                                    :key="i"
                                    :src="filePath(item)"
                                ></v-carousel-item>
                            </v-carousel>
                        </v-flex>
                        <v-flex xs12>
                            <v-container grid-list-xs>
                                <v-layout column fill-height>
                                    <v-flex xs12>
                                        <v-expansion-panel expand>
                                            <v-expansion-panel-content :value="expander1">
                                                <div slot="header">
                                                    <h3 class="headline">{{ resx('auctionDetailInformation') }}</h3>
                                                </div>
                                                <v-container class="grey lighten-3">
                                                    <v-layout row wrap>
                                                        <v-flex xs6>
                                                            <h1 class="display-3 font-weight-medium">{{ record.name }}</h1>
                                                        </v-flex>
                                                        <v-flex xs6>
                                                            <v-layout row justify-end align-center>
                                                                <h1 class=" red--text text--lighten-1 display-3 font-weight-bold">
                                                                    <PriceComponent :price="currentPrice(record)" />
                                                                </h1>
                                                            </v-layout>
                                                        </v-flex>
                                                    </v-layout>
                                                    <v-layout row wrap>
                                                        <v-flex xs6>{{ resx('startingPrice') }}</v-flex>
                                                        <v-flex xs6>
                                                            <v-layout row justify-end align-center>
                                                                <PriceComponent :price="record.startingPrice" />
                                                            </v-layout>
                                                        </v-flex>
                                                    </v-layout>
                                                    <v-layout row wrap>
                                                        <v-flex xs6>{{ resx('minimumBid') }}</v-flex>
                                                        <v-flex xs6>
                                                            <v-layout row justify-end align-center>
                                                                <PriceComponent :price="record.minimumBid" />
                                                            </v-layout>
                                                        </v-flex>
                                                    </v-layout>
                                                    <v-layout row wrap>
                                                        <v-flex xs6>{{ resx('numberOfBids') }}</v-flex>
                                                        <v-flex xs6>
                                                            {{ numberOfBids(record.bids) }}
                                                        </v-flex>
                                                    </v-layout>
                                                    <v-layout row wrap>
                                                        <v-flex xs6>{{ resx('beginningOfTheAuction') }}</v-flex>
                                                        <v-flex xs6>{{ record.validFrom | moment('DD.MM.YYYY HH:mm') }}</v-flex>
                                                    </v-layout>
                                                    <v-layout row wrap>
                                                        <v-flex xs6>{{ resx('endOfAuction') }}</v-flex>
                                                        <v-flex xs6>{{ record.validTo | moment('DD.MM.YYYY HH:mm') }}</v-flex>
                                                    </v-layout>
                                                    <v-layout row wrap>
                                                        <v-flex xs6>{{ resx('contactToAppointment') }}</v-flex>
                                                        <v-flex xs6>{{ record.contactToAppointment }}</v-flex>
                                                    </v-layout>
                                                    <v-layout row wrap>
                                                        <v-flex xs6>{{ resx('seller') }}</v-flex>
                                                        <v-flex xs6>{{ sellerInfo(record.customer) }}</v-flex>
                                                    </v-layout>
                                                </v-container>
                                            </v-expansion-panel-content>
                                        </v-expansion-panel>
                                    </v-flex>
                                </v-layout>
                            </v-container>
                        </v-flex>
                    </v-layout>
                </v-container>
            </v-flex>
            <v-flex xs12 lg6>
                <v-container grid-list-xs>
                    <v-layout column fill-height>
                        <v-flex xs12 >
                            <v-expansion-panel expand>
                                <v-expansion-panel-content :value="expander">
                                    <div slot="header">
                                        <h3 class="headline">{{ resx('carInformation') }}</h3>
                                    </div>
                                    <v-container class="grey lighten-3">
                                        <v-flex xs12 offset-xs1>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('dateOfFirstRegistration') }}</v-flex>
                                                <v-flex xs6>{{ record.dateOfFirstRegistration | moment('YYYY') }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('doors') }}</v-flex>
                                                <v-flex xs6>{{ record.doors }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('mileAge') }}</v-flex>
                                                <v-flex xs6>{{ record.mileage }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('power') }}</v-flex>
                                                <v-flex xs6>{{ record.power }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('fuel') }}</v-flex>
                                                <v-flex xs6>{{ record.fuel }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('color') }}</v-flex>
                                                <v-flex xs6>{{ record.colors }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('transmission') }}</v-flex>
                                                <v-flex xs6>{{ record.transmission }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('numberOfSeets') }}</v-flex>
                                                <v-flex xs6>{{ record.numberOfSeets }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('axle') }}</v-flex>
                                                <v-flex xs6>{{ record.axle }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('euroNorm') }}</v-flex>
                                                <v-flex xs6>{{ record.euroNorm }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('auditControlIsProvidedBy') }}</v-flex>
                                                <v-flex xs6>{{ record.registrationCheck }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('vehicleVinNumber') }}</v-flex>
                                                <v-flex xs6>{{ record.vin }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('technicalViewOfTheVehicle') }}</v-flex>
                                                <v-flex xs6>{{ record.stk | moment('DD.MM.YYYY') }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-container>
                                </v-expansion-panel-content>
                                <v-expansion-panel-content :value="expander">
                                    <div slot="header">
                                        <h3 class="headline">{{ resx('equipment') }}</h3>
                                    </div>
                                    <v-container class="grey lighten-3">
                                        <v-flex xs12 offset-xs1>
                                            <v-layout row wrap>
                                                <v-flex xs12>{{ record.equipment }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-container>
                                </v-expansion-panel-content>
                                <v-expansion-panel-content :value="expander">
                                    <div slot="header">
                                        <h3 class="headline">{{ resx('state') }}</h3>
                                    </div>
                                    <v-container class="grey lighten-3">
                                        <v-flex xs12 offset-xs1>
                                            <v-layout row wrap>
                                                <v-flex xs12>{{ record.state }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-container>
                                </v-expansion-panel-content>
                                <v-expansion-panel-content :value="expander">
                                    <div slot="header">
                                        <h3 class="headline">{{ resx('specification') }}</h3>
                                    </div>
                                    <v-container class="grey lighten-3">
                                        <v-flex xs12 offset-xs1>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('dimensions') }}</v-flex>
                                                <v-flex xs6>{{ record.dimensions }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('maximumWeight') }}</v-flex>
                                                <v-flex xs6>{{ record.maximumWeight }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('operationWeight') }}</v-flex>
                                                <v-flex xs6>{{ record.operationWeight }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('maximumWeightOfRide') }}</v-flex>
                                                <v-flex xs6>{{ record.maximumWeightOfRide }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('mostTechnicallyWeightOfRide') }}</v-flex>
                                                <v-flex xs6>{{ record.mostTechnicallyAcceptableWeight }}</v-flex>
                                            </v-layout>
                                            <v-layout row wrap>
                                                <v-flex xs6>{{ resx('mostTechnicallyAcceptableWeight') }}</v-flex>
                                                <v-flex xs6>{{ record.mostTechnicallyAcceptableWeight }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-container>
                                </v-expansion-panel-content>
                                <v-expansion-panel-content :value="expander">
                                    <div slot="header">
                                        <h3 class="headline">{{ resx('defects') }}</h3>
                                    </div>
                                    <v-container class="grey lighten-3">
                                        <v-flex xs12 offset-xs1>
                                            <v-layout row wrap>
                                                <v-flex xs12>{{ record.defects }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-container>
                                </v-expansion-panel-content>
                                <v-expansion-panel-content :value="expander">
                                    <div slot="header">
                                        <h3 class="headline">{{ resx('moreDescription') }}</h3>
                                    </div>
                                    <v-container class="grey lighten-3">
                                        <v-flex xs12 offset-xs1>
                                            <v-layout row wrap>
                                                <v-flex xs12>{{ record.moreDescription }}</v-flex>
                                            </v-layout>
                                        </v-flex>
                                    </v-container>
                                </v-expansion-panel-content>
                            </v-expansion-panel>
                        </v-flex>
                    </v-layout>
                </v-container>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<<script lang="ts">
import { Component, Prop } from 'vue-property-decorator';
import { Getter, namespace } from 'vuex-class';

import BaseComponent from './BaseComponent.vue';
import { PriceComponent } from '@/components';
import {
    Record,
    Bid,
    Customer,
} from '@/model';
import { FileShortDto } from '@/poco';

const RecordGetter = namespace('record', Getter);

@Component({
    components: {
        PriceComponent,
    },
})
export default class AuctionDetalComponent extends BaseComponent {
    @RecordGetter('getCurrent') public record: Record;

    private expander: boolean[] = [true, true, true, true, true, true];
    private expander1: boolean[] = [true];

    private filePath(file: FileShortDto): string {
        return `/${file.path}/${file.recordId}/images/${file.name}`;
    }

    private currentPrice(record: Record): number {
        return record.bids.length > 0
            ? Math.max.apply(Math, record.bids.map((o) => o.price))
            : record.startingPrice;
    }

    private numberOfBids(bids: Bid[]): number {
        return bids === undefined ? 0 : bids.length;
    }

    private sellerInfo(customer: Customer): string {
        return `${customer.companyName}`;
    }
}

</script>