using Domain.Common;

namespace Domain.Entity
{
    public class Lipid:BaseEntity
    {
        public int FoodId { get; set; }
        public float Saturated { get; set; }
        public float Unsaturated { get; set; }
        public float Cholesterol { get; set; }
        public float Trans { get; set; }
    }

}
