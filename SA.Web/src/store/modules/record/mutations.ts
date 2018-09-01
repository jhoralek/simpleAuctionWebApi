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

        if (record !== null && record.validFrom !== null) {
            state.current.validFrom = new Date(record.validFrom);
        }
        if (record !== null && record.validTo !== null) {
            state.current.validTo = new Date(record.validTo);
        }
        if (record !== null && record.dateOfFirstRegistration !== null) {
            state.current.dateOfFirstRegistration = new Date(record.dateOfFirstRegistration);
        }
        if (record !== null && record.stk !== null) {
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
    RECORD_APPEND_CURRENT_FILES(state, files: FileSimpleDto[]) {
        state.error = false;
        files.forEach((x) => state.current.files.push(x));
    },
    RECORD_SET_CURRENT_USER_ID(state, userId: number) {
        state.error = false;
        state.current.userId = userId;
    },
    RECORD_CHANGE_BIDS_TO_CURRENT(state, bids: BidDto[]) {
        state.error = false;
        state.current.bids = bids as BidDto[];
    },
    RECORD_SET_VALID_DATES(state, record: Record) {
        state.error = false;

        const startDate: Date = new Date(Date.UTC(
            record.validFrom.getFullYear(),
            record.validFrom.getMonth(),
            record.validFrom.getDate(),
            0,
            0,
            0,
            0,
        ));

        const endDate: Date = new Date(Date.UTC(
            record.validTo.getFullYear(),
            record.validTo.getMonth(),
            record.validTo.getDate(),
            23,
            59,
            59,
            0,
        ));

        state.current.validFrom = startDate;
        state.current.validTo = endDate;
    },
    RECORD_SET_VALID_TIMES(state, { from, to }) {
        state.error = false;
        if (state.current.validFrom && from) {
            const fromHours: number = from === undefined
                ? 0
                : parseInt((from as string).split(':')[0], 0);
            const fromMinutes: number = from === undefined
                ? 0
                : parseInt((from as string).split(':')[1], 0);

            const fromDate: Date = new Date(Date.UTC(
                state.current.validFrom.getFullYear(),
                state.current.validFrom.getMonth(),
                state.current.validFrom.getDate(),
                fromHours,
                fromMinutes,
                0,
                0,
            ));
            state.current.validFrom = fromDate;
        }

        if (state.current.validTo && to) {
            const toHours: number = to === undefined
                ? 0
                : parseInt((to as string).split(':')[0], 0);
            const toMinutes: number = to === undefined
                ? 0
                : parseInt((to as string).split(':')[1], 0);

            const toDate: Date = new Date(Date.UTC(
                state.current.validTo.getFullYear(),
                state.current.validTo.getMonth(),
                state.current.validTo.getDate(),
                toHours,
                toMinutes,
                0,
                0,
            ));
            state.current.validTo = toDate;
        }
    },
};

export default mutations;
