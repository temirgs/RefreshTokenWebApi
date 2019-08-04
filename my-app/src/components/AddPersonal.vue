<template>
  <div class="container">
    <br />
    <br />
    <form @submit.prevent="OnSubmit">
      <md-field>
        <label>Name</label>
        <md-input id="name" v-model="personal.name"></md-input>
      </md-field>

      <md-field>
        <label>Surname</label>
        <md-input id="surname" v-model="personal.surname"></md-input>
      </md-field>

      <md-field>
        <label>Phone Number</label>
        <md-input id="phone" v-model="personal.phonenumber"></md-input>
      </md-field>

      <md-field>
        <label>Brith Date</label>
        <md-input id="brithdate" v-model="personal.brithdate"></md-input>
      </md-field>

      <button id="newpersonal" type="submit" class="btn btn-primary btn-lg btn-block">New Personal</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      personal: {
        name: "",
        surname: "",
        phonenumber: "",
        brithdate: ""
      }
    };
  },
  methods: {
    OnSubmit() {
      //token get
      let token = "Bearer " + this.$store.state.token;
      const HTTP = axios.create({
        baseURL: "http://localhost:52091/api/Values/",
        headers: { Authorization: token }
      });
      HTTP.post("AddPErsonal", this.personal).then(response => {
        this.$router.push("/");
      });
      
      // let token = "Bearer " + this.$store.state.token;
      // axios.post('http://localhost:52091/api/Values/AddPErsonal',this.personal,{headers: { Authorization: token }})
      // .then(response=>{
      //   console.log(response.data)
      //   this.$router.push("/");
      // })
   }
  }
};
</script>
