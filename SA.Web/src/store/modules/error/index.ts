import { Module } from 'vuex';
import { RootState,  ErrorState } from '@/store/types';

import getters from './getters';
import actions from './actions';
import mutations from './mutations';

export const state: ErrorState = {
    error: false,
    message: undefined,
};

const namespaced: boolean = true;

export const error: Module<ErrorState, RootState> = {
    namespaced,
    state,
    getters,
    actions,
    mutations,
};
