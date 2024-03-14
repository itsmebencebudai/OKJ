<script setup lang="ts">
import chatLogout from '../components/chat/chatLogout.vue';
import chatSendMessage from '../components/chat/chatSendMessage.vue';
import chatMessageBox from '../components/chat/chatMessageBox.vue';

window.onload = function () {
  window.scrollTo(0, 0);
}

</script>

<template>
  <div class="chat-container">
    <chatLogout />

    <chatMessageBox />

    <chatSendMessage />
  </div>
</template>

<style>
::-webkit-scrollbar {
  overflow: scroll;
  width: 10px;
  height: 10px;
}

::-webkit-scrollbar-track {
  background-color: transparent;
}

::-webkit-scrollbar-thumb {
  background-color: #1c98f7;
  border-radius: 15px;
}

.chat-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
  background-image: url(https://images.pexels.com/photos/7919/pexels-photo.jpg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1);
  background-size: cover;
  background-repeat: no-repeat;
  background-position: center;
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