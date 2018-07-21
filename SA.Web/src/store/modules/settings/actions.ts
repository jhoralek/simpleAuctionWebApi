import axios from 'axios';
import { ActionTree } from 'vuex';
import {
    RootState,
    SettingsState,
    Dictionary,
} from '@/store/types';

import { Country } from '@/model';

import {
    SETTINGS_INITIAL_STATE,
    SETTINGS_CHANGE_LANG,
    SETTINGS_LOAD_COUNTRIES,
} from '@/store/mutation-types';

import { Translator } from '@/lang';

const actions: ActionTree<SettingsState, RootState> = {
    /**
     * Initial state of Settings object
     * @param param - commit
     */
    initialState({ state, commit, rootState, dispatch }): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            if (!state.language) {
                const res: Dictionary<string> = Translator.setResource('');
                commit(SETTINGS_INITIAL_STATE, res);
                dispatch('loadCountries').then((countries) => {
                    return resolve(true);
                })
                .catch((error) => {
                    return resolve(false);
                });
            }
            return resolve(true);
        });
    },
    /**
     * Change language
     * @param param - commit
     * @param language - new language value
     */
    changeLanguage({commit, rootState }, language: string): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            const res: Dictionary<string> = Translator.setResource(language);
            return axios.get(`${rootState.settings.apiUrl}/settings/countries?lang=${language}`)
                    .then((response) => {
                        const countries: Country[] = response.data as Country[];
                        commit(SETTINGS_CHANGE_LANG, { language, res, countries });
                        return resolve(true);
                    })
                    .catch((error) => {
                        return resolve(false);
                    });
        });
    },
    /**
     * Load countries
     * @param param - state
     */
    loadCountries({commit, rootState}): Promise<Dictionary<Country[]>> {
        const lang: string = rootState.settings.language;
        return new Promise<Dictionary<Country[]>>((resolve) => {
            return axios.get(`${rootState.settings.apiUrl}/settings/countries?lang=${lang}`)
                .then((response) => {
                    const countries: Dictionary<Country[]> = response.data as Dictionary<Country[]>;
                    commit(SETTINGS_LOAD_COUNTRIES, countries);
                    return resolve(countries);
                })
                .catch((error) => {
                    return error;
                });
        });
    },
};

export default actions;
