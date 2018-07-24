<template>
  <div class="auction-detail">
      <AuctionDetailComponent />
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
