<template>
  <div class="profile-password">
    <div class="card">
      <header class="card-header">
        <p class="card-header-title">Change password</p>
        <span class="card-header-icon">
          <b-icon icon="lock-outline"></b-icon>
        </span>
      </header>
      <div class="card-content">
        <form>
          <b-field label="New password">
            <b-input type="password"></b-input>
          </b-field>
          <b-field label="Confirm new password">
            <b-input type="password"></b-input>
          </b-field>
        </form>
      </div>
      <footer class="card-footer">
        <div class="card-footer-item">
          <button class="button is-primary">
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
  name: 'UserPassword',
  computed: {
    me(): User {
      return this.$store.getters['auth/currentUser'];
    },
  },
});
</script>

