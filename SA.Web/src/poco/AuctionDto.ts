import RecordTableDto from './RecordTableDto';
export default interface AuctionDto {
    id: number;
    name: string;
    isActive: boolean;
    isEnded: boolean;
    validFrom: Date;
    validTo: Date;
    created: Date;
    records: RecordTableDto[];
}
