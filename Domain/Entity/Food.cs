using Domain.Common;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Food:BaseEntity
    {
        public string Name { get; set; }
        public string NameTr { get; set; }
        public float? KCal { get; set; }
        public float? Protein { get; set; }
        public Lipid Fat { get; set; }  
        public Carbohydrate Carbohydrate { get; set; }  
        public float? Water { get; set; }
        public float? Nitrogen { get; set; }
        public string? ImageName { get; set; }
        public string? Benefits { get; set; }
        public string? History { get; set; }
        public float? Portion { get; set; }
        public string? PortionUnit { get; set; }
        public float? Caffeine { get; set; }
        public Vitamin Vitamin { get; set; }
        public Mineral Mineral { get; set; }
    }

}
