using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Foods.Dtos
{
    public class FoodsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float KCal { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbs { get; set; }
        public float Fiber { get; set; }
        public float Sugar { get; set; }
        public float Salt { get; set; }
        public float Iron { get; set; }
        public float VitaminA { get; set; }
        public float VitaminC { get; set; }
        public float VitaminD { get; set; }
        public float VitaminE { get; set; }
        public float VitaminK { get; set; }
        public float VitaminB1 { get; set; }
        public float VitaminB2 { get; set; }
        public float VitaminB3 { get; set; }
        public float VitaminB5 { get; set; }
        public float VitaminB6 { get; set; }
        public float VitaminB7 { get; set; }
        public float VitaminB9 { get; set; }
        public float VitaminB12 { get; set; }
        public float Calcium { get; set; }
        public float Phosphorus { get; set; }
        public float Magnesium { get; set; }
        public float Zinc { get; set; }
        public float Copper { get; set; }
        public float Manganese { get; set; }
        public float Selenium { get; set; }
        public float Potassium { get; set; }
        public float Sodium { get; set; }
        public float Cholesterol { get; set; }
        public float Caffeine { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;
        public string History { get; set; } = string.Empty;
        public float Portion { get; set; }
        public string PortionUnit { get; set; } = string.Empty;
    }
}
