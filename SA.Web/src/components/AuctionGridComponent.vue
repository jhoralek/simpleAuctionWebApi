<template>
  <v-flex xs12 md4 v-if="records">
    <v-card>
        <v-container fluid grid-list-md>
          <v-layout row>
            <v-flex v-for="record in records" :key="record.id">
              <v-card>
                <v-card-media :src="randomImagePath(record)" height="200px">
                  <v-container fill-height fluid grid-list-xs>
                    <v-layout row>
                      <v-flex xs3>
                        <v-chip color="green lighten-1" text-color="white">
                          {{ resx('currentPrice') }}: {{ record.currentPrice }} CZK
                        </v-chip>
                        <v-chip color="red lighten-1" text-color="white">
                           {{ countDown(record)}}{{ resx('endOfAuction') }}
                           <span id="count-down"></span>
                        </v-chip>
                      </v-flex>
                    </v-layout>
                  </v-container>
                </v-card-media>
                <v-card-title class="headline">
                  <span>{{record.name}}</span>
                </v-card-title>
                <v-card-title>
                  <blockquote class="blockquote mb-5">
                    {{record.state}}
                  </blockquote>
                </v-card-title>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn icon>
                    <v-icon>favorite</v-icon>
                  </v-btn>
                  <v-btn icon>
                    <v-icon>bookmark</v-icon>
                  </v-btn>
                  <v-btn icon>
                    <v-icon>share</v-icon>
                  </v-btn>
                </v-card-actions>
              </v-card>
            </v-flex>
          </v-layout>
        </v-container>
      </v-card>
  </v-flex>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import { Getter, namespace } from 'vuex-class';
import Helpers from '@/helpers';

import { Record, FileShort } from '@/model';
import BaseComponent from './BaseComponent.vue';

@Component({})
export default class AuctionGridComponent extends BaseComponent {
  @Prop({default: undefined}) private records: Record[];

  private randomImagePath(record: Record): string {
    const { files } = record;
    const rf = files[Math.floor(Math.random() * files.length)];
    return `/${rf.path}/${rf.recordId}/images/${rf.name}`;
  }

  private countDown(record: Record): void {
    const x = setInterval(() => {
      const thick = Helpers.countDown(record.validTo);
      document.getElementById('count-down')
        .innerHTML = thick;
    }, 1000);
  }
}

</script>

<style>
#count-down {
  margin-left: 5px;
}
</style>

