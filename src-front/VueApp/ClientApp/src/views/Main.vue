<template>
  <div class="main">
    <app-nav/>
    <div class="main-container" ref="mainContainer">
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
.main {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  display: flex;
  flex-direction: row;
}
.main-container {
  flex-grow: 1;
  height: 100%;
}
</style>

