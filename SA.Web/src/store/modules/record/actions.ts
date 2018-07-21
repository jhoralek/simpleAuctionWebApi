import axios from 'axios';
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
    loadAllActive({commit, rootState}): Promise<Record[]> {
        return axios.get(`${rootState.settings.apiUrl}/records`)
            .then((response) => {
                const records: Record[] = response.data as Record[];
                commit(RECORD_CHANGE_LIST_STATE, records);
                return records;
            })
            .catch((error) => {
                return error;
            });
    },
    /**
     * Get record detail by id
     * @param id - record id
     */
    getDetail({ commit, rootState }, id: number): Promise<Record> {
        return axios.get(`${rootState.settings.apiUrl}/records/${id}`)
        .then((response) => {
            const record: Record = response.data as Record;
            commit(RECORD_CHANGE_CURRENT_STATE, record);
            return record;
        })
        .catch((error) => {
            return error;
        });
    },
};

export default actions;
