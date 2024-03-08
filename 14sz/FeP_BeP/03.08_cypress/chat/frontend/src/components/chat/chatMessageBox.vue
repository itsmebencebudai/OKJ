<script setup lang="ts">
import chatMessageItem from '../chat/chatMessageItem.vue';
import { getData } from '../../extension/connection';
import { User, useUserStore } from '../../../store/user';
import { onMounted, ref } from 'vue';



const userData: any = useUserStore();
const user = JSON.parse(JSON.stringify( userData.user));
let messages: any = ref([]);

onMounted(async () => {
 
  if (user.token) {
  const getMessages = await getData(`${import.meta.env.VITE_BASE_API_URL}message/`,user.token);
  messages.value.push(...getMessages);}
})
</script>
 
<template>
    <div class="chat-messages">
      <span  v-for="message in messages">
        <chatMessageItem v-bind="message" :user="user.userID"/>
      </span>
    </div>
</template>
 
<style scoped>
.chat-messages {
  width: 100%;
  height: 100vh;
  overflow-y: auto;
  padding: 10px;
  display: inline-flex;
  flex-direction: column-reverse;
}
 </style>