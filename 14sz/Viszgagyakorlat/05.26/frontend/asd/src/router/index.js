import { createRouter, createWebHistory } from 'vue-router';
import Home from '@/views/Home.vue';
import asd from '@/views/asd.vue';

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home,
    },
    {
        path: '/asd',
        name: 'asd',
        componennt: asd,
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
});

export default router;