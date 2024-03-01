<template>
  <div class="registration-container">
    <h1>Registration</h1>
    <form @submit.prevent="register">
      <div class="error-message">{{ error }}</div>
      <div class="input-container">
        <input type="text" placeholder="Username" v-model="username" class="input-field">
        <input type="email" placeholder="E-mail" v-model="email" class="input-field">
        <input type="password" placeholder="Password" v-model="password" class="input-field">
        <input type="password" placeholder="Confirm Password" v-model="confirmPassword" class="input-field">
        <label>Van már fiókja?<span @click="redirectToLogin">Katt ide!</span></label>
      </div>
      <button class="register-button">Register</button>
    </form>
  </div>
</template>
  
<script setup lang="ts">
import { ref } from 'vue';
import { autFetch } from '../../extension/connection';
import router from '../../router';
import Swal from 'sweetalert2';

const username = ref('');
const email = ref('');
const password = ref('');
const confirmPassword = ref('');
const error = ref('');

const redirectToLogin = () => {
  router.push('/login');
}

const register = async () => {
  try {
    if (!username.value || !email.value || !password.value || !confirmPassword.value) {
      error.value = "Töltse ki az összes mezőt megfelelően!";
      Swal("Hiba...", "Töltse ki az összes mezőt megfelelően!", "error");
      return;
    }

    if (password.value !== confirmPassword.value) {
      error.value = "A jelszavak nem egyeznek";
      Swal("Hiba...", "A jelszavak nem egyeznek", "error");
      return;
    }

    const data = await autFetch(`${import.meta.env.VITE_BASE_API_URL}registration`, { "username": username.value, "email": email.value, "password": password.value });

    if (data.status === 404 || data.status === 401) {
      Swal("Figyelem!", data.error, "error");
      throw new Error(data.error);
    }

    router.push('/login');
  } catch (err: any) {
    console.log(err);
    Swal('Hiba', `${err}`, 'error');
  }
}
</script>
  
<style scoped>
.registration-container {
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


label {
  color: black;
}

span {
  text-decoration: underline;
  color: blue;
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
}

.input-field:focus {
  border-color: #3498db;
}

.register-button {
  background-color: #3498db;
  color: #fff;
  padding: 10px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 1.5rem;
  transition: background-color 0.3s;
}

.register-button:hover {
  background-color: #2980b9;
}

.error-message {
  color: #e74c3c;
  margin-bottom: 15px;
  text-align: center;
}
</style>
  