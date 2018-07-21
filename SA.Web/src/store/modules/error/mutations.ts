import { MutationTree } from 'vuex';

import { ErrorState } from '@/store/types';

const mutations: MutationTree<ErrorState> = {
    /**
     * Initializaction of error state
     * @param state Error state
     */
    ERROR_INITIAL_STATE(state) {
        state.error = false;
        state.message = undefined;
    },
    /**
     * Change error state
     * @param state Error state
     * @param param1 Object error to mutate state
     */
    ERROR_CHANGE_STATE(state, { error }) {
        state.error = error.error;
        state.message = error.message;
    },
};

export default mutations;
