import Country from './Country';

export default interface Address {
    street: string;
    city: string;
    postCode: string;
    country: Country;
    id?: number;
}
