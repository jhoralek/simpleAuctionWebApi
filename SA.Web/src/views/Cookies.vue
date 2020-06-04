    <template>
    <div class="cookies">
        <v-container grid-list-xs pa-2>
            <h1>{{ resx('cookies') }}</h1>
            <v-layout row wrap>
                <v-flex xs12>
                    <h3>{{ question1 }}</h3>
                    <p>{{ answer1 }}</p>

                    <h3>{{ question2 }}</h3>
                    <p>{{ answer2 }}</p>

                    <h3>{{ question3 }}</h3>
                    <p>{{ answer3 }}</p>

                    <h3>{{ question4 }}</h3>
                    <p>{{ answer4 }}</p>
                    <p>{{ answer41 }}</p>

                    <h3>{{ question5 }}</h3>
                    <p>{{ answer5 }}</p>
                    <p>{{ answer51 }}</p>
                    <p>{{ answer52 }}</p>
                    <p>{{ answer53 }}</p>

                    <h3>{{ question6 }}</h3>
                    <p>{{ answer6 }}</p>

                    <ul>
                        <li>Internet Explorer: support.microsoft.com</li>
                        <li>Microsoft Edge: support.microsoft.com</li>
                        <li>Google Chrome: support.google.com</li>
                        <li>Mozilla Firefox: support.mozilla.org</li>
                        <li>Opera: help.opera.com</li>
                        <li>Safari: support.apple.com</li>
                    </ul>
                </v-flex>
            </v-layout>
        </v-container>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';
import { State } from 'vuex-class';

import { Dictionary, SettingsState } from './../store/types';

@Component({})
export default class Cookies extends BaseView {
    @State('settings') private settings: SettingsState;

    private cookiesQuestion1: Dictionary<string> = {
        cs: 'Prohlášení o použití cookies',
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesAnswer1: Dictionary<string> = {
        cs: 'Tyto webové stránky ukládají v souladu se zákony na vaše zařízení soubory, obecně nazývané cookies.',
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesQuestion2: Dictionary<string> = {
        cs: 'Co jsou soubory cookies?',
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesAnswer2: Dictionary<string> = {
        cs: `Cookies jsou krátké textové soubory, které vytváří webový server a ukládá je v
        počítači prostřednictvím prohlížeče. Cookies jsou malé datové soubory, díky kterým si
        navštívené webové stránky pamatují vaše úkony a nastavení, které jste na nich provedli,
        takže tyto údaje nemusíte zadávat opakovaně. V případě, že se vrátíte na stejné webové stránky,
        prohlížeč pošle uložený soubor zpět a server tak získá veškeré informace, které si předtím u
        vás uložil. Cookies nepředstavují nebezpečí, mají však význam pro ochranu soukromí. Cookies
        nelze použít pro zjištění totožnosti návštěvníků stránek ani ke zneužití přihlašovacích údajů.`,
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesQuestion3: Dictionary<string> = {
        cs: 'Jak a proč se cookies používají?',
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesAnswer3: Dictionary<string> = {
        cs: `Cookies jsou nezbytnou podmínkou pro funkční webovou analytiku. Na principu cookies totiž
        pracují statistiky a další měřící systémy, které si ukládají do cookies identifikátor návštěvníka,
        zdroj návštěvy, čas apod. Získané údaje načítají a doplňují na dalších stránkách a mohou tak
        daného uživatele ,,pronásledovat“. Tyto malé textové soubory se také používají k uložení stavu,
        že je uživatel na dané stránce přihlášený (do administrace webu, eshopu, na sociálních sítích
        apod.). Tento typ cookies se nazývá autentizační cookies. Bez této cookies by server nerozeznal,
        že už ověření a přihlášení uživatele na daném webu proběhlo a vyžadoval by je opětovně při
        návštěvě každé další stránky.`,
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesQuestion4: Dictionary<string> = {
        cs: 'Jaké jsou druhy cookies?',
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesAnswer4: Dictionary<string> = {
        cs: `Cookies první strany – malý textový soubor cookies je uložen pomocí skriptu, který běží
        na dané doméně. Takové cookies se všeobecně považují za bezpečnější. Mnohem lépe prochází přes
        firewally a přísněji nastavená bezpečnostní pravidla prohlížečů. Tento druh cookies využívá
        například Google Analytics (v základním nastavení).`,
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesAnswer41: Dictionary<string> = {
        cs: `Cookies třetí strany – cookies je uložena pomocí skriptu, který je do webu natahován z
        jiné domény. Jednu a tu samou cookies lze tedy načítat na různých místech internetu a tím
        pádem je možné uživatele sledovat napříč různými doménami.`,
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesQuestion5: Dictionary<string> = {
        cs: 'Jaké typy cookies používáme?',
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesAnswer5: Dictionary<string> = {
        cs: `Cookies je možné z hlediska trvanlivosti rozdělit na základní typy druhy. Jedním druhem
        cookies jsou dočasné (session cookies), které se v prohlížeči se ukládají jen po dobu, než
        prohlížeč zavřete. Dalším druhem jsou cookies dlouhodobé (persistent cookies), které
        zůstávají uloženy déle nebo do dobry, kdy je ručně neodstraníte z prohlížeče.`,
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesAnswer51: Dictionary<string> = {
        cs: `Z hlediska jejich funkce lze cookies rozdělit na více typů. Prvním typem cookies jsou
        cookies remarketingové, které využíváme pro personalizaci obsahu našich reklam a jejich
        správnému zacílení. Dalším druhem jsou analytické cookies, které nám napoví, jak zvýšit
        pohodlí našich uživatelů tím, že ze získaných dat pochopíme, jak je náš web uživateli
        používán. Základní cookies jsou nezbytné pro základní funkčnost webu. Dalším typem cookies,
        který používáme, jsou cookies konverzní, které nám pomohou analyzovat výkon konverzních
        kanálů. Posledním typem cookies, které používáme, jsou cookies trackingové
        (tzv. sledovací), které v kombinaci s konverzními cookies pomohou analyzovat výkon
        různých konverzních kanálů.`,
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesAnswer52: Dictionary<string> = {
        cs: `Některé cookies mohou shromažďovat informace, které jsou využity třetími stranami.
        Tyto cookies přímo podporují naše reklamní aktivity (PPC systémy AdWords, Sklik,..).Díky
        těmto cookies je nám umožněno uzpůsobit zobrazování bannerů či inzerátů na vámi zobrazovaných
        internetových stránkách. Na základě těchto údajů vás však není možné identifikovat.`,
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesAnswer53: Dictionary<string> = {
        cs: `Používaní remarketingových, analytických, tranckingových a konverzních cookies
        (společně dále jen „Marketingové cookies“) lze odmítnout odškrtnutím checkboxu ‚Marketingové
        cookies‘ přímo po rozkliknutí cookies lišty zobrazující se na našich webových stránkách.`,
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesQuestion6: Dictionary<string> = {
        cs: 'Souhlas s ukládáním cookies',
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    private cookiesAnswer6: Dictionary<string> = {
        cs: `Většina prohlížečů cookies automaticky akceptuje, pokud není prohlížeč nastaven jinak.
        Používáním těchto webových stránek souhlasíte s ukládáním souborů cookies. Použití cookies
        můžete omezit nebo zablokovat v nastavení svého webového prohlížeče. Informace o nastavení
        konkrétního prohlížeče naleznete na uvedených adresách:`,
        en: '',
        ru: '',
        de: '',
        sk: '',
    };

    get question1(): string {
        return this.cookiesQuestion1[this.settings.language];
    }

    get answer1(): string {
        return this.cookiesAnswer1[this.settings.language];
    }

    get question2(): string {
        return this.cookiesQuestion2[this.settings.language];
    }

    get answer2(): string {
        return this.cookiesAnswer2[this.settings.language];
    }

    get question3(): string {
        return this.cookiesQuestion3[this.settings.language];
    }

    get answer3(): string {
        return this.cookiesAnswer3[this.settings.language];
    }

    get question4(): string {
        return this.cookiesQuestion4[this.settings.language];
    }

    get answer4(): string {
        return this.cookiesAnswer4[this.settings.language];
    }

    get answer41(): string {
        return this.cookiesAnswer41[this.settings.language];
    }

    get question5(): string {
        return this.cookiesQuestion5[this.settings.language];
    }

    get answer5(): string {
        return this.cookiesAnswer5[this.settings.language];
    }

    get answer51(): string {
        return this.cookiesAnswer51[this.settings.language];
    }

    get answer52(): string {
        return this.cookiesAnswer52[this.settings.language];
    }

    get answer53(): string {
        return this.cookiesAnswer53[this.settings.language];
    }

    get question6(): string {
        return this.cookiesQuestion6[this.settings.language];
    }

    get answer6(): string {
        return this.cookiesAnswer6[this.settings.language];
    }
}

</script>

<style>

.cookies h1 {
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

.cookies h3 {
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

.cookies p {
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

.cookies li {
  font-size: 16px;
  font-weight: normal;
  font-style: normal;
  font-stretch: normal;
  line-height: 2.06;
  letter-spacing: 0.5px;
  text-align: justify;
}

</style>
