<script setup lang="ts"> 
</script>
 
<template>
    <div class="chat-input">
      <input type="text" placeholder="Üzenet írása..." @keyup.enter=""/>
      <button>Küldés</button>
    </div>
</template>
<style scoped>
.chat-input {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  padding: 10px;
  background-color: #fff;
}
 
input[type="text"] {
  flex: 1;
  padding: 8px;
  margin-right: 10px;
  border: 1px solid #ccc;
  border-radius: 4px;
}
 

.msg-box {
  background-color: #1c98f7;
  color: #fff;
  max-width: max-content;
  padding: 10px;
  border-radius: 10px;
  margin-bottom: 10px;
}
</style> 
