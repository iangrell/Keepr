<template>
    <div class="row selectable elevation-5 p-2 m-1">
        <div class="col-12 mb-1">
            <img :src="keep?.img" :alt="keep?.name">
        </div>
        <div class="col-12 d-flex justify-content-between">
            <h3>{{ keep?.name }}</h3>
            <img class="profile-pic" :src="keep?.creator?.picture" :alt="keep?.name">
        </div>
    </div>
</template>

<!-- NOTE we should be bringing in our keep details modal here -->


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Keep } from '../models/Keep.js';
export default {
    props: {
        keep: { type: Keep, required: true }
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