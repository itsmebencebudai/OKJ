<script setup lang="ts">
import { ref } from 'vue';
import { autFetch } from '../extension/connection.ts';
import { useUserStore } from '../../store/user';
import router from '../router';
import Swal from 'sweetalert2';
 
const email = ref('');
const password = ref('');
const error = ref('');
 
let userData: any = useUserStore();


const login = async () => {
  try {
    if (!email.value || !password.value) {
      error.value = "";
      Swal("Hiba...", "Töltsd ki az adatokat megfelelően!", "error");
      return;
    }
 
    const data = await autFetch(`${import.meta.env.VITE_BASE_API_URL}login`, {"email": email.value, "password": password.value});
 
    if (data.status === 404 || data.status === 401) {
      Swal("Figyelem!", data.error, "error");
      throw new Error(data.error);
    }
 
    userData.user = data.user;
    localStorage.setItem('userData', JSON.stringify(userData.user));
    router.push('/chat');
  } catch (err:any) {
    console.log(err);
    // SweetAlert hívása egyéb hiba esetén
    
    Swal('Hiba',`${err}`,'error');
  }
}

const signup = () => {
  router.push('/signup')
}
</script>
 
<template>
  <div class="login-container">
    <h1>Login</h1>
    <form @submit.prevent="login">
      <div class="error-message">{{ error }}</div>
      <div class="input-container">
        <input type="email" placeholder="E-mail" v-model="email" class="input-field">
        <input type="password" placeholder="Jelszó" v-model="password" class="input-field">
      </div>
      <div class="login-button-container">
        <button class="login-button">Login</button>
        <a @click="signup" class="login-button right">Regisztráció</a>
      </div>
    </form>
    
  </div>
</template>
 
<style scoped>

.login-button-container {
  display: table;
  width: 100%;
  margin: 0;


}
.login-button-container>button {
  text-align: left;
  display: table-cell;
}
.login-button-container>a {
  text-align: center;
  display: table-cell;
}

.login-container {
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
 
.login-button {
  background-color: #3498db;
  color: #fff;
  padding: 10px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 1.5rem;
  transition: background-color 0.3s;
}
 
.login-button:hover {
  background-color: #2980b9;
}
 
.error-message {
  color: #e74c3c;
  margin-bottom: 15px;
  text-align: center;
}
</style>