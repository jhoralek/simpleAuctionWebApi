import { MutationTree } from 'vuex';

import { AuthState } from '@/store/types';

const mutations: MutationTree<AuthState> = {
    /**
     * Initialization of the state
     * @param state Auth state
     */
    AUTH_INITIAL_STATE(state) {
        state.userId = undefined;
        state.customerId = undefined;
        state.isAuthenticated = false;
        state.token = undefined;
        state.language = undefined;
        state.userName = undefined;
        state.error = false;
        state.errorMessage = undefined;
        state.isDealer = false;
    },
    /**
     * Mutate state of login
     * @param state Store state
     * @param any - contains login and user object
     */
    AUTH_LOGIN_USER(state, { user }) {
        state.userId = user.userId;
        state.customerId = user.customerId;
        state.userName = user.userName;
        state.token  = user.token;
        state.language = user.language;
        state.isAuthenticated = user.error === null;
        state.error = user.error !== null;
        state.errorMessage = user.error;
        state.isDealer = user.isDealer;
    },
    /**
     * Logout user
     * @param state Store state of auth
     */
    AUTH_LOGOUT_USER(state) {
        state.userId = undefined;
        state.customerId = undefined;
        state.isAuthenticated = false;
        state.token = undefined;
        state.language = undefined;
        state.userName = undefined;
        state.error = false;
        state.errorMessage = undefined;
    },
    AUTH_SET_LANGUAGE(state, language: string) {
        state.language = language;
        state.error = language !== undefined;
    },
};

export default mutations;
