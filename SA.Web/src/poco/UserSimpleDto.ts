export default interface UserSimpleDto {
    id: number;
    userName: string;
    isActive: boolean;
    isAgreementToTerms: boolean;
    sendingNews: boolean;
    customerId: number;
    language: string;
    created: Date;
    isFeePayed: boolean;
    email: string;
    phoneNumber: string;
}
