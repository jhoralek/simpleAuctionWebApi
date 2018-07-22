import { Module } from 'vuex';
import { RootState,  MessageState } from '@/store/types';

import getters from '@/store/modules/message/getters';
import actions from '@/store/modules/message/actions';
import mutations from '@/store/modules/message/mutations';

export const state: MessageState = {
    isOn: false,
    module: undefined,
    created: undefined,
    message: undefined,
};

const namespaced: boolean = true;

export const message: Module<MessageState, RootState> = {
    namespaced,
    state,
    getters,
    actions,
    mutations,
};
