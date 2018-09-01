<template>
  <div class="record-administration">
    <v-container grid-list-xs pa-2>
      <v-layout row wrap>
        <v-flex xs12>
          <h1>{{ resx('recordAdministration') }}</h1>
        </v-flex>
      </v-layout>
      <v-layout row wrap>
        <v-flex xs12>
          <admin-record-table-component />
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import Component from 'vue-class-component';

import BaseView from '../BaseView.vue';
import AdminRecordTableComponent from '@/components/auction/AdminRecordTableComponent.vue';

@Component({
  components: {
    AdminRecordTableComponent,
  },
})
export default class RecordsAdministration extends BaseView {
}

</script>

<style>

.record-administration h1 {
  font-family: Roboto;
  font-size: 35px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  text-align: left;
  color: #000000;
  padding-bottom: 30px;
  padding-top: 30px;
}

</style>