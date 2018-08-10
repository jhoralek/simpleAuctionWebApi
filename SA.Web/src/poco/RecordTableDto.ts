import { FileSimpleDto } from '@/poco';

export default interface RecordTableDto {
    id?: number;
    name: string;
    validFrom: Date;
    validTo: Date;
    minimumBid: number;
    startingPrice: number;
    currentPrice: number;
    numberOfBids: number;
    state: string;
    files: FileSimpleDto[];
}
