
namespace Application.Features.Meals.Dtos
{
    public class MealDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Recipe { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public string? History { get; set; } 
        public string? Benefits { get; set; } 
        public NutrientDto TotalNutrients { get; set; }
        public List<MealFoodDto> MealFoods { get; set; } // GetFoods'ta kullanılan DTO
    }
}
