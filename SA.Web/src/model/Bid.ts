import { User, Record } from '@/model';

export default interface Bid {
        user: User;
        record: Record;
        price: number;
        id?: number;
        created?: Date;
        userId: number;
        recordId: number;
}
