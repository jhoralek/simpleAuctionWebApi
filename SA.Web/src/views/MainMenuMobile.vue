<template>
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
            <v-card v-if="auth.isAuthenticated">
            <v-flex justify-start offset-xs1>
                <router-link
                class="nav-item btn btn--flat btn--router"
                style="justify-content: left"
                to="/auctionsAdministration">{{ resx('auctionsAdministration') }}
                </router-link>
            </v-flex>
            </v-card>
            <v-card v-if="auth.isAuthenticated">
            <v-flex justify-start offset-xs1>
                <router-link
                class="nav-item btn btn--flat btn--router"
                style="justify-content: left"
                to="/gdprAdministration">{{ resx('gdprAdministration') }}
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
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';
import { State } from 'vuex-class';
import { SettingsState, AuthState } from '@/store/types';

import {
  LoginFormComponent,
} from '@/components';

@Component({
    components: {
        LoginFormComponent,
    },
})
export default class MainMenuDesktop extends BaseView {
    @State('settings') private settings: SettingsState;
    @State('auth') private auth: AuthState;
}

</script>
