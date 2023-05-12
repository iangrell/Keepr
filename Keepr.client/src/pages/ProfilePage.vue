<template>
    <div class="about text-center">
        <img class="rounded" :src="profile.coverImg" alt="" />
        <img class="rounded" :src="profile.picture" alt="" />
        <h1>{{ profile.name }}</h1>
        <p>5 Vaults | 21 Keeps</p>
    </div>
    <section class="row justify-content-center">
        <div class="col-md-8">
            <h3>Vaults</h3>
            <div class="row">
                <div v-for="v in vaults" :key="v.id" class="col-3">
                    <VaultCard :vault="v" />
                </div>
            </div>
        </div>
        <div class="col-md-8">
            <h3>Keeps</h3>
            <div class="row">
                <div v-for="k in keeps" :key="k.id" data-bs-toggle="modal"
                    data-bs-target="#keep-details" class=" col-6 col-md-3 mb-3">
                    <KeepCard :keep="k" />
                </div>
            </div>
        </div>
    </section>

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
import { AppState } from '../AppState';
import { computed, reactive, onMounted, watchEffect } from 'vue';
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';
import { routerKey, useRoute, useRouter } from 'vue-router';
import { profilesService } from '../services/ProfilesService.js';
export default {
    setup(){
        const route = useRoute();
        const router = useRouter();

        async function getProfile() {
            try {
                const profileId = route.params.profileId;
                await profilesService.getProfile(profileId);
            } catch (error) {
                // let errorMessage = error.response.data;
                // if (errorMessage == "Something went wrong.") {
                //     logger.error(error);
                //     Pop.toast(errorMessage, "error");
                //     router.push({ name: "Home"});
                // }
                // else {
                    Pop.error(error)
                }
                
            }
            watchEffect(() => {
                route.params.profileId;
                getProfile();
        
        });

    return {  
        profile: computed(() => AppState.activeProfile),
        vaults: computed(() => AppState.vaults),
        keeps: computed(() => AppState.keeps),

        async getKeepById(keepId) {
            try {
                await keepsService.getKeepById(keepId)
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