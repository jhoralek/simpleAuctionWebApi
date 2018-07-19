import { MutationTree } from 'vuex';
import { SettingsState } from '@/store/types';

const mutations: MutationTree<SettingsState> = {
    /**
     * Initialization of the state
     * @param state Settigns state
     * @param res - resource with language mutation
     * @param countries - countries with specific lang mutation
     */
    SETTINGS_INITIAL_STATE(state, { res, countries }) {
        state.language = 'cs';
        state.resource = res;
        state.countries = countries;
    },
    /**
     * Change language
     * @param state - Settings state
     * @param language - value of new language
     * @param res - resource with language mutation
     * @param countries - countries with specific lang mutation
     */
    SETTINGS_CHANGE_LANG(state, { language, res, countries }) {
        if (state.language !== language) {
            state.language = language;
            state.resource = res;
            state.countries = countries;
        }
    },
};

export default mutations;
