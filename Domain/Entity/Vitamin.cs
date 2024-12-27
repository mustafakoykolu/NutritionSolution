using Domain.Common;

namespace Domain.Entity
{
    public class Vitamin: BaseEntity
    {
        public int FoodId { get; set; }
        // Vitamin adları ve oranları
        public float? VitaminA { get; set; }  // Vitamin A
        public float? VitaminB1 { get; set; } // Vitamin B1 (Thiamine)
        public float? VitaminB2 { get; set; } // Vitamin B2 (Riboflavin)
        public float? VitaminB3 { get; set; } // Vitamin B3 (Niacin)
        public float? VitaminB5 { get; set; } // Vitamin B5 (Pantothenic Acid)
        public float? VitaminB6 { get; set; } // Vitamin B6
        public float? VitaminB7 { get; set; } // Vitamin B7 (Biotin)
        public float? VitaminB9 { get; set; } // Vitamin B9 (Folate)
        public float? VitaminB12 { get; set; } // Vitamin B12
        public float? VitaminC { get; set; }  // Vitamin C
        public float? VitaminD { get; set; }  // Vitamin D
        public float? VitaminE { get; set; }  // Vitamin E
        public float? VitaminK { get; set; }  // Vitamin K
        public float? VitaminD3 { get; set; } // Vitamin D3 (Cholecalciferol)
        public float? VitaminA1 { get; set; } // Retinol (Preformed Vitamin A)
        public float? VitaminA2 { get; set; } // Beta-Carotene (Pro-Vitamin A)

    }
}
