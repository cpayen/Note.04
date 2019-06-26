<template>
  <div class="home">
    Home...
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
