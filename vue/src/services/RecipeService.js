import axios from 'axios';

const path =  '/pantry';

export default {

  addIngredient(pantry) {
    console.log("Reached add ingredient in service", pantry)
    return axios.post(path, pantry)
}

}
