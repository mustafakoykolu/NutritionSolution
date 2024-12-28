using Domain.Common;

namespace Domain.Entity
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } // Yemek açıklaması
        public string Recipe { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string History { get; set; } = string.Empty;
        public ICollection<MealFood> MealFoods { get; set; } // Yemekte kullanılan yiyecekler
    }
}
