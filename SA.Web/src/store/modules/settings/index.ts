import { Module } from 'vuex';
import { RootState, SettingsState } from '@/store/types';

import getters from './getters';
import actions from './actions';
import mutations from './mutations';

export const state: SettingsState = {
    language: undefined,
    resource: undefined,
    countries: undefined,
};

const namespaced: boolean = true;

export const settings: Module<SettingsState, RootState> = {
    namespaced,
    state,
    getters,
    actions,
    mutations,
};
