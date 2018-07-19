import { GetterTree } from 'vuex';
import { RootState, SettingsState } from '@/store/types';

const getters: GetterTree<SettingsState, RootState> = {
    /**
     * Return translation
     * @param state - Settings state
     * @param key - key of translation
     */
    getTranslate(state) {
        return (key: string) => state.resource[key];
    },
    /**
     * Get available list of countries
     * @param state - Settings state
     */
    getCountries(state) {
        return state.countries;
    },
};

export default getters;
