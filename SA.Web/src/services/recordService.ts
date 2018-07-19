import Mock from '@/mock/mock';
import { MockService } from '@/services';
import { Record } from '@/model';

export default class RecordService {
    private mock: Mock;

    constructor() {
        this.mock = new Mock(MockService);
    }
    /**
     * Get all active records
     */
    public getAllActive(): Promise<Record[]> {
        return this.mock.getAllActiveRecords().then((records) => {
            return records.data;
        });
    }
    /**
     * Get all records
     */
    public getAll(): Promise<Record[]> {
        return this.mock.getRecords().then((records) => {
            return records.data;
        });
    }
    /**
     * Get the record by it's id
     * @param id - id of record
     */
    public getById(id: number): Promise<Record> {
        return this.mock.getRecordById(id).then((record) => {
            return record.data;
        });
    }
}
