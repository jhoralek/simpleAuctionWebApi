<template>
    <v-footer height="auto" class="white">
        <v-card class="flex" flat tile >
            <v-card-actions class="footer-colaboration justify-center">
                <div class="colaboration">
                    {{ resx('weColaborateWith') }}
                </div>
            </v-card-actions>

            <v-card-actions class="footer-colaboration">
                <v-layout row wrap class="text-xs-center">
                    <v-flex xs12 md4>
                        <a href="https://www.suas.cz/" target="blank">
                            <img :src="sokolovskaLogo" />
                        </a>
                    </v-flex>
                    <v-flex xs12 md4>
                        <a href="https://www.suas.cz/" target="blank">
                            <img :src="sokolovskaLogo" />
                        </a>
                    </v-flex>
                    <v-flex xs12 md4>
                        <a href="https://www.suas.cz/" target="blank">
                            <img :src="sokolovskaLogo" />
                        </a>
                    </v-flex>
                </v-layout>
            </v-card-actions>
            <v-card-actions class="black">
                <v-layout row wrap class="footer-content">
                    <v-flex xs12 md6>
                        <v-container fluid>
                            <v-layout row wrap class="text-xs-center">
                                <v-flex xs6 md6>
                                    E: info@jera-trading.cz
                                </v-flex>
                                <v-flex xs6 md6>
                                    T: +420 723 613 713
                                </v-flex>
                            </v-layout>
                        </v-container>
                    </v-flex>
                    <v-flex xs12 md6>
                        <v-container fluid>
                            <v-layout row class="text-xs-center">
                                <v-flex xs12>
                                    &copy; {{ new Date().getFullYear() }} - <strong>{{ resx('auctionHall') }}</strong>
                                </v-flex>
                            </v-layout>
                        </v-container>
                    </v-flex>
                </v-layout>
            </v-card-actions>
        </v-card>
    </v-footer>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';
import { State } from 'vuex-class';
import { SettingsState } from '@/store/types';

@Component({})
export default class FooterView extends BaseView {
    @State('settings') private settings: SettingsState;

    get sokolovskaLogo(): string {
        return `${this.settings.apiUrl.replace('/api', '')}/img/sokolovska-logo.png`;
    }
}

</script>

<style>

.footer-content {
    color: white !important;
    background-color: black !important;
}

.footer-colaboration {
    color: black !important;
    background-color: #f8f8f8 !important;
    text-transform: uppercase !important;
    letter-spacing: 1.5px;
}

.footer-colaboration a img {
    width: 180px;
    height: 49px;
}

.colaboration {
    padding-top: 39px !important;
    padding-bottom: 50px !important;
}

</style>