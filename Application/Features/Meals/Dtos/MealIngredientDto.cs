using Application.Features.Foods.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Meals.Dtos
{
    public class MealIngredientDto
    {
        public int FoodId { get; set; }
        public float Portion { get; set; }
        public string PortionUnit { get; set; } = string.Empty;
        public FoodsDto? Food { get; set; }
    }
}
