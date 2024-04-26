<template>
    <RouterLink to="/new">
        <button class="buttonright" v-link="'/new'">Vásárlás</button>
    </RouterLink>
</template>

<script>
export default {
    name: "ButtonRightComponent",
    data() {
        return {};
    },
};

</script>

<style scoped>
.buttonright {
    width: 300px;
    height: 80px;
    background-color: rgb(128, 213, 0);
    color: white;
    font-size: 30px;
    font-weight: 300px;
    cursor: pointer;
    margin-bottom: 2%;

    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.buttonright:hover {
    background-color: rgb(228, 213, 0);
    font-weight: bolder;
    border-radius: 10px;
}

a {
    text-decoration: none;
}
</style>