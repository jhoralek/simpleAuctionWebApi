import { FuelEnum } from '@/model/FuelEnum';
import { User, Bid } from '@/model';
import { FileShortDto } from '@/poco';

export default interface Record {
    isActive: boolean;
    name: string;
    colors?: string[];
    mileage: string;
    engineCapacity?: string;
    body?: string; // karoserie
    power?: string;
    fuel: FuelEnum;
    transmission: string;
    axle: string; // náprava 4x4
    registrationCheck: string;
    contactToAppointment: string;
    dealer: User; // user who creates this record (can be only dealer)
    minimumBid: number;
    startingPrice: number;
    validFrom: Date;
    validTo: Date;
    defects?: string; // závady
    moreDescription?: string;
    state?: string; // stav
    equipment?: string; // výbava
    vin?: string;
    numberOfSeets?: number;
    euroNorm?: string;
    doors?: number;
    dateOfFirstRegistration?: Date;
    stk?: Date;
    dimensions?: string; // celkove rozmery
    operationgWeight?: string; // provozni hmotnost
    mostTechnicallyAcceptableWeight?: string; // nejvetsi technicka pripustna hmotnost
    maximumWeight?: string; // maximalni povolena hmotnost
    mostTechnicallyWeighOfRide?: string; // nejvetsi technicky pripustna hmotnost jizdni soupravy
    maximumWeightOfRide?: string; // nejvetsi povolena hmotnost jizdni soupravy
    files?: FileShortDto[];
    bids?: Bid[];
    id?: number;
    currentPrice: number;
    numberOfBids: number;
}
