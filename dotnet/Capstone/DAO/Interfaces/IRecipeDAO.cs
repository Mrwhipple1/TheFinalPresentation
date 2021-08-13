using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    public interface IRecipeDAO
    {
        bool AddRecipe(Recipe recipe);
        bool DeleteRecipe(int recipeId);

        bool ModifyRecipe(Recipe recipe);

        Recipe GetRecipe(int recipeId);
        List<Recipe> GetRecipes(int userId);
        List<Recipe> GetRecipeByName(string name);
    }
}
