<template>
  <div class="spaces">
    <div class="has-text-centered" v-if="spaces.length === 0">
      <h2 class="is-2">No space available...</h2>
      <button class="button is-primary" @click="toggleNewSpaceForm()">Create a space now</button>
    </div>
    <b-modal :active.sync="isNewSpaceFormActive" :width="640" scroll="keep">
      <div class="modal-card">
        <header class="modal-card-head">
          <p class="modal-card-title">New space</p>
        </header>
        <section class="modal-card-body">
          <space-form/>
        </section>
      </div>
    </b-modal>
    <ul v-if="spaces.length > 0">
      <li v-for="space in spaces" :key="space.id">{{space.name}}</li>
    </ul>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Space } from '@/models/Space';
import SpaceForm from '@/components/note/SpaceForm.vue';

export default Vue.extend({
  name: 'Spaces',
  components: {
    SpaceForm,
  },
  data() {
    return {
      loaded: false,
      error: false,
      isNewSpaceFormActive: false,
    };
  },
  computed: {
    spaces(): Space[] {
      return this.$store.state.space.spaces;
    },
  },
  methods: {
    toggleNewSpaceForm() {
      this.isNewSpaceFormActive = !this.isNewSpaceFormActive;
    },
  },
  created() {
    this.$store.dispatch('space/loadSpaces');
  },
});
</script>

<style lang="scss" scoped>
h2 {
  padding: .75rem;
  font-size: 1.75rem;
  color: #999;
  text-shadow: 0 1px 2ps rgba(#fff, 1);
}
li {
  padding: 1rem;
}
</style>

