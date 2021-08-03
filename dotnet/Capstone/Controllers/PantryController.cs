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
            ingredient.UserId = ingredient.UserId;

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
