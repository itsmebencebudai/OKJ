import { createRouter, createWebHashHistory } from 'vue-router'
import AllatoklistaPage from './components/allatoklistaPage.vue';
import MainPage from './components/mainPage.vue';

const router = createRouter({
  history: createWebHashHistory(),
  routes: [
    {
      path: '/',
      name: 'mainPage',
      component: MainPage,
    },
    {
      path: '/list',
      name: 'allatoklista',
      component: AllatoklistaPage,
    },
  ]
})  

export default router;