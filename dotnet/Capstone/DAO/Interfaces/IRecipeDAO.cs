using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO.Interfaces
{
    interface IRecipeDAO
    {
        bool Addrecipe(Recipe recipe);
        List<Recipe> GetRecipes();
        List<Recipe> GetRecipeByName(string name);
    }
}
