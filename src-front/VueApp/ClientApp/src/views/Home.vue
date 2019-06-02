<template>
  <div class="home">
    <div class="columns is-gapless">
      <div class="column is-one-quarter is-left-pane">
        <spaces/>
      </div>
      <div class="column">
        <last-contents/>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import Spaces from '@/components/note/Spaces.vue';
import LastContents from '@/components/note/LastContents.vue';

export default Vue.extend({
  name: 'Home',
  components: {
    Spaces,
    LastContents,
  },
});
</script>

<style lang="scss">

</style>

