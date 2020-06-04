<template>
    <div class="recordDetail" v-if="record">
        <div v-if="isListDetail">
            <v-layout>
                <v-flex xs12 sm4>
                    <v-card>
                        <v-card-media :src="require(`@/assets${record.files[0].path}/${record.id}/images/${record.files[0].name}`)" height="200px">
                        </v-card-media>
                    </v-card>
                </v-flex>
            </v-layout>
        </div>
        <div v-else>

        </div>
    </div>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import { Record } from './../model';

import BaseComponent from '@/components/BaseComponent.vue';

@Component({})
export default class RecordComponent extends BaseComponent {
    @Prop({ default: null })
    public record: Record;
    @Prop({ type: Boolean, default: false })
    public isListDetail;
}

</script>
