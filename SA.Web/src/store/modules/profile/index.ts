import { Module } from 'vuex';
import { RootState, ProfileState } from '@/store/types';

import getters from './getters';
import actions from './actions';
import mutations from './mutations';

// my profile state will grow depends on the app,
// or I can create more profiles
export const state: ProfileState = {
    user: undefined,
    error: false,
};

const namespaced: boolean = true;

// My state with getter, actions and mutations as a module
export const profile: Module<ProfileState, RootState> = {
    namespaced,
    state,
    getters,
    actions,
    mutations,
};
