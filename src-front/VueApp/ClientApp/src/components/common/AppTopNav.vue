<template>
  <div class="app-top-nav">
    <nav class="navbar is-tranparent" role="navigation" aria-label="main navigation">
      <div class="navbar-brand">
        <span class="navbar-item">
          <img src="@/assets/logo-w.svg"> 
        </span>
        <a role="button" id="topNavbarToggler" class="navbar-burger burger" aria-label="menu" aria-expanded="false" @click="toggleMenu">
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
        </a>
      </div>
      <div id="topNavbar" class="navbar-menu">
        <div class="navbar-end">
          <a class="navbar-item">
            <b-icon icon="email" custom-size="mdi-18px"/>
          </a>
          <a class="navbar-item">
            <b-icon icon="bug" custom-size="mdi-18px"/>
          </a>
          <span class="separator"/>
          <UserInfo></UserInfo>
        </div>
      </div>
    </nav>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import UserInfo from '@/components/auth/UserInfo.vue';

export default Vue.extend({
  name: 'AppTopNav',
  components: {
    UserInfo,
  },
  methods: {
    toggleMenu() {
      const $menu = document.getElementById('topNavbar');
      const $toggler = document.getElementById('topNavbarToggler');
      if ($menu && $toggler) {
        $menu.classList.toggle('is-active');
        $toggler.classList.toggle('is-active');
      }
    },
  },
});
</script>

<style lang="scss" scoped>
.navbar {
  height: 3.25rem;
  background: linear-gradient(135deg, #99A7FB, #71B2F8);
}
.navbar-menu {
  background: linear-gradient(135deg, #99A7FB, #71B2F8);
}
.navbar-item {
  color: #fff;
  .icon {
    margin-left: 3px;
    margin-right: 3px;
  }
  &:hover {
    color: #fff;
    background: #65abf7;
  }
  &:active {
    background: #59a5f7
  }
}
.navbar-brand {
  .navbar-item {
    width: 4rem;
    height: 3.25rem;
    background: #888EDC;
    img {
      margin: 0 auto;
    }
  }
}
</style>
