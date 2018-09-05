import { MutationTree } from 'vuex';

import { ProfileState } from '@/store/types';
import { User, Customer, Address } from '@/model';
import { RecordTableDto } from '@/poco';

const mutations: MutationTree<ProfileState> = {
    /**
     * Mutate state of user
     * @param state Store state
     * @param user changing user object
     */
    USER_CHANGE(state, user: User) {
        state.error = false;
        state.errorMessage = undefined;
        state.user = user;
    },

    /**
     * User object initialization
     * @param state Store state
     */
    USER_INITIAL_STATE(state) {
        state.error = false;
        state.list = [];
        state.user = {
            id: undefined,
            customerId: undefined,
            created: new Date(),
            userName: '',
            password: '',
            isActive: false,
            isAgreementToTerms: null,
            sendingNews: false,
            token: '',
            customer: undefined,
            language: 'cs',
        };
        state.usersCurrent = [] as RecordTableDto[];
        state.usersEnded = [] as RecordTableDto[];
    },
    USER_CHANGE_USERS_CURRENT_AUCTIONS(state, records: RecordTableDto[]) {
        state.error = records === undefined;
        state.usersCurrent = records;
    },
    USER_CHANGE_USERS_ENDED_AUCTIONS(state, records: RecordTableDto[]) {
        state.error = records === undefined;
        state.usersEnded = records;
    },
    USER_SET_CURRENT_USER(state, user: User) {
        state.error = user !== undefined && user !== null;
        state.user = user;
    },
    USER_SET_CURRENT_USERS_CUSTOMER(state, customer: Customer) {
        state.error = customer !== undefined && customer !== null && state.user !== undefined;
        if (state.user) {
            state.user.customer = customer;
        }
    },
    USER_SET_CURRENT_USER_CUSTOMERS_ADDRESS(state, address: Address) {
        state.error = address !== undefined &&
            address !== null &&
            state.user !== undefined &&
            state.user.customer !== undefined;

        if (state.user && state.user.customer) {
            state.user.customer.address = address;
        }
    },
    USER_CHANGE_ADMIN_LIST(state, users: User[]) {
        state.error = users !== undefined;
        state.list = users;
    },
};

export default mutations;
