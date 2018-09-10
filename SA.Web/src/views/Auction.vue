<template>
  <div class="auction">
    <v-container grid-list-xs pa-0>
      <v-layout row wrap>
        <v-flex xs12>
          <auction-grid-component />
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component } from 'vue-property-decorator';

import BaseView from '@/views/BaseView.vue';
import { AuctionGridComponent } from '@/components';

@Component({
  components: {
    AuctionGridComponent,
  },
})
export default class Auction extends BaseView {
}

</script>
