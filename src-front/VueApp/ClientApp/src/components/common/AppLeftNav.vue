<template>
  <div class="app-left-nav">

    <router-link :to="{ name: 'app' }">
      <b-icon icon="home-outline"/>
    </router-link>
    <router-link :to="{ name: 'app/profile' }">
      <b-icon icon="account-outline"/>
    </router-link>
    <router-link :to="{ name: 'app/dashboard', params: { id: 123 }}">
      <b-icon icon="star-outline"/>
    </router-link>

  </div>
</template>

<script>
import Vue from 'vue';

export default Vue.extend({
  name: 'AppLeftNav',
});
</script>

<style lang="scss" scoped>
.app-left-nav {
  width: 4rem;
  height: calc(100vh - 3.25rem);
  padding-top: 2rem;
  background: #fff;
  box-shadow: 0 0 3px rgba(#000, .5);
}
a {
  color: #4a4a4a;
  position: relative;
  display: block;
  text-align: center;
  padding: .75rem 0;
  &:hover {
    background: rgba(#EEF2F9, .5);
  }
  &:active {
    background: rgba(#EEF2F9, 1);
  }
  &.router-link-exact-active {
    background: rgba(#EEF2F9, 1);
  }
}
</style>
