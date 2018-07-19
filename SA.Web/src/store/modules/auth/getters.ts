import { GetterTree } from 'vuex';

import { RootState, AuthState, LoginUser } from '@/store/types';

const getters: GetterTree<AuthState, RootState> = {
    /**
     * Return object of Login
     * @param state Store state
     */
    getLogin(state): LoginUser | undefined {
        const { login } = state;
        return login;
    },
};

export default getters;
