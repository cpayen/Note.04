import Vue from 'vue';
import Vuex, { StoreOptions } from 'vuex';
import { RootState } from './types';
import { auth } from './modules/auth';
import { space } from './modules/space';

Vue.use(Vuex);

const store: StoreOptions<RootState> = {
  state: {
    version: '1.0.0',
  },
  getters: {
    currentUser(state, getters) {
      return getters['auth/currentUser'];
    },
  },
  modules: {
    auth,
    space,
  },
};

export default new Vuex.Store<RootState>(store);
