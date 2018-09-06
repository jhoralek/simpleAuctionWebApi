<template>
    <div class="loginForm fill-height">
        <div v-if="!auth.isAuthenticated">
            <v-dialog class="login-dialog-container" v-model="openedModal" persistent max-width="500px">
                <v-btn class="login-button" flat color="white" slot="activator"><div class="btn-text">{{ resx('login') }}</div></v-btn>
                <v-card v-if="openedModal">
                    <v-progress-linear v-if="isLoging" :indeterminate="isLoging"></v-progress-linear>
                    <v-form lazy-validation v-if="!resetPassword">
                        <v-card-title>
                            <span class="headline">{{ resx('login') }}</span>
                        </v-card-title>
                        <v-card-text>
                            <v-container  grid-list-xs pa-0>
                                    <v-layout wrap>
                                        <v-flex xs12 sm12 md12>
                                            <v-text-field
                                                :label= "labelUserName"
                                                v-model="userName"
                                                required></v-text-field>
                                        </v-flex>
                                        <v-flex xs12 sm12 md12>
                                            <v-text-field
                                                :label="labelPassword"
                                                v-model="password"
                                                :append-icon="visible ? 'visibility_off' : 'visibility'"
                                                :append-icon-cb="() => (visible = !visible)"
                                                :type="visible ? 'text' : 'password'"
                                                :hint="validationMinPasswordChars"
                                                min="4"
                                                counter
                                                required></v-text-field>
                                        </v-flex>
                                    </v-layout>
                            </v-container>
                            <small>*{{ resx('requiredFields') }}</small>
                        </v-card-text>
                        <v-card-actions class="form-action">
                            <v-spacer></v-spacer>
                            <v-btn color="black" @click.native="openedModal = false">{{ resx('close') }}</v-btn>
                            <v-btn color="black" @click="submit">{{ resx('submit') }}</v-btn>
                        </v-card-actions>
                        <v-card-actions>
                            <v-btn color="black" flat  @click.native="resetPassword = true"><div class="btn-underscore">{{ resx('passwordReset') }}</div></v-btn>
                        </v-card-actions>
                    </v-form>
                    <v-form lazy-validation v-else>
                        <v-card-title>
                            <span class="headline">{{ resx('passwordReset') }}</span>
                        </v-card-title>
                         <v-card-text>
                            <v-container  grid-list-xs pa-0>
                                    <v-layout wrap>
                                        <v-flex xs12 sm12 md12>
                                            <v-text-field
                                                :label= "labelEmail"
                                                v-model="email"
                                                required
                                                v-validate="'email|required'"
                                                :error-messages="errors.collect('email')"
                                                data-vv-name="email" />
                                        </v-flex>
                                    </v-layout>
                            </v-container>
                            <small>*{{ resx('requiredFields') }}</small>
                        </v-card-text>
                        <v-card-actions class="form-action">
                            <v-spacer></v-spacer>
                            <v-btn color="black" @click.native="resetPassword = false">{{ resx('back') }}</v-btn>
                            <v-btn color="black" @click="submitResetPassword">{{ resx('submit') }}</v-btn>
                        </v-card-actions>
                    </v-form>
                </v-card>
            </v-dialog>

        </div>
        <div v-if="auth.isAuthenticated">
            <v-btn class="login-button" color="white" flat @click="logout"><div class="btn-text">{{ resx('logout') }}</div></v-btn>
        </div>
    </div>
</template>

<script lang="ts">

import { Component, Vue, Prop } from 'vue-property-decorator';
import { State, Action, namespace } from 'vuex-class';

import { AuthState, ProfileState } from '@/store/types';
import { log } from 'util';
import FormBaseComponent from '@/components/FormBaseComponent.vue';
import { AuthResponse, UserShortInfo } from '@/poco';
import { profile } from '@/store/modules';

const SettingsAction = namespace('settings', Action);
const AuthAction = namespace('auth', Action);
const ProfileAction = namespace('profile', Action);

@Component({})
export default class LoginFormComponent extends FormBaseComponent {
    @State('auth') public  auth: AuthState;
    @State('profile') public profile: ProfileState;

    @ProfileAction('loadByUserNameAndToken') public user: any;
    @SettingsAction('changeLanguage') public langChange: any;
    @SettingsAction('changeFormView') public changeFormView: any;
    @AuthAction('loginUser') public login: any;
    @AuthAction('logoutUser') public logoutUser: any;
    @AuthAction('sendEmailToResetPassowrd') private resetPasswordFnc: any;

    private visiblePwd: boolean = false;
    private openedModal: boolean = false;
    private userName: string = '';
    private password: string = '';
    private email: string = '';
    private isLoging: boolean = false;
    private resetPassword: boolean = false;

    // this is because I cannot pass getter function to the component props
    // so I need to create computed props. They can be used in component props
    // example:
    // <component :label="lableUserName" />
    get labelUserName(): string {
        return this.settings.resource.userName;
    }
    get labelPassword(): string {
        return this.settings.resource.password;
    }

    get labelEmail(): string {
        return this.settings.resource.email;
    }

    get validationMinPasswordChars(): string {
        return this.settings.resource.validation_min_chars.replace('{0}', '4');
    }

    get visible(): boolean {
        return this.visiblePwd;
    }
    set visible(value: boolean) {
        this.visiblePwd = value;
    }

    public submit() {
        this.isLoging = true;
        this.login({
            userName: this.userName,
            password: this.password,
        }).then((response) => {
            if (response) {
                this.openedModal = !this.auth.isAuthenticated;
                this.langChange(this.auth.language);
            }
            this.isLoging = false;
        });
    }

    public submitResetPassword() {
        this.$validator.validateAll().then((response) => {
            if (response) {
                this.isLoging = true;
                this.resetPasswordFnc(this.email)
                    .then((resp1) => {
                        this.isLoging = false;
                        if (resp1) {
                            this.openedModal = false;
                        }
                    });
            }
        });
    }

    public logout() {
        this.logoutUser().then((user) => {
            this.$router.push('/'); // it is Vue handler
        });
    }
}

</script>

<style>

.loginForm {
    -webkit-box-align: center;
    -ms-flex-align: center;
    align-items: center;
}

.loginForm div {
    height: 100%;
}

.loginForm div .login-button {
    height: 40px;
    margin-top: 65px;
}

.form-action .v-btn {
    color: white !important;
    border-radius: 5px !important;
}

.login-button .v-btn__content {
    background-color: black !important;
    color: white !important;
    border-radius: 5px !important;
}

.login-button .v-btn__content .btn-text {
    padding-top: 8px !important;
    padding-bottom: 5px !important;
    padding-left: 15px !important;
    padding-right: 15px !important;
}

.btn-underscore {
    font-size: 12px;
    border-bottom: 3px solid black !important;
}

</style>