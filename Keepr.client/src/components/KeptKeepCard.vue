<template>
    <div class="row selectable elevation-5 p-2 m-1">
        <div class="col-12 mb-1">
            <img :src="keptKeep?.img" :alt="keptKeep?.name">
        </div>
        <div class="col-12 d-flex justify-content-between">
            <h3>{{ keptKeep?.name }}</h3>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { KeptKeep } from '../models/KeptKeep.js';
export default {
    props: {
        keptKeep: { type: KeptKeep, required: true}
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