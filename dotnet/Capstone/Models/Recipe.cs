using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDescription { get; set; }
        public int UserId { get; set; }

        public List<Ingredient> Ingredients { get; set; }

    }
}
