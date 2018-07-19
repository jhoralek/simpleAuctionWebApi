<template>
  <div id="app">
    <v-app v-if="settings.language">
      <v-toolbar>
        <v-toolbar-title>{{ resx('auctionHall') }}</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-toolbar-items class="hidden-sm-and-down">
          <v-btn flat to="/">{{ resx('home') }}</v-btn>
          <v-btn flat to="/news">{{ resx('news') }}</v-btn>
          <v-btn flat to="/forDealers">{{ resx('forDealers') }}</v-btn>
          <v-btn flat to="/auctions">{{ resx('auctions') }}</v-btn>
          <v-btn flat to="/about">{{ resx('about') }}</v-btn>
          <v-btn flat to="/faq">{{ resx('faq') }}</v-btn>
          <v-btn flat to="/contact">{{ resx('contact') }}</v-btn>
          <v-menu offset-y>
            <v-btn slot="activator" flat>{{ resx('terms') }}</v-btn>
            <v-list>
              <v-list-tile to="/termsAndConditions">
                <v-list-tile-title>{{ resx('termsAndConditions') }}</v-list-tile-title>
              </v-list-tile>
              <v-list-tile to="/protectionPersonalData">
                <v-list-tile-title>{{ resx('protectionPersonalData') }}</v-list-tile-title>
              </v-list-tile>
            </v-list>
          </v-menu>
          <v-btn flat v-if="auth.isAuthenticated" to="/customer">{{ resx('customerDetail') }}</v-btn>
          <div class="toolbar__items menu__activator">
            <LoginFormComponent />
          </div>
        </v-toolbar-items>
        <LanguageComponent />
      </v-toolbar>
      <v-content>
        <router-view />
        <v-footer height="auto" class="grey darken-3">
          <v-layout row wrap justify-center>
            <v-btn flat color="white">{{ resx('link') }}</v-btn>
            <v-btn flat color="white">{{ resx('link') }}</v-btn>
            <v-btn flat color="white">{{ resx('link') }}</v-btn>
            <v-btn flat color="white">{{ resx('link') }}</v-btn>
            <v-btn flat color="white">{{ resx('link') }}</v-btn>
            <v-btn flat color="white">{{ resx('link') }}</v-btn>
            <v-flex xs12 py-3 text-xs-center white--text>
              &copy; {{ new Date().getFullYear() }} - <strong>{{ resx('auctionHall') }}</strong>
            </v-flex>
          </v-layout>
        </v-footer>
      </v-content>
    </v-app>
  </div>
</template>

<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { State, Action, Getter } from 'vuex-class';

import {
  LoginFormComponent,
  LanguageComponent,
} from '@/components';

import {
  AuthState,
  ProfileState,
  SettingsState,
} from '@/store/types';

const namespaceAuth: string = 'auth';
const namespaceProfile: string = 'profile';
const namespaceSettings: string = 'settings';

@Component({
  components: {
    LoginFormComponent,
    LanguageComponent,
  },
})
export default class App extends Vue {
  // define states in app root
  @State('auth') public auth: AuthState;
  @State('profile') public profile: ProfileState;
  @State('settings') public settings: SettingsState;

  @Getter('getTranslate', { namespace: namespaceSettings }) public resx: string;

  @Action('initialState', { namespace: namespaceAuth }) public initAuth: any;
  @Action('initialState', { namespace: namespaceProfile }) public initProfile: any;
  @Action('initialState', { namespace: namespaceSettings}) public initSettings: any;
  @Action('loadByToken', { namespace: namespaceProfile }) public loadByToken: any;
  @Action('changeLanguage', { namespace: namespaceSettings }) public setLang: any;

  /**
   * When app is mounted, then initialize stores
   * and restore auth when is available
   */
  public mounted() {
    this.initSettings().then((settings) => {
      this.initProfile().then((x) => {
        if (this.auth.isAuthenticated) {
          this.loadByToken(this.auth.token).then((user) => {
            this.setLang(user.language);
          });
        } else {
          this.initAuth();
        }
      });
    });
  }
}
</script>

<style>
.login-form-button:before {
  height: 100%;
}
</style>