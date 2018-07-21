<template>
    <div class="loginForm">
        <div v-if="!auth.isAuthenticated">
            <v-dialog class="login-dialog-container" v-model="openedModal" persistent max-width="500px">
                <v-btn class="login-button" slot="activator" flat>{{ resx('login') }}</v-btn>
                <v-card>
                    <v-form lazy-validation>
                        <v-card-title>
                            <span class="headline">{{ resx('login') }}</span>
                        </v-card-title>
                        <v-card-text>
                            <v-container grid-list-md>
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
                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn color="info" flat @click.native="openedModal = false">{{ resx('close') }}</v-btn>
                            <v-btn color="success" flat @click="submit">{{ resx('submit') }}</v-btn>
                        </v-card-actions>
                    </v-form>
                </v-card>
            </v-dialog>

        </div>
        <div v-if="auth.isAuthenticated">
            <v-btn class="logout-button" flat @click="logout">{{ resx('logout') }}</v-btn>
        </div>
    </div>
</template>

<script lang="ts">

import { Component, Vue } from 'vue-property-decorator';
import { State, Action, namespace } from 'vuex-class';

import { AuthState, ProfileState } from '@/store/types';
import { log } from 'util';
import BaseComponent from '@/components/BaseComponent.vue';
import { AuthResponse, UserShortInfo } from '@/poco';
import { profile } from '@/store/modules';

const SettingsAction = namespace('settings', Action);
const AuthAction = namespace('auth', Action);
const ProfileAction = namespace('profile', Action);

@Component({})
export default class LoginFormComponent extends BaseComponent {
    @State('auth') public  auth: AuthState;
    @State('profile') public profile: ProfileState;

    @ProfileAction('loadByUserNameAndToken') public user: any;
    @SettingsAction('changeLanguage') public langChange: any;
    @AuthAction('loginUser') public login: any;
    @AuthAction('logoutUser') public logoutUser: any;

    private visiblePwd: boolean = false;
    private openedModal: boolean = false;
    private userName: string = '';
    private password: string = '';

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
        this.login({
            userName: this.userName,
            password: this.password,
        }).then((response) => {
            const authResponse: AuthResponse = response as AuthResponse;
            if (authResponse.userName !== null) {
                this.openedModal = !this.auth.isAuthenticated;
                this.langChange(this.auth.language);
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
.login-dialog-container {
    height: 100%;
}

.login-dialog-container div {
    vertical-align: middle;
    height: 100%;
}

</style>