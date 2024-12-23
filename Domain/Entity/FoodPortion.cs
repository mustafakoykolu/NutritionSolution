using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class FoodPortion:BaseEntity
    {
        public float Value { get; set; }
        public MeasureUnit MeasureUnit { get; set; }
        public float GramWeight { get; set; }
        public int SequenceNumber { get; set; }
        public float Amount { get; set; }
        public int MinYearAcquired { get; set; }
        public Food Food { get; set; }
        public int FoodId { get; set; }

    }
}
