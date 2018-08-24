<template>
  <div class="user-administration">
    <v-container grid-list-xs pa-2>
      <v-layout row wrap>
        <v-flex xs12>
          <h1>{{ resx('usersAdministration') }}</h1>
        </v-flex>
      </v-layout>
      <v-layout row wrap>
        <v-flex xs12>
          <user-table-component :users="users" :loading="isLoading" />
        </v-flex>
      </v-layout>
    </v-container>
  </div>
</template>

<script lang="ts">

import Component from 'vue-class-component';
import { Action, Getter, namespace } from 'vuex-class';

import BaseView from '../BaseView.vue';
import UserTableComponent from '@/components/User/UserTableComponent.vue';
import { UserSimpleDto } from '@/poco';

const ProfileAction = namespace('profile', Action);
const ProfileGetter = namespace('profile', Getter);

@Component({
  components: {
    UserTableComponent,
  },
})
export default class UserAdministration extends BaseView {
  @ProfileAction('getAllUsersForAdmin') private getUsers: any;
  @ProfileGetter('getList') private users: UserSimpleDto[];

  private isLoading: boolean = true;
  private mounted() {
    this.getUsers().then((response) => {
      if (response) {
        this.isLoading = false;
      }
    });
  }
}

</script>

<style>

.user-administration h1 {
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

.user-administration .elevation-1 {
    -webkit-box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0) !important;
    box-shadow: 0 0px 0px 0px rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0),0 0px 0px 0 rgba(0,0,0,.0)!important;
}

</style>