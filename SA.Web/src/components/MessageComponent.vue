<template>
    <v-snackbar v-if="message.isOn"
        :color="messageColor"
        v-model="message.isOn"
        :bottom="true"
        :multi-line="true"
        :right="true"
        :timeout="6000"
        :vertical="true">
        {{ resx(messageInner) }}
        <v-btn
            color="white"
            flat
            @click="initMessage">
            {{ resx('close') }}
        </v-btn>
    </v-snackbar>
</template>

<script lang="ts">

import { Component } from 'vue-property-decorator';
import { State, Action, Getter, namespace } from 'vuex-class';

import BaseComponent from '@/components/BaseComponent.vue';
import { MessageState } from '@/store/types';
import { MessageDto } from '@/poco';
import { MessageStatusEnum } from '@/model';

const MessageGetter = namespace('message', Getter);
const MessageAction = namespace('message', Action);

@Component({})
export default class MessageComponent extends BaseComponent {
    @State('message') public message: MessageState;

    @MessageGetter('getMessage') public innerMessage: MessageDto;
    @MessageAction('initialState') public initMessage: any;

    get messageColor() {
        switch (this.innerMessage.state) {
        case MessageStatusEnum.Success:
            return 'green darken-3';
        case MessageStatusEnum.Warning:
            return 'amber darken-3';
        case MessageStatusEnum.Error:
            return 'red darken-4';
        default: // menas other
            return 'grey darkent-3';
        }
    }

    get messageInner() {
        return this.innerMessage.message;
    }
}

</script>
