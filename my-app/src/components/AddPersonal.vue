<template>
  <div class="container">
      <br>
      <br>
      <form action="">
        
      </form>
    <md-field>
      <label>Name</label>
      <md-input v-model="personal.name"></md-input>
    </md-field>

    <md-field>
      <label>Surname</label>
      <md-input v-model="personal.surname" ></md-input>
    </md-field>

    <md-field>
      <label>Phone Number</label>
      <md-input v-model="personal.phonenumber"></md-input>
    </md-field>

    <md-field>
      <label>Brith Date</label>
      <md-input v-model="personal.brithdate"></md-input>
    </md-field>
    <button type="button" class="btn btn-primary btn-lg btn-block">New Personal</button>
  </div>
</template>

<script>
  export default {
    data(){
      return{
        personal:{
          name:'',
          surname:'',
          phonenumber:'',
          brithdate:''
        }
      }
    },
    methods:{

    }
  }
</script>