using Domain.Common;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Food:BaseEntity
    {
        public string FoodClass { get; set; }
        public string Description { get; set; }
        public string DescriptionTr { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsHistoricalReference { get; set; }
        public int NdbNumber { get; set; }
        public string DataType { get; set; }
        public int FdcId { get; set; }
        public ICollection<FoodPortion> FoodPortions { get; set; }
        public ICollection<FoodNutrient> FoodNutrients { get; set; }
        public ICollection<InputFood> InputFoods { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public ICollection<NutrientConversionFactor> NutrientConversionFactors { get; set; }
        public string ImageName { get; set; }

    }
}
