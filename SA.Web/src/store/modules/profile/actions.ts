import axios from 'axios';
import { ActionTree } from 'vuex';
import {
    RootState,
    ProfileState,
} from '@/store/types';

import { User, MessageStatusEnum } from '@/model';
import { UserShortInfo } from '@/poco';

import {
    USER_INITIAL_STATE,
    USER_CHANGE,
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
};

export default actions;
