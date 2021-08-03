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

        public PantryController(IIngredientsDAO ingredientsDAO)
        {
            this.ingredientsDAO = ingredientsDAO;
        }

        [HttpPost]
        public ActionResult<bool> AddNewIngredient(Ingredients ingredient)
        {

            bool result = ingredientsDAO.AddIngredient(ingredient);

            if(result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpGet]
        public ActionResult<List<Ingredients>> ListAllIngredients(int userId)
        {
            List<Ingredients> ingredients = ingredientsDAO.GetAllIngredients(userId);
            foreach(Ingredients ingredients1 in ingredients)
            {
                return NotFound(ingredients1);
            }
            return Ok(ingredients);
        }
    }
}
