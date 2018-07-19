import { Module } from 'vuex';
import { RootState,  AuthState } from '@/store/types';

import getters from './getters';
import actions from './actions';
import mutations from './mutations';

export const state: AuthState = {
    login: undefined,
    userName: undefined,
    token: undefined,
    isAuthenticated: false,
    error: false,
};

const namespaced: boolean = true;

export const auth: Module<AuthState, RootState> = {
    namespaced,
    state,
    getters,
    actions,
    mutations,
};
