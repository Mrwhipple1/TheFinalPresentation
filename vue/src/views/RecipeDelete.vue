<template>
<div>
    <p> id="message">{{message}}</p>
    <h3>Delete Recipe {{deleteRecipe}}</h3>
    <h4>You are about to delete tjhis delicious recipe! Are you sure?</h4>

    <a href="#" class="btn btn-danger" v-on:click="deleteRecipe">Delete</a>

    <router-link class="btn btn-success" v-bind:to="{ name: 'RecipeDetail'}" >
      Cancel</router-link
    >
    </div>
  
</template>

<script>
import recipeService from "@/services/RecipeService.js";
export default {
  name: "RecipeDelete",

  
  
  data() {
    return {
      recipeNumber: 0,
      message: ""
    };
  },

  created() {
    this.recipeNumber = this.$route.params.id;
  },

  methods: {
    deleteRecipe() {
      console.log("Entered delete recipe");
      recipeService
        .deleteRecipe(this.recipeNumber)
        .then(() => {
          console.log("Reached then in deleteRecipe");
          this.$router.push("/pantry");
        })
        .catch((error) => {
          console.log("Reached catch in deleteRecipe");
          if (error.response) {
            this.message =
              "Error: HTTP Response Code: " + error.response.status;
            this.message += "    Description: " + error.response.statustext;
          } else {
            this.message = "Network Error";
          }
        });
    },
  },


};
</script>

<style>
</style>