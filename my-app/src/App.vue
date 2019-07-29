<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
      <a class="navbar-brand" style="color:white;" href="#">Navbar</a>
      <button
        class="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarColor01"
        aria-controls="navbarColor01"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarColor01">
        <ul class="navbar-nav mr-auto">

           <li class="nav-item active">
            <router-link  to="/"><span style="color:white;"  class="btn btn-link" >Home</span></router-link>       
          </li>

          <li class="nav-item active">
            <router-link   to="/AddPersonal"><span style="color:white;" class="btn btn-link">New Personal</span></router-link>       
          </li>
         
        </ul>

        <form class="form-inline my-2 my-lg-0">
         <router-link v-if="!loggedIn" to="/Login" style="margin-right:20px;color:white" class="btn btn-success">Login</router-link>
         <router-link v-if="!loggedIn" to="/Register" style="margin-right:20px;color:white" class="btn btn-dark">Register</router-link>
         <router-link v-if="loggedIn" to="/LogOut" style="margin-right:20px;color:white" class="btn btn-danger">LogOut</router-link>
        </form>

      </div>
    </nav>
    <router-view />
  </div>
</template>
<script>
export default {
  computed:{
    loggedIn(){
      return this.$store.getters.loggedIn
    }
  }
}
</script>
