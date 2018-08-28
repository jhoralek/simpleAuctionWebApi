import { Module } from 'vuex';
import { RootState,  AuctionState } from '@/store/types';

import getters from '@/store/modules/auction/getters';
import actions from '@/store/modules/auction/actions';
import mutations from '@/store/modules/auction/mutations';

export const state: AuctionState = {
    auctionsTable: undefined,
    auctions: undefined,
    current: undefined,
};

const namespaced: boolean = true;

export const auction: Module<AuctionState, RootState> = {
    namespaced,
    state,
    getters,
    actions,
    mutations,
};
