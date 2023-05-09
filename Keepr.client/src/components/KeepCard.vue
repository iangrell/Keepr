<template>
    <div class="row selectable elevation-5 p-2 m-1">
        <div class="col-12">
            <img :src="keep.img" :alt="keep.name">
        </div>
        <div class="col-12">
            <h2>{{ keep.name }}</h2>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Keep } from '../models/Keep.js';
export default {
    props: {
        keep: { type: Keep, required: true}
    },

    setup(){
    return {  }
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