<template>
    <div class="termsAndConditions">
        <v-container grid-list-md>
            <h1 class="display-1 primary--text">{{ resx('termsAndConditions') }}</h1>
        </v-container>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';

@Component({})
export default class TermsAndConditions extends BaseView {}

</script>