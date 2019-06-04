<template>
  <div class="spaces-nav">
    <div class="has-text-centered" v-if="spaces && spaces.length === 0">
      <h2 class="is-2">No content available...</h2>
      <router-link :to="{ name: 'addSpace' }" class="button is-primary">
        Create a space now
      </router-link>
    </div>
    <ul v-if="spaces && spaces.length > 0">
      <li v-for="space in spaces" :key="space.id">{{space.name}}</li>
    </ul>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Space } from '@/models/Space';

export default Vue.extend({
  name: 'SpacesNav',
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

