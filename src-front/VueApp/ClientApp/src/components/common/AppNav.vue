<template>
  <div class="app-nav">
    <div class="logo">
      <img src="@/assets/logo-w.svg"> 
    </div>
    <ul>
      <li>
        <router-link :to="{ name: 'default' }">
          <b-icon icon="home-outline"/>
        </router-link>
      </li>
      <li>
        <router-link :to="{ name: 'profile' }">
          <b-icon icon="account-outline"/>
        </router-link>
      </li>
      <li>
        <router-link :to="{ name: 'space', params: { space: 'my-space' }}">
          <b-icon icon="plus"/>
        </router-link>
      </li>
      <li>
        <router-link :to="{ name: 'space', params: { space: 'my-space-settings' }}">
          <b-icon icon="settings-outline"/>
        </router-link>
      </li>
    </ul>
  </div>
</template>

<script>
import Vue from 'vue';

export default Vue.extend({
  name: 'AppNav',
});
</script>

<style lang="scss" scoped>
.app-nav {
  width: 4rem;
  height: 100vh;
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
  height: calc(100vh - 4rem);
  padding-top: 2rem;
  background-image: linear-gradient( 116.9deg,  rgba(232,10,116,1) -9.3%, rgba(244,79,79,1) 77.3% );

  a {
    color: #fff;
    position: relative;
    display: block;
    text-align: center;
    padding: .75rem 0;
  }
}
</style>
