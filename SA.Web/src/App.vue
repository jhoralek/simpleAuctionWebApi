<template>
  <div id="app">
    <v-progress-linear v-if="isLoading" :indeterminate="isLoading"></v-progress-linear>
    <v-app v-if="settings.language">
      <nav>
        <v-toolbar class="hidden-sm-and-down">
          <v-toolbar-title>
            <router-link class="nav-item" to="/">{{ resx('auctionHall') }}</router-link>
          </v-toolbar-title>
          <v-spacer></v-spacer>
          <v-toolbar-items>
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
            <v-menu offset-y v-if="auth.isAuthenticated && auth.isDealer">
              <v-btn slot="activator" flat>{{ resx('administration') }}</v-btn>
              <v-list>
                <v-list-tile to="/customer">
                  <v-list-tile-title>{{ resx('customerDetail') }}</v-list-tile-title>
                </v-list-tile>
                <v-list-tile to="/usersAdministration">
                  <v-list-tile-title>{{ resx('usersAdministration')}}</v-list-tile-title>
                </v-list-tile>
              </v-list>
            </v-menu>
            <v-btn flat v-if="auth.isAuthenticated && !auth.isDealer" to="/customer">{{ resx('customerDetail') }}</v-btn>
            <div class="toolbar__items menu__activator">
              <login-form-component />
            </div>
          </v-toolbar-items>
          <language-component />
        </v-toolbar>
        <div class="hidden-md-and-up">
          <v-expansion-panel>
            <v-expansion-panel-content>
              <div slot="header">
                <router-link
                  class="nav-item btn btn--flat btn--router"
                  to="/">{{ resx('auctionHall') }}
                </router-link>
              </div>
              <v-card>
                <v-flex justify-start offset-xs1>
                  <router-link
                    class="nav-item btn btn--flat btn--router"
                    style="justify-content: left"
                    to="/news">{{ resx('news') }}
                  </router-link>
                </v-flex>
              </v-card>
              <v-card>
                <v-flex justify-start offset-xs1>
                  <router-link
                    class="nav-item btn btn--flat btn--router"
                    style="justify-content: left"
                    to="/forDealers">{{ resx('forDealers') }}
                  </router-link>
                </v-flex>
              </v-card>
              <v-card>
                <v-flex justify-start offset-xs1>
                  <v-layout row>
                    <router-link
                      class="nav-item btn btn--flat btn--router"
                      style="justify-content: left"
                      to="/auctions">{{ resx('auctions') }}
                    </router-link>
                  </v-layout>
                </v-flex>
              </v-card>
              <v-card>
                <v-flex justify-start offset-xs1>
                  <router-link
                    class="nav-item btn btn--flat btn--router"
                    style="justify-content: left"
                    to="/about">{{ resx('about') }}
                  </router-link>
                </v-flex>
              </v-card>
              <v-card>
                <v-flex justify-start offset-xs1>
                  <router-link
                    class="nav-item btn btn--flat text-xs-left"
                    style="justify-content: left"
                    to="/faq">{{ resx('faq') }}
                  </router-link>
                </v-flex>
              </v-card>
              <v-card>
                <v-flex justify-start offset-xs1>
                  <router-link
                    class="nav-item btn btn--flat text-xs-left"
                    style="justify-content: left"
                    to="/contact">{{ resx('contact') }}
                  </router-link>
                </v-flex>
              </v-card>
              <v-card v-if="auth.isAuthenticated && auth.isDealer">
                <v-flex justify-start offset-xs1>
                  <router-link
                    class="nav-item btn btn--flat btn--router"
                    style="justify-content: left"
                    to="/usersAdministration">{{ resx('usersAdministration') }}
                  </router-link>
                </v-flex>
              </v-card>
              <v-card v-if="auth.isAuthenticated">
                <v-flex justify-start offset-xs1>
                  <router-link
                    class="nav-item btn btn--flat btn--router"
                    style="justify-content: left"
                    to="/customer">{{ resx('customerDetail') }}
                  </router-link>
                </v-flex>
              </v-card>
              <v-card>
                <v-flex justify-start offset-sm1>
                    <login-form-component />
                </v-flex>
              </v-card>
            </v-expansion-panel-content>
          </v-expansion-panel>
        </div>
      </nav>
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
        <message-component />
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
  MessageComponent,
} from '@/components';

import {
  AuthState,
  ProfileState,
  SettingsState,
  MessageState,
} from '@/store/types';

import { UserShortInfo } from '@/poco';

const SettingsGetter = namespace('settings', Getter);
const AuthGetter = namespace('auth', Getter);
const AuthAction = namespace('auth', Action);
const ProfileAction = namespace('profile', Action);
const SettingsAction = namespace('settings', Action);
const MessageAction = namespace('message', Action);

@Component({
  components: {
    LoginFormComponent,
    LanguageComponent,
    MessageComponent,
  },
})
export default class App extends Vue {
  // define states in app root
  @State('message') public message: MessageState;
  @State('auth') public auth: AuthState;
  @State('profile') public profile: ProfileState;
  @State('settings') public settings: SettingsState;

  @SettingsGetter('getTranslate') public resx: string;

  @AuthAction('initialState') public initAuth: any;
  @ProfileAction('loadByToken') public loadByToken: any;
  @ProfileAction('initialState')  public initProfile: any;
  @SettingsAction('initialState') public initSettings: any;
  @SettingsAction('changeLanguage') public setLang: any;
  @MessageAction('initialState') public initMessage: any;

  private isLoading: boolean = false;
  /**
   * When app is mounted, then initialize stores
   * and restore auth when is available
   */
  public mounted() {
    this.isLoading = true;
    this.initMessage().then((response) => {
      this.initSettings().then((settings) => {
        this.initProfile().then((x) => {
          if (this.auth.isAuthenticated) {
              this.setLang(this.profile.user.language);
          } else {
            this.initAuth();
          }
          this.isLoading = false;
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