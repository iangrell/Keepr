<template>
    <form @submit.prevent="createKeep">
        <div class="mb-3">
            <label for="" class="form-label">Name</label>
            <input v-model="editable.name" type="text" class="form-control" aria-describedby="helpId">
        </div>
        <div class="mb-3">
            <label for="" class="form-label">Description</label>
            <input v-model="editable.description" type="text" class="form-control" aria-describedby="helpId">
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


<script setup>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js';
import { Modal } from 'bootstrap';
import { router } from '../router.js';

const editable = ref({})

async function createKeep() {
    try {
        let newKeep = await keepsService.createKeep(editable.value)
        Modal.getOrCreateInstance('#create-keep').hide()
    } catch (error) {
        Pop.error(error)
    }
}

</script>


<style lang="scss" scoped>

</style>