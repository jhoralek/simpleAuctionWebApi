import { MutationTree } from 'vuex';
import { RecordState } from '@/store/types';
import { Record } from '@/model';
import { FileSimpleDto, RecordTableDto, BidDto } from '@/poco';

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
            files: [],
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

        if (record.validFrom !== null) {
            state.current.validFrom = new Date(record.validFrom);
        }
        if (record.validTo !== null) {
            state.current.validTo = new Date(record.validTo);
        }
        if (record.dateOfFirstRegistration !== null) {
            state.current.dateOfFirstRegistration = new Date(record.dateOfFirstRegistration);
        }
        if (record.stk !== null) {
            state.current.stk = new Date(record.stk);
        }
    },
    /**
     * Change list of records
     * @param state - Record state
     * @param records - list of records
     */
    RECORD_CHANGE_LIST_STATE(state, records: RecordTableDto[]) {
        state.error = false;
        state.records = records;
    },
    RECORD_DELETE_RECORD_FROM_LIST(state, record: Record) {
        state.error = false;
        state.records = state.records
            .filter((item) => item.id !== record.id);
    },
    RECORD_SET_CURRENT_FILES(state, files: FileSimpleDto[]) {
        state.error = false;
        state.current.files = files;
    },
    RECORD_SET_CURRENT_USER_ID(state, userId: number) {
        state.error = false;
        state.current.userId = userId;
    },
    RECORD_CHANGE_BIDS_TO_CURRENT(state, bids: BidDto[]) {
        state.error = false;
        state.current.bids = bids as BidDto[];
    },
};

export default mutations;
