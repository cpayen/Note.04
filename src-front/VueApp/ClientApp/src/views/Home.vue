<template>
  <div class="home">
    <div class="columns is-gapless">
      <div class="column is-one-quarter is-left-pane">
        <spaces-nav/>
      </div>
      <div class="column is-right-pane">
        <router-view/>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import SpacesNav from '@/components/note/SpacesNav.vue';
import LastContents from '@/components/note/LastContents.vue';

export default Vue.extend({
  name: 'Home',
  components: {
    SpacesNav,
    LastContents,
  },
});
</script>

<style lang="scss">

</style>
