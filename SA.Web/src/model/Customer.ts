import Address from '@/model/Address';

export default interface Customer {
    firstName: string;
    lastName: string;
    phoneNumber: string;
    email: string;
    isDealer: boolean;
    address: Address;
    addressId: number;
    isFeePayed: boolean;
    birthNumber?: string;
    titleBefore?: string;
    titleAfter?: string;
    webPageUrl?: string;
    companyNumber?: string;
    companyLegalNumber?: string;
    companyName?: string;
    id?: number;
    created: Date;
}
