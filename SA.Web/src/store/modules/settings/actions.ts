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
} from '@/store/mutation-types';

import { Translator } from '@/lang';
import { SettingsService } from '@/services';

const service: SettingsService = new SettingsService();

const actions: ActionTree<SettingsState, RootState> = {
    /**
     * Initial state of Settings object
     * @param param - commit
     */
    initialState({ state, commit }): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            if (!state.language) {
                const res: Dictionary<string> = Translator.setResource('');
                return service.getCountries('cs').then((countries) => {
                    commit(SETTINGS_INITIAL_STATE, { res, countries });
                    return resolve(true);
                });
            }
            return resolve(false);
        });
    },
    /**
     * Change language
     * @param param - commit
     * @param language - new language value
     */
    changeLanguage({commit }, language: string): Promise<boolean> {
        return new Promise<boolean>((resolve) => {
            return service.getCountries(language).then((countries) => {
                const res: Dictionary<string> = Translator.setResource(language);
                commit(SETTINGS_CHANGE_LANG, { language, res, countries });
                return resolve(true);
            });

        });
    },
    /**
     * Load countries
     * @param param - state
     */
    loadCountries({state}): Promise<Country[]> {
        return service.getCountries(state.language).then((response) => {
            return response;
        });
    },
};

export default actions;
