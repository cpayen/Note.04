<template>
  <div class="main">

    <app-nav/>
    
    <div class="main-container">
      <router-view/>
    </div>

  </div>
</template>

<script>
import Vue from 'vue';
import AppNav from '@/components/common/AppNav.vue';

export default Vue.extend({
  name: 'Main',
  components: {
    AppNav,
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
}
</style>

