<template>
  <div class="main-container">
    <button class="list_btn">
      <router-link v-bind:to="{ name: 'pantry' }" class="list-rt">
        List</router-link
      >
    </button>
    <button class="delete_btn">
      <router-link
        v-bind:to="{
          name: 'RecipeDelete',
          params: { recipeId: recipe.recipeId },
        }"
        class="delete-rt"
      >
        Delete Recipe</router-link
      >
    </button>
    <button class="modify_btn">
      <router-link
        v-bind:to="{
          name: 'RecipeModify',
          params: { recipeId: recipe.recipeId },
        }"
        class="modify-rt"
      >
        Modify Recipe</router-link
      >
    </button>

    <table class="table table-bordered table-hover">
      <tbody>
        <tr>
          <th class="name">Recipe Name</th>
          <td class="first_td text">{{ recipe.recipeName }}</td>
        </tr>

        <tr>
          <th class="description">Recipe Description</th>
          <td class="second_td text">{{ recipe.recipeDescription }}</td>
        </tr>
        <tr>
          <th class="instructions">Recipe Instructions</th>
          <td class="third_td text">{{ recipe.recipeInstructions }}</td>
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

<style scoped>
.list_btn,
.delete_btn,
.modify_btn {
  max-width: 200px;
  height: 30px;
  margin: 40px 0px 50px 10px;
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

.list_btn:hover,
.delete_btn:hover,
.modify_btn:hover {
  max-width: 200px;
  height: 30px;
  margin: 40px 0px 50px 10px;
  border: #b8b8b8;
  border-radius: 2em;
  box-sizing: border-box;
  text-decoration: none;
  font-family: "Roboto", sans-serif;
  font-weight: bold;
  font-size: 17px;
  color: #242424;
  background-color: #6e6e6e;
  text-align: center;
  transition: all 0.2s;
  caret-color: transparent;
}

.list-rt {
  color: #242424;
  text-decoration: none;
}

.delete-rt {
  color: #242424;
  text-decoration: none;
}

.modify-rt {
  color: #131313;
  text-decoration: none;
}

.main-container {
  background-color: #303030;
}

th {
  padding: 20px 10px;
  font-family: "Roboto", sans-serif;
  caret-color: transparent;
  color: rgb(250, 249, 249);
  font-size: 16px;
  background-color: #303030;
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
  border-left: solid 2px rgba(255, 255, 255, 0.1);
  background-color: #303030;
}

.text:first-letter {
  text-transform: capitalize;
}

.first_td,
.second_td,
.third_td {
  border-top: solid 1px white;
  padding: 20px 55px 20px 55px;
}
.first_td,
.second_td,
.third_td {
  border-right: solid 1px white;
  padding: 20px 55px 20px 55px;
}
.name,
.description,
.instructions {
  border-top: solid 1px white;
  padding: 20px 55px 20px 55px;
}
</style>