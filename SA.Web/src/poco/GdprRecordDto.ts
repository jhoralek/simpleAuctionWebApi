import { GdprApplicationType } from '@/model';

export default interface GdprRecordDto {
    int: number;
    firstName: string;
    lastName: string;
    email: string;
    companyNumber: string;
    birtNumber: string;
    companyName: string;
    phoneNumber: string;
    street: string;
    city: string;
    postCode: string;
    countryId: number;
    description: string;
    type: GdprApplicationType;
    isProcessed: boolean;
}
