using Domain.Entity;

namespace Application.Features.Meals.Dtos
{
    public class MealDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Recipe { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string History { get; set; } = string.Empty;

        public ICollection<MealIngredientDto> MealIngredients { get; set; } = new List<MealIngredientDto>();


    }
}
