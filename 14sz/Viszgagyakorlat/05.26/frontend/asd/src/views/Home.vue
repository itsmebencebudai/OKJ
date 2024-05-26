<template>
    <div>
        <h1>Hello World</h1>
    </div>
</template>

<script>

export default {
    name: 'HomeWebPage',
    methods: {
        add() {
            this.$router.push('/add');
        },
        list() {
            this.$router.push('/list');
        }
    }
}
</script>

<style scoped>
    h1 {
        color: red;
    }
</style>