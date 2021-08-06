<template>
  <div>
    <h2 id="ingredientHeading">
      {{ ingredientHeading }}
    </h2>
    <thead>
      <tr>
        <th>Recipe Name</th>
        <th>Recipe Description</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="recipe in recipes" v-bind:key="recipe.id">
          <td>{{ recipe.recipeName }}</td>
          <td>{{ recipe.recipe }}</td>
      </tr>
    </tbody>
    <!-- <p id="ingredientBody">
          {{ ingredientBody }}
      </p> -->
  </div>
</template>

<script>
import recipeService from "@/services/RecipeService.js";
export default {
    name: "ViewRecipe",

    data() {
        return {
            ingredientHeading: "",
            ingredientBody: "",
        };
    },

    computed: {
        recipes() {
            return this.$store.state.recipes;
        },
    },

    created() {
        this.ingredientHeading = "";
        this.ingredientBody = "";

    console.log("Reached ViewReipe in component");
    recipeService.getRecipes().then((Response) => {
        this.$store.commit("LIST_RECIPES", response.data);
    });

    },

};
</script>

<style>
</style>