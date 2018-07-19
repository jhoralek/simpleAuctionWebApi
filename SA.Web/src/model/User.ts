
import Customer from './Customer';

export default interface User {
        userName: string;
        password: string;
        isActive: boolean;
        isAgreementToTerms: boolean;
        sendingNews: boolean;
        customer: Customer;
        id?: number;
        token: string;
        language: string;
}
