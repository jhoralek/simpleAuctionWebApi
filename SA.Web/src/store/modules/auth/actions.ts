import { ActionTree } from "vuex";
import axios from "axios";

import { RootState, AuthState } from "@/store/types";

import { AuthResponse, LoginDto, ChangePasswordDto } from "@/poco";

import { MessageStatusEnum } from "@/model";

import {
  AUTH_LOGIN_USER,
  AUTH_LOGOUT_USER,
  AUTH_INITIAL_STATE,
  AUTH_SET_LANGUAGE,
  AUTH_TAKE_SECOND_TO_LOGOUT,
  AUTH_RESET_TIMER,
  AUTH_SET_TIMER,
  AUTH_STOP_TIMER
} from "@/store/mutation-types";

const actions: ActionTree<AuthState, RootState> = {
  startTimer({ commit, dispatch }): Promise<boolean> {
    return new Promise<boolean>(resolve => {
      const timer = setInterval(() => {
        commit(AUTH_TAKE_SECOND_TO_LOGOUT);
        dispatch("auth/checkTime", {}, { root: true });
      }, 1000);
      commit(AUTH_SET_TIMER, { timer });

      return resolve(true);
    });
  },
  stopTimer({ commit }): Promise<boolean> {
    return new Promise<boolean>(resolve => {
      commit(AUTH_STOP_TIMER);
      return resolve(true);
    });
  },
  resetTimer({ commit, rootState, dispatch }): Promise<boolean> {
    return new Promise<boolean>(resolve => {
      if (rootState.auth.timer != undefined || rootState.auth.timer != null) {
        commit(AUTH_RESET_TIMER);
        dispatch("message/initialState", {}, { root: true });
      }
      return resolve(true);
    });
  },
  checkTime({ rootState, dispatch }): Promise<boolean> {
    return new Promise<boolean>(resolve => {
      if (rootState.auth.secondsToLogout <= 300) {
        if (rootState.auth.secondsToLogout == 0) {
          dispatch("auth/logoutUser", {}, { root: true });
          return resolve(true);
        }
        const msg =
          rootState.settings.resource["autoLogoutMessage"] +
          rootState.auth.secondsToLogout +
          " " +
          rootState.settings.resource["seconds"];

        dispatch(
          "message/change",
          {
            mod: "Auth",
            message: {
              state: MessageStatusEnum.Warning,
              message: msg
            },
            timeout: rootState.auth.secondsToLogout * 1000,
            fromResources: false,
            buttonText: "extend",
            callbackFnc: () => {
              dispatch("auth/resetTimer", {}, { root: true });
            }
          },
          { root: true }
        );
      }

      return resolve(true);
    });
  },
  /**
   * Validate time to auto logout
   */
  timeValidation({ rootState, dispatch }): Promise<boolean> {
    return new Promise<boolean>(resolve => {
      if (rootState.auth.secondsToLogout > 0) {
        dispatch("auth/resetTimer", {}, { root: true });
      } else {
        dispatch("auth/logoutUser", {}, { root: true });
      }

      return resolve(true);
    });
  },
  /**
   * Login user
   * Will change token after user is successfuly logged in change state
   * @param param - commit with mutating of the state
   * @param login - object with login information
   */
  loginUser(
    { commit, rootState, dispatch },
    login: LoginDto
  ): Promise<boolean> {
    return new Promise<boolean>(resolve => {
      return axios
        .post(`${rootState.settings.apiUrl}/accounts/login`, {
          UserName: login.userName,
          Password: login.password
        })
        .then(response => {
          const user: AuthResponse = response.data as AuthResponse;
          commit(AUTH_LOGIN_USER, { user });
          if (user.error !== null) {
            dispatch(
              "message/change",
              {
                mod: "Auth",
                message: {
                  state: MessageStatusEnum.Error,
                  message: user.error
                }
              },
              { root: true }
            );
            return resolve(false);
          } else {
            dispatch(
              "message/change",
              {
                mod: "Auth",
                message: {
                  state: MessageStatusEnum.Success,
                  message: "userLoggedInSuccessfully"
                },
                timeout: 2000
              },
              { root: true }
            );
            dispatch("auth/startTimer", {}, { root: true });
            return resolve(true);
          }
        })
        .catch(error => {
          dispatch(
            "message/change",
            {
              mod: "Auth",
              message: {
                state: MessageStatusEnum.Error,
                message: error
              }
            },
            { root: true }
          );
          return resolve(false);
        });
    });
  },
  /**
   * Reset LoginUser object
   * @param param - cmmit with mutating of the state
   */
  logoutUser({ commit, dispatch }): void {
    commit(AUTH_LOGOUT_USER);
    dispatch("auth/stopTimer", {}, { root: true });
    dispatch(
      "message/change",
      {
        mod: "Auth",
        message: {
          state: MessageStatusEnum.Success,
          message: "userLoggedOutSuccessfully"
        },
        timeout: 2000
      },
      { root: true }
    );
  },
  /**
   * Initial state
   * @param param - comit with mutating of the state
   */
  initialState({ commit }): void {
    commit(AUTH_INITIAL_STATE);
  },
  setLanguage({ commit }, language: string): void {
    commit(AUTH_SET_LANGUAGE, language);
    commit(AUTH_RESET_TIMER);
  },
  sendEmailToResetPassowrd(
    { commit, dispatch, rootState },
    email: string
  ): Promise<boolean> {
    return new Promise<boolean>(resolve => {
      return axios
        .get(`${rootState.settings.apiUrl}/users/resetPassword?email=${email}`)
        .then(response => {
          const result = response.data as boolean;
          const myMessage = {
            state: result ? MessageStatusEnum.Success : MessageStatusEnum.Error,
            message: result ? "emailSent" : "emailNotExists"
          };

          dispatch(
            "message/change",
            {
              mod: "Auth",
              message: myMessage
            },
            { root: true }
          );
          resolve(response.data as boolean);
        })
        .catch(error => {
          dispatch(
            "message/change",
            {
              mod: "Auth",
              message: {
                state: MessageStatusEnum.Error,
                message: error
              }
            },
            { root: true }
          );
          return resolve(false);
        });
    });
  },
  resetPassword(
    { commit, dispatch, rootState },
    model: ChangePasswordDto
  ): Promise<boolean> {
    return new Promise<boolean>(resolve => {
      return axios
        .post(`${rootState.settings.apiUrl}/users/resetPassword`, model)
        .then(response => {
          const user: AuthResponse = response.data as AuthResponse;
          commit(AUTH_LOGIN_USER, { user });
          if (user.error !== null) {
            dispatch(
              "message/change",
              {
                mod: "Auth",
                message: {
                  state: MessageStatusEnum.Error,
                  message: user.error
                }
              },
              { root: true }
            );
            return resolve(false);
          } else {
            dispatch(
              "message/change",
              {
                mod: "Auth",
                message: {
                  state: MessageStatusEnum.Success,
                  message: "userLoggedInSuccessfully"
                }
              },
              { root: true }
            );
            return resolve(true);
          }
        })
        .catch(error => {
          dispatch(
            "message/change",
            {
              mod: "Auth",
              message: {
                state: MessageStatusEnum.Error,
                message: error
              }
            },
            { root: true }
          );
          return resolve(false);
        });
    });
  }
};

export default actions;
