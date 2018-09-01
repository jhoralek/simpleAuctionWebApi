import axios from 'axios';
import { ActionTree } from 'vuex';
import {
    RootState,
    RecordState,
} from '@/store/types';

import { Record, MessageStatusEnum, Bid } from '@/model';

import {
    RECORD_INITIAL_STATE,
    RECORD_CHANGE_LIST_STATE,
    RECORD_CHANGE_CURRENT_STATE,
    RECORD_INITIAL_CURRENT,
    RECORD_DELETE_RECORD_FROM_LIST,
    RECORD_SET_CURRENT_FILES,
    RECORD_APPEND_CURRENT_FILES,
    RECORD_SET_CURRENT_USER_ID,
    RECORD_CHANGE_BIDS_TO_CURRENT,
    RECORD_SET_VALID_DATES,
    RECORD_SET_VALID_TIMES,
} from '@/store/mutation-types';
import {
    RecordTableDto,
    FileSimpleDto,
    ResponseMessage,
    BidDto,
} from '@/poco';

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
                `${rootState.settings.apiUrl}/records/getAllCurrentAuctionItems`)
                .then((response) => {
                    const records: RecordTableDto[] = response.data as RecordTableDto[];
                    commit(RECORD_CHANGE_LIST_STATE, records);
                    if (records.length === 0) {
                        dispatch('auction/getFutureAutions', {
                            mod: 'Auction',
                        },
                        { root: true });
                    } else {
                        dispatch('auction/initialState', {}, { root: true});
                    }
                    return resolve(true);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Record',
                        message: {
                            state: MessageStatusEnum.Error,
                            message: error.message,
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
                            message: error.message,
                        },
                    },
                    { root: true});
                    return resolve(false);
                });
        });
    },
    getActualRandom({ commit, rootState, dispatch }): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return axios.get(`${rootState.settings.apiUrl}/records/actualRandom`)
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
                            message: error.message,
                        },
                    },
                    { root: true});
                    return resolve(false);
                });
        });
    },
    getBids({ commit, rootState, dispatch }, recordId: number): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return axios.get(`${rootState.settings.apiUrl}/records/getBids?id=${recordId}`)
                .then((response) => {
                    commit(RECORD_CHANGE_BIDS_TO_CURRENT, response.data as BidDto[]);
                    return resolve(true);
                })
                .catch((error) => {
                    dispatch('message/change', {
                        mod: 'Record',
                        message: {
                            state: MessageStatusEnum.Error,
                            message: error.message,
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
                            message: error.message,
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
                            message: error.message,
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
                        message: error.message,
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
                        message: error.message,
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
                        message: error.message,
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
    addFiles({commit}, files: FileSimpleDto[]): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit (RECORD_APPEND_CURRENT_FILES, files);
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
                        message: error.message,
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
                        message: error.message,
                    },
                },
                { root: true});
                return resolve(false);
            });
        });
    },
    addBid({rootState, dispatch}, bid: Bid): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return axios.post(`${rootState.settings.apiUrl}/bids/create`, bid,
                { headers: { authorization: rootState.auth.token }})
            .then((resp1) => {
                const response = resp1.data as ResponseMessage<Bid>;
                dispatch('record/getDetail', bid.recordId, { root: true}).then((resp2) => {
                    dispatch('message/change', {
                        mod: 'Record',
                        message: {
                            state: response.status,
                            message: response.code,
                        },
                    },
                    { root: true});
                    return resolve(true);
                });

            })
            .catch((error) => {
                dispatch('message/change', {
                    mod: 'Record',
                    message: {
                        state: MessageStatusEnum.Error,
                        message: error.message,
                    },
                },
                { root: true});
                return resolve(false);
            });
        });
    },
    setValidDates({commit}, record: Record): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(RECORD_SET_VALID_DATES, record);
            return resolve(true);
        });
    },
    setValidTimes({commit}, {from, to}): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            commit(RECORD_SET_VALID_TIMES, { from, to});
            return resolve(true);
        });
    },
};

export default actions;
