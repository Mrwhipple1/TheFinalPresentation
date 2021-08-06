using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IIngredientsDAO
    {
        bool AddIngredient(Ingredient ingredient);

        List<Ingredient> GetAllIngredients(int userId);





    }
}
