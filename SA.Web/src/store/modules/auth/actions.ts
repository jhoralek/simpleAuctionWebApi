import { ActionTree } from 'vuex';
import axios from 'axios';
import {
    RootState,
    AuthState,
} from '@/store/types';
import {
    AuthResponse,
    LoginDto,
 } from '@/poco';

import {
    AUTH_LOGIN_USER,
    AUTH_LOGOUT_USER,
    AUTH_INITIAL_STATE,
} from '@/store/mutation-types';

const actions: ActionTree<AuthState, RootState> = {
    /**
     * Login user
     * Will change token after user is successfuly logged in change state
     * @param param - commit with mutating of the state
     * @param login - object with login information
     */
    loginUser({commit, rootState, dispatch}, login: LoginDto): Promise<AuthResponse> {
        return new Promise<AuthResponse>((resolve) => {
            return axios.post(`${rootState.settings.apiUrl}/accounts/login`, {
                    UserName: login.userName,
                    Password: login.password })
                .then((response) => {
                    const user: AuthResponse = response.data as AuthResponse;
                    commit(AUTH_LOGIN_USER, { login, user });
                    if (user.error !== null) {
                        dispatch('error/change',
                        { error: true, message: user.error },
                        { root: true });
                    }
                    return resolve(user);
                })
                .catch((error) => {
                    dispatch('error/change',
                        { error: true, message: error },
                        { root: true });
                    return resolve({ error } as AuthResponse);
                });
        });
    },
    /**
     * Reset LoginUser object
     * @param param - cmmit with mutating of the state
     */
    logoutUser({commit}): void {
        commit(AUTH_LOGOUT_USER);
    },
    /**
     * Initial state
     * @param param - comit with mutating of the state
     */
    initialState({commit}): void {
        commit(AUTH_INITIAL_STATE);
    },
};

export default actions;
