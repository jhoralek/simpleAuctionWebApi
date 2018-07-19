<template>
    <div class="faq">
        <v-container fluid>
            <h1>{{ resx('faq') }}</h1>
        </v-container>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';

@Component({})
export default class Faq extends BaseView {}

</script>