<template>
  <div class="app-nav" ref="appNav">
    <div class="logo">
      <img src="@/assets/logo-w.svg"> 
    </div>
    <ul>
      <li>
        <a @click="selectMenu($refs.spacesNav)">
          <b-icon icon="home-outline"/>
        </a>
      </li>
      <li>
        <a @click="selectMenu($refs.userInfo)">
          <b-icon icon="account-outline"/>
        </a>
      </li>
      <li>
        <a>
          <b-icon icon="plus"/>
        </a>
      </li>
      <li>
        <a>
          <b-icon icon="settings-outline"/>
        </a>
      </li>
    </ul>
    <div class="submenu" ref="subMenu">
      <div class="submenu-item spaces-nav-container" ref="spacesNav">
        <spaces-nav/>
      </div>
      <div class="submenu-item user-info-container" ref="userInfo">
        <user-info/>
      </div>
    </div>
  </div>
</template>

<script>
import Vue from 'vue';
import SpacesNav from '@/components/note/SpacesNav.vue';
import UserInfo from '@/components/auth/UserInfo.vue';

export default Vue.extend({
  name: 'AppNav',
  components: {
    SpacesNav,
    UserInfo,
  },
  data() {
    return {
      currentMenu: null,
    };
  },
  methods: {
    selectMenu(menu) {
      if (menu === this.currentMenu) {
        menu.classList.remove('active');
        this.$refs.subMenu.classList.remove('active');
        this.currentMenu = null;
        this.$refs.appNav.style.width = '4rem';
      } else {
        menu.classList.add('active');
        this.$refs.subMenu.classList.add('active');
        if (this.currentMenu !== null) {
          this.currentMenu.classList.remove('active');
        }
        this.$refs.appNav.style.width = '30rem';
        this.currentMenu = menu;
      }
    },
  },
});
</script>

<style lang="scss" scoped>
.app-nav {
  height: 100%;
  width: 4rem;
}
.logo {
  width: 4rem;
  height: 4rem;
  background: #222;
  text-align: center;
  padding-top: .75rem;
}
ul {
  width: 4rem;
  height: calc(100% - 4rem);
  padding-top: 2rem;
  // background-image: linear-gradient( 116.9deg,  rgba(232,10,116,1) -9.3%, rgba(244,79,79,1) 77.3% );
  background: #414141;

  a {
    color: #fff;
    position: relative;
    display: block;
    text-align: center;
    padding: .75rem 0;
  }
}
.submenu {
  display: none;
  position: absolute;
  top: 0;
  left: 4rem;
  bottom: 0;
  width: 26rem;
  background: #f5f5f5;
  border-right: 1px solid #ddd;

  &.active {
    display: block;
  }

  .submenu-item {
    display: none;

    &.active {
      display: block;
    }
  }
}
</style>
