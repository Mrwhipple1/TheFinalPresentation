<template>
  <div>
    <h1>Your Kitchen</h1>
    <h2>See and add your ingredients here, and create recipes too!</h2>

    <add-ingredient />
    <view-ingredients />
  </div>
</template>

<script>
import AddIngredient from "@/components/AddIngredient.vue";
import ViewIngredients from "@/components/ViewIngredients.vue";

export default {
  components: {
    AddIngredient,
    ViewIngredients,
  },
};
</script>

<style>
</style>