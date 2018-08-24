<template>
    <div class="protection-personal-data">
        <v-container grid-list-xs pa-2>
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

<style>

.protection-personal-data h1 {
  font-family: Roboto;
  font-size: 35px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  text-align: left;
  color: #000000;
  padding-bottom: 30px;
  padding-top: 30px;
}

.protection-personal-data p {
  font-size: 16px;
  font-weight: normal;
  font-style: normal;
  font-stretch: normal;
  line-height: 2.06;
  letter-spacing: 0.5px;
  text-align: justify;
  padding-right: 10%;
  padding-bottom: 10px;
}


.protection-personal-data h3 {
  font-family: Roboto;
  font-size: 21px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  text-align: left;
  color: #000000;
  padding-top: 15px;
  padding-bottom: 15px;
}

</style>