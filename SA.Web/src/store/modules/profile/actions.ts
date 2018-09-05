import axios from 'axios';
import { ActionTree } from 'vuex';
import {
    RootState,
    ProfileState,
} from '@/store/types';

import { User, MessageStatusEnum, Customer, Address, GdprRecord } from '@/model';
import { UserShortInfo, UserSimpleDto, GdprRecordTableDto, RecordTableDto } from '@/poco';

import {
    USER_INITIAL_STATE,
    USER_CHANGE,
    USER_SET_CURRENT_USER,
    USER_SET_CURRENT_USERS_CUSTOMER,
    USER_SET_CURRENT_USER_CUSTOMERS_ADDRESS,
    USER_CHANGE_ADMIN_LIST,
    USER_CHANGE_USERS_CURRENT_AUCTIONS,
    USER_CHANGE_USERS_ENDED_AUCTIONS,
} from '@/store/mutation-types';

const actions: ActionTree<ProfileState, RootState> = {
    /**
     * Initial state of User object
     * @param param - commit
     */
    initialState({ commit }): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(USER_INITIAL_STATE);
            return resolve(true);
        });
    },
    loadLoggedUser({ commit, rootState, dispatch }): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            const { auth } = rootState;
            return axios.get(
                `${rootState.settings.apiUrl}/users/loadByNameAndToken?uName=${auth.userName}&token=${auth.token}`,
                { headers: { authorization: auth.token }})
                .then((response) => {
                    const user: User = response.data as User;
                    commit(USER_CHANGE, user);
                    resolve(true);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Profile',
                        message: {
                            state: MessageStatusEnum.Error,
                            message: error,
                        },
                    },
                    { root: true });
                    resolve(false);
                });
        });
    },
    /**
     * Load user to the store
     * @param param - commit
     */
    loadUser({ commit, rootState }, id: number): Promise<User> {
        return axios.get(`${rootState.settings.apiUrl}/users/${id}`)
            .then((response) => {
                return new Promise<User>((resolve) => {
                    const user: User = response.data as User;
                    commit(USER_CHANGE, user);
                    return resolve(user);
                });
            })
            .catch((error) => {
                return error;
            });
    },
    /**
     * Load user by userNam and valid token
     * @param param0 - commit with rootState
     * @param userInfo - User short object with userName and token
     */
    loadByUserNameAndToken({commit, rootState}, userInfo: UserShortInfo): Promise<User> {
        return new Promise<User>((resolve) => {
            return axios.post(`${rootState.settings.apiUrl}/users/loadByNameAndToken`,
                { userInfo })
                .then((response) => {
                    const user: User = response.data as User;
                    commit(USER_CHANGE, user);
                    return resolve(user);
                })
                .catch((error) => {
                    return error;
                });
        });
    },
    setCurrentUser({commit}, user: User): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(USER_SET_CURRENT_USER, user);
            return resolve(true);
        });
    },
    setCurrentUsersCustomer({commit}, customer: Customer): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(USER_SET_CURRENT_USERS_CUSTOMER, customer);
            return resolve(true);
        });
    },
    setCurrentUserCustomersAddress({commit}, address: Address): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(USER_SET_CURRENT_USER_CUSTOMERS_ADDRESS, address);
            return resolve(true);
        });
    },
    newUser({rootState, dispatch}, user: User): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            const { auth } = rootState;
            return axios.post(`${rootState.settings.apiUrl}/users/create`, user)
            .then((response) => {
                if (response) {
                    dispatch('message/change', {
                        mod: 'Profile',
                        message: {
                            state: MessageStatusEnum.Success,
                            message: 'createdSuccessfully',
                        },
                    },
                    { root: true });
                    return resolve(true);
                }
                return resolve(false);
            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Profile',
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
    updateUserAdmin({commit, rootState, dispatch}, user: UserSimpleDto): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            const { auth } = rootState;
            return axios.post(`${rootState.settings.apiUrl}/users/updateUserAdmin`, user,
                { headers: { authorization: auth.token }})
            .then((response) => {
                if (response) {
                    commit(USER_SET_CURRENT_USER, user);
                    dispatch('message/change', {
                        mod: 'Profile',
                        message: {
                            state: MessageStatusEnum.Success,
                            message: 'updatedSuccessfully',
                        },
                    },
                    { root: true });
                    return resolve(true);
                }
                return resolve(false);
            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Profile',
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
    getAllUsersForAdmin({commit, rootState, dispatch}): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            const { auth } = rootState;
            return axios.get(`${rootState.settings.apiUrl}/users/getAllUsersForAdmin`,
                { headers: { authorization: auth.token }})
            .then((response) => {
                commit(USER_CHANGE_ADMIN_LIST, response.data as UserSimpleDto[]);
                return resolve(true);
            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Profile',
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
    updateAddress({rootState, dispatch}, address: Address): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            const { auth } = rootState;
            return axios.put(`${rootState.settings.apiUrl}/addresses`, address,
                { headers: { authorization: auth.token }})
            .then((response) => {
                dispatch('message/change', {
                    mod: 'Profile',
                    message: {
                        state: MessageStatusEnum.Success,
                        message: 'updatedSuccessfully',
                    },
                },
                { root: true });
                return resolve(response.data !== undefined);
            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Profile',
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
    userUpdate({rootState, dispatch}, user: User): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            const { auth } = rootState;
            return axios.put(`${rootState.settings.apiUrl}/users`, user,
                { headers: { authorization: auth.token }})
            .then((response) => {
                if (rootState.auth.language !== user.language) {
                    dispatch('auth/setLanguage', user.language, { root: true });
                    dispatch('settings/changeLanguage', user.language, { root: true });
                }
                dispatch('message/change', {
                    mod: 'Profile',
                    message: {
                        state: MessageStatusEnum.Success,
                        message: 'updatedSuccessfully',
                    },
                },
                { root: true });
                return resolve(response.data !== undefined);
            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Profile',
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
    updateCustomer({rootState, dispatch}, customer: Customer): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            const { auth } = rootState;
            return axios.put(`${rootState.settings.apiUrl}/customers`, customer,
                { headers: { authorization: auth.token }})
            .then((response) => {
                dispatch('message/change', {
                    mod: 'Profile',
                    message: {
                        state: MessageStatusEnum.Success,
                        message: 'updatedSuccessfully',
                    },
                },
                { root: true });
                return resolve(response.data !== undefined);
            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Profile',
                    message: {
                        state: MessageStatusEnum.Error,
                        message: error,
                    },
                },
                { root: true });
                return resolve(false);
            });
            return resolve(true);
        });
    },
    createGdprRequest({rootState, dispatch}, request: GdprRecord): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return axios.post(`${rootState.settings.apiUrl}/gdprRecords/create`, request)
                .then((response) => {
                    dispatch('message/change', {
                        mod: 'Profile',
                        message: {
                            state: MessageStatusEnum.Success,
                            message: 'gdprSendSuccessfully',
                        },
                    },
                    { root: true });
                    return resolve(response.data !== undefined);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Profile',
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
    getAllGdprRecordsForAdmin({rootState, dispatch}): Promise<GdprRecordTableDto> {
        return axios.get(`${rootState.settings.apiUrl}/gdprRecords/getAllGdprRecordsAdmin`,
            { headers: { authorization: rootState.auth.token }})
        .then((response) => {
            const { data } = response;
            return data as GdprRecordTableDto[];
        })
        .catch((error) => {
            dispatch('message/change', {
                mod: 'Profile',
                message: {
                    state: MessageStatusEnum.Error,
                    message: error,
                },
            },
            { root: true });
            return null;
        });
    },
    checkUserName({rootState, dispatch}, userName: string): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return axios.get(`${rootState.settings.apiUrl}/users/checkUserName?userName=${userName}`)
                .then((response) => {
                    return resolve(response.data as boolean);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Profile',
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
    checkEmail({rootState, dispatch}, email: string): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return axios.get(`${rootState.settings.apiUrl}/users/checkEmail?email=${email}`)
                .then((response) => {
                    return resolve(response.data as boolean);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Profile',
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
    loadUsersCurrentAuctions({commit, rootState, dispatch}): Promise<boolean> {
        return new Promise<boolean>((resolve) => {

            const { userId, token } = rootState.auth;
            const { apiUrl } = rootState.settings;

            return axios.get(`${apiUrl}/users/getUsersCurrentAuctions?userId=${userId}`,
                { headers: { authorization: token }})
                .then((response) => {
                    commit(USER_CHANGE_USERS_CURRENT_AUCTIONS, response.data as RecordTableDto[]);
                    return resolve(true);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Profile',
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
    loadUsersEndedAuctions({commit, rootState, dispatch}): Promise<boolean> {
        return new Promise<boolean>((resolve) => {

            const { userId, token } = rootState.auth;
            const { apiUrl } = rootState.settings;

            return axios.get(`${apiUrl}/users/getUsersEndedAuctions?userId=${userId}`,
                { headers: { authorization: token }})
                .then((response) => {
                    commit(USER_CHANGE_USERS_ENDED_AUCTIONS, response.data as RecordTableDto[]);
                    return resolve(true);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Profile',
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
};

export default actions;
