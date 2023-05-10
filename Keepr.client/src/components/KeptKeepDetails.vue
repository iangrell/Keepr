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
                    </div>
                    <div class="col-12">
                        <h5>{{ activeKeep?.name }}</h5>
                        <p>{{ activeKeep?.description }}</p>
                    </div>
                    <div class="col-12 d-flex justify-content-between">
                        <button class="btn btn-secondary">Remove</button>
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
export default {
    setup(){
    return { 
        activeKeep: computed(() => AppState.activeKeep)
    }
    }
};
</script>


<style lang="scss" scoped>

.profile-pic {
    height: 4vh;
    width: 4vh;
    border-radius: 50%;
}

</style>