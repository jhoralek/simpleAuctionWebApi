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
        auctions: 'Aukce',
        auctionHall: 'Aukční síň',
        actualPrice: 'Aktuální cena',
        bids: 'Příhozy',
        birthNumber: 'Rodné číslo',
        cancel: 'Zrušit',
        city: 'Město',
        close: 'Zavřít',
        companyLegalNumber: 'DIČ',
        companyNumber: 'IČO',
        contact: 'Kontakt',
        country: 'Země',
        customer: 'Zákazník',
        customerDetail: 'Detail zákazníka',
        dealer: 'Prodávající',
        email: 'Email',
        end: 'Konec',
        faq: 'Otázky a odpovědi',
        feeExpirationDate: 'Datum vypršení poplatku',
        firstName: 'Jméno',
        forDealers: 'Pro prodejce',
        home: 'Domů',
        language: 'Jazyk',
        lastName: 'Příjmení',
        link: 'Odkaz',
        login: 'Přihlásit se',
        logout: 'Odhlásit',
        name: 'Název',
        news: 'Novinky',
        ok: 'OK',
        password: 'Heslo',
        phoneNumber: 'Telefonní číslo',
        postCode: 'PSČ',
        protectionPersonalData: 'Ochrana osobních údajů',
        requiredFields: 'Povinné  pole',
        sendingNews: 'Zasílat novinky',
        street: 'Ulice',
        submit: 'Odeslat',
        terms: 'Podmínky',
        termsAndConditions: 'Obchodní podmínky',
        titleAfter: 'Titul za',
        titleBefore: 'Titul před',
        user: 'Uživatel',
        userLoggedInSuccessfully: 'Úspěšně přihlášen.',
        userLoggedOutSuccessfully: 'Úspěšně odhlášen.',
        userName: 'Uživatelské jméno',
        userNotAuthenticated: 'Špatné jméno nebo heslo!',
        validation_min_chars: 'Minimum znaků {0}',
        webPageUrl: 'URL webových stránek',
    };

    private static en: Dictionary<string> = {
        about: 'About',
        address: 'Address',
        active: 'Active',
        action: 'Action',
        auctions: 'Auctions',
        auctionHall: 'Auction hall',
        actualPrice: 'Current price',
        bids: 'Bids',
        birthNumber: 'Birth number',
        cancel: 'Cancel',
        city: 'City',
        close: 'Close',
        companyLegalNumber: 'Company legal number',
        companyNumber: 'Company number',
        contact: 'Contact',
        country: 'Country',
        customer: 'Customer',
        customerDetail: 'Customer\'s detail',
        dealer: 'Dealer',
        email: 'Email',
        end: 'End',
        faq: 'FAQ',
        feeExpirationDate: 'Fee expiration date',
        firstName: 'First name',
        forDealers: 'For dealers',
        home: 'Home',
        language: 'Language',
        lastName: 'Last name',
        link: 'Link',
        login: 'Login',
        logout: 'Logout',
        name: 'Name',
        news: 'News',
        ok: 'OK',
        password: 'Password',
        phoneNumber: 'Phone number',
        postCode: 'Post code',
        protectionPersonalData: 'Protection of personal data',
        requiredFields: 'Required fields',
        sendingNews: 'Sending news',
        street: 'Street',
        submit: 'Submit',
        terms: 'Terms',
        termsAndConditions: 'Terms and conditions',
        titleAfter: 'Prefix',
        titleBefore: 'Postfix',
        user: 'User',
        userLoggedInSuccessfully: 'Successfully logged in.',
        userLoggedOutSuccessfully: 'Logged out successfully.',
        userName: 'User name',
        userNotAuthenticated: 'Wrong user name or password!',
        validation_min_chars: 'At least {0} characters',
        webPageUrl: 'Web page URL',
    };

    private static sk: Dictionary<string> = {};

    private static de: Dictionary<string> = {};

    private static ru: Dictionary<string> = {};
}
