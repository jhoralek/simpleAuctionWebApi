import { ActionTree } from 'vuex';

import {
    RootState,
    MessageState,
} from '@/store/types';

import { MessageDto } from '@/poco';

import {
    MESSAGE_INITIAL_STATE,
    MESSAGE_CHANGE_STATE,
} from '@/store/mutation-types';

const actions: ActionTree<MessageState, RootState> = {
    /**
     * Initial state
     * @param param - comit with mutating of the state
     */
    initialState({commit}): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(MESSAGE_INITIAL_STATE);
            return resolve(true);
        });
    },
    /**
     * Change state of the message state
     * @param param0 Commit with mutation of the message state
     * @param mod Module name from where the message become
     * @param message Object of message state
     */
    change({commit}, { mod, message }): void {
        commit(MESSAGE_CHANGE_STATE, { mod, message });
    },
};

export default actions;
