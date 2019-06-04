import { Module } from 'vuex';
import { RootState, NoteState } from '../types';
import { GetterTree } from 'vuex';
import { MutationTree } from 'vuex';
import { ActionTree } from 'vuex';
import { NoteApi } from '@/store/api/NoteApi';

const namespaced: boolean = true;

// State

const noteState: NoteState = {
    spaces: undefined,
    error: false,
};

// Getters

const getters: GetterTree<NoteState, RootState> = {

  // Spaces
  spaces(state) {
    return state.spaces;
  },

};

// Actions

const actions: ActionTree<NoteState, RootState> = {

  // Spaces

  loadSpaces({ commit }) {
    NoteApi.loadSpaces()
    .then((response) => {
      commit('loadSpacesSuccess', {
        spaces: response,
      });
    })
    .catch((error) => {
      //
    });
  },

  createSpace({ commit }, { value }) {
    NoteApi.createSpace(value)
    .then((response) => {
      commit('createSpacesSuccess', {
        spaces: response,
      });
    })
    .catch((error) => {
      //
    });
  },

};

// Mutations

const mutations: MutationTree<NoteState> = {

  // Spaces
  loadSpacesSuccess(state, { spaces }) {
    state.spaces = spaces;
  },

};

export const space: Module<NoteState, RootState> = {
  namespaced,
  state: noteState,
  getters,
  actions,
  mutations,
};
