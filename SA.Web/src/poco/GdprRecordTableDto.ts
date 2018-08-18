import { GdprApplicationType } from '@/model';

export default interface GdprRecordTableDto {
    id: number;
    fullName: string;
    email: string;
    phoneNumber: string;
    city: string;
    type: GdprApplicationType;
    isProcessed: boolean;
    created: Date;
}
