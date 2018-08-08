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

import { MessageStatusEnum } from '@/model';

import {
    AUTH_LOGIN_USER,
    AUTH_LOGOUT_USER,
    AUTH_INITIAL_STATE,
    AUTH_SET_LANGUAGE,
} from '@/store/mutation-types';

const actions: ActionTree<AuthState, RootState> = {
    /**
     * Login user
     * Will change token after user is successfuly logged in change state
     * @param param - commit with mutating of the state
     * @param login - object with login information
     */
    loginUser({commit, rootState, dispatch}, login: LoginDto): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return axios.post(`${rootState.settings.apiUrl}/accounts/login`, {
                UserName: login.userName,
                Password: login.password })
            .then((response) => {
                const user: AuthResponse = response.data as AuthResponse;
                commit(AUTH_LOGIN_USER, { login, user });
                if (user.error !== null) {
                    dispatch('message/change',
                        {
                            mod: 'Auth',
                            message: {
                                state: MessageStatusEnum.Error,
                                message: user.error,
                            },
                        },
                        { root: true });
                    return resolve(false);
                } else {
                    dispatch('message/change', {
                            mod: 'Auth',
                            message: {
                                state: MessageStatusEnum.Success,
                                message: 'userLoggedInSuccessfully',
                            },
                        },
                        { root: true });
                    return resolve(true);
                }
            })
            .catch((error) => {
                dispatch('message/change', {
                        mod: 'Auth',
                        message: {
                            state: MessageStatusEnum.Error,
                            message: error,
                        },
                    },
                    { root: true });
                return resolve(false);
            });
        });
    },
    /**
     * Reset LoginUser object
     * @param param - cmmit with mutating of the state
     */
    logoutUser({commit, dispatch}): void {
        commit(AUTH_LOGOUT_USER);
        dispatch('message/change', {
                mod: 'Auth',
                message: {
                    state: MessageStatusEnum.Success,
                    message: 'userLoggedOutSuccessfully',
                },
        },
        { root: true });
    },
    /**
     * Initial state
     * @param param - comit with mutating of the state
     */
    initialState({commit}): void {
        commit(AUTH_INITIAL_STATE);
    },
    setLanguage({commit}, language: string): void {
        commit(AUTH_SET_LANGUAGE, language);
    },
};

export default actions;
