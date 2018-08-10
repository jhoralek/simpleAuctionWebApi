import { MutationTree } from 'vuex';
import { RecordState } from '@/store/types';
import { Record } from '@/model';

const mutations: MutationTree<RecordState> = {
    /**
     * Initialization of the state
     * @param state Record state
     */
    RECORD_INITIAL_STATE(state) {
        state.current = undefined;
        state.records = [];
        state.error = false;
    },
    RECORD_INITIAL_CURRENT(state) {
        state.error = false;
        state.current = {
            isActive: false,
        } as Record;
    },
    /**
     * Change current record state
     * @param state - Record state
     * @param record - value of record
     */
    RECORD_CHANGE_CURRENT_STATE(state, record: Record) {
        state.error = false;
        state.current = record;
    },
    /**
     * Change list of records
     * @param state - Record state
     * @param records - list of records
     */
    RECORD_CHANGE_LIST_STATE(state, records: Record[]) {
        state.error = false;
        state.records = records;
    },
};

export default mutations;
