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

        public ICollection<FoodNutrient> FoodNutrients { get; set; }
    }
}
