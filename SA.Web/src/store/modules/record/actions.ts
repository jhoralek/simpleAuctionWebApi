import axios from 'axios';
import { ActionTree } from 'vuex';
import {
    RootState,
    RecordState,
} from '@/store/types';

import { Record, MessageStatusEnum } from '@/model';

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
        return new Promise<boolean>((resolve) => {
            commit(RECORD_INITIAL_STATE);
            return resolve(true);
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
    /**
     * Get all users active auctions where bidding
     * @param param0 Commit, root and dispatch object to manipulate and call other actions
     * @param id User id
     */
    getAllActiveWithUsersBids({commit, rootState, dispatch}, id: number): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return axios.get(
                `${rootState.settings.apiUrl}/records/allActiveWithUsersBids?id=${id}`,
                { headers: { authorization: rootState.profile.user.token } })
                .then((response) => {
                    const recods: Record[] = response.data as Record[];
                    commit(RECORD_CHANGE_LIST_STATE, recods);
                    return resolve(true);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Record',
                        message: {
                            state: MessageStatusEnum.Error,
                            message: error,
                        },
                    });
                });
        });
    },
    /**
     * Get actual price for record
     * @param param0 States
     * @param id idRecord
     */
    getActualPrice({rootState, dispatch}, id: number): Promise<number> {
        return new Promise<number>((resolve) => {
            return axios.get(`${rootState.settings.apiUrl}/bids/getActualPrice?id=${id}`,
            { headers: { authorization: rootState.profile.user.token } })
                .then((response) => {
                    return resolve(response.data as number);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Record',
                        message: {
                            state: MessageStatusEnum.Error,
                            message: error,
                        },
                    });
                });
        });
    },
};

export default actions;
