<template>
  <div class="login">
    <!-- <img alt="Vue logo" src="../assets/logo.png"> -->
    <LoginForm/>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import LoginForm from '@/components/auth/LoginForm.vue'; // @ is an alias to /src

export default Vue.extend({
  name: 'login',
  components: {
    LoginForm,
  },
});
</script>

<style lang="scss" scoped>
.login {
  width: 95%;
  max-width: 400px;
  margin: 0 auto;
  padding-top: 50px;
}
</style>

