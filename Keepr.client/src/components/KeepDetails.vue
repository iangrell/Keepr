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
                        <!--FIXME the Id of the activeKeep needs to be passed as a argument inside of this function  -->
                        <button class="btn btn-danger" @click="deleteKeep(activeKeep?.id)">delete keep</button>
                    </div>
                    <div class="col-12">
                        <h5>{{ activeKeep?.name }}</h5>
                        <p>{{ activeKeep?.description }}</p>
                    </div>
                    <div class="col-12 d-flex justify-content-between">
                        <button class="btn btn-secondary">Save</button>
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
export default {
    setup() {
        return {
            activeKeep: computed(() => AppState.activeKeep),

            // TODO create the delete function make sure that we're passing down the activeKeep Id -> now the activeKeep Id is a parameter 
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