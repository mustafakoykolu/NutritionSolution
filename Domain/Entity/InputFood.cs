using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class InputFood:BaseEntity
    {
        public string FoodDescription { get; set; }
        public string FoodDescriptionTr { get; set; }
        public Food Food { get; set; }
    }
}
