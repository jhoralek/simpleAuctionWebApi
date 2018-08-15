import { Module } from 'vuex';
import { RootState,  AuthState } from '@/store/types';

import getters from '@/store/modules/auth/getters';
import actions from '@/store/modules/auth/actions';
import mutations from '@/store/modules/auth/mutations';

export const state: AuthState = {
    userId: undefined,
    userName: undefined,
    token: undefined,
    language: undefined,
    isAuthenticated: false,
    isDealer: false,
    isFeePayed: false,
    error: false,
    errorMessage: undefined,
};

const namespaced: boolean = true;

export const auth: Module<AuthState, RootState> = {
    namespaced,
    state,
    getters,
    actions,
    mutations,
};
