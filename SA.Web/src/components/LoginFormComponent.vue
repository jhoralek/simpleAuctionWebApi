<template>
    <div class="loginForm">
        <div v-if="auth.login && !auth.isAuthenticated">
            <v-dialog class="login-dialog-container" v-model="auth.error" persistent max-width="500px">
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
                                                v-model="auth.login.userName"
                                                required></v-text-field>
                                        </v-flex>
                                        <v-flex xs12 sm12 md12>
                                            <v-text-field
                                                :label="labelPassword"
                                                v-model="auth.login.password"
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
                            <v-btn color="info" flat @click.native="auth.error = false">{{ resx('close') }}</v-btn>
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
import { State, Action, Getter } from 'vuex-class';

import { AuthState, SettingsState } from '@/store/types';

const namespaceAuth: string = 'auth';
const namespaceProfile: string = 'profile';
const namespaceSettings: string = 'settings';

@Component({})
export default class LoginFormComponent extends Vue {
    @State('auth') public  auth: AuthState;
    @State('settings') public settings: SettingsState;

    @Getter('getTranslate', { namespace: namespaceSettings }) public resx: string;

    @Action('loginUser', { namespace: namespaceAuth }) public login: any;
    @Action('logoutUser', { namespace: namespaceAuth }) public logoutUser: any;
    @Action('loadUser', { namespace: namespaceProfile }) public user: any;
    @Action('changeLanguage', { namespace: namespaceSettings }) public langChange: any;

    private visiblePwd: boolean = false;

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
        this.login(this.auth.login).then((response) => {
            if (response !== undefined) {
                this.user(response.id).then((user) => {
                    this.langChange(user.language);
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
.login-dialog-container {
    height: 100%;
}

.login-dialog-container div {
    vertical-align: middle;
    height: 100%;
}

</style>