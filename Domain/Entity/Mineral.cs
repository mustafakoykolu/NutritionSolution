using Domain.Common;

namespace Domain.Entity
{
    public class Mineral:BaseEntity
    {
        public float Calcium { get; set; }
        public float Iron { get; set; }
        public float Magnesium { get; set; }
        public float Phosphorus { get; set; }
        public float Potassium { get; set; }
        public float Sodium { get; set; }
        public float Zinc { get; set; }
        public float Copper { get; set; }
        public float Manganese { get; set; }
        public float Selenium { get; set; }
        public int FoodId { get; set; }
    }

}
