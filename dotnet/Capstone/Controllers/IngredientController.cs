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
    public class IngredientController : ControllerBase
    {
        private readonly IUserDAO userDAO;
        private readonly IIngredientsDAO ingredientsDAO;

        public IngredientController(IIngredientsDAO ingredientsDAO, IUserDAO userDAO)
        {
            this.ingredientsDAO = ingredientsDAO;
            this.userDAO = userDAO;
        }

        [HttpPost]
        public ActionResult<bool> AddNewIngredient()
        {
            Ingredients ingredient = new Ingredients();
            ingredient.IngredientId = 1;
            ingredient.IngredientName = "";
            ingredient.MeasurementUnit = "";
            ingredient.UserId = 1;

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
    }
}
