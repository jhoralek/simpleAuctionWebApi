import { MutationTree } from 'vuex';
import { AuthState } from '@/store/types';

const TIME_TO_LOGOUT = 30 * 60; // in minutes

const mutations: MutationTree<AuthState> = {
  /**
   * Initialization of the state
   * @param state Auth state
   */
  AUTH_INITIAL_STATE(state) {
    state.userId = undefined;
    state.isAuthenticated = false;
    state.token = undefined;
    state.language = undefined;
    state.userName = undefined;
    state.error = false;
    state.errorMessage = undefined;
    state.isDealer = false;
    state.isFeePayed = false;
    state.secondsToLogout = TIME_TO_LOGOUT;
    state.timer = null;
  },
  /**
   * Mutate state of login
   * @param state Store state
   * @param any - contains login and user object
   */
  AUTH_LOGIN_USER(state, { user }) {
    state.userId = user.userId;
    state.userName = user.userName;
    state.token = user.token;
    state.language = user.language;
    state.isAuthenticated = user.error === null;
    state.error = user.error !== null;
    state.errorMessage = user.error;
    state.isDealer = user.isDealer;
    state.isFeePayed = user.isFeePayed;
    state.secondsToLogout = TIME_TO_LOGOUT;
  },
  /**
   * Logout user
   * @param state Store state of auth
   */
  AUTH_LOGOUT_USER(state) {
    state.userId = undefined;
    state.isAuthenticated = false;
    state.token = undefined;
    state.language = undefined;
    state.userName = undefined;
    state.error = false;
    state.errorMessage = undefined;
    state.isFeePayed = false;
    state.secondsToLogout = TIME_TO_LOGOUT;
  },
  AUTH_SET_LANGUAGE(state, language: string) {
    state.language = language;
    state.error = language !== undefined;
  },
  AUTH_TAKE_SECOND_TO_LOGOUT(state) {
    if (state.secondsToLogout === 0) {
      return;
    }
    state.secondsToLogout--;
  },
  AUTH_SET_TIMER(state, { timer }) {
    state.timer = timer;
  },
  AUTH_STOP_TIMER(state) {
    clearInterval(state.timer);
    state.timer = null;
  },
  AUTH_RESET_TIMER(state) {
    state.secondsToLogout = TIME_TO_LOGOUT;
  },
};

export default mutations;
