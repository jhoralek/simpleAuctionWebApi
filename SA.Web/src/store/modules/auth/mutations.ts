import { MutationTree } from 'vuex';

import { AuthState } from '@/store/types';

const mutations: MutationTree<AuthState> = {
    /**
     * Initialization of the state
     * @param state Auth state
     */
    AUTH_INITIAL_STATE(state) {
        state.isAuthenticated = false;
        state.token = undefined;
        state.language = undefined;
        state.userName = undefined;
        state.error = false;
        state.errorMessage = undefined;
    },
    /**
     * Mutate state of login
     * @param state Store state
     * @param any - contains login and user object
     */
    AUTH_LOGIN_USER(state, { user }) {
        state.userName = user.userName;
        state.token  = user.token;
        state.language = user.language;
        state.isAuthenticated = user.error === null;
        state.error = user.error !== null;
        state.errorMessage = user.error;
    },
    /**
     * Logout user
     * @param state Store state of auth
     */
    AUTH_LOGOUT_USER(state) {
        state.isAuthenticated = false;
        state.token = undefined;
        state.language = undefined;
        state.userName = undefined;
        state.error = false;
        state.errorMessage = undefined;
    },
};

export default mutations;
