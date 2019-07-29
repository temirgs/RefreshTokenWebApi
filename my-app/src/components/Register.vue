<template>
  <div class="container">
    <br />
    <br />
    <form @submit.prevent="onSubmit">
      <md-field>
        <label>UserName</label>
        <md-input v-model="register.username"></md-input>
      </md-field>

      <md-field>
        <label>Password</label>
        <md-input v-model="register.password" type="password"></md-input>
      </md-field>

      <md-field>
        <label>Email</label>
        <md-input v-model="register.email" type="email"></md-input>
      </md-field>

      <button type="submit" class="btn btn-primary btn-lg btn-block">Register</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      register: {
        username: "",
        password: "",
        email: ""
      }
    };
  },
  methods: {
    onSubmit() {
      this.$store.dispatch("register", this.register).then(response => {
        this.$router.push("/Login");
      });
    }
  }
};
</script>