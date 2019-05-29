import { Module } from 'vuex';
import { RootState, ProfileState } from '../types';
import { GetterTree } from 'vuex';
import { MutationTree } from 'vuex';
import { ActionTree } from 'vuex';
import { auth } from './auth';
import { User } from '@/models/User';
import Api from '../../api/api';

const namespaced: boolean = true;
// let currentUser: User;

// State

const profileState: ProfileState = {
    user: undefined,
};

// Getters

const getters: GetterTree<ProfileState, RootState> = {
  user(state) {
    return state.user;
  },
};

// Actions

const actions: ActionTree<ProfileState, RootState> = {
  loadProfile({ commit, rootState }) {
    //
  },
  updateProfile({ commit }, { email, firstName, lastName }) {
    //
  },
  updatePassword({ commit }, { currentPassword, newPassword }) {
    //
  },
};

// Mutations

const mutations: MutationTree<ProfileState> = {
  //
};

export const profile: Module<ProfileState, RootState> = {
  namespaced,
  state: profileState,
  getters,
  actions,
  mutations,
};
