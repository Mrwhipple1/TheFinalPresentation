<template>
  <div>
    <p id="message">{{ message }}</p>
    <table class="table table-bordered table-hover">
      <tbody>
        <th>List Of Ingredients</th>
        <tr v-for="ingredient in ingredients" v-bind:key="ingredient.ingredientId">
          <td>{{ ingredient.ingredientName }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import recipeService from "@/services/RecipeService.js";
export default {
  name: "ViewIngredients",

  data() {
    return {
      message: "",
    };
  },
  computed: {
    ingredients() {
      return this.$store.state.ingredients;
    },
  },

  created() {
    this.message = "";

    console.log("Reached all ingredients in component");
    recipeService.allIngredients().then((response) => {
      this.$store.commit("LIST_INGREDIENTS", response.data);
    });
  },
};
</script>

<style>


</style>