<template>
  <div class="user-info navbar-item">
    <div class="buttons">
      <b-dropdown aria-role="list" position="is-bottom-left">
        <button class="button is-primary trigger" slot="trigger">
          <span class="username">{{ userName }}</span>
          <b-icon icon="account-outline"></b-icon>
        </button>
        <b-dropdown-item aria-role="menu-item" custom paddingless>
          <div class="account has-text-centered">
            <div class="thumb">
              <b-icon icon="account-outline" size="is-large"></b-icon>
            </div>
            <div class="username is-size-5">
              <span>{{ userName }}</span>
            </div>
          </div>
          <div class="actions has-text-centered">
            <a class="button is-light">My profile</a>
            <a class="button is-danger" @click="logout()">Logout</a>
          </div>
        </b-dropdown-item>
      </b-dropdown>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'UserInfo',
  computed: {
    userName(): string {
      return this.$store.getters['auth/currentUser'].fullName;
    },
  },
  methods: {
    logout(): void {
      this.$store.dispatch('auth/logout');
      this.$router.push({ name: 'login' });
    },
  },
});
</script>

<style lang="scss" scoped>
.user-info {
  padding: 0;
  margin-left: 15px;
  border-left: 1px solid rgba(#fff, .1);
  .buttons {
    margin: 0;
    margin-right: 5px;
  }
  button {
    height: 3.25rem;
    margin-bottom: 0;
    padding-left: 25px;
    padding-right: 25px;
    .username {
      margin-right: 15px;
    }
  }
  .icon {
    width: 30px;
    height: 30px;
    border-radius: 100%;
    background: rgba(#000, .2);
  }
  .account {
    width: 200px;
    margin: 15px 30px;
    .icon {
      width: 100px;
      height: 100px;
      background: #65abf7;
      color: #fff;
    }
    .username {
      margin: 15px;
    }
  }
  .actions {
    padding-top: 12px;
    border-top: 2px solid #f5f5f5;
  }
}
</style>
