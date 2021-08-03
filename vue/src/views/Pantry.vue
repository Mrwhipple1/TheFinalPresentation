<template>
  <div>
    <h1>Your Pantry</h1>
    <h2>See and add your ingredients here</h2>

    <add-ingredient />
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