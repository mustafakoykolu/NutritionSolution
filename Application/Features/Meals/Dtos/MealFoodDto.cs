
using Application.Features.Foods.Dtos;

namespace Application.Features.Meals.Dtos
{
    public class MealFoodDto
    {
        public FoodsDto Food { get; set; }
        public float Portion { get; set; }
        public string PortionUnit { get; set; }
    }
}
