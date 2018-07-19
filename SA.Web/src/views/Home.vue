<template>
  <div class="homePage">
    <v-container fluid>
      <h1>{{ resx('home') }}</h1>
    </v-container>
  </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';

@Component({})
export default class Home extends BaseView {}

</script>
