<template>
  <div>
    <h2 id="ingredientHeading">
      {{ ingredientHeading }}
    </h2>
    <thead>
      <tr>
        <th>Recipe Id</th>
        <th>Recipe Name</th>
        <th>Recipe Description</th>
        <th>Recipe Instructions</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="recipe in recipes" v-bind:key="recipe.recipeId">
        <td>{{ recipe.recipeId }}</td>
        <td>{{ recipe.recipeName }}</td>
        <td>{{ recipe.recipeDescription }}</td>
        <td>{{ recipe.recipeInstructions }}</td>
        <td>
          <router-link
            v-bind:to="{
              name: 'recipe',
              params: { recipeId: recipe.recipeId },
            }"
            class="btn btn-success"
            >Recipe Details</router-link
          >
        </td>
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

    console.log("Reached ViewRecipe in component");
    recipeService.getRecipes().then((response) => {
      this.$store.commit("LIST_RECIPES", response.data);
    });
  },
};
</script>

<style>
</style>