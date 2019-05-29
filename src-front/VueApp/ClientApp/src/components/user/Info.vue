<template>
  <div class="profile-info">
    <div class="card">
      <header class="card-header">
        <p class="card-header-title">Informations</p>
        <span class="card-header-icon">
          <b-icon icon="account-outline"></b-icon>
        </span>
      </header>
      <div class="card-content">
        <form>
          <b-field label="Username">
            <b-input v-model="user.userName" disabled></b-input>
          </b-field>
          <b-field label="Email">
            <b-input v-model="user.email" required></b-input>
          </b-field>
          <b-field label="First name">
            <b-input v-model="user.firstName"></b-input>
          </b-field>
          <b-field label="Last name">
            <b-input v-model="user.lastName"></b-input>
          </b-field>
        </form>
      </div>
      <footer class="card-footer">
        <div class="card-footer-item">
          <button class="button is-primary" @click="update()">
            <b-icon icon="check" size="is-small"></b-icon> 
            <span>Save changes</span>
          </button>
        </div>
      </footer>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { User } from '@/models/User';

export default Vue.extend({
  name: 'UserInfo',
  computed: {
    user(): User {
      return this.$store.getters['auth/currentUser'];
    },
  },
  methods: {
    update() {
      this.$store.dispatch('auth/updateProfile', {
        email: this.user.email,
        firstName: this.user.firstName,
        lastName: this.user.lastName });
    },
  },
});
</script>

