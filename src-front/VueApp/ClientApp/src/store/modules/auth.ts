import { Module } from 'vuex';
import { RootState, AuthState } from '../types';
import { GetterTree } from 'vuex';
import { MutationTree } from 'vuex';
import { ActionTree } from 'vuex';
import { AuthApi } from '@/store/api/AuthApi';

const namespaced: boolean = true;
const currentUserStorageKey: string = 'Note.currentUser';
const currentUserTokenStorageKey: string = 'Note.currentUserToken';

// Helpers

const tryToLogUserIn = (state: any) => {

  // Return if user is already logged in
  if (state.currentUser) {
    return;
  }

  // Get user from local storage
  const localStorageUser = localStorage.getItem(currentUserStorageKey);
  const localStorageUserToken = localStorage.getItem(currentUserTokenStorageKey);
  if (localStorageUser && localStorageUserToken) {
    sessionStorage.setItem(currentUserStorageKey, localStorageUser);
    sessionStorage.setItem(currentUserTokenStorageKey, localStorageUserToken);
    state.currentUser = JSON.parse(localStorageUser);
    state.currentUserToken = localStorageUserToken;
    return;
  }

  // Get user from session storage
  const sessionStorageUser = sessionStorage.getItem(currentUserStorageKey);
  const sessionStorageUserToken = sessionStorage.getItem(currentUserTokenStorageKey);
  if (sessionStorageUser) {
    state.currentUser = JSON.parse(sessionStorageUser);
    state.currentUserToken = sessionStorageUserToken;
    return;
  }
};

// State

const authState: AuthState = {
    currentUser: undefined,
    currentUserToken: undefined,
    error: false,
};

// Getters

const getters: GetterTree<AuthState, RootState> = {
  userIsLoggedIn(state): boolean {
    tryToLogUserIn(state);
    if (state.currentUser && state.currentUserToken) {
      return true;
    }
    return false;
  },
  currentUser(state) {
    tryToLogUserIn(state);
    return state.currentUser;
  },
  currentUserToken(state) {
    tryToLogUserIn(state);
    return state.currentUserToken;
  },
};

// Actions

const actions: ActionTree<AuthState, RootState> = {

  // Login
  login({ commit }, { login, password, rememberMe }) {
    commit('loginRequest');
    AuthApi.login(login, password)
      .then((response) => {
        if (rememberMe) {
          localStorage.setItem(currentUserStorageKey, JSON.stringify(response.user));
          localStorage.setItem(currentUserTokenStorageKey, response.token);
        }
        sessionStorage.setItem(currentUserStorageKey, JSON.stringify(response.user));
        sessionStorage.setItem(currentUserTokenStorageKey, response.token);
        commit('loginSuccess', {
          authUser: response,
        });
      })
      .catch((error) => {
        commit('loginFailure', {
          error,
        });
      });
  },
  logout({ commit }) {
    localStorage.removeItem(currentUserStorageKey);
    localStorage.removeItem(currentUserTokenStorageKey);
    sessionStorage.removeItem(currentUserStorageKey);
    sessionStorage.removeItem(currentUserTokenStorageKey);
    commit('logout');
  },

  // Profile
  updateProfile({ commit, state }, { email, firstName, lastName }) {
    if (!state.currentUser) {
      return;
    }
    AuthApi.setProfileInfo(state.currentUser.id, email, firstName, lastName)
    .then((response) => {
      commit('updateProfileSuccess', {
        profile: response,
      });
    })
    .catch((error) => {
      //
    });
  },
};

// Mutations

const mutations: MutationTree<AuthState> = {

  // Login
  loginRequest(state) {
    state.error = false;
  },
  loginSuccess(state, { authUser }) {
    state.currentUser = authUser.user;
    state.currentUserToken = authUser.token;
  },
  loginFailure(state, error) {
    state.error = true;
  },
  logout(state) {
    state.currentUser = undefined;
    state.currentUserToken = undefined;
    state.error = false;
  },

  // Profile
  // updateProfileRequest(state, { profile }) {
  //   state.currentUser = profile;
  // },
  updateProfileSuccess(state, { profile }) {
    state.currentUser = profile;
  },
  // updateProfileError(state, { profile }) {
  //   state.currentUser = profile;
  // },
};

export const auth: Module<AuthState, RootState> = {
  namespaced,
  state: authState,
  getters,
  actions,
  mutations,
};
