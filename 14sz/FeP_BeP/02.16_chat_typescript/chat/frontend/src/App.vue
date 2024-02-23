<script setup lang="ts">
import { useUserStore } from '../store/user';
import router from './router';

const userData: any = useUserStore(); 
if (localStorage.getItem('userData')) {
  userData.user = localStorage.getItem('userData');
  if (window.location.pathname === '/') {
    router.push('/chat')
  }
} else {
  router.push('/')
}


</script>

<template>
  <router-view />
</template>

<style scoped>
</style>
