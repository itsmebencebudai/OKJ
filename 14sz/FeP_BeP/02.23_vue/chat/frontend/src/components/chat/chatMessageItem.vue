<script setup lang="ts">
const props = defineProps(['message','name','sendTime']);

</script>
 
<template>
    
    <span class="msg-box" >{{ props.name + props.message + props.sendTime }}</span>
    
</template>
 
<style scoped>
    .msg-box {
  background-color: #1c98f7;
  color: #fff;
  max-width: max-content;
  padding: 10px;
  border-radius: 10px;
  margin-bottom: 10px;
}

 </style>