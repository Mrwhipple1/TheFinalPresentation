<template>
  <div>
      <p id="message">{{message}}</p>
    <table class="table table-bordered table-hover">
      <tbody>
          <th>List Of Ingredients</th>
          <tr v-for="(ingredient, id) in ingredients" v-bind:key="id">
          <td>{{ ingredients.name }}</td>
          <td>{{ingredients.measurment}}</td>
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
        }
    },
    computed: {
        ingredients() {
            return this.$store.state.ingredients;
        },
    },

    craeted() {
        this.message = "";

        recipeService
        .allIngredients()
    }
};
</script>

<style>
</style>