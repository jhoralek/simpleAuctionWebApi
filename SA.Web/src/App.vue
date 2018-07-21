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
        <v-snackbar
              color="red lighten-1"
              v-model="error.error"
              :bottom="true"
              :multi-line="true"
              :right="true"
              :timeout="6000"
              :vertical="true">
              {{ resx(error.message) }}
              <v-btn
                  color="white"
                  flat
                  @click="initError">
                  {{ resx('close') }}
              </v-btn>
          </v-snackbar>
      </v-content>
    </v-app>
  </div>
</template>

<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { State, Action, Getter, namespace } from 'vuex-class';

import {
  LoginFormComponent,
  LanguageComponent,
} from '@/components';

import {
  AuthState,
  ProfileState,
  SettingsState,
  ErrorState,
} from '@/store/types';

import { UserShortInfo } from '@/poco';

const SettingsGetter = namespace('settings', Getter);
const AuthGetter = namespace('auth', Getter);
const AuthAction = namespace('auth', Action);
const ProfileAction = namespace('profile', Action);
const SettingsAction = namespace('settings', Action);
const ErrorAction = namespace('error', Action);

@Component({
  components: {
    LoginFormComponent,
    LanguageComponent,
  },
})
export default class App extends Vue {
  // define states in app root
  @State('error') public error: ErrorState;
  @State('auth') public auth: AuthState;
  @State('profile') public profile: ProfileState;
  @State('settings') public settings: SettingsState;

  @SettingsGetter('getTranslate') public resx: string;

  @AuthAction('initialState') public initAuth: any;
  @ProfileAction('loadByToken') public loadByToken: any;
  @ProfileAction('initialState')  public initProfile: any;
  @SettingsAction('initialState') public initSettings: any;
  @SettingsAction('changeLanguage') public setLang: any;
  @ErrorAction('initialState') public initError: any;

  /**
   * When app is mounted, then initialize stores
   * and restore auth when is available
   */
  public mounted() {
    this.initError().then((response) => {
      this.initSettings().then((settings) => {
        this.initProfile().then((x) => {
          if (this.auth.isAuthenticated) {
              this.setLang(this.profile.user.language);
          } else {
            this.initAuth();
          }
        });
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