<template>
    <v-container v-if="record">
        <h1>{{ record.name }}</h1>
    </v-container>
</template>

<<script lang="ts">
import { Component, Prop } from 'vue-property-decorator';
import { Getter, namespace } from 'vuex-class';
import BaseComponent from './BaseComponent.vue';

import { Record } from '@/model';

const RecordGetter = namespace('record', Getter);

@Component({})
export default class AuctionDetalComponent extends BaseComponent {
    @RecordGetter('getCurrent') private record: Record;
}

</script>