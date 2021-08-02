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
        public IActionResult AddNewIngredient(Ingredient ingredient)
        {
            
        }
    }
}
