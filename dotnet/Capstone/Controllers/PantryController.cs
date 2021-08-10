using Capstone.DAO.Interfaces;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class PantryController : ControllerBase
    {
        private readonly IIngredientsDAO ingredientsDAO;
        private readonly IRecipeDAO recipeDAO;

        public PantryController(IIngredientsDAO ingredientsDAO, IRecipeDAO recipeDAO)
        {
            this.ingredientsDAO = ingredientsDAO;
            this.recipeDAO = recipeDAO;
        }

        [HttpPost]
        public ActionResult<bool> AddNewIngredient(Ingredient ingredient)
        {

            bool result = ingredientsDAO.AddIngredient(ingredient);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet("{userId}")]
        public ActionResult<List<Ingredient>> ListAllIngredients(int userId)
        {


            List<Ingredient> ingredients = ingredientsDAO.GetAllIngredients(userId);

            return Ok(ingredients);

            //return NotFound(ingredients);
        }

        [HttpPost("addrecipe")]
        public ActionResult<bool> AddNewRecipe(Recipe recipe)
        {

            bool result = recipeDAO.AddRecipe(recipe);

            if (result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet("getrecipe/{userId}")]
        public ActionResult<List<Recipe>> GetRecipes(int userId)
        {
            List<Recipe> recipes = recipeDAO.GetRecipes(userId);

            return Ok(recipes);
        }

        [HttpGet("recipe/{recipeId}")]
        public ActionResult<Recipe> GetRecipe(int recipeId)
        {
            return Ok(recipeDAO.GetRecipe(recipeId));
        }

        [HttpDelete("recipedelete/{recipeId}")]
        public ActionResult<Recipe> DeleteRecipe(int recipeId)
        {
            return Ok(recipeDAO.DeleteRecipe(recipeId));
        }
    }
}
