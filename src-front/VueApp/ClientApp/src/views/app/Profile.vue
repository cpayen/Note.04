<template>
  <div class="profile">
    <h1 class="is-size-3 has-text-grey">My profile</h1>
    <div class="columns">
      <div class="column is-one-quarter">
        <user-info/>
      </div>
      <div class="column is-one-quarter">
        <user-picture/>
      </div>
      <div class="column is-one-quarter">
        <user-password/>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import UserInfo from '@/components/user/Info.vue';
import UserPicture from '@/components/user/Picture.vue';
import UserPassword from '@/components/user/Password.vue';

export default Vue.extend({
  name: 'Profile',
  components: {
    UserInfo,
    UserPicture,
    UserPassword,
  },
});
</script>

<style lang="scss">
h1 {
  margin-bottom: 2rem;
  text-shadow: 0 2px 1px #fff;
}
.profile {
  padding: 30px 50px;
}
.upload .upload-draggable {
  display: block;
}
</style>

