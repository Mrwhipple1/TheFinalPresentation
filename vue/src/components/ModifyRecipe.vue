<template>
  <div class="container">
    <a
      v-on:click="isFormShown = true"
      v-if="!isFormShown"
      class="btn btn-success"
      ><button>Modify Recipe</button></a
    >
    <form v-on:submit.prevent="modifyRecipe" v-if="isFormShown">
      <div class="form-group">
        <label for="RecipeName"> Name of Recipe</label>
        <input
          type="text"
          required
          id="RecipeName"
          name="RecipeName"
          class="form-control"
          v-model="newItem.RecipeName"
        />

        <label for="RecipeDescription"> Recipe Description</label>
        <input
          type="text"
          id="RecipeDescription"
          name="recipeDescription"
          class="form-control"
          v-model="newItem.RecipeDescription"
        />

        <label for="RecipeInstructions"> Instructions for Recipe</label>
        <input
          type="text"
          required
          id="RecipeInstructions"
          name="RecipeInstructions"
          class="form-control"
          v-model="newItem.RecipeInstructions"
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
  name: "ModifyRecipe",
  data() {
    return {
      newItem: {
        RecipeName: "",
      },

      isFormShown: false,
    };
  },

  methods: {
    modifyRecipe() {
      console.log("reached add recipe", this.newItem);
      this.$store.commit("MODIFY_RECIPE", this.newItem);

      recipeService.modifyRecipe(this.newItem).then((response) => {
        console.log("Success", response);
        //this.$router.push({ recipeName: "Pantry" });
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