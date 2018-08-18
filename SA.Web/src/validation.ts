
import { Translator } from './lang';
import { Dictionary } from '@/store/types';

export default class Validation {
    public static loadValidationAttributes(formName: string, language: string): any {
        const resource = Translator.setResource(language);
        return this.rgistrationForm(resource);
    }

    private static rgistrationForm(resource: Dictionary<string>): any {
        return {
            attributes: {
                userName: `"${resource.userName}"`,
                password: `"${resource.password}"`,
                repPassword: `"${resource.repeatPassword}"`,
                isAgreementToTerms: `"${resource.agreementToTerms}"`,
                lastName: `"${resource.lastName}"`,
                firstName: `"${resource.firstName}"`,
                phoneNumber: `"${resource.phoneNumber}"`,
                email: `"${resource.email}"`,
                titleAfter: `"${resource.titleAfter}"`,
                titleBefore: `"${resource.titleBefore}"`,
                birthNumber: `"${resource.birthNumber}"`,
                webPageUrl: `"${resource.webPageUrl}"`,
                companyName: `"${resource.companyName}"`,
                companyNumber: `"${resource.companyNumber}"`,
                companyLegalNumber: `"${resource.companyLegalNumber}"`,
                city: `"${resource.city}"`,
                countryId: `"${resource.country}"`,
                postCode: `"${resource.postCode}"`,
                stret: `"${resource.street}"`,
                language: `"${resource.language}"`,
                name: `"${resource.name}"`,
                minimumBid: `"${resource.minimumBid}"`,
                startingPrice: `"${resource.startingPrice}"`,
                validFrom: `"${resource.validFrom}"`,
                validTo: `"${resource.validTo}"`,
                mileAge: `"${resource.mileAge}"`,
                active: `"${resource.active}"`,
                color: `"${resource.color}"`,
                fuel: `"${resource.fuel}"`,
                engineCapacity: `"${resource.engineCapacity}"`,
                power: `"${resource.power}"`,
                vin: `"${resource.vehicleVinNumber}"`,
                dors: `"${resource.doors}"`,
                numberOfSeets: `"${resource.numberOfSeets}"`,
                euroNorm: `"${resource.euroNorm}"`,
                axel: `"${resource.axle}"`,
                transmission: `"${resource.transmission}"`,
                state:  `"${resource.state}"`,
                contactToAppointment: `"${resource.contactToAppointment}"`,
                operationgWeight: `"${resource.operationgWeight}"`,
                maximumWeight: `"${resource.maximumWeight}"`,
                maximumWeightOfRide: `"${resource.maximumWeightOfRide}"`,
                dimensions: `"${resource.dimensions}"`,
                mostTechnicallyWeightOfRide: `"${resource.mostTechnicallyWeightOfRide}"`,
                mostTechnicallyAcceptableWeight: `"${resource.mostTechnicallyAcceptableWeight}"`,
                registrationCheck: `"${resource.registrationCheck}"`,
                equipment: `"${resource.equipment}"`,
                defects: `"${resource.defects}"`,
                moreDescription: `"${resource.moreDescription}"`,
                dateOfFirstRegistration: `"${resource.dateOfFirstRegistration}"`,
                bid: `"${resource.bid}"`,
                applicationType: `"${resource.applicationType}"`,
            },
        };
    }
}
