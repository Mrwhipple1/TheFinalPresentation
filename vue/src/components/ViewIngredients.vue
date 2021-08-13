<template>
  <div>
    <p id="message">{{ message }}</p>
    <table class="table table-bordered table-hover">
      <tbody>
        <th>List Of Ingredients</th>
        <tr
          v-for="ingredient in ingredients"
          v-bind:key="ingredient.ingredientId"
        >
          <div class="ingdiv">
            <td>{{ ingredient.ingredientName }}</td>
          </div>
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

<style scoped>
th {
  color: white;
  font-family: "Roboto", sans-serif;
  font-weight: bold;
  border-bottom: solid 2px white;
  font-size: 20px;
  padding-left: 20px;
}

td {
  color: white;
  font-family: "Roboto", sans-serif;
  font-weight: bold;
  font-size: 17px;
  padding-left: 20px;
}
</style>