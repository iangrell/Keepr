<template>
    <div class="row elevation-5 p-2 m-1">
        <div class="col-12 mb-1">
            <img class="selectable" data-bs-toggle="modal" data-bs-target="#keep-details" :src="keep?.img" :alt="keep?.name">
        </div>
        <div class="col-12 d-flex justify-content-between">
            <h3>{{ keep?.name }}</h3>
            <router-link :to="{ name: 'Profile', params: { profileId: keep?.creatorId }}">
                <img class="profile-pic selectable" :src="keep?.creator?.picture" :alt="keep?.name">
            </router-link>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Keep } from '../models/Keep.js';
import { Profile } from '../models/Account.js';
export default {
    props: {
        keep: { type: Keep, required: true },
        profile: { type: Profile }
    },

    setup() {
        return {
            // NOTE this is where the keep setActive or getById should live
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

.profile-pic {
    height: 4vh;
    width: 4vh;
    border-radius: 50%;
}
</style>