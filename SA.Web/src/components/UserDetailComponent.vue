<template>
  <div class="user-form">
    <v-progress-linear v-if="isLoading" indeterminate></v-progress-linear>
    <v-container  grid-list-md>
      <v-form lazy-validation ref="user" v-if="user">
        <v-layout row wrap>
          <v-flex xs12>
            <v-select
              v-model="user.language"
              v-validate="'required'"
              data-vv-name="language"
              :error-messages="errors.collect('language')"
              :hint="`<img src='${current}' />`"
              item-value="language"
              item-text="language"
              single-line
              :label="labelLanguage"
              persistent-hint
              :items="flags" />
          </v-flex>
          <v-flex xs12>
             <v-switch
                v-model="user.sendingNews"
                :label="labelSendingNews" />
          </v-flex>
        </v-layout>
        <v-layout row wrap>
          <v-flex xs12 justify-end align-center>
            <v-btn color="black" @click="submitUser">{{ resx('submit') }}</v-btn>
          </v-flex>
        </v-layout>
      </v-form>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';
import { Action, namespace } from 'vuex-class';

import { SettingsState } from './../store/types';
import { User } from './../model';

import { Translator } from './../lang';

import BaseComponent from './BaseComponent.vue';

const ProfileAction = namespace('profile', Action);

@Component({})
export default class UserDetailComponent extends BaseComponent {
  @Prop({ default: undefined })
  private user: User;
  @ProfileAction('userUpdate')
  private update: any;

  private isLoading: boolean = false;

  private submitUser(): void {
    this.$validator.validateAll().then((response) => {
      if (response) {
        this.isLoading = true;
        this.update(this.user).then((responseUser) => {
          if (responseUser) {
            this.isLoading = false;
          }
        });
      }
    });
  }

  get labelUserName(): string {
    return this.settings.resource.userName;
  }

  get labelSendingNews(): string {
    return this.settings.resource.sendingNews;
  }

  get labelLanguage(): string {
    return this.settings.resource.language;
  }

  get flags(): string[] {
    return Translator.languages;
  }

  get current(): NodeRequire {
    return require(`@/assets/${this.user.language}.png`);
  }
}

</script>

<style>

.user-form .v-btn {
  color: white !important;
  border-radius: 5px !important;
}

</style>