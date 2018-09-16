import { Module } from 'vuex';
import { RootState, ProfileState } from '@/store/types';

import getters from '@/store/modules/profile/getters';
import actions from '@/store/modules/profile/actions';
import mutations from '@/store/modules/profile/mutations';

// my profile state will grow depends on the app,
// or I can create more profiles
export const state: ProfileState = {
    user: undefined,
    usersCurrent: [],
    usersEnded: [],
    list: [],
    error: false,
    errorMessage: undefined,
    customerCurrent: undefined,
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
