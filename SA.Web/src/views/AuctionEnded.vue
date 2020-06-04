<template>
  <div class="auction-ended">
    <v-container grid-list-xs pa-0>
      <v-layout row wrap>
        <v-flex xs12>
          <auction-ended-component />
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import Component from 'vue-class-component';

import BaseView from './BaseView.vue';
import { AuctionEndedComponent } from './../components';

@Component({
  components: {
    AuctionEndedComponent,
  },
})
export default class AuctionEnded extends BaseView {
}

</script>
