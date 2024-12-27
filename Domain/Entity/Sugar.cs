using Domain.Common;

namespace Domain.Entity
{
    public class Sugar:BaseEntity
    {
        public int CarbohydrateId { get; set; }
        public float Sucrose { get; set; }
        public float Glucose { get; set; }
        public float Fructose { get; set; }
        public float Lactose { get; set; }
        public float Maltose { get; set; }
        public float Galactose { get; set; }

    }

}
