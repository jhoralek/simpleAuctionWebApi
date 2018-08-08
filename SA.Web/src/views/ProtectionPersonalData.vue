<template>
    <div class="protectionPersonalData">
        <v-container grid-list-md>
            <h1 class="display-1 primary--text">{{ resx('protectionPersonalData') }}</h1>
        </v-container>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';

@Component({})
export default class ProtectionPersonalData extends BaseView {}

</script>