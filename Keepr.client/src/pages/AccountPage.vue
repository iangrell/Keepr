<template>
  <div class="about text-center">
    <img class="rounded" :src="account.coverImg" alt="">
    <img class="rounded" :src="account.picture" alt="" />
    <h1>{{ account.name }}</h1>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  setup() {
    return {
      account: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
