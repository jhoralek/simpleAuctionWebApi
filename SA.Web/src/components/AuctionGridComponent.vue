<template>
  <div class="auction-grid-list">
    <v-container v-bind="{ [`grid-list-xs`]: true }" fluid v-if="records">
      <v-layout row wrap>
        <v-flex xs12 sm3 v-for="(record, index) in records" :key="index">
          <v-card>
              <v-progress-linear v-if="isLoading" indeterminate></v-progress-linear>
              <v-card-media :src="randomImagePath(record)" height="200px">
                <v-container fill-height fluid grid-list-xs>
                  <v-layout row>
                    <v-flex xs3>
                      <v-chip color="green lighten-1" text-color="white">
                        {{ resx('currentPrice') }}: {{ record.currentPrice }} CZK
                      </v-chip>
                      <v-chip color="red lighten-1" text-color="white">
                          <CountdownComponent
                            :id="recordIdToString(record)"
                            :date="record.validTo" />
                      </v-chip>
                    </v-flex>
                  </v-layout>
                </v-container>
              </v-card-media>
              <v-card-title class="headline">
                <span>{{record.name}}</span>
              </v-card-title>
              <v-card-text>
                <blockquote class="blockquote mb-5">
                  {{record.state}}
                </blockquote>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-tooltip top>
                  <v-btn icon slot="activator" @click="detail(record)">
                    <v-icon>desktop_windows</v-icon>
                  </v-btn>
                  <span>{{ resx('detailOfAuction') }}</span>
                </v-tooltip>
                <v-tooltip top>
                  <v-btn icon slot="activator">
                    <v-icon>favorite</v-icon>
                  </v-btn>
                  <span>{{ resx('intoFavorites') }}</span>
                </v-tooltip>
                <v-tooltip top>
                  <v-btn icon slot="activator">
                    <v-icon>share</v-icon>
                  </v-btn>
                  <span>{{ resx('share') }}</span>
                </v-tooltip>
              </v-card-actions>
            </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import { Action, namespace } from 'vuex-class';

import { Record, FileShort } from '@/model';
import BaseComponent from './BaseComponent.vue';
import CountdownComponent from './helpers/CountdownComponent.vue';

const RecordAction = namespace('record', Action);

@Component({
    components: {
        CountdownComponent,
    },
})
export default class AuctionGridComponent extends BaseComponent {
  @Prop({default: undefined}) public records: Record[];
  @RecordAction('getDetail') public loadRecord: any;

  public selectedRecordObj: Record = undefined;
  private isLoading: boolean = false;

  private randomImagePath(record: Record): string {
    const { files } = record;
    const rf = files[Math.floor(Math.random() * files.length)];
    return `/${rf.path}/${rf.recordId}/images/${rf.name}`;
  }

  private recordIdToString(record: Record): string {
      return record.id.toString();
  }

  get selectedRecord() {
    return this.selectedRecordObj;
  }

  private detail(record: Record): void {
    this.selectedRecordObj = record;
    this.isLoading = true;
    this.loadRecord(record.id).then((response) => {
      const result = response as boolean;
      this.isLoading = false;
      if (result) {
        this.$router.push({ name: 'auctionDetail' });
      }
    });
  }
}

</script>
