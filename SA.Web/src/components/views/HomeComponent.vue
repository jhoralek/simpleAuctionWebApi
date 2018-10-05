<template>
    <div class="home">
        <h1>{{ header }}</h1>
        <p class="content">
            {{ content }}
        </p>
        <v-container fluid>
            <v-layout row justify-center>
                <v-flex xs12 md6>
                    <router-link
                        to="/termsAndConditions"
                        class="v-btn v-btn--flat v-btn--router">
                        <div class="btn-text">
                            {{ resx('termsAndConditions') }}
                        </div>
                    </router-link>
                </v-flex>
                <v-flex xs12 md6>
                    <router-link
                        to="/gdpr-info"
                        class="v-btn v-btn--flat v-btn--router">
                        <div class="btn-text">
                            {{ resx('protectionPersonalData') }}
                        </div>
                    </router-link>
                </v-flex>
            </v-layout>
        </v-container>
    </div>
</template>

<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';

import FormBaseComponent from '@/components/FormBaseComponent.vue';
import { Dictionary } from '@/store/types';

@Component({})
export default class HomeComponent extends FormBaseComponent {

    private headers: Dictionary<string> = {
        cs: 'Vítejte na stránkách společnosti JERA Trading s.r.o.',
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private contents: Dictionary<string> = {
        cs: `Naše společnost se zabývá zajišťováním prodeje nepotřebné techniky
        pro firmy a společnosti pomocí internetových aukcí konaných na našich
        stránkách. Prodávající se díky spolupráci s námi zbavuje téměř veškeré
        administrativní zátěže související s prodejem techniky. Díky prodeji pomocí
        veřejné internetové aukci se jedná o naprosto transparentní prodej. Pro
        kupující je hlavní výhodou nákupu u naší společnosti koupě ověřené techniky,
        zpravidla po prvním majiteli, pravidelně servisované a s poctivými km. Mezi
        naše největší obchodní partnery patří Sokolovská uhelná, právní nástupce, a.s.`,
        en: ``,
        ru: ``,
        de: ``,
        sk: ``,
    };

    get header(): string {
        return this.headers[this.settings.language];
    }

    get content(): string {
        return this.contents[this.settings.language];
    }
}

</script>

<style>
.home h1 {
  font-family: Roboto;
  font-size: 45px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  text-align: left;
  color: #000000;
  padding-bottom: 51px;
  padding-right: 10%;
  padding-left: 10px;
  padding-top: 80px;
}

.spacer1 {
    height: 51px;
}

.content {
  font-size: 16px;
  font-weight: normal;
  font-style: normal;
  font-stretch: normal;
  line-height: 2.06;
  letter-spacing: 0.5px;
  text-align: justify;
  padding-right: 10%;
  padding-left: 10px;
  padding-bottom: 30px;

}

.homePage a .btn-text {
    border-bottom: 3px solid black !important;
}

</style>