using Application.Features.Foods.Commands;
using Application.Features.Foods.Dtos;
using AutoMapper;
using Domain.Entity;


namespace Application.Features.Foods.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entity.Food, FoodsDto>();
            CreateMap<CreateFoodCommand, Food>()
            // Lipid Mapping
            .ForMember(dest => dest.Fat, opt => opt.MapFrom(src => new Lipid
            {
                Saturated = src.Saturated ?? 0, // Null kontrolü
                Unsaturated = src.Unsaturated ?? 0,
                Cholesterol = src.Cholesterol ?? 0,
                Trans = src.Trans ?? 0
            }))
            // Carbohydrate Mapping
            .ForMember(dest => dest.Carbohydrate, opt => opt.MapFrom(src => new Carbohydrate
            {
                Fiber = src.Fiber ?? 0,
                Starch = src.Starch ?? 0,
                Sugar = new Sugar
                {
                    Sucrose = src.Sucrose ?? 0,
                    Glucose = src.Glucose ?? 0,
                    Fructose = src.Fructose ?? 0,
                    Lactose = src.Lactose ?? 0,
                    Maltose = src.Maltose ?? 0,
                    Galactose = src.Galactose ?? 0
                }
            }))
            // Vitamin Mapping
            .ForMember(dest => dest.Vitamin, opt => opt.MapFrom(src => new Vitamin
            {
                VitaminA = src.VitaminA ?? 0,
                VitaminB1 = src.VitaminB1 ?? 0,
                VitaminB2 = src.VitaminB2 ?? 0,
                VitaminB3 = src.VitaminB3 ?? 0,
                VitaminB5 = src.VitaminB5 ?? 0,
                VitaminB6 = src.VitaminB6 ?? 0,
                VitaminB7 = src.VitaminB7 ?? 0,
                VitaminB9 = src.VitaminB9 ?? 0,
                VitaminB12 = src.VitaminB12 ?? 0,
                VitaminC = src.VitaminC ?? 0,
                VitaminD = src.VitaminD ?? 0,
                VitaminE = src.VitaminE ?? 0,
                VitaminK = src.VitaminK ?? 0,
                VitaminD3 = src.VitaminD3 ?? 0,
                VitaminA1 = src.VitaminA1 ?? 0,
                VitaminA2 = src.VitaminA2 ?? 0
            }))
            // Mineral Mapping
            .ForMember(dest => dest.Mineral, opt => opt.MapFrom(src => new Mineral
            {
                Calcium = src.Calcium ?? 0,
                Iron = src.Iron ?? 0,
                Magnesium = src.Magnesium ?? 0,
                Phosphorus = src.Phosphorus ?? 0,
                Potassium = src.Potassium ?? 0,
                Sodium = src.Sodium ?? 0,
                Zinc = src.Zinc ?? 0,
                Copper = src.Copper ?? 0,
                Manganese = src.Manganese ?? 0,
                Selenium = src.Selenium ?? 0
            }));
        }
    }
}
