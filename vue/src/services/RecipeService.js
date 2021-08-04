import axios from 'axios';
import store from '../store/index'

const path = '/pantry';

export default {

  allIngredients() {
    console.log("Reached all ingredients in service")
    return axios.get(path)
  },

  addIngredient(pantry) {
    pantry.userId = store.state.user.userId;
    console.log("Reached add ingredient in service", pantry)
    return axios.post(path, pantry)
  },


}
