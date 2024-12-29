using Domain.Entity;

namespace Application.Features.Meals.Dtos
{
    public class NutrientDto
    {
        public int Id { get; set; }
        public float? KCal { get; set; }
        public float? Protein { get; set; }
        public Lipid Fat { get; set; }
        public Carbohydrate Carbohydrate { get; set; }
        public float? Water { get; set; }
        public float? Nitrogen { get; set; }
        public float? Portion { get; set; }
        public string? PortionUnit { get; set; }
        public float? Caffeine { get; set; }
        public Vitamin Vitamin { get; set; }
        public Mineral Mineral { get; set; }
    }
}
