<template>
  <div class="loginForm fill-height languageComponent text-xs-center" v-if="settings.language">
    <v-menu offset-y>
        <v-btn flat slot="activator">
            <img :src="current" />
        </v-btn>
        <v-list>
            <v-list-tile v-for="(flag, index) in flags" :key="index" @click="selectLang(flag.key)">
                <v-list-tile-title>
                    <img :src="flag.value" />
                </v-list-tile-title>
            </v-list-tile>
        </v-list>
    </v-menu>
  </div>
</template>

<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { Action, namespace } from 'vuex-class';

import { SettingsState } from '@/store/types';
import { Translator } from '@/lang';
import BaseComponent from '@/components/BaseComponent.vue';
import Validation from '@/validation';

const SettingsAction = namespace('settings', Action);

@Component({})
export default class LanguageComponent extends BaseComponent {

    @SettingsAction('changeLanguage') public change: any;

    get current(): any {
        return require(`@/assets/${this.settings.language}.png`);
    }
    get flags(): any [] {
        return Translator.languages
            .filter((x) => x !== this.settings.language)
            .map((item) => {
                return { key: item, value: require(`@/assets/${item}.png`)};
            });
    }

    public selectLang(key: string) {
        this.change(key);

        const attributes = Validation.loadValidationAttributes(this.settings.currentForm, key);

        if (attributes) {
            this.$validator.localize(key, attributes);
        }
        this.$validator.localize(key);
    }
}

</script>

<style>
img {
    width: 32px;
}
</style>
