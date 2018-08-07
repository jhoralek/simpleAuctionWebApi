import { Dictionary } from '@/store/types';

export class Translator {

    public static languages: string [] = [
        'cs',
        'en',
        'de',
        'ru',
        'sk',
    ];
    /**
     * Set resource
     * @param key - key which is neccessary to show right text
     */
    public static setResource(key: string): Dictionary<string> {
        switch (key) {
            case 'cs':
                return this.cs;
            case 'en':
                return this.en;
            case 'de':
                return this.de;
            case 'ru':
                return this.ru;
            case 'sk':
                return this.sk;
            default:
                return this.cs;
        }
    }

    private static cs: Dictionary<string> = {
        about: 'O nás',
        address: 'Adresa',
        action: 'Akce',
        active: 'Aktivní',
        administration: 'Administrace',
        agreementToTerms: 'Souhlasím s obchodními podmínkami',
        auctions: 'Aukce',
        auctionDetailInformation: 'Informace o aukci',
        auctionHall: 'Aukční síň',
        auditControlIsProvidedBy: 'Evidenční kontrolu zajišťuje',
        actualPrice: 'Aktuální cena',
        axle: 'Konfigurace nápravy',
        back: 'Zpět',
        beginningOfTheAuction: 'Začátek aukce',
        bids: 'Příhozy',
        birthNumber: 'Rodné číslo',
        cancel: 'Zrušit',
        carInformation: 'Informace o vozidle',
        city: 'Město',
        close: 'Zavřít',
        color: 'Barva',
        companyLegalNumber: 'DIČ',
        companyName: 'Název společnosti',
        companyNumber: 'IČO',
        contact: 'Kontakt',
        contactToAppointment: 'Kontaktní osoba',
        country: 'Země',
        created: 'Vytvořen',
        createdSuccessfully: 'Zánam úspěšně vytvořen.',
        currentPrice: 'Cena',
        customer: 'Zákazník',
        customerDetail: 'Detail zákazníka',
        dateOfFirstRegistration: 'Datum první registrace',
        dealer: 'Prodávající',
        defects: 'Závady',
        detailOfAuction: 'Detail aukce',
        dimensions: 'Celkové rozměry (délka / šířka / výška)',
        doors: 'Dveře',
        equipment: 'Vybavení',
        email: 'Email',
        end: 'Konec',
        endOfAuction: 'Konec aukce',
        euroNorm: 'Euronorma',
        faq: 'Otázky a odpovědi',
        feeExpirationDate: 'Datum vypršení poplatku',
        feePayed: 'Poplatek zaplacen',
        firstName: 'Jméno',
        forDealers: 'Pro prodejce',
        fuel: 'Palivo',
        grid: 'Mříž',
        home: 'Domů',
        intoFavorites: 'Do oblíbených',
        language: 'Jazyk',
        lastName: 'Příjmení',
        link: 'Odkaz',
        loadingData: 'Nahrávám',
        login: 'Přihlásit se',
        logout: 'Odhlásit',
        maximumWeight: 'Nejvyšší povolená hmotnost',
        maximumWeightOfRide: 'Nejvyšší technicky přípustná hmotnost jízdní soupravy',
        mileAge: 'Najeto',
        minimumBid: 'Minimální příhoz',
        moreDescription: 'Další informace',
        mostTechnicallyWeightOfRide: 'Nejvyšší technicky přípustná hmotnost',
        mostTechnicallyAcceptableWeight: 'Největší povolená hmotnost jízdní soupravy',
        name: 'Název',
        next: 'Další',
        news: 'Novinky',
        numberOfBids: 'Počet příhozů',
        numberOfSeets: 'Počet sedadel',
        ok: 'OK',
        operationWeight: 'Provozní hmotnost',
        password: 'Heslo',
        phoneNumber: 'Telefonní číslo',
        postCode: 'PSČ',
        power: 'Výkon',
        protectionPersonalData: 'Ochrana osobních údajů',
        registration: 'Registrace',
        registrationSent: 'Registrace úspěšně odeslána!',
        requiredFields: 'Povinné  pole',
        repeatPassword: 'Opakovat heslo',
        seller: 'Prodejce',
        sendingNews: 'Zasílat novinky',
        share: 'Sdílet',
        specification: 'Technické údaje',
        state: 'Stav',
        startingPrice: 'Vyvolávací cena',
        step1: 'Krok 1/3',
        street: 'Ulice',
        submit: 'Odeslat',
        table: 'Tabulka',
        technicalViewOfTheVehicle: 'STK',
        terms: 'Podmínky',
        termsAndConditions: 'Obchodní podmínky',
        titleAfter: 'Titul za',
        titleBefore: 'Titul před',
        transmission: 'Řazení',
        user: 'Uživatel',
        usersAdministration: 'Administrace uživatelů',
        userLoggedInSuccessfully: 'Úspěšně přihlášen.',
        userLoggedOutSuccessfully: 'Úspěšně odhlášen.',
        userName: 'Uživatelské jméno',
        updatedSuccessfully: 'Záznam úspěšně upraven.',
        userNotAuthenticated: 'Špatné jméno nebo heslo!',
        validation_max_chars: 'Maximálně {0} znaků!',
        validation_min_chars: 'Minimum znaků {0}!',
        validation_required: 'Pole je povinné',
        validation_pwd_must_be_same: 'Hesla se musejí shodovat',
        vehicleVinNumber: 'VIN vozidla',
        webPageUrl: 'URL webových stránek',
        yearOfManufacture: 'Rok výroby',
    };

    private static en: Dictionary<string> = {
        about: 'About',
        address: 'Address',
        active: 'Active',
        administration: 'Administration',
        agreementToTerms: 'Agree with terms and conditions',
        action: 'Action',
        auctions: 'Auctions',
        auctionDetailInformation: 'Detailed auction information',
        auctionHall: 'Auction hall',
        auditControlIsProvidedBy: 'Audit control is provided by',
        actualPrice: 'Current price',
        axle: 'Axle',
        back: 'Back',
        beginningOfTheAuction: 'Beginning of the auction',
        bids: 'Bids',
        birthNumber: 'Birth number',
        cancel: 'Cancel',
        carInformation: 'Vehicle information',
        city: 'City',
        close: 'Close',
        color: 'Color',
        companyLegalNumber: 'Company legal number',
        companyName: 'Company name',
        companyNumber: 'Company number',
        contact: 'Contact',
        contactToAppointment: 'Contact person',
        country: 'Country',
        created: 'Created',
        createdSuccessfully: 'Record created successfully',
        currentPrice: 'Price',
        customer: 'Customer',
        customerDetail: 'Customer\'s detail',
        dateOfFirstRegistration: 'Date of first registration',
        dealer: 'Dealer',
        defects: 'Defets',
        detailOfAuction: 'Detail of auction',
        dimensions: 'Overall dimensions (length / width / height)',
        doors: 'Doors',
        equipment: 'Equipment',
        email: 'Email',
        end: 'End',
        endOfAuction: 'End of auction',
        euroNorm: 'Euronorm',
        faq: 'FAQ',
        feeExpirationDate: 'Fee expiration date',
        feePayed: 'Fee payed',
        firstName: 'First name',
        forDealers: 'For dealers',
        fuel: 'Fuel',
        grid: 'Grid',
        home: 'Home',
        intoFavorites: 'To favorites',
        language: 'Language',
        lastName: 'Last name',
        link: 'Link',
        loadingData: 'Loading',
        login: 'Login',
        logout: 'Logout',
        maximumWeight: 'Maximum allowable weight',
        maximumWeightOfRide: 'Technically permissible maximum mass of the combination',
        mileAge: 'Mileage',
        minimumBid: 'Minimum bid',
        moreDescription: 'More information',
        mostTechnicallyWeightOfRide: 'Technically permissible maximum weight',
        mostTechnicallyAcceptableWeight: 'The maximum permitted weight of the combination',
        name: 'Name',
        next: 'Next',
        news: 'News',
        numberOfBids: 'Number of bids',
        numberOfSeets: 'Number of seets',
        ok: 'OK',
        operationWeight: 'Operating weight',
        password: 'Password',
        phoneNumber: 'Phone number',
        postCode: 'Post code',
        power: 'Power',
        protectionPersonalData: 'Protection of personal data',
        registration: 'Registration',
        registrationSent: 'Registration sucessfully sent!',
        requiredFields: 'Required fields',
        repeatPassword: 'Repeat password',
        seller: 'Seller',
        sendingNews: 'Sending news',
        share: 'Share',
        specification: 'Specifications',
        state: 'State',
        startingPrice: 'Starting price',
        step1: 'Step 1/3',
        street: 'Street',
        submit: 'Submit',
        table: 'Table',
        technicalViewOfTheVehicle: 'Technical view of the vehicle',
        terms: 'Terms',
        termsAndConditions: 'Terms and conditions',
        titleAfter: 'Prefix',
        titleBefore: 'Postfix',
        transmission: 'Transmission',
        user: 'User',
        usersAdministration: 'Users administration',
        userLoggedInSuccessfully: 'Successfully logged in.',
        userLoggedOutSuccessfully: 'Logged out successfully.',
        userName: 'User name',
        updatedSuccessfully: 'Record updated sucessfully.',
        userNotAuthenticated: 'Wrong user name or password!',
        validation_min_chars: 'At least {0} characters!',
        validation_max_chars: 'Maximum {0} characters!',
        validation_required: 'Is required!',
        validation_pwd_must_be_same: 'Passwords must be equal!',
        vehicleVinNumber: 'Vehicle VIN',
        webPageUrl: 'Web page URL',
        yearOfManufacture: 'Year of manufacture',
    };

    private static sk: Dictionary<string> = {};

    private static de: Dictionary<string> = {};

    private static ru: Dictionary<string> = {};
}
