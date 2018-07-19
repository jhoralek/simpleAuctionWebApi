import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
// Instance of the MockAdapter can be only once through app
const MockService: MockAdapter = new MockAdapter(axios);

import UserService from './userService';
import AuthService from './authService';
import SettingsService from './settingsService';
import RecordService from './recordService';

export {
    UserService,
    AuthService,
    SettingsService,
    RecordService,
    MockService, // export as a service and then use in other services as param in constructor
};
