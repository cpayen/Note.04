import Vue from 'vue';
import Router from 'vue-router';
import Login from './views/Login.vue';
import Main from './views/Main.vue';
import Home from '@/views/Home.vue';
import Profile from './views/Profile.vue';
import store from './store/store';

Vue.use(Router);

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/login',
      name: 'login',
      component: Login,
    },
    {
      path: '/',
      name: 'main',
      component: Main,
      children: [
        {
          path: '/',
          name: 'home',
          component: Home,
        },
        {
          path: 'profile',
          name: 'profile',
          component: Profile,
        },
        {
          path: ':space',
          name: 'space',
          component: Home,
        },
      ],
    },
  ],
});

router.beforeEach((to, from, next) => {
  if (to.name && to.name !== 'login') {
    if (!store.getters['auth/userIsLoggedIn']) {
      router.push({ name: 'login' });
    }
  }
  if (to.name && to.name === 'login') {
    if (store.getters['auth/userIsLoggedIn']) {
      router.push({ name: 'home' });
    }
  }
  next();
});

export default router;
