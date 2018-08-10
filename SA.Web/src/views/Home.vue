<template>
  <div class="homePage">
    <v-container grid-list-xs pa-2>
      <v-layout row wrap>
        <v-flex xs12>
          <h1 class="display-1 primary--text">{{ resx('home') }}</h1>
        </v-flex>
      </v-layout>
      <v-layout row wrap>
        <v-flex xs12 sm12 md6>
          Tady bude obrázek
        </v-flex>
        <v-flex xs12 sm12 md6>
          <registration-component v-if="showRegistrationForm" />
          <v-btn color="success" v-else @click.native="showRegistrationForm = true">{{ resx('registration') }}</v-btn>
        </v-flex>
      </V-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';
import { RegistrationComponent } from '@/components';
import { Action, namespace } from 'vuex-class';

const ProfileAction = namespace('profile', Action);

@Component({
  components: {
    RegistrationComponent,
  },
})
export default class Home extends BaseView {
  @ProfileAction('initialState') private init: any;

  private showRegistrationForm: boolean = false;
  private mounted() {
    this.init();
  }
}

</script>
