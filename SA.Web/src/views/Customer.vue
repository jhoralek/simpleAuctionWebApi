<template>
  <div class="customer">
    <v-container fluid>
      <h1>{{ resx('customerDetail') }}</h1>
      <v-layout row>
          <v-flex xs6 order-lg2>
            <v-card tile flat>
              <v-card-text>
                <UserDetailComponent />
              </v-card-text>
            </v-card>
          </v-flex>
          <v-flex xs6>
            <v-card tile flat>
              <v-card-text>
                <CustomerDetailComponent />
              </v-card-text>
            </v-card>
          </v-flex>
        </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component } from 'vue-property-decorator';

import BaseView from './BaseView.vue';
import { UserDetailComponent, CustomerDetailComponent } from '@/components';

@Component({
  components: {
    UserDetailComponent,
    CustomerDetailComponent,
  },
})
export default class Customer extends BaseView {
}

</script>