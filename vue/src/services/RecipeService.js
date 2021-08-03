import axios from 'axios';

const path =  '/pantry';

export default {

  addIngredient(pantry) {
    return axios.post(path, pantry)
}

}
