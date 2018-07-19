import { ActionTree } from 'vuex';
import {
    RootState,
    AuthState,
    LoginUser,
} from '@/store/types';
import { User } from '@/model';

import {
    AUTH_LOGIN_USER,
    AUTH_LOGOUT_USER,
    AUTH_INITIAL_STATE,
} from '@/store/mutation-types';

import { AuthService } from '@/services';

const service: AuthService = new AuthService();

const actions: ActionTree<AuthState, RootState> = {
    /**
     * Login user
     * Will change token after user is successfuly logged in change state
     * @param param - commit with mutating of the state
     * @param login - object with login information
     */
    loginUser({commit}, login: LoginUser): Promise<User> {
         return service.login(login.userName, login.password).then((user) => {
             commit(AUTH_LOGIN_USER, { login, user });
             return user;
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
