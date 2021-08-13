<template>
  <div>
    <p id="message">{{ message }}</p>
    <h3>Delete Recipe {{ recipeNumber }}</h3>
    <h4>You are about to delete this delicious recipe! Are you sure?</h4>

    <a href="#" class="delete_btn" v-on:click="deleteRecipe">Delete</a>

    <router-link class="cancel_btn" v-bind:to="{ name: 'Pantry' }">
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
      message: "",
    };
  },

  props: ["recipeId"],

  created() {
    this.recipeNumber = this.$route.params.recipeId;
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
.delete_btn,
.cancel_btn
 {
  max-width: 200px;
  height: 30px;
  margin: 40px 20px 50px 10px;
  border: #b8b8b8;
  box-sizing: border-box;
  text-decoration: none;
  font-family: "Roboto", sans-serif;
  font-weight: bold;
  font-size: 17px;
  color: #242424;
  background-color: #c2c2c2;
  text-align: center;
  transition: all 0.2s;
  caret-color: transparent;
}
</style>