using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class FoodNutrient:BaseEntity
    {
        public string Type { get; set; }
        public Nutrient Nutrient { get; set; }
        public int DataPoints { get; set; }
        public FoodNutrientDerivation Derivation { get; set; }
        public float Median { get; set; }
        public float Amount { get; set; }
    }
}
