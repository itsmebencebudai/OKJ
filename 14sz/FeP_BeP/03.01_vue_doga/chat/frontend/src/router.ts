import {createRouter, createWebHistory} from 'vue-router'

const routes = [{
    path: '/login',
    name: 'Login',
    component: () => import('./pages/Login.vue'),
},
{
    path: "/chat",
    name:'Chat',
    component: () => import('./pages/Chat.vue'),
},
{
    path: "/registration",
    name:'Registration',
    component: () => import('./pages/Registration.vue'),
},

{
    path: "/profile",
    name:'Profile',
    component: () => import('./pages/Profile.vue'),
},
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

export default router