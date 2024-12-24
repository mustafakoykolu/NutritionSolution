using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Features.Foods.Dtos
{
    public class FoodsDto
    {
        public int Id { get; set; }
        public string FoodClass { get; set; }
        public string Description { get; set; }
        public string DescriptionTr { get; set; }
        public ICollection<FoodPortion> FoodPortions { get; set; }
        public ICollection<FoodNutrient> FoodNutrients { get; set; }
        public ICollection<InputFood> InputFoods { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public ICollection<NutrientConversionFactor> NutrientConversionFactors { get; set; }
        public string ImageName { get; set; }

    }
}
