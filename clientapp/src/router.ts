import Vue from "vue";
import Router from "vue-router";
import Login from "./views/Login.vue";
import Demo from "./views/Demo.vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/login",
      name: "login",
      component: Login
    },
    {
      path: "/demo",
      name: "demo",
      component: Demo
    },
  ]
});
