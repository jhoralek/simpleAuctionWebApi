/* eslint-disable no-console */

import { register } from 'register-service-worker';
import { log } from 'util';

if (process.env.NODE_ENV === 'production') {
    register(`${process.env.NODE_ENV}/service-worker.js`, {
        ready() {
            log(
                'App is being served from cache by a service worker.\n' +
                'For more details, visit https://goo.gl/AFskqB');
        },
        cached() {
            log('Content has been cached for offline use.');
        },
        updated() {
            log('New content is available; please refresh.');
        },
        offline() {
            log('No internet connection found. App is running in offline mode.');
        },
        error(error: any) {
            error('Error during service worker registration:', error);
        },
    });
}
