<template>
  <recipe-modify v-bind:id="recipeNumber" />
</template>

<script>
import RecipeModify from '@/components/RecipeModify.vue';
export default {
  name: "RecipeUpdate",

  components: {
    ModifyRecipe,
  },
  data() {
    return {
      recipeNumber: 0,
    };
  },

  created() {
    this.recipeNumber = this.$route.params.recipeId;
  },
};
</script>

<style>
</style>