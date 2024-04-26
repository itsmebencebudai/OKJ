<script>
import AddnewFromComponent from "./addnew/addnewFromComponent.vue";

export default {
    name: "AddNew",
    components: {
        AddnewFromComponent
    },
    data() {
        return {};
    },
};
</script>

<template>
    <div class="addnew">
        <AddnewFromComponent />
    </div>
</template>

<style scoped>
.addnew {
    background-position: center;
    background-repeat: repeat-y;
    height: 90vh;
}
</style>