﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class FoodNutrientSource:BaseEntity
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string DescriptionTr { get; set; }
    }
}
