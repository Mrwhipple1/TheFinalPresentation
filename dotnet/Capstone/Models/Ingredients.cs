using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Ingredients
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public string MeasurementUnit { get; set; }

        public int UserId { get; set; }
    }
}
