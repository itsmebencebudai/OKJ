<template>
    <div class="profile-container">
        <h1>Profile</h1>
        <div v-if="loading">Loading...</div>
        <div class="profileDiv" v-else-if="userData">
            <img :src="userData.profilePicture" :alt="userData.name + ' Profile Picture'" v-if="userData.profilePicture"
                class="profile-picture">
            <p class="profile-info">Name: {{ userData.user.name }}</p>
            <p class="profile-info">Email: {{ userData.user.email }}</p>
            <div class="buttondiv">
                <router-link to="/chat" class="chatbutton">Open Chat</router-link>
            </div>
        </div>
        <div v-else class="no-profile">No profile data available</div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import Swal from 'sweetalert2';
import router from '../../router';
import { useRoute } from 'vue-router';

const loading = ref(true);
const route = useRoute();
const userDataString = route.query.userData ?? '';
const userData = typeof userDataString === 'string' ? JSON.parse(userDataString) : null;
const fetchUserData = async () => {
    try {
        loading.value = false;
    } catch (error: any) {
        Swal('Error', error.message || 'Hiba a felhasználói adatok letöltése', 'error');
        router.push('/login');
    }
};

onMounted(fetchUserData);
</script>

<style scoped>
.profile-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    height: max-content;
    width: max-content;
    background-color: #ecf0f1;
    border-radius: 8px;
    padding: 20px;
    margin: 20px;
    color: black;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

h1 {
    font-size: 3rem;
    margin-bottom: 1rem;
    color: #3498db;
}

.profile-picture {
    max-width: 200px;
    max-height: 200px;
    border-radius: 50%;
    margin-bottom: 1rem;
}

.profile-info {
    margin-bottom: 0.5rem;
    font-size: 1.5rem;
}

.no-profile {
    color: #e74c3c;
    margin-top: 2rem;
    font-size: 2rem;
}

.buttondiv {
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
}

.chatbutton {
    margin-top: 20px;
    padding: 10px 20px;
    background-color: #3498db;
    color: white;
    text-decoration: none;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    text-align: center;
    font-size: 20px;
}

.chatbutton:hover {
    background-color: #2980b9;
}
</style>