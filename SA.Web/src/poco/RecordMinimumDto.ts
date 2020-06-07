export default interface RecordMinimumDto {
    id: number;
    name: string;
    validFrom: Date;
    validTo: Date;
    currentPrice: number;
    winningUserId: number;
    biddingUserIds: number[];
    withVat: boolean;
}
