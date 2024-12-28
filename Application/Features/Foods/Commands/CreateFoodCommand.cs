using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Foods.Commands
{
    public class CreateFoodCommand: IRequest<int>
    {
        //General
        public string? Name { get; set; }
        public string NameTr { get; set; }
        public float? KCal { get; set; }
        public float? Protein { get; set; }
        public float? Water { get; set; }
        public float? Nitrogen { get; set; }
        public string? ImageName { get; set; }
        public string? Benefits { get; set; }
        public string? History { get; set; }
        public float? Portion { get; set; }
        public string? PortionUnit { get; set; }
        public float? Caffeine { get; set; }
        public IFormFile Image { get; set; }


        // Lipid Fat
        public float? Saturated { get; set; }
        public float? Unsaturated { get; set; }
        public float? Cholesterol { get; set; }
        public float? Trans { get; set; }

        //Carbohydrate
        public float? Fiber { get; set; }
        public float? Starch { get; set; }
        //Sugar
        public float? Sucrose { get; set; }
        public float? Glucose { get; set; }
        public float? Fructose { get; set; }
        public float? Lactose { get; set; }
        public float? Maltose { get; set; }
        public float? Galactose { get; set; }
        //Vitamin
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

        // Mineral
        public float? Calcium { get; set; }
        public float? Iron { get; set; }
        public float? Magnesium { get; set; }
        public float? Phosphorus { get; set; }
        public float? Potassium { get; set; }
        public float? Sodium { get; set; }
        public float? Zinc { get; set; }
        public float? Copper { get; set; }
        public float? Manganese { get; set; }
        public float? Selenium { get; set; }
    }
}
