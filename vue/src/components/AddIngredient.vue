<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      >Add an Ingredient</a
    >

    <form v-on:submit.prevent="addNewIngredient" v-if="isFormShown">
      <div class="form-group">
        <label for="name">Name of Ingredient: </label>
        <input
          required
          type="text"
          id="name"
          name="name"
          class="form-control"
          v-model="newItem.name"
        />
      </div>

      <div class="form-group">
        <label for="measurement">Measurement Unit/Qauntity </label>
        <input
          type="text"
          id="measurement"
          name="measurement"
          class="form-control"
          v-model="newItem.measurement"
        />
      </div>

      <button class="btn btn-submit">Submit</button>

      <button
        type="cancel"
        v-on:click.prevent="resetForm"
        class="btn btn-cancel"
      >
        Cancel
      </button>
    </form>
  </div>
</template>

<script>
import recipeService from "@/services/RecipeService.js";

export default {
  name: "AddIngredient",
  data() {
    return {
      newItem: {
        name: "",
        measurement: "",
      },

      isFormShown: false,
    };
  },

  methods: {
    addNewIngredient() {
      console.log("Reached add ingredient", this.newItem)
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