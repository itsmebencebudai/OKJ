<script>
import buttonLeft from "./mainpage/buttonLeftComponent.vue";
import buttonRight from "./mainpage/buttonRightComponent.vue";

export default {
    name: "mainPage",
    components: {
        buttonLeft,
        buttonRight,
    },
};
</script>

<template>
    <div class="mainPage">
        <div class="button-container">
            <buttonLeft/>
            <buttonRight/>
        </div>
    </div>
</template>

<style scoped>
.mainPage {
    height: 90vh;
    background-image: url("../assets/pet.jpg");
    background-size: contain;
    background-repeat: no-repeat;
    background-position: center;
    display: flex;
    justify-content: center;
}

.button-container {
    display: flex;
    justify-content: space-around;
    align-items: flex-end;
    height: 100%;
    width: 100%;
    flex-direction: row;
    gap: 25%;
}
</style>