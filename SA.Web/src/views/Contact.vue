<template>
    <div class="contact">
        <v-container fluid>
            <h1>{{ resx('contact') }}</h1>
        </v-container>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';

@Component({})
export default class Contact extends BaseView {}

</script>
