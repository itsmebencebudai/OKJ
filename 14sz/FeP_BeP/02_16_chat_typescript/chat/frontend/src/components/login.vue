<script setup lang="ts">
import { ref } from 'vue';
import { autFetch } from '../extension/connection.ts';
import { useUserStore } from '../../store/user';
import router from '../router';

const email = ref('');
const password = ref('');
const error = ref('');

let userData: any = useUserStore();

const login = () => {
  if (!email.value || !password.value) {
    error.value = "Töltsd ki az adatokat megfelelően";
    return
  }
  autFetch("http://localhost:8000/api/login", { "email": email.value, "password": password.value })
    .then((data) => {
      console.log(data);
      if (data.status == 404) {
        error.value = data.error
        throw new Error(data.error);
      }
      if (data.status == 401) {
        error.value = data.error
        throw new Error(data.error);
      }
      userData.user = data.user;
      localStorage.setItem('userData', JSON.stringify(userData.user));
      router.push('/chat');
      console.log(data);


    }).catch((err) => {
      console.log(err);
    })
  //....


}

</script>

<template>
  <!-- <h1>Login</h1>
  <div class="dispflex">
    <form class="dispflex" @submit.prevent="login">
      {{ error }}
      <input type="email" placeholder="email" v-model="email">
      <input type="password" placeholder="jelszó" v-model="password">
      <button>Login</button>
    </form>
  </div> -->
  <div class="dispfelx">
    <div class="container">
      <div class="login_text">
        <div class="h1">Login</div>
        <svg baseProfile="tiny" height="24px" id="Layer_1" version="1.2" viewBox="0 0 24 24" width="24px"
          xml:space="preserve" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
          <path
            d="M17,9c0-1.381-0.56-2.631-1.464-3.535C14.631,4.56,13.381,4,12,4S9.369,4.56,8.464,5.465C7.56,6.369,7,7.619,7,9  s0.56,2.631,1.464,3.535C9.369,13.44,10.619,14,12,14s2.631-0.56,3.536-1.465C16.44,11.631,17,10.381,17,9z" />
          <path d="M6,19c0,1,2.25,2,6,2c3.518,0,6-1,6-2c0-2-2.354-4-6-4C8.25,15,6,17,6,19z" />
        </svg>
      </div>
      <form @submit.prevent="login">
        <input type="email" placeholder="email" v-model="email">
        <input type="password" placeholder="password" v-model="password">
        <span class="error_text">{{ error }}</span>
        <button>Login</button>
      </form>
    </div>
  </div>
</template>



<style>
@import url('https://fonts.cdnfonts.com/css/elegant-2');
</style>

<style scoped>
body {
  background-color: #f5f7fa;
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
}

.dispfelx {
  font-family: 'ELEGANT', sans-serif;
  font-weight: bolder;
  background-image: url(https://wallsneedlove.com/cdn/shop/products/w0518_1s_art-deco-arches-wallpaper-for-walls-all-that-jazz_Repeating-Pattern-Sample-1.jpg?v=1620245484);
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  background-attachment: fixed;
  background-color: #87b2f2;
  justify-content: center;
  display: flex;
  width: 100%;
  height: 80vh;
  align-items: center;
  overflow: hidden;
  zoom: 125%;
  letter-spacing: 3px;
}

.container {
  background-color: #fff;
  border-radius: 10px;
  border: 2px solid goldenrod;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  padding: 20px;
  width: 300px;
  height: auto;
  text-align: center;
  gap: 10px;
  display: flex;
  flex-direction: column;
}

.login_text {
  display: flex;
  justify-content: center;
  align-items: center;
  margin: 10px;
}

.login_text .h1 {
  font-size: 24px;
  color: #333;
  position: relative;
}

.login_text .h1 svg {
  position: relative;
  height: 24px;
  width: 24px;
  top: calc((100% - height)/2);
}

form {
  display: flex;
  flex-direction: column;
  align-items: center;
}

input[type="email"],
input[type="password"] {
  width: 100%;
  margin-bottom: 10px;
  padding: 10px;
  border-radius: 5px;
  border: 1px solid #ccc;
  font-family: 'ELEGANT', sans-serif;
  font-weight: bold;
  letter-spacing: 2px;
}

button {
  padding: 10px 20px;
  background-color: goldenrod;
  color: #333;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s;
  font-family: 'ELEGANT', sans-serif;
  font-weight: bold;
  letter-spacing: 2px;
}

button:hover {
  background-color: #555;
  color: goldenrod;
}

.error_text {
  color: red;
  font-size: 12px;
  text-align: center;
  width: 100%;
  margin: 10px;
}

@media screen and (max-width: 768px) {
  .container {
    width: 80%;
  }
}

@media screen and (max-width: 480px) {
  .container {
    width: 90%;
  }
}
</style>


