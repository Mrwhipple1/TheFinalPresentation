<template>
  <div>
    <h1>Your Kitchen</h1>
    <h2>See and add your ingredients here, and create recipes too!</h2>

    <div class="ingredient-container"><add-ingredient /></div>
    <div class="recipe-container"></div>
  </div>
</template>

<script>
import AddIngredient from "@/components/AddIngredient.vue";
export default {
  components: {
    AddIngredient,
  },
};
</script>

<style>
</style>