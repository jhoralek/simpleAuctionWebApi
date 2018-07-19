import { GetterTree } from 'vuex';

import {
    RootState,
    ProfileState,
} from '@/store/types';

import { User, Customer, Address } from '@/model';

const getters: GetterTree<ProfileState, RootState> = {
    /**
     * Return object of User or undefined
     * @param state - Store state
     */
    getUser(state): User | undefined {
        const { user } = state;
        return user;
    },
    /**
     * Get customer from user instance
     * @param state - Store state
     */
    getUsersCustomer(state): Customer {
        const { customer } = state.user && state.user;
        return customer;
    },
    /**
     * Get customers address
     * @param state - Store state
     */
    getCustomersAddress(state): Address {
        if (state.user.customer) {
            const { address } = state.user && state.user.customer && state.user.customer;
            return address;
        }
        return undefined;
    },
    /**
     * Check if Customer object is propperly loaded
     * @param state - Store state of profile
     */
    isCustomerLoaded(state): boolean {
        return state.user !== undefined
            && state.user.customer !== undefined;
    },
};

export default getters;
