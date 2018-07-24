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
  ],
});
