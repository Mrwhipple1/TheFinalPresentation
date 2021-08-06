import axios from 'axios';
import store from '../store/index'

const path = '/pantry';

export default {
  
  addIngredient(ingredient) {
    ingredient.userId = store.state.user.userId;
    console.log("Reached add ingredient in service", ingredient)
    return axios.post(path, ingredient)
  },

  addRecipe(recipe) {
    recipe.userId = store.state.user.userId;
    console.log("Reached add ingredient in service", recipe)
    return axios.post(path + "/addrecipe", recipe)
  },

  allIngredients() {
    const userId = store.state.user.userId;
    console.log("Reached all ingredients in service")
    return axios.get(path + "/" + userId)
  },

  allRecipes() {
    const userId = store.state.user.userId;
    console.log("Reached all Recipes in service")
    return axios.get(path + "/" + userId)
  }

}
