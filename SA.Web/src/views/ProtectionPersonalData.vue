<template>
    <div class="protectionPersonalData">
        <v-container fluid>
            <h1>{{ resx('protectionPersonalData') }}</h1>
        </v-container>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';

@Component({})
export default class ProtectionPersonalData extends BaseView {}

</script>