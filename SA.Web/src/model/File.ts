import { User, Record } from '@/model';
export default interface File {
    user: User;
    record: Record;
    path: string;
    name: string;
    created?: Date;
    id?: number;
}
