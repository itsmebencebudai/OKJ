<script setup lang="ts">
import { ref } from 'vue';
import { postData, getData } from '../../extension/connection';
// import router from '../../router';

const userData = JSON.parse(localStorage.userData);
const messagebox = ref('');
const sendmessage = async () => {
  try {
    const upload = await postData(`${import.meta.env.VITE_BASE_API_URL}message`, { "message": messagebox.value, "userID": userData.userID }, userData.token);
    // console.log(messagebox.value);

    if (upload.ok) {
      messagebox.value = " ";
      getData(`${import.meta.env.VITE_BASE_API_URL}message`, userData.token);
      window.location.reload();
    }
  }
  catch (e) {
    console.log(e);
  }
}

</script>

<template>
  <div class="chat-input">
    <input type="text" placeholder="Üzenet írása..." @keydown.enter="sendmessage" v-model="messagebox" />
    <button @click="sendmessage">Küldés</button>
  </div>
</template>
<style scoped>
.chat-input {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  padding: 10px;
  background-color: transparent;
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