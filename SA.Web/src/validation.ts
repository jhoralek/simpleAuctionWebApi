
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
                street: `"${resource.street}"`,
                language: `"${resource.language}"`,
            },
        };
    }
}
