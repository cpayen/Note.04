<template>
  <div class="login-form">
    <form v-on:submit.prevent="requestSpaceCreation">

      <header class="form-header">
        <h2 class="subtitle is-3">New space</h2>
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
      </main>

    </form>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { CreateSpace } from '@/models/CreateSpace';

export default Vue.extend({
  name: 'AddSpace',
  data() {
    return {
      space: new CreateSpace() as CreateSpace,
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
      return Boolean(this.space.name) && Boolean(this.space.slug);
    },
  },
  watch: {
    hasError() {
      this.loading = false;
      this.error = this.hasError;
    },
  },
  methods: {
    requestSpaceCreation() {
      this.loading = true;
      this.success = false;
      this.error = false;

      this.space.ownerId = this.$store.getters['auth/currentUser'].id;
      // this.$store.dispatch('space/createSpace', this.space);

      this.$store.dispatch('space/createSpace', this.space)
      .then((response) => {
        this.$emit('success');
        this.$router.push({ name: 'space', params: { space: response.slug }});
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
