<template>
  <div class="auction" v-if="all">
    <v-container fluid>
      <h1>{{ resx('auctions') }}</h1>
      <v-container fluid v-for="(rec, index) in recordsPerPage" :key="index">
        <RecordComponent :record="rec" :is-list-detail="true" />
      </v-container>
      <div class="text-xs-center" v-if="recordLength > 1">
        <v-pagination :length="recordLength" v-model="page" :total-visible="7"></v-pagination>
      </div>
    </v-container>
  </div>
</template>

<script lang="ts">

import Component from 'vue-class-component';
import { Action, Getter } from 'vuex-class';

import BaseView from '@/views/BaseView.vue';
import { Record } from '@/model';
import RecordComponent from '@/components/RecordComponent.vue';

const namespace: string = 'record';

@Component({
  components: {
    RecordComponent,
  },
})
export default class Auction extends BaseView {
    @Getter('getRecords', { namespace }) public all: Record[];
    @Action('loadAllActive', { namespace }) public loadAll: any;
    @Action('initialState', { namespace }) public init: any;

    public page: number = 1;
    private itemPerPage: number = 2;

    public mounted() {
      this.init().then((initialized) => {
        if (initialized) {
          this.loadAll();
        }
      });
    }

    get recordLength(): number {
      return this.all.length > 0
        ? Math.ceil(this.all.length / this.itemPerPage)
        : 0;
    }

    get recordsPerPage(): Record[] {
      const from: number  = (this.page * this.itemPerPage) - this.itemPerPage;
      const to: number = this.page * this.itemPerPage;

      return this.all.slice(from, to);
    }
}

</script>
