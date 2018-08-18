<template>
    <div class="gdpr">
        <v-container grid-list-xs pa-2>
            <h1 class="display-1 primary--text">{{ resx('gdpr') }}</h1>
            <v-layout row wrap>
                <v-flex xs12>
                    <gdpr-form-component />
                </v-flex>
            </v-layout>
        </v-container>
    </div>
</template>

<script lang="ts">

import Component from 'vue-class-component';

import BaseView from './BaseView.vue';
import { GdprFormComponent } from '@/components';

@Component({
    components: {
        GdprFormComponent,
    },
})
export default class Gdpr extends BaseView {}

</script>