<template>
  <div>
    <h2 id="ingredientHeading">
      {{ ingredientHeading }}
    </h2>
    <thead>
      <tr>
        <th>Recipe Name</th>
        <th>Recipe Description</th>
        <th>Recipe Instructions</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="recipe in recipes" v-bind:key="recipe.recipeName">
        <td>{{ recipe.recipeName }}</td>
        <td>{{ recipe.recipeDescription }}</td>
        <td>{{ recipe.recipeInstructions }}</td>
        <td>
          <router-link
            v-bind:to="{ name: 'recipe', params: { id: recipe.id } }"
            class="recipe"
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
div {
  border: 2px solid;
  padding: 20px;
  width: 1450px;
  resize: both;
  overflow: auto;
  background: red;
  animation: mymove 5s infinite;
}
@keyframes mymove {
  50% {
    background-color: blue;
  }
}
</style>