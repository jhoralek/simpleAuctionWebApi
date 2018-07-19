import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';

import { Dictionary } from '@/store/types';
import { User, Country, Record } from '@/model';
import { FuelEnum } from '@/model/FuelEnum';

export default class Mock {
    public mock: MockAdapter;

    /**
     * Fake data of countries
     */
    public countries: Dictionary<Country[]> = {
         cs:  [
            { id: 1, name: 'Česká Republika' },
            { id: 2, name: 'Německo' },
            { id: 3, name: 'Slovenská Republika' },
            { id: 4, name: 'Velká Británie' },
            { id: 5, name: 'Rusko' },
         ],
         en: [
             { id: 1, name: 'Czech Republic' },
             { id: 2, name: 'Germany' },
             { id: 3, name: 'Slovak Republic' },
             { id: 4, name: 'Great Britain' },
             { id: 5, name: 'Russia' },
         ],
    };
    /**
     * Fake data collection
     */
    public users: User[] = [
        {
            id: 1,
            userName: 'n00by',
            password: 'test',
            isActive: true,
            isAgreementToTerms: true,
            sendingNews: false,
            token: 'asdasdfqeoriqjwelkadf',
            language: 'en',
            customer: {
                id: 1,
                firstName: 'Jiri',
                lastName: 'Horalek',
                titleAfter: 'DiS.',
                email: 'horalek.jiri@gmail.com',
                isDealer: false,
                phoneNumber: '773587457',
                feeExpiration: new Date(2018, 7, 20, 0, 0, 0),
                birthNumber: '8110090560',
                address: {
                    id: 1,
                    street: 'Turpin court 458',
                    city: 'Cambridge',
                    postCode: 'CB4XY1',
                    country: {
                        id: 4,
                        name: 'Great Britain',
                    },
                },
            },
         },
         {
             id: 2,
             userName: 'pavelNovak',
             password: 'test',
             isActive: true,
             isAgreementToTerms: true,
             sendingNews: true,
             token: '',
             language: 'cs',
             customer: {
                 id: 2,
                 firstName: 'Pavel',
                 lastName: 'Novak',
                 email: 'pavel.novak@seznam.cz',
                 isDealer: false,
                 phoneNumber: '772456928',
                 feeExpiration: null,
                 birthNumber: '6789234568',
                 address: {
                    id: 2,
                    street: 'Prazska 125',
                    city: 'Benesov u Prahy',
                    postCode: '25601',
                    country: {
                        id: 1,
                        name: 'Ceska Republika',
                    },
                },
             },
         },
    ];

    public records: Record[] = [
        {
            isActive: true,
            name: 'BMW 1',
            colors: ['#ff00ff', '#00ff00', '#00ffff'],
            mileage: '100000',
            engineCapacity: '1800 ccm',
            body: '5 dveří',
            power: '100 bhp',
            fuel: FuelEnum.diesel,
            transmission: 'manual',
            axle: '',
            registrationCheck: 'tohle zatim nevi co ma byt',
            contactToAppointment: 'Katerina Horalkova, jelikat@seznam.cz',
            dealer: {
                id: 2,
                userName: 'pavelNovak',
                password: 'test',
                isActive: true,
                isAgreementToTerms: true,
                sendingNews: true,
                token: '',
                language: 'cs',
                customer: {
                    id: 2,
                    firstName: 'Pavel',
                    lastName: 'Novak',
                    email: 'pavel.novak@seznam.cz',
                    isDealer: true,
                    phoneNumber: '772456928',
                    feeExpiration: null,
                    birthNumber: '6789234568',
                    address: {
                       id: 2,
                       street: 'Prazska 125',
                       city: 'Benesov u Prahy',
                       postCode: '25601',
                       country: {
                           id: 1,
                           name: 'Ceska Republika',
                       },
                   },
                },
            },
            minimumBid: 5000,
            startingPrice: 50000,
            validFrom: new Date(2018, 5, 20),
            validTo: new Date(2018, 7, 20),
            defects: 'Karoserie je poskrabana, prmackliny na prednim blaniku. Opotrebovane brzdy, Popraskana sedadla.',
            moreDescription: 'Vice popisku muze byt zde',
            state: 'stav ???? asi v jakem je stavu',
            equipment: 'vybava. Elektrony dve sady, central, start na tlacitko atd.',
            vin: 'VUB56465465adf6a54645df',
            numberOfSeets: 5,
            euroNorm: '4',
            doors: 5,
            dateOfFirstRegistration: new Date(2004, 1, 1),
            stk: new Date(2018, 1, 23),
            dimensions: 'celkove rozmery',
            operationgWeight: 'provozni hmotnost',
            mostTechnicallyAcceptableWeight: 'nejvetsi technicka pripustna hmotnost',
            maximumWeight: 'maximalni povolena hmotnost',
            mostTechnicallyWeighOfRide: 'nejvetsi technicky pripustna hmotnost jizdni soupravy',
            maximumWeightOfRide: 'nejvetsi povolena hmotnost jizdni soupravy',
            files: [
                { id: 1, name: 'cockpit.jpg', path: '/auction' },
                { id: 2, name: 'cockpit-1.jpg', path: '/auction' },
                { id: 3, name: 'cockpit-2.jpg', path: '/auction' },
                { id: 4, name: 'inside-front.jpg', path: '/auction' },
                { id: 5, name: 'back-seats.jpg', path: '/auction' },
                { id: 6, name: 'stearing-wheel.jpg', path: '/auction' },
                { id: 7, name: 'mileage.jpg', path: '/auction' },
                { id: 8, name: 'vin.jpg', path: '/auction' },
                { id: 9, name: 'levers.jpg', path: '/auction' },
                { id: 10, name: 'front-window-controls.jpg', path: '/auction' },
                { id: 11, name: 'back-window-controls.jpg', path: '/auction' },
                { id: 12, name: 'engine.jpg', path: '/auction' },
            ],
            id: 1,
        },
        {
            isActive: true,
            name: 'Jawa 555',
            colors: ['#ab00ff', '#00eeee', '#bd84da'],
            mileage: '25000',
            engineCapacity: '50 ccm',
            body: '1 sedlo',
            power: '2,3 bhp',
            fuel: FuelEnum.diesel,
            transmission: 'manual',
            axle: '',
            registrationCheck: 'tohle zatim nevi co ma byt',
            contactToAppointment: 'Jiri Horalek horalek.jiri@gmail.com',
            dealer: {
                id: 2,
                userName: 'pavelNovak',
                password: 'test',
                isActive: true,
                isAgreementToTerms: true,
                sendingNews: true,
                token: '',
                language: 'cs',
                customer: {
                    id: 2,
                    firstName: 'Pavel',
                    lastName: 'Novak',
                    email: 'pavel.novak@seznam.cz',
                    isDealer: true,
                    phoneNumber: '772456928',
                    feeExpiration: null,
                    birthNumber: '6789234568',
                    address: {
                       id: 2,
                       street: 'Prazska 125',
                       city: 'Benesov u Prahy',
                       postCode: '25601',
                       country: {
                           id: 1,
                           name: 'Ceska Republika',
                       },
                   },
                },
            },
            minimumBid: 1000,
            startingPrice: 5000,
            validFrom: new Date(2018, 5, 20),
            validTo: new Date(2018, 7, 20),
            defects: 'Prosezena sedacka, nestartuje, zaseknute brzdy.',
            moreDescription: 'rok vyroby 1959',
            state: 'Nalezovy stav. Nepojizdny',
            vin: '234144',
            numberOfSeets: 1,
            dateOfFirstRegistration: new Date(1959, 10, 22),
            files: [
                { id: 1, name: 'parez.jpg', path: '/auction' },
            ],
            id: 2,
        },
        {
            isActive: true,
            name: 'Aprilia 125',
            colors: ['#ab00ff', '#00eeee', '#bd84da'],
            mileage: '25000',
            engineCapacity: '150 ccm',
            body: '1 sedlo',
            power: '15 bhp',
            fuel: FuelEnum.diesel,
            transmission: 'manual',
            axle: '',
            registrationCheck: 'tohle zatim nevi co ma byt',
            contactToAppointment: 'Jiri Horalek horalek.jiri@gmail.com',
            dealer: {
                id: 2,
                userName: 'pavelNovak',
                password: 'test',
                isActive: true,
                isAgreementToTerms: true,
                sendingNews: true,
                token: '',
                language: 'cs',
                customer: {
                    id: 2,
                    firstName: 'Pavel',
                    lastName: 'Novak',
                    email: 'pavel.novak@seznam.cz',
                    isDealer: true,
                    phoneNumber: '772456928',
                    feeExpiration: null,
                    birthNumber: '6789234568',
                    address: {
                       id: 2,
                       street: 'Prazska 125',
                       city: 'Benesov u Prahy',
                       postCode: '25601',
                       country: {
                           id: 1,
                           name: 'Ceska Republika',
                       },
                   },
                },
            },
            minimumBid: 1000,
            startingPrice: 5000,
            validFrom: new Date(2018, 5, 20),
            validTo: new Date(2018, 7, 20),
            defects: 'Prosezena sedacka, nestartuje, zaseknute brzdy.',
            moreDescription: 'rok vyroby 1959',
            state: 'Nalezovy stav. Nepojizdny',
            vin: '234144',
            numberOfSeets: 1,
            dateOfFirstRegistration: new Date(1959, 10, 22),
            files: [
                { id: 1, name: 'engine.jpg', path: '/auction' },
            ],
            id: 3,
        },
    ];

    constructor(adapter: MockAdapter) {
        this.mock = adapter;
    }

    /**
     * Get list of users without any filter
     * @returns Promise with list of Users
     */
    public getUsers(): Promise<any> {
        this.mock.onGet('/users').reply(200, {
            users: this.users,
        });

        return axios.get('/users');
    }
    /**
     * Get user by his ID
     * @param id - users d
     * @returns Promise with User object
     */
    public getUser(id: number): Promise<any> {
        this.mock.onGet('/users', { params: { id } }).reply(200,
            this.users.filter((x) => x.id === id)[0]);

        return axios.get('/users', { params: { id } });
    }
    /**
     * Fake login user
     * @param userName - User's login name
     * @param password - User's password
     */
    public login(userName: string, password: string): Promise<any> {
        const filtered: User[] = this.users.filter((x) => x.userName === userName
            && x.password === password);

        this.mock.onGet('/users', {
            params: {
                userName,
                password,
            },
        }).reply(200,
            filtered.length > 0 ? filtered[0] : null);

        return axios.get('/users', {
            params: {
                userName,
                password,
            },
        });
    }
    /**
     * Get list of countries
     * @param lang - lang
     */
    public getCountries(lang: string): Promise<any> {
        this.mock.onGet('/countries').reply(200, this.countries[lang]);
        return axios.get('/countries');
    }
    /**
     * Update user's token and return whole user back
     * @param id - User's id
     * @param token - new token string
     */
    public updateUserToken(id: number, token: string): Promise<any> {
        const filtered: User[] = this.users.filter((x) => x.id === id);
        // filtered[0].token = token;

        this.mock.onGet('/users', { params: { id } })
            .reply(200, filtered[0]);

        return axios.get('/users', { params: { id } });
    }
    /**
     * Return user by his token string
     * @param token - Users token string
     */
    public getUserByToken(token: string): Promise<any> {
        const filtered: User[] = this.users.filter((x) => x.token === token);

        this.mock.onGet('/users', { params: { token } })
            .reply(200, filtered[0]);

        return axios.get('/users', { params: { token } });
    }
    /**
     * Get all records
     */
    public getRecords(): Promise<any> {
        this.mock.onGet('/records').reply(200, this.records);
        return axios.get('/records');
    }
    /**
     * Get all active records
     */
    public getAllActiveRecords(): Promise<any> {
        const date: Date = new Date();
        const available: Record[] = this.records
            .filter((x) => x.validFrom <= date
                && x.validTo >= date
                && x.isActive);

        this.mock.onGet('/records', { params: { date }})
            .reply(200, available);

        return axios.get('/records', { params: { date }});
    }
    /**
     * Get record object by it's id
     * @param id - id of record
     */
    public getRecordById(id: number): Promise<any> {
        const date: Date = new Date();
        const available: Record[] = this.records
            .filter((x) => x.validFrom <= date
                && x.validTo >= date
                && x.isActive);

        this.mock.onGet('/records', { params: { id }})
            .reply(200, available.filter((x) => x.id === id)[0]);

        return axios.get('/records', { params: { id }});
    }
}
