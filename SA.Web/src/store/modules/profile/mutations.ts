import { MutationTree } from 'vuex';

import { ProfileState } from '@/store/types';
import { User } from '@/model';

const mutations: MutationTree<ProfileState> = {
    /**
     * Mutate state of user
     * @param state Store state
     * @param user changing user object
     */
    USER_CHANGE(state, user: User) {
        state.error = false;
        state.user = user;
    },

    /**
     * User object initialization
     * @param state Store state
     */
    USER_INITIAL_STATE(state) {
        state.error = false;
        state.user = {
            userName: '',
            password: '',
            isActive: false,
            isAgreementToTerms: false,
            sendingNews: false,
            token: '',
            customer: undefined,
            language: 'cs',
        };
    },
};

export default mutations;
