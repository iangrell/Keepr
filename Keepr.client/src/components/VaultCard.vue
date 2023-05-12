<template>
    <div class="row elevation-5 p-2 m-1">
        <div class="col-12 mb-1">
            <router-link :to="{ name: 'Vault', params: { vaultId: vault.id }}">
                <img class="selectable" :src="vault.img" :alt="vault.name">
            </router-link>
        </div>
        <div class="col-12 d-flex justify-content-between">
            <h3 class="text-dark">{{ vault.name }}</h3>
            <i v-if="vault.isPrivate != false" class="mdi mdi-lock text-dark"></i>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Vault } from '../models/Vault.js';
export default {
    props: { 
        vault: { type: Vault, required: true }
    },

    setup(){
    return {  }
    }
};
</script>


<style lang="scss" scoped>

img {
    height: 20vh;
    width: 100%;
    object-fit: cover;
    object-position: center;
}


</style>