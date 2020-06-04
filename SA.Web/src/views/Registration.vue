<template>
    <div class="registration">
        <v-layout row wrap>
      <v-flex xs12 md6 class="logo-container">
        <div class="rectangle">
        </div>
        <img :src="logo" class="home-page-logo" />
      </v-flex>
      <v-flex xs12 md6 class="registration-container">
        <h2 class="header">{{ resx('registration') }}</h2>
        <registration-component />
      </v-flex>
    </v-layout>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';
import { State} from 'vuex-class';

import { SettingsState } from './../store/types';
import { RegistrationComponent } from './../components';

@Component({
  components: {
    RegistrationComponent,
  },
})
export default class Registration extends BaseView {
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
  font-size: 46px;
  font-weight: normal;
  font-style: normal;
  font-stretch: normal;
  line-height: 1.15;
  letter-spacing: 0.3px;
  text-align: left;
  color: #1a1a2e;
}

.registration-container {
  padding-top: 80px !important;
  padding-bottom: 50px !important;
  max-width: 700px !important;
}

</style>