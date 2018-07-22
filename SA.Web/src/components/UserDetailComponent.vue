<template>
  <div class="userDetailForm" v-if="user">
    <v-container>
      <v-form lazy-validation>
        <v-text-field
          v-model="user.userName"
          required
          :label="labelUserName" />
        <v-layout>
          <v-checkbox
            v-model="user.isActive"
            :disabled="true"
            hide-details
            class="shrink mr-2" />
          <v-text-field :label="labelIsActive" />
        </v-layout>
        <v-switch
          v-model="user.sendingNews"
          :label="lableSendingNews" />
        <v-select
          v-model="user.language"
          :hint="`<img src='${current}' />`"
          item-value="language"
          item-text="language"
          single-line
          :label="labelLanguage"
          persistent-hint
          :items="flags" />
      </v-form>
    </v-container>
  </div>
</template>

<script lang="ts">

import { Component, Prop } from 'vue-property-decorator';

import { SettingsState } from '@/store/types';
import { User } from '@/model';
import BaseComponent from './BaseComponent.vue';

import { Translator } from '@/lang';

@Component({})
export default class UserDetailComponent extends BaseComponent {
  @Prop({ default: undefined }) public user: User;

  get labelUserName(): string {
    return this.settings.resource.userName;
  }

  get labelIsActive(): string {
    return this.settings.resource.active;
  }

  get lableSendingNews(): string {
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