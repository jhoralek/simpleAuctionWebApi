<template>
    <v-menu
        v-if="innerTime !== undefined"
        ref="menu"
        :close-on-content-click="false"
        v-model="menu"
        :nudge-right="40"
        :return-value.sync="innerTime"
        lazy
        transition="scale-transition"
        offset-y
        full-width
        max-width="290px"
        min-width="290px"
    >
        <v-text-field
            slot="activator"
            v-model="innerTime"
            :label="label"
            prepend-icon="access_time"
            readonly
            :error-messages="errors.collect(name)"
            :data-vv-name="name"
            v-validate="validation" />
        <v-time-picker
            color="blue-grey darken-1"
            :format="format"
            v-if="menu"
            v-model="innerTime"
            @change="$refs.menu.save(innerTime)" />
    </v-menu>
</template>

<script lang="ts">

import { Vue, Prop, Component, Watch } from 'vue-property-decorator';
import { Getter, namespace } from 'vuex-class';

import BaseComponent from '../BaseComponent.vue';

@Component({})
export default class TimePickerComponent extends BaseComponent {
    @Prop({default: null})
    private time: string;
    @Prop({default: undefined})
    private name: string;
    @Prop({default: undefined})
    private validation: object;
    @Prop({default: ''})
    private label: string;
    @Prop({default: '24hr'})
    private format: string;

    private menu: boolean = false;
    private innerTime: string = null;

    @Watch('innerTime')
    private innerTimeChange(time) {
        if (time === undefined) {
            return;
        }

        this.$emit('time', time);
    }

    private mounted() {
        this.innerTime = this.time;
    }
}

</script>