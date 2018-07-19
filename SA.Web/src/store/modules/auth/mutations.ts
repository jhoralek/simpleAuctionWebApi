import { MutationTree } from 'vuex';

import { AuthState } from '@/store/types';

const mutations: MutationTree<AuthState> = {
    /**
     * Initialization of the state
     * @param state Auth state
     */
    AUTH_INITIAL_STATE(state) {
        state.isAuthenticated = false;
        state.login = { userName: '', password: '' };
        state.token = undefined;
        state.userName = undefined;
        state.error = false;
    },
    /**
     * Mutate state of login
     * @param state Store state
     * @param any - contains login and user object
     */
    AUTH_LOGIN_USER(state, { login, user }) {
        state.login = login;
        state.userName = user.userName;
        state.token  = user.token;
        state.isAuthenticated = user !== undefined;
        state.error = user === undefined;
    },
    /**
     * Logout user
     * @param state Store state of auth
     */
    AUTH_LOGOUT_USER(state) {
        state.isAuthenticated = false;
        state.login = { userName: '', password: '' };
        state.token = undefined;
        state.userName = undefined;
        state.error = false;
    },
};

export default mutations;
