<template>
  <div>
    
    <router-link class="btn btn-success" v-bind:to="{ name: 'pantry' }">
      List</router-link
    >
    <router-link class="btn btn-danger" v-bind:to="{ name: 'RecipeDelete', params: {recipeId: recipe.recipeId} }">
      Delete Recipe</router-link
    >
        <router-link class="btn btn-danger" v-bind:to="{ name: 'RecipeModify', params: {recipeId: recipe.recipeId} }">
      Modify Recipe</router-link
    >

    <table class="table table-bordered table-hover">
      <tbody>
        <tr>
          <th>Recipe Name</th>
          <td>{{ recipe.recipeName }}</td>
        </tr>

        <tr>
          <th>Recipe Description</th>
          <td>{{ recipe.recipeDescription }}</td>
        </tr>
        <tr>
          <th>Recipe Instructions</th>
          <td>{{ recipe.recipeInstructions }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "RecipeDetail",

  data: function () {
    return {
      recipe: {},
    };
  },
  props: ["recipeId"],

  created() {
    let recipes = this.$store.state.recipes;
    this.recipe = recipes.find((item) => {
      return item.id == this.id;
    });
  },
};
</script>

<style>
</style>