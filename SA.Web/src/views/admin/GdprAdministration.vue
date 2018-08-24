<template>
  <div class="gdpr-administration">
    <v-container grid-list-xs pa-2>
      <v-layout row wrap>
        <v-flex xs12>
          <h1>{{ resx('gdprAdministration') }}</h1>
        </v-flex>
      </v-layout>
      <v-layout row wrap>
        <v-flex xs12>
            <gdpr-table-component :gdprRecords="records" :loading="isLoading" />
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import Component from 'vue-class-component';
import { Action, Getter, namespace } from 'vuex-class';

import BaseView from '../BaseView.vue';
import GdprTableComponent from '@/components/User/GdprTableComponent.vue';
import { GdprRecordTableDto } from '@/poco';

const ProfileAction = namespace('profile', Action);

@Component({
  components: {
    GdprTableComponent,
  },
})
export default class GdprAdministration extends BaseView {
  @ProfileAction('getAllGdprRecordsForAdmin') private getRecords: any;

  private records: GdprRecordTableDto[] = [] as GdprRecordTableDto[];
  private isLoading: boolean = true;

  private mounted() {
    this.getRecords().then((response) => {
      if (response) {
        this.records = response as GdprRecordTableDto[];
        this.isLoading = false;
      }
    });
  }
}

</script>

<style>

.gdpr-administration h1 {
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
