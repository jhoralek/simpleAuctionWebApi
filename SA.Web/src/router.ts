import Vue from 'vue';
import Router from 'vue-router';
import {
  About,
  Contact,
  Customer,
  Faq,
  ForDealers,
  Home,
  News,
  ProtectionPersonalData,
  TermsAndConditions,
  Auction,
  AuctionDetail,
  UserAdministration,
  AuctionAdministration,
  RecordsAdministration,
  Cookies,
  Gdpr,
  GdprAdministration,
  Registration,
  Results,
  ResetPassword,
  AuctionEnded,
  AuctionEndedAdministration,
  GdprInfo,
} from '@/views';

import { state } from '@/store/modules/auth';

Vue.use(Router);

const authenticated = (to, from, next) => {
  if (state.isAuthenticated) {
    next();
    return;
  }
  next('/');
};

const adminAuthenticated = (to, from, next) => {
  if (state.isAuthenticated && state.isDealer) {
    next();
    return;
  }
  next('/');
};

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/about',
      name: 'about',
      component: About,
    },
    {
      path: '/auctions',
      name: 'auctions',
      component: Auction,
    },
    {
      path: '/contact',
      name: 'contact',
      component: Contact,
    },
    {
      path: '/customer',
      name: 'customer',
      component: Customer,
      beforeEnter: authenticated,
    },
    {
      path: '/usersAdministration',
      name: 'usersAdministration',
      component: UserAdministration,
      beforeEnter: adminAuthenticated,
    },
    {
      path: '/record-administration',
      name: 'recordAdministration',
      component: RecordsAdministration,
      beforeEnter: adminAuthenticated,
    },
    {
      path: '/auctionsAdministration',
      name: 'auctionsAdministration',
      component: AuctionAdministration,
      beforeEnter: adminAuthenticated,
    },
    {
      path: '/gdprAdministration',
      name: 'gdprAdministration',
      component: GdprAdministration,
      beforeEnter: adminAuthenticated,
    },
    {
      path: '/faq',
      name: 'faq',
      component: Faq,
    },
    {
      path: '/forDealers',
      name: 'forDealres',
      component: ForDealers,
    },
    {
      path: '/',
      name: 'home',
      component: Home,
    },
    {
      path: '/news',
      name: 'news',
      component: News,
    },
    {
      path: '/ended',
      name: 'ended',
      component: AuctionEnded,
    },
    {
      path: '/endedAdministration',
      name: 'endedAdministration',
      component: AuctionEndedAdministration,
      beforeEnter: adminAuthenticated,
    },
    {
      path: '/protectionPersonalData',
      name: 'protectionPersonalData',
      component: ProtectionPersonalData,
    },

    {
      path: '/termsAndConditions',
      name: 'termsAndConditions',
      component: TermsAndConditions,
    },
    {
      path: '/auctionDetail',
      name: 'auctionDetail',
      component: AuctionDetail,
    },
    {
      path: '/cookies',
      name: 'cookies',
      component: Cookies,
    },
    {
      path: '/gdpr-info',
      name: 'gdprInfo',
      component: GdprInfo,
    },
    {
      path: '/gdpr',
      name: 'gdpr',
      component: Gdpr,
    },
    {
      path: '/registration',
      name: 'registration',
      component: Registration,
    },
    {
      path: '/validation-expired',
      name: 'validationExpired',
      component: Results,
    },
    {
      path: '/validated-successfully',
      name: 'validationSucessfully',
      component: Results,
    },
    {
      path: '/password-reset-failed',
      name: 'passwordResetFailed',
      component: Results,
    },
    {
      path: '/password-reset',
      name: 'passwordReset',
      component: ResetPassword,
    },
    {
      path: '/successfully-registered',
      name: 'successfullyRegistered',
      component: Results,
    },
    {
      path: '/password-reset-successfully',
      name: 'passwordResetSuccessfully',
      component: Results,
    },
  ],
});
