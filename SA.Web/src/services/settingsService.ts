import Mock from '@/mock/mock';
import { MockService } from '@/services';
import { Country } from '@/model';

export default class SettingsService {
    private service: Mock;

    constructor() {
        this.service = new Mock(MockService);
    }
    /**
     * Get list of countries
     * @param lang - language which determine what language mutation of
     * countries will be choosen.
     */
    public getCountries(lang: string): Promise<Country[]> {
        return this.service.getCountries(lang).then((countries) => {
            return countries.data;
        });
    }
}
