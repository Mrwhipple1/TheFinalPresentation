import axios from 'axios';

const path =  '/login';

export default {
    
  addIngredient(pantry) {
    return axios.post(path, pantry)
}

}
