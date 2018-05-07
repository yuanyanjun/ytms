// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import App from './App'
import axios from 'axios'
import router from './router'
import store from './store'
import echarts from 'echarts'
import Http from './http'
window.http=new Http();
Vue.prototype.$echarts = echarts 
window.router=router;
Vue.config.productionTip = false;
Vue.use(ElementUI)
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App },
  store,
})
