import { MessageStatusEnum } from '@/model';

export default interface ResponseMessage<T> {
    code: string;
    status: MessageStatusEnum;
    entity: T;
}
