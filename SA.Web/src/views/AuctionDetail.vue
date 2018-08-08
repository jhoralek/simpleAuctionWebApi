<template>
  <div class="auction-detail">
      <auction-detail-component />
  </div>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import BaseView from '@/views/BaseView.vue';
import { AuctionDetailComponent } from '@/components';

@Component({
    components: {
        AuctionDetailComponent,
    },
})
export default class AuctionDetail extends BaseView {
}

</script>
