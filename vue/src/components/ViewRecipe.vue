<template>
  <div>
    <h2>Recipe List</h2>
    <div class="tbl-header">
      <table cellpadding="0" cellspacing="0" border="0">
        <thead>
          <tr>
            <th class="name">Recipe Name</th>
            <th>Recipe Description</th>
          </tr>
        </thead>
      </table>
    </div>
    <div class="tbl-content">
      <table cellpadding="0" cellspacing="0" border="0">
        <tbody>
          <tr v-for="recipe in recipes" v-bind:key="recipe.recipeId">
            <td class="first-td">{{ recipe.recipeName }}</td>
            <td>{{ recipe.recipeDescription }}</td>
            <td>
              <button class="detail-btn">
                <router-link
                  v-bind:to="{
                    name: 'recipe',
                    params: { recipeId: recipe.recipeId },
                  }"
                  type="button"
                  class="btn btn-success detail-router"
                  >Recipe Details</router-link
                >
              </button>
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

<style scoped>
h2 {
  font-family: "Roboto", sans-serif;
  caret-color: transparent;
  color: rgb(250, 249, 249);
  font-size: 35px;
  font-weight: 300;
  text-align: center;
  margin-bottom: 15px;
}
table {
  table-layout: fixed;
}
.tbl-header {
  background-color: black;
}
.tbl-content {
  height: 300px;
  overflow-x: auto;
  margin-top: 0px;
  border: 1px solid black;
}

.name {
  padding-right: 30px;
  padding-left: 20px;
}

th {
  padding: 20px 10px;
  font-family: "Roboto", sans-serif;
  caret-color: transparent;
  color: rgb(250, 249, 249);
  font-size: 16px;
}
td {
  font-family: "Roboto", sans-serif;
  caret-color: transparent;
  color: rgb(250, 249, 249);
  font-size: 16px;
  padding: 20px;
  text-align: left;
  vertical-align: middle;
  font-weight: 300;
  color: white;
  border-bottom: solid 1px rgba(255, 255, 255, 0.1);
}

.first-td {
  border-right: solid 1px white;
  padding: 20px 55px 20px 55px;
}

td::first-letter {
  text-transform: capitalize;
}

.detail-btn {
  max-width: 200px;
  height: 30px;
  margin: 0px 20px 0px 0px;
  border: #b8b8b8;
  border-radius: 2em;
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

.detail-btn:hover {
  max-width: 200px;
  height: 30px;
  margin: 0px 20px 0px 0px;
  border: #b8b8b8;
  border-radius: 2em;
  box-sizing: border-box;
  text-decoration: none;
  font-family: "Roboto", sans-serif;
  font-weight: bold;
  font-size: 17px;
  color: #242424;
  background-color: #959595;
  text-align: center;
  transition: all 0.2s;
  caret-color: transparent;
}

.detail-router {
  color: #2e2e2e;
  text-decoration: none;
}
</style>