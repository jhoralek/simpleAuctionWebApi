import { GetterTree } from 'vuex';
import { RootState, SettingsState } from '@/store/types';

const getters: GetterTree<SettingsState, RootState> = {
    /**
     * Return translation
     * @param state - Settings state
     * @param key - key of translation
     */
    getTranslate(state) {
        // first character of the key must be lower case
        return (key: string) =>
            state.resource[`${key.charAt(0).toLowerCase()}${key.slice(1)}`] === undefined
                ? `Translate {{ ${key} }}`
                : state.resource[`${key.charAt(0).toLowerCase()}${key.slice(1)}`];
    },
    /**
     * Get available list of countries
     * @param state - Settings state
     */
    getCountries(state) {
        return state.countries[state.language];
    },
    /**
     * Get api url
     * @param state Settings state
     */
    getApiUrl(state) {
        return state.apiUrl;
    },
    /**
     * Get type of data view
     * @param state Settings state
     */
    getDataViewType(state) {
        return state.tableView;
    },
    /**
     * Language
     * @param state Settings state
     */
    getLanguage(state) {
        return state.language;
    },
};

export default getters;
