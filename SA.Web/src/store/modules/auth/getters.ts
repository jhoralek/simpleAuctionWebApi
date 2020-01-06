import { GetterTree } from "vuex";

import { RootState, AuthState } from "@/store/types";
import { AuthUser } from "@/poco";

const getters: GetterTree<AuthState, RootState> = {
  getCurrentLoggedUser(state): AuthUser {
    return {
      userName: state.userName,
      isDealer: state.isDealer,
      isAuthenticated: state.isAuthenticated,
      token: state.token,
      langauge: state.language,
      isFeePayed: state.isFeePayed,
      userId: state.userId
    } as AuthUser;
  }
};

export default getters;
