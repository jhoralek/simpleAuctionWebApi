import { Module } from 'vuex';
import { RootState, RecordState } from '@/store/types';

import actions from './actions';
import getters from './getters';
import mutations from './mutations';

export const state: RecordState = {
    current: undefined,
    records: undefined,
    error: false,
};

const namespaced: boolean = true;

export const record: Module<RecordState, RootState> = {
    namespaced,
    state,
    actions,
    getters,
    mutations,
};
