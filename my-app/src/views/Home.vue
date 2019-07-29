<template>
  <dir class="container">
    <br />
    <br />
    <table class="table table-borderless">
      <thead>
        <tr>
          <th scope="col">Id</th>
          <th scope="col">Name</th>
          <th scope="col">Surname</th>
          <th scope="col">Phone Number</th>
          <th scope="col">Brith Date</th>
          <th scope="col">Update</th>
          <th scope="col">Delete</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(item,index) in Personal" :key="index">
          <th scope="row">{{item.id}}</th>
          <td>{{item.name}}</td>
          <td>{{item.surname}}</td>
          <td>{{item.phoneNumber}}</td>
          <td>{{item.brithDate}}</td>
          <td>
            <button type="button" class="btn btn-primary">Update</button>
          </td>
          <td>
            <button type="button" class="btn btn-danger">Delete</button>
          </td>
        </tr>
      </tbody>
    </table>
  </dir>
</template>
<script lang="ts">
import Vue from 'vue'
import axios from 'axios'
export default Vue.extend({
  data(){
    return{
      Personal:[]
    } 
  },
  methods:{
    loadPersonal(){
      console.log('home page loaded');
      let token = 'Bearer ' + this.$store.state.token;
      
      console.log(token)
    //axios.defaults.headers.common['Authorization'] = 'bearer' + this.$store.state.token
     axios.get('http://localhost:52091/api/Values/GetPersonalList', {headers: {Authorization: token} }).then(response=>{this.Personal=response.data})
    }
  },
  created()
  {
    this.loadPersonal();
  }
})
</script>
