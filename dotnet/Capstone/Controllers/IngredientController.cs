using Capstone.DAO.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class IngredientController : Controller
    {
        private readonly IUserDAO userDAO; 

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
