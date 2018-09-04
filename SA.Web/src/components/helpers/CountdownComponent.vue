<template>
    <div class="count-down" :id="countDownSelector()"></div>
</template>

<script lang="ts">

import { Vue, Prop, Component, Watch } from 'vue-property-decorator';
import Helpers from '@/helpers';

import BaseComponent from '../BaseComponent.vue';
import { clearTimeout, setTimeout } from 'timers';

@Component({})
export default class CountdownComponent extends BaseComponent {
    @Prop({default: undefined}) private date: string;
    @Prop({default: undefined}) private startDate: string;
    @Prop({default: 1}) private id: string;

    private counter: any = null;

    @Watch('date') private changeDate(newDate) {
        if (newDate !== undefined) {
            this.setCountdownWatch(new Date(this.startDate), newDate);
        }
    }

    private mounted() {
        const validTo = new Date(this.date);
        const validFrom = new Date(this.startDate);

        this.setCountdownWatch(validFrom, validTo);
    }

    private beforeDestroy() {
        if (this.counter !== null) {
            clearInterval(this.counter);
        }
    }

    private setCountdownWatch(validFrom: Date, validTo: Date) {

        if (this.counter !== null) {
            clearInterval(this.counter);
        }

        this.counter = setInterval(() => {
            const element = document.getElementById(`count-down-${this.id}`);

            if (element !== null) {
                const valueForThick = Helpers.countDown(validTo);
                const thick = valueForThick === 'endOfAcution'
                    ? this.settings.resource.endOfAuction
                    : valueForThick;

                if (this.startDate !== undefined) {
                    if (new Date() < validFrom) {
                        element.innerHTML = '--d --h --m --s';
                    } else {
                        element.innerHTML = thick;
                    }
                } else {
                    element.innerHTML = thick;
                }
            }
        }, 1000);
    }

    private countDownSelector(): string {
        return `count-down-${this.id}`;
    }
}

</script>
