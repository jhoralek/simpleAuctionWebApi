<template>
    <v-snackbar v-if="message.isOn"
        :color="messageColor"
        v-model="message.isOn"
        :bottom="true"
        :multi-line="true"
        :right="true"
        :timeout="timeout"
        :vertical="true">
        {{ showMessage }}
        <v-btn
            color="white"
            flat
            @click="callback()">
            {{ resx(message.buttonText) }}
        </v-btn>
    </v-snackbar>
</template>

<script lang="ts">
import { Component } from 'vue-property-decorator';
import { State, Action, Getter, namespace } from 'vuex-class';

import { MessageState } from './../store/types';
import { MessageDto } from './../poco';
import { MessageStatusEnum } from './../model';

import BaseComponent from '@/components/BaseComponent.vue';

const MessageGetter = namespace('message', Getter);
const MessageAction = namespace('message', Action);

@Component({})
export default class MessageComponent extends BaseComponent {
  @State('message')
  public message: MessageState;

  @MessageGetter('getMessage')
  public innerMessage: MessageDto;

  @MessageAction('initialState')
  public initMessage: any;

  public callback() {
      if (this.message.callbackFnc !== undefined) {
        this.message.callbackFnc();
        this.initMessage();
      } else {
          // call close only snackbar windows
          this.initMessage();
      }
  }

  get messageColor() {
    switch (this.innerMessage.state) {
      case MessageStatusEnum.Success:
        return 'blue-grey darken-1';
      case MessageStatusEnum.Warning:
        return 'amber darken-3';
      case MessageStatusEnum.Error:
        return 'red darken-4';
      default:
        // menas other
        return 'grey darkent-3';
    }
  }

  get messageInner() {
    return this.innerMessage.message;
  }

  get timeout() {
    return this.message.timeout;
  }

  get showMessage() {
      return this.message.fromResources
        ? this.resx(this.innerMessage.message)
        : this.innerMessage.message;
  }
}
</script>
