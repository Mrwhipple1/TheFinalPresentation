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
        List<Recipe> GetRecipes();
        List<Recipe> GetRecipeByName(string name);
    }
}
