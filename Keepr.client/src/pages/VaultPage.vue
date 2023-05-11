<template>
    <div class="container-fluid d-flex justify-content-center">
        <div class="row">
            <div class="col-12">
                <img class="img-fluid" :src="vault?.img" :alt="vault?.name">
                <h1>{{ vault?.name }}</h1>
                <p>by {{ vault?.creator.name }}</p>
                <button class="btn btn-danger" @click="deleteVault(vault?.id)">delete vault</button>
            </div>
            <div class="row">
                <div v-for="k in keptKeeps" :key="k.id" @click="getKeepById(k.id)" data-bs-toggle="modal" data-bs-target="#keptKeep-details" class="col-6 col-md-3">
                    <KeptKeepCard :keptKeep="k" />
                </div>
            </div>
        </div>
    </div>

    <Modal id="keptKeep-details" size="xl">

<template #header>
  <h5 class="text-dark"></h5>
</template>

<template #modalBody>
  <KeptKeepDetails />
</template>

</Modal>
</template>


<script>
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted, watchEffect } from 'vue';
import Pop from '../utils/Pop.js';
import { vaultsService } from '../services/VaultsService.js';
import { logger } from '../utils/Logger.js';
import { vaultKeepsService } from '../services/VaultKeepsService.js'
import KeptKeepCard from '../components/KeptKeepCard.vue';
import KeptKeepDetails from '../components/KeptKeepDetails.vue';
import { keepsService } from '../services/KeepsService.js';
import { Modal } from 'bootstrap';
export default {
    setup() {
        const route = useRoute();
        const router = useRouter();
        async function getVaultById() {
            try {
                const vaultId = route.params.vaultId;
                await vaultsService.getVaultById(vaultId);
            }
            catch (error) {
                let errorMessage = error.response.data;
                if (errorMessage == "Something went wrong.") {
                    logger.error(error);
                    Pop.toast(errorMessage, "error");
                    router.push({ name: "Home" });
                }
                else {
                    Pop.error(error);
                }
            }
        }
        async function getKeepsInVault() {
            try {
                const vaultId = route.params.vaultId;
                await vaultKeepsService.getKeepsInVault(vaultId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        watchEffect(() => {
            route.params.vaultId;
            getVaultById();
            getKeepsInVault();
        });
        return {
            vault: computed(() => AppState.activeVault),
            keptKeeps: computed(() => AppState.keptKeeps),
            activeKeep: computed(() => AppState.activeKeep),

            async getKeepById(keepId) {
                try {
                await keepsService.getKeepById(keepId)
                } catch (error) {
                Pop.error(error)
                }
            },

            async deleteVault(vaultId) {
                try {
                    if (await Pop.confirm('Do you want to delete this Vault?')) {
                        await vaultsService.deleteVault(vaultId)
                    }
                    router.push({ name: 'Account'})
                } catch (error) {
                    Pop.error(error)
                }
            }
        };
    },
    components: { KeptKeepCard }
};
</script>


<style lang="scss" scoped>

</style>