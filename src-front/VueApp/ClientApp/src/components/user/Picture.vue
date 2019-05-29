<template>
  <div class="profile-picture">
    <div class="card">
      <header class="card-header">
        <p class="card-header-title">Picture</p>
        <span class="card-header-icon">
          <b-icon icon="camera-enhance-outline"></b-icon>
        </span>
      </header>
      <div class="card-content">
        <b-field>
          <b-upload drag-drop>
            <section class="section">
                <div class="content has-text-centered">
                  <p>
                    <b-icon icon="upload" size="is-large"></b-icon>
                  </p>
                  <p>Drop your files here or click to upload</p>
                </div>
            </section>
          </b-upload>
        </b-field>
      </div>
      <footer class="card-footer">
        <div class="card-footer-item">
          <button class="button is-primary">
            <b-icon icon="check" size="is-small"></b-icon> 
            <span>Save changes</span>
          </button>
        </div>
      </footer>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import { User } from '@/models/User';

export default Vue.extend({
  name: 'UserPicture',
  computed: {
    me(): User {
      return this.$store.getters['auth/currentUser'];
    },
  },
});
</script>

