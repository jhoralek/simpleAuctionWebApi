<template>
  <div class="passwordReset">
    <v-layout row wrap>
      <v-flex xs12 md6 class="logo-container">
        <div class="rectangle">
        </div>
        <img :src="logo" class="home-page-logo" />
      </v-flex>
      <v-flex xs12 md6>
        <v-container grid-list-md>
          <v-layout row wrap>
            <v-flex xs12>
              <h1>{{ resx('passwordReset') }}</h1>
            </v-flex>
          </v-layout>
          <v-layout row wrap class="pwd-form" v-if="change">
            <v-flex xs12 >
                <v-form lazy-validation>
                    <v-text-field :label="labelNewPassword"
                                  v-model="change.newPassword"
                                  :append-icon="visibleNewPwdFnc ? 'visibility_off' : 'visibility'"
                                  :append-icon-cb="() => (visibleNewPwdFnc = !visibleNewPwdFnc)"
                                  :type="visibleNewPwdFnc ? 'text' : 'password'"
                                  counter
                                  v-validate="'required|max:25|min:4'"
                                  :error-messages="errors.collect('newPassword')"
                                  data-vv-name="newPassword" />
                    <v-text-field :label="labelRepeatPassword"
                                  v-model="change.repeatNewPassword"
                                  :append-icon="visibleRep ? 'visibility_off' : 'visibility'"
                                  :append-icon-cb="() => (visibleRep = !visibleRep)"
                                  :type="visibleRep ? 'text' : 'password'"
                                  counter
                                  v-validate="{is:change.newPassword, required: true}"
                                  :error-messages="errors.collect('repPassword')"
                                  data-vv-name="repPassword" />
                    <v-btn :loading="loading"
                           :disabled="disable"
                           color="black"
                           @click="submit">
                        {{ resx('submit') }}
                    </v-btn>
                </v-form>
            </v-flex>
          </v-layout>
        </v-container>
      </v-flex>
    </v-layout>
  </div>
</template>

<script lang="ts">
import { State, Action, namespace } from 'vuex-class';
import Component from 'vue-class-component';

import BaseView from '../BaseView.vue';

import { ChangePasswordDto } from '@/poco';
import { SettingsState } from '@/store/types';

const AuthAction = namespace('auth', Action);

@Component({})
export default class ResetPassword extends BaseView {
  @State('settings') private settings: SettingsState;
  @AuthAction('resetPassword') private resetPwd: any;

  private visiblePwd: boolean = false;
  private visibleRepPwd: boolean = false;
  private visibleNewPwd: boolean = false;
  private loading: boolean = false;
  private disable: boolean = false;

  private change: ChangePasswordDto = {
    repeatNewPassword: '',
    newPassword: '',
    token: '',
  } as ChangePasswordDto;

  private mounted() {
    if (this.$route.name === 'passwordReset') {
      this.change.token = this.$route.query.token;
    }
  }

  get logo(): string {
    return `${this.settings.apiUrl.replace('/api', '')}/img/home_cars_jera_trading.png`;
  }
  get labelRepeatPassword(): string {
      return this.settings.resource.repeatPassword;
  }

  get labelNewPassword(): string {
      return this.settings.resource.newPassword;
  }

  get visibleRep(): boolean {
      return this.visibleRepPwd;
  }

  set visibleRep(value: boolean) {
      this.visibleRepPwd = value;
  }

  get visibleNewPwdFnc(): boolean {
    return this.visibleNewPwd;
  }

  set visibleNewPwdFnc(value: boolean) {
    this.visibleNewPwd = value;
  }

  private submit(): void {
    this.$validator.validateAll().then((response) => {
      if (response) {
        this.loading = true;
        this.disable = true;
        this.resetPwd(this.change).then((resp1) => {
          this.loading = false;
          this.disable = false;
          if (resp1) {
            this.$router.push({ name: 'passwordResetSuccessfully' });
          }
        });
      }
    });
  }
}

</script>

<style>

.logo-container {
  position: relative;
}

.home-page-logo {
  width: 90%;
  max-width: 706px;
  top: 0px;
  left: 0px;
  position: absolute;
}

.rectangle {
  max-width: 404px;
  height: 100%;
  border-bottom-right-radius: 59px;
  background-color: #000000;
  z-index: 1;
}

.passwordReset h1 {
  font-family: Roboto;
  font-size: 35px !important;
  font-weight: normal;
  font-style: normal;
  font-stretch: normal;
  line-height: 1.15;
  letter-spacing: 0.3px;
  color: #1a1a2e;
  padding-bottom: 30px !important;
}

.passwordReset .v-btn {
    color: white !important;
    border-radius: 5px !important;
}

.pwd-form {
  max-width: 650px !important;
  padding-bottom: 100px !important;
}

</style>