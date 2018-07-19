import { GetterTree } from 'vuex';
import {
    RootState,
    RecordState,
} from '@/store/types';

import { Record } from '@/model';

const getters: GetterTree<RecordState, RootState> = {
    /**
     * Check if the record state is not empty
     * @param state - Record's state
     */
    isRecordLoaded(state): boolean {
        return state.current !== undefined;
    },
    /**
     * Get current record in state
     * @param state - Record state
     */
    getCurrent(state): Record {
        const { current } = !state.error && state;
        return current;
    },
    /**
     *
     * @param state
     */
    getRecords(state): Record[] {
        const { records } = !state.error && state;
        return records;
    },
};

export default getters;
