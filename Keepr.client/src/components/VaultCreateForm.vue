<template>
    <form @submit.prevent="createVault">
        <div class="mb-3">
            <label for="" class="form-label">Name</label>
            <input v-model="editable.name" type="text" class="form-control" aria-describedby="helpId">
        </div>
        <div class="mb-3">
            <label for="" class="form-label">Img Url</label>
            <input v-model="editable.img" type="text" class="form-control" aria-describedby="helpId">
        </div>
        <div>
            <button class="btn btn-success">Submit</button>
        </div>
    </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { vaultsService } from '../services/VaultsService.js';
import { Modal } from 'bootstrap';
export default {
    setup(){
        const editable = ref({})

    return { 
        editable,

        async createVault() {
            try {
                await vaultsService.createVault(editable.value)
                Modal.getOrCreateInstance('#create-vault').hide()
            } catch (error) {
                Pop.error(error)
            }
        }
    }
    }
};
</script>


<style lang="scss" scoped>

</style>