<template>
    <div class="termsAndConditions">
        <v-container fluid>
            <h1>{{ resx('termsAndConditions') }}</h1>
        </v-container>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';

@Component({})
export default class TermsAndConditions extends BaseView {}

</script>