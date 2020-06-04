<template>
    <div class="faq">
        <v-container grid-list-xs pa-2>
            <h1>{{ resx('faq') }}</h1>
            <h3>Jak se mohu účastnit aukce?</h3>
            <p>Aukce je možné se zúčastnit pouze po řádném zaregistrování na stránkách JERA-Trading.cz. <v-btn flat to="/registration">{{ resx('registration') }}</v-btn></p>
            <p>Po vyplnění registračního formuláře budou data ověřena a obratem Vám přidělíme přihlašovací údaje, které obdržíte v elektronické podobě na Váš e-mail.</p>
            <p>Přihlašovací údaje Vám umožní  přístup do nabídky  vozidel, po zaplacení jistiny se můžete aktivně účastnit závazné elektronické aukce.</p>
            <h3>Je nutná pro aktivní účast na aukci jistina?</h3>
            <p>Ano, pro aktivní účast na aukci je potřeba mít slouženou jistinu na náš účet. Bližší informace obdržíte po Vaší registraci.</p>
            <h3>Co se stane s jistinou v případě, že má nabídka nebude nejvyšší?</h3>
            <p>Pokud se nehodláte účastnit dalších aukcí, zašlete e-mailem žádost o vracení jistiny. Jistina Vám bude vrácena v plné výši. Vrácení jistiny není naší společností nijak zpoplatněno.</p>
            <h3>Co se stane s jistinou v případě, že má nabídka bude nejvyšší?</h3>
            <p>Po zdárném předání vozidla můžete, pokud se nehodláte účastnit dalších aukcí, zažádat e-mailem o vracení jistiny. Jistina Vám bude vrácena v plné výši. Vrácení jistiny není naší společností nijak zpoplatněno.</p>
            <h3>Muže být jistina využita k zaplacení vozidla?</h3>
            <p>Ne. Jistinu nelze použít k zaplacení vozidla. </p>
            <h3>Co když má nabídka bude nejvyšší, ale rozmyslím si nákup vozu?</h3>
            <p>Z Vaší jistiny bude stržena částka za zmaření aukce ve výši 5 000Kč a to za každou zmařenou aukci.</p>
            <h3>Jakou formou mohu vozidlo zaplatit?</h3>
            <p>Jediný způsob platby je bankovním převodem na účet společnosti JERA Trading s.r.o.</p>
            <h3>Jak mohu prodávat své vozy či techniku?</h3>
            <p>V případě zájmu o prodej Vašich vozidel nás neváhejte kontaktovat info@jera-trading.cz. Ke každému prodávajícímu přistupujeme individuálně dle jeho potřeb a požadavků.</p>
            <h3>Proč nakupovat vozidla či techniku prostřednictvím JERA Trading s.r.o.?</h3>
            <p>Většina vozů je po prvním majiteli s jasnou historií a servisována v autorizovaných servisech. Najeté kilometry či motohodiny odpovídají vždy skutečnosti.</p>
            <h3>Je cena v aukci bez DPH?</h3>
            <p><strong>Ano</strong>, ceny v aukcích jsou uváděny <strong>bez DPH</strong>. Pokud se jedná o cenu s DPH je tato skutečnost v popisu výslovně uvedena.</p>
            <h3>Zapomněl jsem své přihlašovací údaje?</h3>
            <p>V tomto případě nás kontaktujte e-mailem MAIL, obratem Vám pošleme nové přihlašovací údaje.</p>
            <h3>Kdy a kde si mohu vozidla či techniku prohlédnout?</h3>
            <p>Nabízené vozy lze prohlédnout přímo u majitele v předem stanovených termínech, které jsou uvedeny u každé aukce a to včetně kontaktu na kompetentní osobu a místo konání.</p>
            <h3>Co se stane když má nabídka byla nejvyšší?</h3>
            <p>V případě, že Vaše nabídka byla nejvyšší, obdržíte obratem e-mail, který Vás informuje, že jste vozidlo či techniku v aukci vyhrál. V tomto e-mailu obdržíte zároveň fakturu, smlouvu, předepsánu plnou moc pro přepis vozidla na Vás a předávací protokol. Po zaplacení faktury a podepsání kupní smlouvy  Vás budeme kontaktovat s informací, kdy a kde proběhne předání Vašeho vozu či techniky. </p>
            <h3>Kdy si mohu vyhrané vozidlo vyzvednout?</h3>
            <p>K předání vozu či techniky dochází zpravidla do 10ti pracovních dnů po zaplacení faktury a zaslání potřebných dokumentů zpět na naši firmu (Kupní smlouva, Plná moc k přepisu, doklad o pojištění vozidla "zelená karta").</p>
            <h3>Co se děje s vozidlem od vyhlášení aukce do jeho vyzvednutí?</h3>
            <p>Vystavením vozidla do aukce je vozidlo majitelem dále neprovozováno a nejsou na něm prováděny žádné změny</p>
            <h3>Kde a jak probíhá předání?</h3>
            <p>K předání vozu či techniky dochází většinou v prostorech majitele vozidla. Při předání bude sepsán předávací protokol k vozidlu.</p>
        </v-container>
    </div>
</template>

<script lang="ts">

import BaseView from './BaseView.vue';
import Component from 'vue-class-component';

import { SettingsState } from './../store/types';

@Component({})
export default class Faq extends BaseView {
}

</script>

<style>

.faq h1 {
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

.faq p {
  font-size: 16px;
  font-weight: 200;
  font-style: normal;
  font-stretch: normal;
  line-height: 2.06;
  letter-spacing: 0.5px;
  text-align: justify;
  padding-right: 10%;
}


.faq h3 {
  font-family: Roboto;
  font-size: 21px;
  font-weight: 500;
  font-style: normal;
  font-stretch: normal;
  letter-spacing: 0px;
  text-align: left;
  color: #000000;
  padding-top: 5px;
  padding-bottom: 15px;
}

.faq .v-btn__content {
    border-bottom: 3px solid black !important;
    line-height: 1.3 !important;
}

.faq .v-btn {
    margin: 0px;
    padding: 0px;
}

</style>