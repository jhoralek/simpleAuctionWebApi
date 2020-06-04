<template>
    <v-dialog v-model="dialog" persistent max-width="400px">
        <v-form class="question-dialog">
            <v-card>
                <v-progress-linear v-if="progress" indeterminate></v-progress-linear>
                <v-card-title class="headline grey lighten-2">
                    {{ header }}
                </v-card-title>
                <v-card-text v-html="question">
                </v-card-text>
                <v-divider></v-divider>
                <v-card-actions>
                    <v-container>
                        <v-layout row wrap justify-end align-center>
                            <v-btn color="black" :disabled="progress" @click="cancel">{{ resx('cancel') }}</v-btn>
                            <v-btn color="black" :disabled="progress" @click="submit">{{ resx('submit' )}}</v-btn>
                        </v-layout>
                    </v-container>
                </v-card-actions>
            </v-card>
        </v-form>
    </v-dialog>
</template>

<script lang="ts">

import { Component, Prop, Watch } from 'vue-property-decorator';
import BaseComponent from '../BaseComponent.vue';

@Component({})
export default class QuestionDialogComponent extends BaseComponent {
    @Prop({default: 'Question'})
    private header: string;
    @Prop({default: undefined})
    private question: string;
    @Prop({default: false})
    private dialog: boolean;

    private progress: boolean = false;

    @Watch('dialog')
    private watchDialog(newDialog) {
        if (newDialog !== undefined) {
            if (newDialog === false) {
                this.progress = newDialog;
            }
        }
    }

    private cancel() {
        this.$emit('result', false);
    }

    private submit() {
        this.progress = true;
        this.$emit('result', true);
    }
}

</script>

<style>

.question-dialog .v-btn {
    color: white !important;
    border-radius: 5px !important;
}

</style>