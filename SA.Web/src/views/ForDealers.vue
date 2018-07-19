<template>
    <div class="forDealers">
        <v-container fluid>
            <h1>{{ resx('forDealers') }}</h1>
        </v-container>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';

@Component({})
export default class ForDealers extends BaseView {}

</script>