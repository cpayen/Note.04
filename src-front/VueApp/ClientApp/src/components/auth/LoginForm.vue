<template>
  <div class="login-form">
      <form v-on:submit.prevent="requestLogin">

        <div class="login-status has-text-centered">
          <b-icon icon="account-outline" size="is-large" type="is-primary" v-show="!loading && !success && !error"></b-icon>
          <b-icon icon="loading" size="is-large" type="is-primary" custom-class="mdi-spin" v-show="loading"></b-icon>
          <b-icon icon="account-check-outline" size="is-large" type="is-success" v-show="success"></b-icon>
          <b-icon icon="account-remove-outline" size="is-large" type="is-danger" v-show="error"></b-icon>
        </div>

        <div class="card">
          <div class="card-content">
            <b-field label="Username">
              <b-input id="username" size="is-medium" v-model="login" placeholder="Your username" icon="account"></b-input>
            </b-field>
            <b-field label="Password">
              <b-input type="password" size="is-medium" password-reveal v-model="password" placeholder="Your password" icon="lock"></b-input>
            </b-field>
              <b-checkbox v-model="rememberMe">Remember me</b-checkbox>
            <hr>
            <button type="submit" class="button is-primary is-fullwidth is-medium" :disabled="!formIsValid">Login</button>
          </div>
        </div>

      </form>
    </div>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'loginform',
  data() {
    return {
      login: null,
      password: null,
      rememberMe: true,
      loading: false,
      error: false,
      success: false,
    };
  },
  computed: {
    currentUser(): any {
      if (this.$store.state.auth.currentUser) {
        this.$router.push({ name: 'app' });
      }
      return this.$store.state.auth.currentUser;
    },
    hasError(): boolean {
      return this.$store.state.auth.error;
    },
    formIsValid(): boolean {
      return (this.login || false) && (this.password || false);
    },
  },
  watch: {
    currentUser() {
      this.loading = false;
      this.success = true;
    },
    hasError() {
      this.loading = false;
      this.error = this.hasError;
    },
  },
  methods: {
    requestLogin() {
      this.loading = true;
      this.success = false;
      this.error = false;
      this.$store.dispatch('auth/login', {
        login: this.login,
        password: this.password,
        rememberMe: this.rememberMe,
      });
    },
  },
  created() {
    this.$nextTick(
      () => {
        const input = document.getElementById('username');
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

