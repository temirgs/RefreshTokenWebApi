<template>
  <div class="container">
    <br />
    <br />
    <form @submit.prevent="onSubmit">
      <md-field>
        <label>UserName</label>
        <md-input v-model="login.username"></md-input>
      </md-field>

      <md-field>
        <label>Password</label>
        <md-input v-model="login.password" type="password"></md-input>
      </md-field>

      <button type="submit" class="btn btn-primary btn-lg btn-block">Login</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      login: {
        username: "",
        password: ""
      }
    };
  },
  methods: {
    onSubmit() {
      this.$store.dispatch("login", this.login)
      .then(response=>{
            axios.defaults.headers.common['Authorization'] = 'bearer' + this.$store.state.token

        this.$router.push('/');
        
        })
    }
  }
};
</script>