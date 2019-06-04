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
          <b-input id="name" size="is-large" v-model="name" placeholder="Space name" maxlength="250"></b-input>
        </b-field>
        <a style="float: right">Generate slug from name</a>
        <b-field label="Slug">
          <b-input v-model="slug" placeholder="Space slug" maxlength="100"></b-input>
        </b-field>
        <b-field label="Description">
          <b-input type="textarea" v-model="description" placeholder="Space description" maxlength="2000"></b-input>
        </b-field>
        <b-field label="Color">
          <b-input v-model="color" placeholder="Space color (hex: #000000)" maxlength="8"></b-input>
        </b-field>
      </main>

    </form>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'AddSpace',
  data() {
    return {
      name: null,
      slug: null,
      description: null,
      color: null,
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
      return (this.name || false) && (this.slug || false) && (this.color || false);
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
      this.$store.dispatch('space/createSpace', {
        value: {
          name: this.name,
          slug: this.slug,
          description: this.description,
          color: this.color,
          ownerId: this.$store.getters['auth/currentUser'].id,
        },
      });
    },
  },
  created() {
    this.$nextTick(
      () => {
        const input = document.getElementById('name');
        if (input) {
          input.focus();
        }
      },
    );
  },
});
</script>

<style lang="scss" scoped>
.login-status {
  width: 80px;
  height: 80px;
  border-radius: 100%;
  margin: 0 auto 15px auto;
  padding-top: 18px;
  background: rgba(#fff, .5);
}
</style>

