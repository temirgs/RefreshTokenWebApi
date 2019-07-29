import Vue from "vue";
import Router from "vue-router";
import Home from "./views/Home.vue";
import AddPersonal from "./components/AddPersonal.vue";
import Login from "./components/Login.vue";
import LogOut from "./components/LogOut.vue";
import Register from "./components/Register.vue"
Vue.use(Router);

export default new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "Home",
      component: Home,
      meta:{
        requiresAuth:true,
      }
    },
    {
      path: "/AddPersonal",
      name: "AddPersonalme",
      component: AddPersonal,
      meta:{
        requiresAuth:true,
      }
    },
    {
      path: "/Login",
      name: "Login",
      component: Login,
      meta:{
        requiresVisitor:true,
      }

    },
    {
      path: "/Register",
      name: "Register",
      component: Register,
      meta:{
        requiresVisitor:true,
      }

    },
    {
      path: "/LogOut",
      name: "LogOut",
      component: LogOut
    },

  ]
});
