<template>
  <div class="main">

    <app-nav/>
    
    <div class="main-container">
      <router-view/>
      <user-info/>
    </div>

  </div>
</template>

<script>
import Vue from 'vue';
import AppNav from '@/components/common/AppNav.vue';
import UserInfo from '@/components/auth/UserInfo.vue';

export default Vue.extend({
  name: 'Main',
  components: {
    AppNav,
    UserInfo,
  },
});
</script>

<style lang="scss" scoped>
.main-container {
  position: absolute;
  top: 0;
  left: 4rem;
  right: 0;
  bottom: 0;

  .user-info {
    position: absolute;
    top: 1rem;
    right: 1rem;
  }
}
</style>

