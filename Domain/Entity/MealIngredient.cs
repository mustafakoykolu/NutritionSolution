using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class MealIngredient: BaseEntity 
    {
        public int MealId { get; set; }
        public int FoodId { get; set; }
        public float Portion { get; set; }
        public string PortionUnit { get; set; } = string.Empty;

        public Food Food { get; set; } // Navigation Property
        public Meal Meal { get; set; } // Navigation Property
    }
}
