<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'App',
});
</script>

<style>
@import 'https://cdn.materialdesignicons.com/3.5.95/css/materialdesignicons.min.css';
@import 'https://fonts.googleapis.com/css?family=PT+Sans:400,700';
</style>

<style lang="scss">
@import './theme/theme.scss';
body, html {
  width: 100%;
  height: 100%;
  overflow: hidden;
}
</style>
