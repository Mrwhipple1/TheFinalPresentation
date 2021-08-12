<template>
<div>
    <h2>Recipe List</h2>
    <div class="tbl-header">
      <table cellpadding="0" cellspacing="0" border="0">
        <thead>
          <tr>
            <th>Recipe Id</th>
            <th>Recipe Name</th>
            <th>Recipe Description</th>
            <th>Recipe Instructions</th>
          </tr>
        </thead>
      </table>
    </div>
    <div class="tbl-content">
      <table cellpadding="0" cellspacing="0" border="0">
        <tbody>
          <tr v-for="recipe in recipes" v-bind:key="recipe.recipeId">
            <td>{{ recipe.recipeId }}</td>
            <td>{{ recipe.recipeName }}</td>
            <td>{{ recipe.recipeDescription }}</td>
            <td>{{ recipe.recipeInstructions }}</td>
            <td>
              <button><router-link
                v-bind:to="{
                  name: 'recipe',
                  params: { recipeId: recipe.recipeId },
                }"
                type="button"
                class="btn btn-success"
                >Recipe Details</router-link
              ></button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
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
h2{
  font-size: 30px;
  color: cadetblue;
  text-transform: uppercase;
  font-weight: 300;
  text-align: center;
  margin-bottom: 15px;
}
table{
  table-layout: fixed;
}
.tbl-header{
  background-color: black;
 }
.tbl-content{
  height:300px;
  overflow-x:auto;
  margin-top: 0px;
  border: 1px solid black;
}
th{
  padding: 20px 10px;
  text-align: left;
  font-weight: 500;
  font-size: 13px;
  color:cadetblue;
  text-transform: uppercase;
}
td{
  padding: 20px;
  text-align: center;
  vertical-align:middle;
  font-weight: 300;
  font-size: 14px;
  color:purple;
  border-bottom: solid 1px rgba(255,255,255,0.1);
}

</style>