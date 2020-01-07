import { MutationTree } from "vuex";
import { SettingsState } from "@/store/types";

const mutations: MutationTree<SettingsState> = {
  /**
   * Initialization of the state
   * @param state Settigns state
   * @param res - resource with language mutation
   */
  SETTINGS_INITIAL_STATE(state, { res, apiUrl, version }) {
    state.language = "cs";
    state.resource = res;
    state.countries = undefined;
    state.apiUrl = apiUrl;
    state.tableView = true;
    state.currentForm = "";
    state.version = version;
    state.isMobile = true;
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
  /**
   * Load countries
   * @param state Settings state
   * @param countries Countries to be changed
   */
  SETTINGS_LOAD_COUNTRIES(state, countries) {
    state.countries = countries;
  },
  /**
   * Mutate setup of data view
   * @param state Settings state
   * @param tableView True - tableView / False - gridView
   */
  SETTINGS_CHAGE_DATA_VIEW(state, tableView) {
    state.tableView = tableView;
  },

  SETTINGS_CHANGE_FORM_VIEW(state, formView) {
    state.currentForm = formView;
  },
  /**
   * Change used device from mobile to desktop or vice versa
   * @param state State of the settings store
   * @param isMobile Boolean value when the used device is mobile then true otherwise false
   */
  SETTINGS_CHANGE_DEVICE(state, { isMobile }) {
    state.isMobile = isMobile;
  }
};

export default mutations;
