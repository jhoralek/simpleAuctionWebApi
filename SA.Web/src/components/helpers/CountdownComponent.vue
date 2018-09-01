<template>
    <div class="count-down" :id="countDownSelector()"></div>
</template>

<script lang="ts">

import { Vue, Prop, Component } from 'vue-property-decorator';
import Helpers from '@/helpers';

@Component({})
export default class CountdownComponent extends Vue {
    @Prop({default: undefined}) private date: string;
    @Prop({default: undefined}) private startDate: string;
    @Prop({default: 1}) private id: string;

    private mounted() {
        const realDate = new Date(this.date);
        const realStartDate = new Date(this.startDate);

        const x = setInterval(() => {
            const element = document.getElementById(`count-down-${this.id}`);

            if (element !== null) {
                const thick = Helpers.countDown(realDate);

                if (this.startDate !== undefined) {
                    if (new Date() < realStartDate) {
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
