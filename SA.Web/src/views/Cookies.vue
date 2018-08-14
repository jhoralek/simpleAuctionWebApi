    <template>
    <div class="contact">
        <v-container grid-list-xs pa-2>
            <h1 class="display-1 primary--text">{{ resx('cookies') }}</h1>
            <v-layout row wrap>
                <v-flex xs12>
                    <p><strong>Prohlášení o použití cookies</strong></p>
                    <p>Tyto webové stránky ukládají v souladu se zákony na vaše zařízení soubory, obecně nazývané cookies.</p>

                    <p><strong>Co jsou soubory cookies?</strong></p>
                    <p>Cookies jsou krátké textové soubory, které vytváří webový server a ukládá je v počítači prostřednictvím prohlížeče. Cookies jsou malé datové soubory, díky kterým si navštívené webové stránky pamatují vaše úkony a nastavení, které jste na nich provedli, takže tyto údaje nemusíte zadávat opakovaně. V případě, že se vrátíte na stejné webové stránky, prohlížeč pošle uložený soubor zpět a server tak získá veškeré informace, které si předtím u vás uložil. Cookies nepředstavují nebezpečí, mají však význam pro ochranu soukromí. Cookies nelze použít pro zjištění totožnosti návštěvníků stránek ani ke zneužití přihlašovacích údajů.</p>

                    <p><strong>Jak a proč se cookies používají?</strong></p>
                    <p>Cookies jsou nezbytnou podmínkou pro funkční webovou analytiku. Na principu cookies totiž pracují statistiky a další měřící systémy, které si ukládají do cookies identifikátor návštěvníka, zdroj návštěvy, čas apod. Získané údaje načítají a doplňují na dalších stránkách a mohou tak daného uživatele ,,pronásledovat“. Tyto malé textové soubory se také používají k uložení stavu, že je uživatel na dané stránce přihlášený (do administrace webu, eshopu, na sociálních sítích apod.). Tento typ cookies se nazývá autentizační cookies. Bez této cookies by server nerozeznal, že už ověření a přihlášení uživatele na daném webu proběhlo a vyžadoval by je opětovně při návštěvě každé další stránky.</p>

                    <p><strong>Jaké jsou druhy cookies?</strong</p>
                    <p>Cookies první strany – malý textový soubor cookies je uložen pomocí skriptu, který běží na dané doméně. Takové cookies se všeobecně považují za bezpečnější. Mnohem lépe prochází přes firewally a přísněji nastavená bezpečnostní pravidla prohlížečů. Tento druh cookies využívá například Google Analytics (v základním nastavení).</p>
                    <p>Cookies třetí strany – cookies je uložena pomocí skriptu, který je do webu natahován z jiné domény. Jednu a tu samou cookies lze tedy načítat na různých místech internetu a tím pádem je možné uživatele sledovat napříč různými doménami.</p>

                    <p><strong>Jaké typy cookies používáme?</strong></p>
                    <p>Cookies je možné z hlediska trvanlivosti rozdělit na základní typy druhy. Jedním druhem cookies jsou dočasné (session cookies), které se v prohlížeči se ukládají jen po dobu, než prohlížeč zavřete. Dalším druhem jsou cookies dlouhodobé (persistent cookies), které zůstávají uloženy déle nebo do dobry, kdy je ručně neodstraníte z prohlížeče.</p>
                    <p>Z hlediska jejich funkce lze cookies rozdělit na více typů. Prvním typem cookies jsou cookies remarketingové, které využíváme pro personalizaci obsahu našich reklam a jejich správnému zacílení. Dalším druhem jsou analytické cookies, které nám napoví, jak zvýšit pohodlí našich uživatelů tím, že ze získaných dat pochopíme, jak je náš web uživateli používán. Základní cookies jsou nezbytné pro základní funkčnost webu. Dalším typem cookies, který používáme, jsou cookies konverzní, které nám pomohou analyzovat výkon konverzních kanálů. Posledním typem cookies, které používáme, jsou cookies trackingové (tzv. sledovací), které v kombinaci s konverzními cookies pomohou analyzovat výkon různých konverzních kanálů.</p>
                    <p>Některé cookies mohou shromažďovat informace, které jsou využity třetími stranami. Tyto cookies přímo podporují naše reklamní aktivity (PPC systémy AdWords, Sklik,..).Díky těmto cookies je nám umožněno uzpůsobit zobrazování bannerů či inzerátů na vámi zobrazovaných internetových stránkách. Na základě těchto údajů vás však není možné identifikovat.</p>
                    <p>Používaní remarketingových, analytických, tranckingových a konverzních cookies (společně dále jen „Marketingové cookies“) lze odmítnout odškrtnutím checkboxu ‚Marketingové cookies‘ přímo po rozkliknutí cookies lišty zobrazující se na našich webových stránkách.</p>

                    <p><strong>Souhlas s ukládáním cookies</strong></p>
                    <p>Většina prohlížečů cookies automaticky akceptuje, pokud není prohlížeč nastaven jinak. Používáním těchto webových stránek souhlasíte s ukládáním souborů cookies. Použití cookies můžete omezit nebo zablokovat v nastavení svého webového prohlížeče. Informace o nastavení konkrétního prohlížeče naleznete na uvedených adresách:</p>

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

@Component({})
export default class Cookies extends BaseView {}

</script>
