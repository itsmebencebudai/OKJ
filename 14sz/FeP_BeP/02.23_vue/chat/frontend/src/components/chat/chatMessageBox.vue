<script setup lang="ts">
import chatMessageItem from '../chat/chatMessageItem.vue';
import { getData } from '../../extension/connection';
import { User, useUserStore } from '../../../store/user';
import { onMounted, ref, Ref } from 'vue';

const userData: any = useUserStore();
const user: User = JSON.parse(userData.user);

// Correct type annotation for the ref holding an array
let messages: Ref<any[]> = ref([]);

onMounted(async () => {
  const getMessages = await getData(`${import.meta.env.VITE_BASE_API_URL}message/`, user.token);
  messages.value.push(...getMessages);

  // Logging the messages array
  console.log('Messages:', messages.value[0].userID); // userID
  // Logging the user information
  console.log('User:', user);
})
</script>

<template>
  <div class="chat-messages">
    <div v-for="message in messages" :key="message.id"
      :class="[message.userID === user.userID ? 'user2-message' : 'user1-message']">
      <chatMessageItem v-bind="message" :userID="user.userID" />
    </div>
  </div>
</template>

<style scoped>
.chat-messages {
  width: 100%;
  height: 100vh;
  overflow-y: auto;
  padding: 10px;
  display: flex;
  flex-direction: column-reverse;
}

.user1-message {
  align-self: flex-start;
  /* Align left */
}

.user2-message {
  align-self: flex-end;
  /* Align right */
}
</style>
