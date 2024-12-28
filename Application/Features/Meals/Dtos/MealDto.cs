
namespace Application.Features.Meals.Dtos
{
    public class MealDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } // Yemek açıklaması
        public string Recipe { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string History { get; set; } = string.Empty;
        public NutrientDto TotalNutrients { get; set; }
        public List<MealFoodDto> Ingredients { get; set; } // GetFoods'ta kullanılan DTO
    }
}
