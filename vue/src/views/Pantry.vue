<template>
  <div>
    <h1>Your Kitchen</h1>
    <h2>Add your ingredients, see them, and create recipes too!</h2>

    <add-ingredient />
    <add-recipe />
    <view-ingredients />
    <add-recipe />
  </div>
</template>

<script>
import AddIngredient from "@/components/AddIngredient.vue";
import ViewIngredients from "@/components/ViewIngredients.vue";
import AddRecipe from "@/components/AddRecipe.vue";
export default {
  components: {
    AddIngredient,
    ViewIngredients,
    AddRecipe,
  },
};
</script>

<style>
</style>s