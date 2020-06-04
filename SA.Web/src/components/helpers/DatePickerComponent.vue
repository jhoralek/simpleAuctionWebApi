<template>
    <v-menu
        ref="menu"
        :close-on-content-click="false"
        v-model="menu"
        :nudge-right="40"
        lazy
        transition="scale-transition"
        offset-y
        full-width
        max-width="290px"
        min-width="290px">
        <v-text-field v-if="validation && name"
            slot="activator"
            v-model="dateFormatted"
            :v-validate="validation"
            :data-vv-name="name"
            :error-messages="errors.collect(name)"
            :label="label"
            :hint="hintFormat"
            persistent-hint
            prepend-icon="event"
            @blur="dateString = parseDate(dateFormatted)" />
        <v-date-picker
            v-model="dateString"
            no-title
            @input="menu = false"
            :locale="settings.language">
        </v-date-picker>
    </v-menu>
</template>

<script lang="ts">

import { Vue, Prop, Component, Watch } from 'vue-property-decorator';
import { Getter, namespace } from 'vuex-class';

import BaseComponent from '../BaseComponent.vue';
import Helpers from './../../helpers';

@Component({})
export default class DatePickerComponent extends BaseComponent {
    @Prop({default: undefined})
    private date: Date;
    @Prop({default: 'date' })
    private name: string;
    @Prop({default: undefined})
    private validation: object;
    @Prop({default: ''})
    private label: string;

    private dateFormatted: string = null;
    private menu: boolean = false;
    private dateString: string = null;

    @Watch('dateString') private watchDate(date) {
        if (date === undefined) {
            return;
        }

        this.dateFormatted = this.formatDate(date);

        const [year, month, day] = date.split('-');
        const now = new Date();
        now.setFullYear(year, Number(month) - 1, day);

        this.$emit('date', now);
    }

    get hintFormat(): string {
        return `DD.MM.YYYY ${this.settings.resource.format}`;
    }

    private mounted() {
        if (!this.date) {
            return;
        }

        this.dateString = `${this.date.getFullYear()}-${this.date.getMonth() + 1}-${this.date.getDate()}`;
    }

    private formatDate(date: string): string {
        if (!date) {
            return;
        }

        const [year, month, day] = date.split('-');
        const parsedMonth = month.length === 1 ? `0${month}` : month;
        const parsedDay = day.length === 1 ? `0${day}` : day;

        return `${parsedDay}.${parsedMonth}.${year}`;
    }

    private parseDate(date: string): string {
        if (!date) {
            return;
        }

        const [day, month, year] = date.split('.');
        const parsedMonth = month.length === 1 ? `0${month}` : month;
        const parsedDay = day.length === 1 ? `0${day}` : day;
        return `${year}-${parsedMonth}-${parsedDay}`;
    }
}

</script>