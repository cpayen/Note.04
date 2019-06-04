import Vue from 'vue';
import Router from 'vue-router';
import Login from './views/Login.vue';
import Main from './views/Main.vue';
import Home from '@/views/Home.vue';
import LastContent from '@/components/note/LastContents.vue';
import AddSpace from '@/components/note/AddSpace.vue';
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
          children: [
            {
              path: '/',
              name: 'last',
              component: LastContent,
            },
            {
              path: 'add',
              name: 'addSpace',
              component: AddSpace,
            },
            {
              path: ':space',
              name: 'space',
              // component: Space,
            },
            {
              path: ':space/add',
              name: 'addPage',
              // component: Space,
            },
            {
              path: ':space/:page',
              name: 'page',
              // component: Home,
            },
          ],
        },
        {
          path: 'profile',
          name: 'profile',
          component: Profile,
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
