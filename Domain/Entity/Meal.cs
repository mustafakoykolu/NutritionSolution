using Domain.Common;

namespace Domain.Entity
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Recipe { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string History { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<MealIngredient> MealIngredients { get; set; } = new List<MealIngredient>();
    }
}
