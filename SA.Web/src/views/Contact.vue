<template>
    <div class="contact">
        <v-layout row wrap>
            <v-flex xs12 md6 class="logo-container">
                <div class="rectangle">
                </div>
                <img :src="logo" class="home-page-logo" />
            </v-flex>
            <v-flex xs12 md6>
                <h1>{{ resx('contact') }}</h1>
                <v-container grid-list-xs>
                    <v-layout row wrap>
                        <v-flex xs12>
                            <div class="company-name">
                                <h2>JERA</h2><h4>Trading s.r.o.</h4>
                            </div>
                        </v-flex>
                    </v-layout>
                    <v-layout row wrap>
                        <v-flex xs12>
                            <h5>Tyršova 842, 357 35 Chodov</h5>
                        </v-flex>
                    </v-layout>
                    <v-layout row wrap>
                        <v-flex xs12>
                            <h5>{{resx('companyNumber') }}: 07310099</h5>
                        </v-flex>
                    </v-layout>
                    <v-layout row wrap>
                        <v-flex xs12>
                            <h5>{{resx('phoneNumber') }}: +420 723613713</h5>
                        </v-flex>
                    </v-layout>
                    <v-layout row wrap>
                        <v-flex xs12>
                            <h5>{{resx('email') }}: info@jera-trading.cz</h5>
                        </v-flex>
                    </v-layout>
                    <v-layout row wrap>
                        <v-flex xs12>
                            <h5>{{ resx('bankConnection') }} Fio banka, a.s.: {{ resx('accountNumber') }}: 2801475849/2010</h5>
                        </v-flex>
                    </v-layout>
                    <v-layout row wrap>
                        <v-flex xs12>
                            <h5>{{ filedBy }}</h5>
                        </v-flex>
                    </v-layout>
                </v-container>
            </v-flex>
        </v-layout>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';
import { State } from 'vuex-class';

import { SettingsState } from './../store/types';

@Component({})
export default class Contact extends BaseView {
  @State('settings')
  private settings: SettingsState;

  get filedBy(): string {
      return this.settings.resource.filedByTheRegionalCurtInPilsen.replace('{0}', 'C 36595');
  }

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

.contact h1 {
  font-family: Roboto;
  font-size: 35px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  text-align: left;
  color: #000000;
  padding-bottom: 30px;
  padding-top: 50px;
}

.registration-container {
  padding-top: 80px !important;
  padding-bottom: 50px !important;
  max-width: 700px !important;
}

.contact h2 {
  font-family: Roboto;
  font-size: 30px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  text-align: left;
  color: #000000;
  float: left;
  position: absolute;
  bottom: 0px;
}

.contact h4 {
    font-family: Roboto;
    float: left;
    font-size: 20px;
    font-style: normal;
    font-stretch: normal;
    position: absolute;
    bottom: 7px;
    left: 80px;
}

.contact h5 {
    font-family: Roboto;
    float: left;
    font-size: 18px;
    font-weight: 200;
    font-style: normal;
    font-stretch: normal;
    padding-bottom: 10px;
}

.company-name {
    position: relative;
    padding-bottom: 30px;
}


</style>
