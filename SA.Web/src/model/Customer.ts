import Address from './Address';

export default interface Customer {
    firstName: string;
    lastName: string;
    phoneNumber: string;
    email: string;
    isDealer: boolean;
    address: Address;
    feeExpiration?: Date;
    birthNumber?: string;
    titleBefore?: string;
    titleAfter?: string;
    webPageUrl?: string;
    companyNumber?: string;
    companyLegalNumber?: string;
    id?: number;
}
