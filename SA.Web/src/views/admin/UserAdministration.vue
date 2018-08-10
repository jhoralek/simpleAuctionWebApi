<template>
  <div class="user-administration">
    <v-container grid-list-md>
      <v-layout row wrap>
        <v-flex xs12>
          <h1 class="display-1 primary--text">{{ resx('usersAdministration') }}</h1>
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
