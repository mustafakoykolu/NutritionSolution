using Application.Features.Foods.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Meals.Dtos
{
    public class GetMealDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Recipe { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string History { get; set; } = string.Empty;

        public ICollection<FoodsDto> MealIngredients { get; set; } = new List<FoodsDto>();

    }
}
