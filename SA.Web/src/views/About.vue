<template>
  <div class="about">
    <v-container fluid>
      <h1>{{ resx('about') }}</h1>
    </v-container>
  </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';

@Component({})
export default class About extends BaseView {}

</script>
