<template>
<div>
  <recipe-detail v-bind:id="recipeNumber" />
</div>
</template>

<script>
import recipeDetail from "@/components/RecipeDetail.vue";
export default {
  name: "Recipe",

  components: {
    recipeDetail,
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