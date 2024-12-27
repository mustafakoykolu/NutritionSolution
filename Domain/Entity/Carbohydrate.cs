using Domain.Common;

namespace Domain.Entity
{
    public class Carbohydrate:BaseEntity
    {
        public int FoodId { get; set; }
        public Sugar Sugar { get; set; }
        public float Fiber { get; set; }
        public float Starch { get; set; }

    }

}
