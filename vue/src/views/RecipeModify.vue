<template>
  <div>
    <p id="message">{{ message }}</p>
    <h3>Modify Recipe {{ recipeNumber }}</h3>
    <h4>You are about to modify this recipe! Are you sure?</h4>

    <a href="#" class="btn btn-danger" v-on:click="modifyRecipe">Modify Recipe</a>

    <router-link class="btn btn-success" v-bind:to="{ name: 'Pantry' }">
      Cancel</router-link
    >
  </div>
</template>

<script>
import recipeService from "@/services/RecipeService.js";
export default {
  name: "RecipeModify",

  data() {
    return {
      recipeNumber: 0,
      message: "",
    };
  },

  props: ["recipeId"],

  created() {
    this.recipeNumber = this.$route.params.recipeId;
  },

  methods: {
    modifyRecipe() {
      console.log("Entered modify recipe");
      recipeService
        .modifyRecipe(this.recipeNumber)
        .then(() => {
          console.log("Reached then in modify");
          this.$router.push("/pantry");
        })
        .catch((error) => {
          console.log("Reached catch in modify");
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