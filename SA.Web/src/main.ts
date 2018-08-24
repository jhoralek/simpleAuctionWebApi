import 'babel-polyfill';
import Vuetify from 'vuetify';
import Vue from 'vue';
import VeeValidate from 'vee-validate';

import moment from 'vue-moment';

import 'babel-polyfill';

import App from './App.vue';
import router from '@/router';
import store from '@/store';

import '@/registerServiceWorker';
import 'vuetify/dist/vuetify.min.css';

import cs from 'vee-validate/dist/locale/cs';
import en from 'vee-validate/dist/locale/en';
import sk from 'vee-validate/dist/locale/sk';
import de from 'vee-validate/dist/locale/de';
import ru from 'vee-validate/dist/locale/ru';

Vue.config.productionTip = false;
Vue.use(Vuetify);
Vue.use(moment);
Vue.use(VeeValidate, {
  locale: 'cs',
  dictionary: { cs, en, sk, de, ru },
});

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');
