
import Customer from '@/model/Customer';

export default interface User {
        userName: string;
        password: string;
        isActive: boolean;
        isAgreementToTerms: boolean;
        sendingNews: boolean;
        customer: Customer;
        customerId: number;
        id?: number;
        token: string;
        language: string;
        created: Date;
}
