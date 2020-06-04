<template>
    <div class="gdpr">
        <v-layout row wrap>
            <v-flex xs12 md6 class="logo-container">
                <div class="rectangle"></div>
                <img :src="logo" class="home-page-logo" />
            </v-flex>
            <v-flex xs12 md6 class="registration-container">
                <h2 class="header">{{ resx('gdpr') }}</h2>
                <gdpr-form-component />
            </v-flex>
      </v-layout>
    </div>
</template>

<script lang="ts">

import Component from 'vue-class-component';
import { State} from 'vuex-class';

import { SettingsState } from './../store/types';
import { GdprFormComponent } from './../components';

import BaseView from './BaseView.vue';

@Component({
    components: {
        GdprFormComponent,
    },
})
export default class Gdpr extends BaseView {
    @State('settings')
    private settings: SettingsState;

    get logo(): string {
        return `${this.settings.apiUrl.replace('/api', '')}/img/home_cars_jera_trading.png`;
    }
}

</script>

<style>

.logo-container {
  position: relative;
}

.home-page-logo {
  width: 90%;
  max-width: 706px;
  top: 0px;
  left: 0px;
  position: absolute;
}

.rectangle {
  max-width: 404px;
  height: 100%;
  border-bottom-right-radius: 59px;
  background-color: #000000;
  z-index: 1;
}

h2.header {
 font-family: Roboto;
 font-size: 35px;
 font-weight: 500;
 font-style: normal;
 font-stretch: normal;
 letter-spacing: 0px;
 text-align: left;
 color: #000000;
 padding-bottom: 20px !important;
}

.registration-container {
  padding-top: 80px !important;
  padding-bottom: 50px !important;
  max-width: 700px !important;
}

</style>