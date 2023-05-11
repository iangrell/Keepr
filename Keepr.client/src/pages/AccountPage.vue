<template>
  <div class="about text-center">
    <img class="rounded" :src="account.coverImg" alt=""/>
    <img class="rounded" :src="account.picture" alt="" />
    <button data-bs-toggle="modal" data-bs-target="#AccountEditForm" class="btn btn-secondary">edit</button>
    <h1>{{ account.name }}</h1>
    <p>5 Vaults | 21 Keeps</p>
  </div>
  <section class="row justify-content-center">
    <div class="col-md-8">
      <h3>Vaults</h3>
      <div class="row">
        <div v-for="v in vaults" :key="v.id" class="col-3">
          <VaultCard :vault="v"/>
        </div>
      </div>
    </div>
    <div class="col-md-8">
      <h3>Keeps</h3>
    </div>
  </section>

  <Modal id="AccountEditForm" size="xl">

<template #header>
  <h5 class="text-dark"></h5>
</template>

<template #modalBody>
  <AccountEditForm />
</template>

</Modal>
</template>

<script>
import { computed, onMounted, watchEffect } from 'vue'
import { AppState } from '../AppState'
import Pop from '../utils/Pop.js'
import { vaultsService } from '../services/VaultsService.js'
import { logger } from '../utils/Logger.js'
import VaultCard from '../components/VaultCard.vue'
import { keepsService } from '../services/KeepsService.js'


export default {
    setup() {
        async function getMyVaults() {
            try {
                const profileId = AppState?.account?.id;
                await vaultsService.getMyVaults(profileId);
            }
            catch (error) {
                Pop.error(error);
            }
        };

        async function getMyKeeps() {
          try {
            const profileId = AppState?.account?.id;
            await keepsService.getMyKeeps(profileId);
          } catch (error) {
            Pop.error(error)
          }
        }

        watchEffect(() => {
            if (AppState.account.id) {
                getMyVaults();
            }
        });
        return {
            account: computed(() => AppState.account),
            vaults: computed(() => AppState.vaults),
        };
    },
    components: { VaultCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
