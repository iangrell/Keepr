<template>
    <div class="row elevation-5 p-2 m-1">
        <div class="col-12 mb-1">
            <img  class="selectable img-fluid" data-bs-toggle="modal" data-bs-target="#keptKeep-details" :src="keptKeep?.img" :alt="keptKeep?.name">
        </div>
        <div class="col-12 d-flex justify-content-between">
            <h3>{{ keptKeep?.name }}</h3>
            <button class="btn btn-secondary btn-sm" @click="removeVaultKeep(keptKeep?.vaultKeepId)">Remove</button>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { KeptKeep } from '../models/KeptKeep.js';
import Pop from '../utils/Pop.js';
import { vaultKeepsService } from '../services/VaultKeepsService.js';
export default {
    props: {
        keptKeep: { type: KeptKeep, required: true}
    },

    setup(){
    return { 

        async removeVaultKeep(vaultKeepId) {
            try {
                if (await Pop.confirm('Do you want to remove this Keep from this Vault?')) {
                    await vaultKeepsService.removeVaultKeep(vaultKeepId)
                }
            } catch (error) {
                Pop.error(error)
            }
        }
    }
    }
};
</script>


<style lang="scss" scoped>

img {
    height: 30vh;
    width: 100%;
    object-fit: cover;
    object-position: center;
}

</style>