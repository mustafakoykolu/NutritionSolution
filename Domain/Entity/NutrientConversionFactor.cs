using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class NutrientConversionFactor: BaseEntity
    {
        public string Type { get; set; }
        public float? ProteinValue { get; set; }
        public float? CarbohydrateValue { get; set; }
        public float? FatValue { get; set; }
        public float? Value { get; set; }
    }
}
