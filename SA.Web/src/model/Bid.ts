import { User, Record } from '@/model';

export default interface Bid {
        user: User;
        record: Record;
        currentPrice: number;
        id?: number;
        created?: Date;
}
