import { ActionTree } from 'vuex';

import { RootState, MessageState } from '@/store/types';

import {
  MESSAGE_INITIAL_STATE,
  MESSAGE_CHANGE_STATE,
} from '@/store/mutation-types';

const actions: ActionTree<MessageState, RootState> = {
  /**
   * Initial state
   * @param param - comit with mutating of the state
   */
  initialState({ commit }): Promise<boolean> {
    return new Promise<boolean>((resolve) => {
      commit(MESSAGE_INITIAL_STATE);
      return resolve(true);
    });
  },
  /**
   * Change state of the message state
   * @param param0 Commit with mutation of the message state
   * @param mod Module name from where the message become
   * @param message Object of message state
   * @param timeout time in miliseconds until the modal window will be shown
   * @param fromResources determines when the message will be from resource (localization) or plain text
   * @param callbackFnc Customized func to the message button
   * @param buttonText Text on the button (close is default value)
   */
  change({ commit }, { mod, message, timeout, fromResources, callbackFnc, buttonText }): void {
    commit(MESSAGE_CHANGE_STATE, {
      mod,
      message,
      timeout,
      fromResources,
      callbackFnc,
      buttonText,
    });
  },
};

export default actions;
