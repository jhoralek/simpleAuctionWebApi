import { Module } from 'vuex';
import { RootState, SettingsState } from '@/store/types';

import getters from '@/store/modules/settings/getters';
import actions from '@/store/modules/settings/actions';
import mutations from '@/store/modules/settings/mutations';

export const state: SettingsState = {
    language: undefined,
    resource: undefined,
    countries: undefined,
    apiUrl: undefined,
};

const namespaced: boolean = true;

export const settings: Module<SettingsState, RootState> = {
    namespaced,
    state,
    getters,
    actions,
    mutations,
};
