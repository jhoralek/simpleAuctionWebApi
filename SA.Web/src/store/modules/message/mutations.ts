import { MutationTree } from 'vuex';

import { MessageState } from '@/store/types';

const mutations: MutationTree<MessageState> = {
    /**
     * Initializaction of error state
     * @param state Error state
     */
    MESSAGE_INITIAL_STATE(state) {
        state.isOn = false;
        state.module = undefined;
        state.created = undefined;
        state.message = undefined;
    },
    /**
     * Change error state
     * @param state Error state
     * @param param1 Object error to mutate state
     */
    MESSAGE_CHANGE_STATE(state, { mod, message } ) {
        state.isOn = true;
        state.module = mod;
        state.created = new Date();
        state.message = message;
    },
};

export default mutations;
