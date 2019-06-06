import { Module } from 'vuex';
import { RootState, NoteState } from '../types';
import { GetterTree } from 'vuex';
import { MutationTree } from 'vuex';
import { ActionTree } from 'vuex';
import { NoteApi } from '@/store/api/NoteApi';

import { Space } from '@/models/Space';
import { CreateSpace } from '@/models/CreateSpace';
import { UpdateSpace } from '@/models/UpdateSpace';

const namespaced: boolean = true;

// State

const noteState: NoteState = {
    spaces: undefined,
    currentSpace: undefined,
};

// Getters

const getters: GetterTree<NoteState, RootState> = {

  // Spaces
  spaces(state) {
    return state.spaces;
  },
  currentSpace(state) {
    return state.currentSpace;
  },

};

// Actions

const actions: ActionTree<NoteState, RootState> = {

  // Spaces

  loadSpaces({ commit }) {
    NoteApi.loadSpaces()
    .then((response) => {
      commit('loadSpacesSuccess', { spaces: response });
    })
    .catch((error) => {
      //
    });
  },

  loadSpaceBySlug({ commit }, slug: string) {
    NoteApi.loadSpaceBySlug(slug)
    .then((response) => {
      commit('loadSpaceSuccess', { currentSpace: response });
    })
    .catch((error) => {
      //
    });
  },

  createSpace({ commit }, createSpace: CreateSpace) {
    return new Promise((resolve, reject) => {
      NoteApi.createSpace(createSpace)
      .then((response) => {
        commit('createSpacesSuccess', { newSpace: response });
        resolve(response);
      })
      .catch((error) => {
        reject(error);
      });
    });
  },

  updateSpace({ commit }, { id, updateSpace }) {
    return new Promise((resolve, reject) => {
      NoteApi.updateSpace(id, updateSpace)
      .then((response) => {
        commit('updateSpaceSuccess', { updatedSpace: response });
        resolve(response);
      })
      .catch((error) => {
        reject(error);
      });
    });
  },

  deleteSpace({ commit }, id: string) {
    return new Promise((resolve, reject) => {
      NoteApi.deleteSpace(id)
      .then((response) => {
        commit('deleteSpaceSuccess', { id });
        resolve(response);
      })
      .catch((error) => {
        reject(error);
      });
    });
  },

};

// Mutations

const mutations: MutationTree<NoteState> = {

  // Spaces

  loadSpacesSuccess(state, { spaces }) {
    state.spaces = spaces;
  },
  loadSpaceSuccess(state, { currentSpace }) {
    state.currentSpace = currentSpace;
  },
  createSpacesSuccess(state, { newSpace }) {
    if (!state.spaces) {
      state.spaces = new Array<Space>();
    }
    state.spaces.push(newSpace);
    state.currentSpace = newSpace;
  },
  updateSpaceSuccess(state, { updatedSpace }) {
    if (!state.spaces) {
      return;
    }
    state.spaces = [
      ...state.spaces.filter((o) => o.id !== updatedSpace.id),
      updatedSpace,
    ];
    state.currentSpace = updatedSpace;
  },
  deleteSpaceSuccess(state, { id }) {
    if (!state.spaces) {
      return;
    }
    state.spaces = [
      ...state.spaces.filter((o) => o.id !== id),
    ];
    state.currentSpace = undefined;
  },

};

export const space: Module<NoteState, RootState> = {
  namespaced,
  state: noteState,
  getters,
  actions,
  mutations,
};
