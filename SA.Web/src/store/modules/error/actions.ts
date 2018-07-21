import { ActionTree } from 'vuex';

import {
    RootState,
    ErrorState,
} from '@/store/types';

import { Error } from '@/poco';

import {
    ERROR_INITIAL_STATE,
    ERROR_CHANGE_STATE,
} from '@/store/mutation-types';

const actions: ActionTree<ErrorState, RootState> = {
    /**
     * Initial state
     * @param param - comit with mutating of the state
     */
    initialState({commit}): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(ERROR_INITIAL_STATE);
            return resolve(true);
        });
    },
    /**
     * Change state of the error state
     * @param param0 Commit with mutation of the error state
     * @param error Object of error state
     */
    change({commit}, error: Error): void {
        commit(ERROR_CHANGE_STATE, { error });
    },
};

export default actions;
