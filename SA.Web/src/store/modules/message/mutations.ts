import { MutationTree } from 'vuex';

import { MessageState } from '@/store/types';

const mutations: MutationTree<MessageState> = {
  /**
   * Initializaction of error state
   * @param state Error state
   */
  MESSAGE_INITIAL_STATE(state) {
    state.isOn = false;
    state.module = undefined;
    state.created = undefined;
    state.message = undefined;
    state.timeout = 6000;
    state.fromResources = true;
    state.callbackFnc = undefined;
    state.buttonText = 'close';
  },
  /**
   * Change error state
   * @param state Error state
   * @param param1 Object error to mutate state
   */
  MESSAGE_CHANGE_STATE(state, { mod, message, timeout, fromResources, callbackFnc, buttonText }) {
    state.isOn = true;
    state.module = mod;
    state.created = new Date();
    state.message = message;
    state.timeout = timeout === undefined ? 6000 : timeout;
    state.fromResources = fromResources === undefined ? true : false;
    state.callbackFnc = callbackFnc;
    state.buttonText = buttonText === undefined ? 'close' : buttonText;
  },
};

export default mutations;
