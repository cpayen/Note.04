import Vue from 'vue';
import Router from 'vue-router';
import Login from './views/Login.vue';
import Main from './views/app/Main.vue';
import Profile from './views/app/Profile.vue';
import Dashboard from './views/app/Dashboard.vue';
import store from './store/store';

Vue.use(Router);

// export default new Router({
const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'login',
      component: Login,
    },
    {
      path: '/app',
      name: 'app',
      component: Main,
      children: [
        {
          path: 'profile',
          name: 'app/profile',
          component: Profile,
        },
        {
          path: 'dashboard/:id',
          name: 'app/dashboard',
          component: Dashboard,
        },
      ],
    },
  ],
});

router.beforeEach((to, from, next) => {
  if (to.name && to.name.indexOf('app') === 0) {
    if (!store.getters['auth/userIsLoggedIn']) {
      router.push({ name: 'login' });
    }
  }
  if (to.name && to.name === 'login') {
    if (store.getters['auth/userIsLoggedIn']) {
      router.push({ name: 'app' });
    }
  }
  next();
});

export default router;
