import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);
import axios from 'axios';
export default new Vuex.Store({
  state: {
    token: localStorage.getItem('token') || null
  },

  mutations: {
    login(state, token) {
      state.token = token;
    },
    LogOut(state) {
      state.token = null
    }
  },

  actions: {
    login(context, credentials) {

      return new Promise((resolve, reject) => {

        axios.post('http://localhost:52091/api/Account/Login', credentials)
          .then(response => {
            const token = response.data.token;
            localStorage.setItem('token', token);
            context.commit('login', token)
            resolve(response)
          })

          .catch(error => {
            console.log(error)
            reject(error)
          })

      })

    },

    register(context, credentials) {
      return new Promise((resolve, reject) => {
        axios.post('http://localhost:52091/api/Account/Register', credentials)
          .then(response => {
            resolve(response)
          })
          .catch(error => {
            console.log(error)
            reject(error)
          })
      })
    },

    LogOut(context) {
     
      if (context.getters.loggedIn) {
        localStorage.removeItem('token')
        context.commit('LogOut')
      }
    }
  },
  getters: {

    loggedIn(state) {
      return state.token != null
    },


  }
});
