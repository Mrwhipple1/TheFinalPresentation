import axios from 'axios';
import store from '../store/index'

const path = '/pantry';

export default {
  
  addIngredient(pantry) {
    pantry.userId = store.state.user.userId;
    console.log("Reached add ingredient in service", pantry)
    return axios.post(path, pantry)
  },

  addRecipe(pantry) {
    pantry.userId = store.state.user.userId;
    console.log("Reached add ingredient in service")
    return axios.post(path + "/addrecipe/" + pantry)
  },

  allIngredients() {
    const userId = store.state.user.userId;
    console.log("Reached all ingredients in service")
    return axios.get(path + "/" + userId)
  },




}
