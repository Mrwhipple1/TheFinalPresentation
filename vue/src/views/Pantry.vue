<template>
  <div>
    <h1 class="text">Your Kitchen</h1>
    <h2 class="text">
      Add your ingredients, see them, and create recipes too!
    </h2>

    <add-ingredient />
    <add-recipe />
    <view-ingredients />
    <view-recipe />
  </div>
</template>

<script>
import AddIngredient from "@/components/AddIngredient.vue";
import ViewIngredients from "@/components/ViewIngredients.vue";
import AddRecipe from "@/components/AddRecipe.vue";
import ViewRecipe from "@/components/ViewRecipe.vue";

export default {
  components: {
    AddIngredient,
    ViewIngredients,
    AddRecipe,
    ViewRecipe,
  },
};
</script>

<style scoped>
div {
  background-color: rgb(46, 46, 46);
}

.text {
  color: white;
  padding: 20px 20px 20px 20px;
  font-family: "Roboto", sans-serif;
}
</style>