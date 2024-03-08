<script setup lang="ts">
import { ref } from 'vue';
import { postFormData } from '../extension/connection';

const username = ref('');
const email = ref('');
const passwd = ref('');
const passwd2 = ref('');
const error = ref('');
const file = ref<File | null>(null)
const uploadedFile = ref<{ message: string; filename: string } | null>(null)

const onFileChange = (event: Event) => {
  const target = event.target as HTMLInputElement
  file.value = (target.files && target.files[0]) || null
}

const uploadUserData = async () => {
  const formData = new FormData()
  if (file.value) {
    formData.append('file', file.value)
  }
  formData.append('username', username.value)
  formData.append('username', email.value)
  formData.append('username', passwd.value)
  

  try {
    const response = await postFormData (`${import.meta.env.VITE_BASE_API_URL}upload`, formData)

    uploadedFile.value = response.data
  } catch (error) {
    console.error('Hiba a feltöltés során:', error)
  }
}

</script>

<template>
   <div class="signup-container">
    <h1>Regisztráció</h1>
    <form @submit.prevent="uploadUserData">
      <div class="error-message">{{ error }}</div>
      <div class="input-container">
        <input type="text" placeholder="Felhasználó név" v-model="username" class="input-field" required>
        <input type="email" placeholder="Email" v-model="email" class="input-field" required>
        <input type="password" placeholder="Jelszó" v-model="passwd" class="input-field" required>
        <input type="password" placeholder="Jelszó ismét" v-model="passwd2" class="input-field" required>
        <label for="upload">Tölts fel fényképet</label>
        <input type="file" id="upload" @change="onFileChange"  accept="image/png, image/jpg, image/gif, image/jpeg" />
        
        
      </div>
      <button type="submit" class="signup-button">Regisztráció</button>
    </form>
  </div>
</template>
 
<style scoped>

.signup-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  height: 100vh;
}
 
h1 {
  font-size: 3rem;
  margin-bottom: 1rem;
  color: #3498db;
}
 
form {
  width: 300px;
  background-color: #ecf0f1;
  border-radius: 8px;
  padding: 20px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}
 
.input-container {
  margin-bottom: 15px;
}
 
.input-field {
  width: 100%;
  padding: 10px;
  margin-bottom: 15px;
  border: 1px solid #bdc3c7;
  border-radius: 4px;
  background-color: #ecf0f1;
  transition: border-color 0.3s;
  background-color: rgb(206, 206, 206);
  color: black;
}
 
.input-field:focus {
  border-color: #3498db;
}
 
.signup-button {
  background-color: #3498db;
  color: #fff;
  padding: 10px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 1.5rem;
  transition: background-color 0.3s;
}
 
.signup-button:hover {
  background-color: #2980b9;
}
 
.error-message {
  color: #e74c3c;
  margin-bottom: 15px;
  text-align: center;
}
input::file-selector-button {
    background-color: #3498db;
  color: #fff;
  padding: 5px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 1rem;
  transition: background-color 0.3s;
}
input[type=file] {
  width: 350px;
  max-width: 100%;
  color: #444;
  padding: 5px;
  background: #fff;
  border-radius: 10px;
  border: 1px solid #555;
}
input[type=file]::file-selector-button:hover {
  background: #0d45a5;
}
label {
    color: #3498db;
}
</style>