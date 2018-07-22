import Vuetify from 'vuetify';
import Vue from 'vue';
import moment from 'vue-moment';

import 'babel-polyfill';

import App from './App.vue';
import router from '@/router';
import store from '@/store';

import '@/registerServiceWorker';
import 'vuetify/dist/vuetify.min.css';

Vue.config.productionTip = false;
Vue.use(Vuetify);
Vue.use(moment);

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');
