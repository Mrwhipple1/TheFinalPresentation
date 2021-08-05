<template>
  <div>
    <h1>Your Kitchen</h1>
    <h2>See and add your ingredients here, and create recipes too!</h2>

    <add-ingredient />
    <add-recipe />
    <view-ingredients />
  </div>
</template>

<script>
import AddIngredient from "@/components/AddIngredient.vue";
import ViewIngredients from "@/components/ViewIngredients.vue";
import AddRecipe from '@/components/AddRecipe.vue';

export default {
  components: {
    AddIngredient,
    ViewIngredients,
    AddRecipe,
  },
};
</script>

<style>
</style>