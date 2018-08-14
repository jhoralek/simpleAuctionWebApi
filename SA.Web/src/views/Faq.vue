<template>
    <div class="faq">
        <v-container grid-list-xs pa-2>
            <h1 class="display-1 primary--text">{{ resx('faq') }}</h1>
        </v-container>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';

@Component({})
export default class Faq extends BaseView {}

</script>