<template>
    <span classs="count-down" :id="countDownSelector()"></span>
</template>

<script lang="ts">

import { Vue, Prop, Component } from 'vue-property-decorator';
import Helpers from '@/helpers';

@Component({})
export default class CountdownComponent extends Vue {
    @Prop({default: undefined}) public date: string;
    @Prop({default: 1}) public id: string;

    public mounted() {
        const realDate = new Date(this.date);

        const x = setInterval(() => {
            const element = document.getElementById(`count-down-${this.id}`);

            if (element !== null) {
                const thick = Helpers.countDown(realDate);
                element.innerHTML = thick;
            }
        }, 1000);
    }

    private countDownSelector(): string {
        return `count-down-${this.id}`;
    }
}

</script>

<style>
.count-down {
  margin-left: 5px;
}
</style>