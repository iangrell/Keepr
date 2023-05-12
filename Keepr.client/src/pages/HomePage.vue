<template>
  <div class="container-fluid">
    <div class="row">
      <div v-for="k in keeps" :key="k.id" @click="getKeepById(k.id)" 
        class=" col-6 col-md-3 mb-3">
        <KeepCard :keep="k" />
      </div>
    </div>
  </div>

  <Modal id="keep-details" class="modal-xl">

    <template #header>
      <h5 class="text-dark"></h5>
    </template>

    <template #modalBody>
      <KeepDetails />
    </template>

  </Modal>
</template>

<script>
import { computed, onMounted, watchEffect } from 'vue';
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js'
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';
import KeepDetails from '../components/KeepDetails.vue';
import { logger } from '../utils/Logger.js';

export default {
  setup() {
    onMounted(() => {
      getKeeps();
    });

    async function getKeeps() {
      try {
        await keepsService.getKeeps();
      }
      catch (error) {
        Pop.error(error);
      }
    }

    watchEffect(() => {
      getKeeps();
    })

    return {
      keeps: computed(() => AppState.keeps),
      account: computed(() => AppState.account),
      activeKeep: computed(() => AppState.activeKeep),

      async getKeepById(keepId) {
        try {
          await keepsService.getKeepById(keepId)
        } catch (error) {
          Pop.error(error)
        }
      }
    };
  },
  components: { KeepCard, KeepDetails }
}
</script>

<style scoped lang="scss"></style>
