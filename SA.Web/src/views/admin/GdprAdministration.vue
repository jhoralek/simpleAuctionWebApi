<template>
  <div class="gdpr-administration">
    <v-container grid-list-xs pa-2>
      <v-layout row wrap>
        <v-flex xs12>
          <h1 class="display-1 primary--text">{{ resx('gdprAdministration') }}</h1>
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
