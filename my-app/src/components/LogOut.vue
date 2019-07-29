<template>
    
</template>
<script>
export default {
   created(){
       this.$store.dispatch('LogOut')
       .then(response=>{
           this.$router.push('/')
       })
   }
}
</script>
