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
    RECORD_INITIAL_CURRENT,
    RECORD_DELETE_RECORD_FROM_LIST,
    RECORD_SET_CURRENT_FILES,
    RECORD_SET_CURRENT_USER_ID,
} from '@/store/mutation-types';
import { RecordTableDto, FileSimpleDto } from '@/poco';

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
    initialCurrent({commit}): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(RECORD_INITIAL_CURRENT);
            return resolve(true);
        });
    },
    /**
     * Load all active records
     */
    loadAllPublished({commit, rootState, dispatch}): Promise<boolean> {
        return new Promise<boolean> ((resolve) => {
            return axios.get(
                `${rootState.settings.apiUrl}/records/getAllForList`)
                .then((response) => {
                    const records: Record[] = response.data as Record[];

                    commit(RECORD_CHANGE_LIST_STATE, records);
                    return resolve(true);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Record',
                        message: {
                            state: MessageStatusEnum.Error,
                            message: error,
                        },
                    },
                    { root: true});
                    return resolve(false);
                });
        });
    },
    /**
     * Get record detail by id
     * @param id - record id
     */
    getDetail({ commit, rootState, dispatch }, id: number): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return axios.get(`${rootState.settings.apiUrl}/records/getById?id=${id}`)
                .then((response) => {
                    const record: Record = response.data as Record;
                    commit(RECORD_CHANGE_CURRENT_STATE, record);
                    return resolve(true);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Record',
                        message: {
                            state: MessageStatusEnum.Error,
                            message: error,
                        },
                    },
                    { root: true});
                    return resolve(false);
                });
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
                { headers: { authorization: rootState.auth.token } })
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
                    },
                    { root: true});
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
            { headers: { authorization: rootState.auth.token } })
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
                    },
                    { root: true});
                });
        });
    },
    getAllForAdmin({commit, rootState, dispatch}): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return axios.get(`${rootState.settings.apiUrl}/records/getAllForAdmin`,
                { headers: { authorization: rootState.auth.token } })
            .then((response) => {
                commit(RECORD_CHANGE_LIST_STATE, response.data as RecordTableDto[]);
                return resolve(true);
            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Record',
                    message: {
                        state: MessageStatusEnum.Error,
                        message: error,
                    },
                },
                { root: true});
            });
        });
    },
    createRecord({commit, rootState, dispatch}, record: Record): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return axios.post(`${rootState.settings.apiUrl}/records/create`, record,
                { headers: { authorization: rootState.auth.token } })
            .then((response) => {
                commit(RECORD_CHANGE_CURRENT_STATE, response.data as Record);
                dispatch('message/change', {
                    mod: 'Record',
                    message: {
                        state: MessageStatusEnum.Success,
                        message: 'createdSuccessfully',
                    },
                },
                { root: true });
                dispatch('record/getAllForAdmin', {}, { root: true });
                dispatch('record/initialCurrent', {}, { root: true });
                return resolve(true);
            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Record',
                    message: {
                        state: MessageStatusEnum.Error,
                        message: error,
                    },
                },
                { root: true});
                return resolve(false);
            });
        });
    },
    uploadFiles({commit, rootState, dispatch}, formData: any): Promise<File[]> {
        return new Promise<File[]>((resolve) => {
            return axios.post(`${rootState.settings.apiUrl}/files/uploadFiles`, formData,
                { headers: { authorization: rootState.auth.token } })
            .then((response) => {
                return resolve(response.data as File[]);
            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Record',
                    message: {
                        state: MessageStatusEnum.Error,
                        message: error,
                    },
                },
                { root: true});
                return resolve(undefined);
            });
        });
    },
    setCurrent({commit}, record: Record): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(RECORD_CHANGE_CURRENT_STATE, record);
            return resolve(true);
        });
    },
    setCurrentUserId({commit}, userId: number): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(RECORD_SET_CURRENT_USER_ID, userId);
        });
    },
    setFiles({commit}, files: FileSimpleDto[]): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(RECORD_SET_CURRENT_FILES, files);
            return resolve(true);
        });
    },
    updateRecord({rootState, dispatch}, record: Record): Promise<boolean> {
        return new Promise<boolean> ((resolve) => {
            return axios.put(`${rootState.settings.apiUrl}/records`, record,
                { headers: { authorization: rootState.auth.token } })
            .then((response) => {
                dispatch('message/change', {
                    mod: 'Record',
                    message: {
                        state: MessageStatusEnum.Success,
                        message: 'updatedSuccessfully',
                    },
                },
                { root: true });
                dispatch('record/getAllForAdmin', {}, { root: true });
                dispatch('record/initialCurrent', {}, { root: true });
                return resolve(true);
            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Record',
                    message: {
                        state: MessageStatusEnum.Error,
                        message: error,
                    },
                },
                { root: true});
                return resolve(undefined);
            });
        });
    },
    deleteRecord({commit, rootState, dispatch}, recordId: number): Promise<boolean> {
        return new Promise<boolean> ((resolve) => {
            return axios.delete(`${rootState.settings.apiUrl}/records/delete`,
                {
                    params: {
                        id: recordId,
                    },
                    headers: {
                        authorization: rootState.auth.token,
                    },
                })
            .then((response) => {
                commit(RECORD_DELETE_RECORD_FROM_LIST, response.data as Record);
                commit(RECORD_INITIAL_CURRENT);
                dispatch('message/change', {
                    mod: 'Record',
                    message: {
                        state: MessageStatusEnum.Success,
                        message: 'deleteSuccessfully',
                    },
                },
                { root: true });
                return resolve(true);
            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Record',
                    message: {
                        state: MessageStatusEnum.Error,
                        message: error,
                    },
                },
                { root: true});
                return resolve(false);
            });
        });
    },
};

export default actions;
