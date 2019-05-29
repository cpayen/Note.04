<template>
  <div class="me">

    <app-top-nav/>
    <app-left-nav/>
    
    <div class="app-container">
      <router-view/>
    </div>

  </div>
</template>

<script>
import Vue from 'vue';
import AppTopNav from '@/components/common/AppTopNav.vue';
import AppLeftNav from '@/components/common/AppLeftNav.vue';

export default Vue.extend({
  name: 'Main',
  components: {
    AppTopNav,
    AppLeftNav,
  },
});
</script>

<style lang="scss" scoped>
.app-container {
  position: absolute;
  top: 3.25rem;
  left: 4rem;
  right: 0;
  bottom: 0;
}
</style>

