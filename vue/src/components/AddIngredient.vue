<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Add Ingredients</a
    >

    <form v-on:submit.prevent="newIngredient" v-if="isFormShown">
      <div class="form-group">
        <label for="name">Name: </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="newIngredient.name"
        />
      </div>

      <div class="form-group">
        <label for="measurement">Measurement Unit </label>
        <input
          type="text"
          id="measurement"
          name="measurement"
          class="form-control"
          v-model="newIngredient.measurement"
        />
      </div>
    </form>
  </div>
</template>

<script>
import recipeService from "@/services/RecipeService.js";

export default {
  name: "AddIngredients",
  data() {
    return {
      newIngredient: {},

      isFormShown: false,
    };
  },

  methods: {
    addNewIngredient() {
      this.$store.commit("ADD_INGREDIENT", this.newItem);

      recipeService.addIngredient(this.newItem).then((response) => {
        console.log("Success", response);
        this.$router.push({ name: "Pantry" });
      });
      this.resetForm();
    },

    resetForm() {
      this.newItem = {};
      this.isFormShown = false;
    },
  },
};
</script>

<style>
</style>