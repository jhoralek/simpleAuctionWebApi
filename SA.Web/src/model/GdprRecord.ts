import { Country, GdprApplicationType } from '@/model';

export default interface GdprRecord {
    id: number;
    firstName: string;
    lastName: string;
    phoneNumber: string;
    email: string;
    companyName?: string;
    companyNumber?: string;
    birtNumber?: string;
    street: string;
    city: string;
    postCode: string;
    country: Country;
    countryId: number;
    description: string;
    type: GdprApplicationType;
    created: Date;
    isProcessed: boolean;
}
