<template>
  <div class="space">
    <div v-if="space">
      <div v-if="!editing" class="space-detail">
        <button @click="setEditingMode(true)">edit space</button>
        <button @click="deleteSpace()">delete space</button>
        <h1>{{space.name}}</h1>
        <p v-if="space.description">{{space.description}}</p>
      </div>
      <div v-if="editing">
        <button @click="setEditingMode(false)">cancel</button>
        <edit-space :initial-space="space"/>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Space } from '@/models/Space';
import EditSpace from '@/components/note/EditSpace.vue';

export default Vue.extend({
  name: 'Space',
  components: {
    EditSpace,
  },
  data() {
    return {
      editing: false,
      loaded: false,
      error: false,
    };
  },
  computed: {
    space(): Space {
      return this.$store.getters['space/currentSpace'];
    },
  },
  methods: {
    setEditingMode(edit: boolean) {
      this.editing = edit;
    },
    loadSpace(slug: string) {
      this.setEditingMode(false);
      this.$store.dispatch('space/loadSpaceBySlug', slug);
    },
    deleteSpace() {
      this.$store.dispatch('space/deleteSpace', this.space.id)
      .then((response) => {
        this.$router.push({ name: 'default' });
      })
      .catch((error) => {
        // this.$emit('error');
      });
    },
  },
  watch: {
    '$route.params.space'(space) {
      this.loadSpace(space);
    },
  },
  created() {
    this.loadSpace(this.$router.currentRoute.params.space);
  },
});
</script>
