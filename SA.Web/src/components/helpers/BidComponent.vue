<template>
   <v-container>
       <v-layout row>
           <v-flex xs10>
                <v-text-field
                    type="number"
                    v-model="localBid"
                    v-validate="{ required: true, numeric: true, min_value: this.record.minimumBid }"
                    :error-messages="errors.collect('bid')"
                    data-vv-name="bid"
                    :height="10"
                    solo />
            </v-flex>
            <v-flex xs2>
                <v-btn
                    :loading="loading"
                    :disabled="disable"
                    color="error"
                    @click.native="submitBid"
                    >
                    {{ resx('bid') }}
                </v-btn>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script lang="ts">

import { Component, Prop, Watch } from 'vue-property-decorator';
import { Action, Getter, namespace } from 'vuex-class';

import BaseComponent from '../BaseComponent.vue';
import { Record, Bid } from '@/model';
import { AuthUser } from '@/poco';

const RecordAction = namespace('record', Action);
const RecordGetter = namespace('record', Getter);
const AuthGetter = namespace('auth', Getter);

@Component({})
export default class BidComponent extends BaseComponent {
    @Prop({default: 0}) private bid: number;
    @RecordAction('addBid') private addBid: any;
    @RecordGetter('getCurrent') private record: Record;
    @AuthGetter('getCurrentLoggedUser') private user: AuthUser;

    private loading: boolean = false;
    private localBid: number = 0;
    private disable: boolean = false;

    private mounted() {
        this.localBid = this.bid;
    }

    @Watch('localBid') private watchBid(newBid: string) {

        if (!/^[0-9]+$/.test(newBid)) {
            this.disable = true;
        } else {
            if (parseInt(newBid, 0) < this.record.minimumBid) {
                this.disable = true;
            } else {
                this.disable = false;
            }
            this.localBid = parseInt(newBid, 0);
        }
    }

    private submitBid() {
        this.loading = true;
        this.disable = true;
        const bidPrice = this.localBid + this.record.currentPrice;
        this.addBid({
                    recordId: this.record.id,
                    price: bidPrice,
                    created: new Date(),
                    userId: this.user.userId,
                } as Bid)
            .then((response) => {
                this.loading = false;
                this.disable = false;
                this.localBid = this.record.minimumBid;
            });
    }
}

</script>