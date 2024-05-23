import { createRouter, createWebHistory } from 'vue-router';
import Home from '../components/Home.vue';
import add from '@/components/add.vue';
import list from '@/components/list.vue';

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/add',
    name: 'TermekFelvetel',
    component: add
  },
  {
    path: '/list',
    name: 'TermekListazas',
    component: list
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
});

export default router;
