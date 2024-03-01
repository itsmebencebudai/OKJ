<script setup lang="ts">
import router from '../../router';
import chatMessageItem from '../chat_components/chatMessageItem.vue';
import { getData } from '../../extension/connection';
import { onMounted, ref } from 'vue';

const userData = JSON.parse(localStorage.userData);
let messages: any = ref([]);

onMounted(async () => {
  const getMessages = await getData(`${import.meta.env.VITE_BASE_API_URL}message/`, userData.token)
    .catch((err) => {
      if (err) {
        localStorage.removeItem('userData');
        router.push('/');
        window.location.reload();
      }
    })
  messages.value.push(...getMessages);
})

</script>
 
<template>
  <div class="chat-messages">
    <span v-for="message in messages">
      <chatMessageItem v-bind="message" :user="userData.userID" />
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