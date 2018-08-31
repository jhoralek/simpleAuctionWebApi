import Record from './Record';

export default interface Auction {
    id: number;
    name: string;
    isActive: boolean;
    isEnded: boolean;
    validFrom: Date;
    validTo: Date;
    created: Date;
    records: Record[];
}
