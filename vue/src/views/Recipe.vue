<template>
  <recipe-detail v-bind:id="recipeNumber" />
</template>

<script>
import RecipeDetail from '@/components/RecipeDetail.vue'
export default {
    name: "Recipe",

  components: { 
      RecipeDetail
},
 data() {
     return {
         recipeNumber: 0,
     };
 },

 created() {
     this.recipeNumber = this.$route.params.id;
 },
};
</script>

<style>

</style>