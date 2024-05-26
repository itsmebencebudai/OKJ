<template>
    <div>
        <h1>Hello World</h1>
        <button @click="add">Add</button>
        <button @click="list">List</button>
    </div>
</template>

<script>
export default {
    name: 'asdWebPage',
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