<template>
  <div class="login-form">
    <form v-on:submit.prevent="requestSpaceUpdate">

      <header class="form-header">
        <h2 class="subtitle is-3">Edit space</h2>
        <div class="has-text-right">
          <button type="submit" class="button is-primary is-medium" :disabled="!formIsValid">Save</button>
        </div>
      </header>

      <main class="form-main">
        <b-field label="Name">
          <b-input size="is-large" v-model="space.name" placeholder="Space name" maxlength="250"></b-input>
        </b-field>
        <a style="float: right">Generate slug from name</a>
        <b-field label="Slug">
          <b-input v-model="space.slug" placeholder="Space slug" maxlength="100"></b-input>
        </b-field>
        <b-field label="Description">
          <b-input type="textarea" v-model="space.description" placeholder="Space description" maxlength="2000"></b-input>
        </b-field>
        <b-field label="Color">
          <b-input v-model="space.color" placeholder="Space color (hex: #000000)" maxlength="8"></b-input>
        </b-field>
      </main>

    </form>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { Space } from '@/models/Space';
import { UpdateSpace } from '@/models/UpdateSpace';

export default Vue.extend({
  name: 'EditSpace',
  props: ['initialSpace'],
  data() {
    return {
      space: Object.assign(new UpdateSpace(), this.initialSpace),
      loading: false,
      error: false,
      success: false,
    };
  },
  computed: {
    hasError(): boolean {
      return this.$store.state.space.error;
    },
    formIsValid(): boolean {
      return Boolean(this.space.name) && Boolean(this.space.slug) && Boolean(this.space.color);
    },
  },
  watch: {
    hasError() {
      this.loading = false;
      this.error = this.hasError;
    },
  },
  methods: {
    requestSpaceUpdate() {
      this.loading = true;
      this.success = false;
      this.error = false;

      this.$store.dispatch('space/updateSpace', { id: this.initialSpace.id, updateSpace: this.space })
      .then((response) => {
        this.$emit('success');
      })
      .catch((error) => {
        this.$emit('error');
      });
    },
  },
  // created() {
  //   this.$nextTick(
  //     () => {
  //       const input = document.getElementById('name');
  //       if (input) {
  //         input.focus();
  //       }
  //     },
  //   );
  // },
});
</script>
