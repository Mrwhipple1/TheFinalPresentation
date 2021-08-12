import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if (currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},

    ingredients: [],
    recipes: []
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user', JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    ADD_INGREDIENT(state, ingredient) {
      console.log("Reached add Ingredient Mutator", ingredient)
      state.ingredients.push(ingredient);
    },
    LIST_INGREDIENTS(state, ingredients) {
      console.log("Reached list ingredient mutator", ingredients)
      state.ingredients = ingredients;
    },
    ADD_RECIPE(state, pantry) {
      console.log("Reached  add recipe Mutator", pantry)
      state.recipes.push(pantry);
    },
    LIST_RECIPES(state, recipes) {
      console.log("reached list recipe mutator", recipes)
      state.recipes = recipes;
    },

    MODIFY_RECIPE(state, pantry) {
      console.log("Reached  add recipe Mutator", pantry)
      state.recipes.push(pantry);
    },
  }
});
