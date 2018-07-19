import { ActionTree } from 'vuex';
import {
    RootState,
    RecordState,
} from '@/store/types';

import { Record } from '@/model';

import {
    RECORD_INITIAL_STATE,
    RECORD_CHANGE_LIST_STATE,
    RECORD_CHANGE_CURRENT_STATE,
} from '@/store/mutation-types';

import { RecordService } from '@/services';

const service: RecordService = new RecordService();

const actions: ActionTree<RecordState, RootState> = {
    /**
     * Initial state of Record object
     * @param param - commit
     */
    initialState({ commit }): Promise<boolean> {
        return new Promise<boolean>((resolver) => {
            commit(RECORD_INITIAL_STATE);
            return resolver(true);
        });
    },
    /**
     * Load all active records
     */
    loadAllActive({commit}): Promise<Record[]> {
        return service.getAllActive().then((records) => {
            commit(RECORD_CHANGE_LIST_STATE, records);
            return records;
        });
    },
    /**
     * Get record detail by id
     * @param id - record id
     */
    getDetail({ commit }, id: number): Promise<Record> {
        return service.getById(id).then((record) => {
            commit(RECORD_CHANGE_CURRENT_STATE, record);
            return record;
        });
    },
};

export default actions;
