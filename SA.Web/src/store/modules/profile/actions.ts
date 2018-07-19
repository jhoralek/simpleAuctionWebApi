import { ActionTree } from 'vuex';
import {
    RootState,
    ProfileState,
} from '@/store/types';

import { User } from '@/model';

import {
    USER_INITIAL_STATE,
    USER_CHANGE,
} from '@/store/mutation-types';

import { UserService } from '@/services';

const service: UserService = new UserService();

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
    /**
     * Load user to the store
     * @param param - commit
     */
    loadUser({ commit }, id: number): Promise<User> {
        return service.getById(id).then((user) => {
            commit(USER_CHANGE, user);
            return user;
        });
    },
    /**
     * Load user by his token string
     * - Used when web page is reloaded by browser. Then we need to
     *   load user from localStorage where the auth store is located
     * @param param - commit
     * @param token - User's unique token string
     */
    loadByToken({ commit }, token: string): Promise<User> {
        return service.getByToken(token).then((user) => {
            commit(USER_CHANGE, user);
            return user;
        });
    },
    /**
     * Update user in storage (reload state and return the object)
     * @param param - commit
     * @param user - user object
     */
    updateUser({ commit }, user: User): Promise<User> {
        return service.updateUser(user).then((response) => {
            commit(USER_CHANGE, response);
            return response;
        });
    },
};

export default actions;
