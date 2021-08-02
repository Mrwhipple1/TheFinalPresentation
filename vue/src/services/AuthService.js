import axios from 'axios';

const path =  '/login';

export default {

  login(user) {
    return axios.post(path, user)
  },

  register(user) {
    return axios.post(path +'/register', user)
  },

  addIngredient(pantry) {
    return axios.post(path, pantry)
}

}
