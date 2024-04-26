import { createRouter, createWebHashHistory } from 'vue-router'
import mainPage from './components/mainPage.vue'
import autoList from './components/autoList.vue'
import add from './components/addNew.vue'

const router = createRouter({
  history: createWebHashHistory(),
  routes: [
    {
      path: '/',
      name: 'mainPage',
      component: mainPage
    },
    {
      path: '/list',
      name: 'autoList',
      component: autoList
    },
    {
      path: '/new',
      name: 'add',
      component: add
    }
  ]
})  

export default router;