<script setup lang="ts">
import chatLogout from '../components/chat/chatLogout.vue';
import chatSendMessage from '../components/chat/chatSendMessage.vue';
import chatMessageBox from '../components/chat/chatMessageBox.vue';
</script>
 
<template>
  <div class="chat-container">
    <chatLogout />
    
      <chatMessageBox />
  
    <chatSendMessage />
  </div>
</template>
 
<style >
.chat-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  background-color: #f0f0f0;
}

button {
  background-color: #1c98f7;
  color: #fff;
  border: none;
  padding: 8px 15px;
  border-radius: 4px;
  cursor: pointer;
}
 
button:hover {
  background-color: #2980b9;
}
</style>