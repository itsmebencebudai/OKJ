import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import { createPinia } from 'pinia';
import router from './router';
import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';

import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faUser } from '@fortawesome/free-regular-svg-icons';
library.add(faUser);

const options = {
    confirmButtonColor: '#41b882',
    cancelButtonColor: '#ff7674',
  };

createApp(App).
use(router).
use(VueSweetalert2,options).
use(createPinia()).
component('font-awesome-icon',FontAwesomeIcon).
mount('#app')
