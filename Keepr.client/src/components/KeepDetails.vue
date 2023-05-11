<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-6">
                <img class="img-fluid" :src="activeKeep?.img" :alt="activeKeep?.name">
            </div>
            <div class="col-6">
                <div class="row">
                    <div class="col-12">
                        <i class="mdi mdi-eye-outline">{{ activeKeep?.views }}</i>
                        <i class="mdi mdi-alpha-k-box-outline">{{ activeKeep?.kept }}</i>
                        <button class="btn btn-danger" @click="deleteKeep(activeKeep?.id)">delete keep</button>
                    </div>
                    <div class="col-12">
                        <h5>{{ activeKeep?.name }}</h5>
                        <p>{{ activeKeep?.description }}</p>
                    </div>
                    <div class="col-12 d-flex justify-content-between">
                        <div class="dropdown">
                            <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                        My Vaults
                                    </button>
                            <ul class="dropdown-menu">
                                <li v-for="v in vaults" class="dropdown-item" href="#" @click="getVaultById(v.id)">{{ v.name }}</li>
                            </ul>
                        </div>
                        <button class="btn btn-secondary" @click="createVaultKeep(activeKeep?.id)">Save</button>
                        <img class="profile-pic selectable" :src="activeKeep?.creator?.picture" :alt="activeKeep?.name">
                        <p>{{ activeKeep?.creator?.name }}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { keepsService } from '../services/KeepsService.js';
import { Modal } from 'bootstrap';
import { vaultsService } from '../services/VaultsService.js';
import { vaultKeepsService } from '../services/VaultKeepsService.js';
export default {
    setup() {
        return {
            activeKeep: computed(() => AppState.activeKeep),
            vaults: computed(() => AppState.myVaults),
            activeVault: computed(() => AppState.activeVault),

            async deleteKeep(keepId) {
                try {
                    logger.log('keepId', keepId)
                    if (await Pop.confirm('Do you want to delete this Keep?')) {
                        await keepsService.deleteKeep(keepId)
                    }
                    Modal.getOrCreateInstance('#keep-details').hide()
                } catch (error) {
                    Pop.error(error)
                }
            },

            async getVaultById(vaultId) {
                try {
                    await vaultsService.getVaultById(vaultId)
                } catch (error) {
                    Pop.error(error)
                }
            },

            async createVaultKeep(keepId) {
                try {
                    const vaultId = this.activeVault.id
                    logger.log("vaultId :", vaultId,", keepId :", keepId )
                    const vaultKeepData = {vaultId, keepId}
                    logger.log('vaultKeepData', vaultKeepData)
                    await vaultKeepsService.createVaultKeep(vaultKeepData)
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
.profile-pic {
    height: 4vh;
    width: 4vh;
    border-radius: 50%;
}
</style>