export default interface AuctionTableDto {
    id: number;
    name: string;
    isActive: boolean;
    isEnded: boolean;
    validFrom: Date;
    validTo: Date;
    created: Date;
    numberOfRecords: number;
}
