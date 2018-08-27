<template>
  <div class="results">
    <v-layout row wrap>
      <v-flex xs12 md6 class="logo-container">
        <div class="rectangle">
        </div>
        <img :src="logo" class="home-page-logo" />
      </v-flex>
      <v-flex xs12 md6 class="validation-message">
          <v-container fluid>
              <v-layout row wrap v-if="validationExpired">
                  <v-flex xs12 class="text-xs-center">
                      <h1>{{ resx('accountActivation') }}</h1>
                  </v-flex>
                  <v-flex xs12 class="text-xs-center">
                      <p><strong>{{ exspired }}</strong></p>
                  </v-flex>
                  <v-flex xs12 class="text-xs-center">
                        <v-icon size="100px" color="red darken-2">highlight_off</v-icon>
                  </v-flex>
              </v-layout>
              <v-layout row wrap v-if="validationSuccessfully">
                  <v-flex xs12 class="text-xs-center">
                      <h1>{{ resx('accountActivation') }}</h1>
                  </v-flex>
                  <v-flex xs12 class="text-xs-center">
                      <p><strong>{{ successfullyCompleted }}</strong></p>
                  </v-flex>
                  <v-flex xs12 class="text-xs-center">
                        <v-icon size="100px" color="green darken-2">check_circle_outline</v-icon>
                  </v-flex>
              </v-layout>
              <v-layout row wrap v-if="passwordResetFailed">
                  <v-flex xs12 class="text-xs-center">
                      <h1>{{ resx('passwordReset') }}</h1>
                  </v-flex>
                  <v-flex xs12 class="text-xs-center">
                      <p><strong>{{ resx('passwordResetFailed') }}</strong></p>
                  </v-flex>
                  <v-flex xs12 class="text-xs-center">
                        <v-icon size="100px" color="red darken-2">error_outline</v-icon>
                  </v-flex>
              </v-layout>
              <v-layout row wrap v-if="successfullyRegistered">
                  <v-flex xs12 class="text-xs-center">
                      <h1>{{ resx('registration') }}</h1>
                  </v-flex>
                  <v-flex xs12 class="text-xs-center">
                      <p><strong>{{ resx('successfullyCompleted') }}</strong></p>
                  </v-flex>
                  <v-flex xs12 class="text-xs-center">
                        <v-icon size="100px" color="green darken-2">check_circle_outline</v-icon>
                  </v-flex>
              </v-layout>
              <v-layout row wrap v-if="passwordResetSuccessfully">
                  <v-flex xs12 class="text-xs-center">
                      <h1>{{ resx('registration') }}</h1>
                  </v-flex>
                  <v-flex xs12 class="text-xs-center">
                      <p><strong>{{ resx('successfullyCompleted') }}</strong></p>
                  </v-flex>
                  <v-flex xs12 class="text-xs-center">
                        <v-icon size="100px" color="green darken-2">check_circle_outline</v-icon>
                  </v-flex>
              </v-layout>
          </v-container>
      </v-flex>
    </v-layout>
  </div>
</template>

<script lang="ts">

import { State } from 'vuex-class';
import Component from 'vue-class-component';

import BaseView from '../BaseView.vue';
import { SettingsState } from '@/store/types';

@Component({})
export default class Results extends BaseView {
  @State('settings') private settings: SettingsState;

  private validationExpired: boolean = false;
  private validationSuccessfully: boolean = false;
  private passwordResetFailed: boolean = false;
  private successfullyRegistered: boolean = false;
  private passwordResetSuccessfully: boolean = false;

  private mounted() {
      switch (this.$route.name) {
        case 'validationExpired':
            this.validationExpired = true;
            break;
        case 'validationSucessfully':
            this.validationSuccessfully = true;
            break;
        case 'passwordResetFailed':
            this.passwordResetFailed = true;
            break;
        case 'passwordResetSuccessfully':
            this.passwordResetSuccessfully = true;
            break;
        case 'successfullyRegistered':
            this.successfullyRegistered = true;
            break;
      }
  }

  get logo(): string {
    return `${this.settings.apiUrl.replace('/api', '')}/img/home_cars_jera_trading.png`;
  }

  get exspired(): string {
      return this.settings.resource.expired.toLowerCase();
  }

  get successfullyCompleted(): string {
      return this.settings.resource.successfullyCompleted.toLowerCase();
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

.results h1 {
  font-family: Roboto;
  font-size: 35px !important;
  font-weight: normal;
  font-style: normal;
  font-stretch: normal;
  line-height: 1.15;
  letter-spacing: 0.3px;
  color: #1a1a2e;
  padding-bottom: 30px !important;
}

.results p {
  font-size: 16px;
  font-weight: normal;
  font-style: normal;
  font-stretch: normal;
  line-height: 2.06;
  letter-spacing: 0.5px;
  padding-bottom: 30px !important;
  padding-top: 30px !important;
}

.results .validation-message {
    padding-top: 80px !important;
    padding-bottom: 80px !important;
}

</style>