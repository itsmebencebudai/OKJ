<template>
    <RouterLink to="/">
        <button class="backtoMainpage">Főoldalra</button>
    </RouterLink>
</template>

<script>
export default {
    name: "BacktoMainpageComponent",
    data() {
        return {};
    },
};  
</script>

<style scoped>
a {
    display: flex;
    justify-content: end;
    text-decoration: none;
}

.backtoMainpage {
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

.backtoMainpage:hover {
    background-color: rgb(228, 213, 0);
    font-weight: bolder;
    border-radius: 10px;
}
</style>