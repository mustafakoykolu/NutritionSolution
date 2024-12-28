using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class MealFood:BaseEntity
    {
        public int MealId { get; set; } // Meal tablosu ile ilişki
        public Meal Meal { get; set; }

        public int FoodId { get; set; } // Food tablosu ile ilişki
        public Food Food { get; set; }

        public double Quantity { get; set; } // Kullanılan yiyecek miktarı (gram cinsinden)
    }
}
