<script setup lang="ts">
import { useUserStore } from '../../../store/user';
import router from '../../router';
 
useUserStore();
 
const logout = () => {
    localStorage.removeItem("userData");
    router.push('/');
};


</script>

<template>
   <div class="chat-header">
        <img src="../../assets/chat-logo.png" alt="">
      <h2>SocketChat</h2>
      <button @click="logout">Kijelentkezés</button>
   </div>
</template>

<style scoped>
.chat-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  padding: 10px;
  background-color: #1c98f7;
  color: #fff;
}
 
.chat-header img {
    height: 50px;
}
</style>