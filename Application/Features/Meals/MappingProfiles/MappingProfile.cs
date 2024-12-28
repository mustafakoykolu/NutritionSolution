
using Application.Features.Foods.Dtos;
using Application.Features.Meals.Dtos;
using AutoMapper;
using Domain.Entity;



namespace Application.Features.Meals.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Meal -> MealDto
            CreateMap<Meal, MealDto>()
                .ForMember(dest => dest.TotalNutrients, opt => opt.Ignore()); // Toplam besin değerlerini hesaplayacağız

            // MealFood -> MealFoodDto
            CreateMap<MealFood, MealFoodDto>()
                .ForMember(dest => dest.Food, opt => opt.MapFrom(src => src.Food)) // Food -> FoodDto
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Meal, MealDto>()
            // Total Nutrient mapping
            .ForMember(dest => dest.TotalNutrients, opt => opt.MapFrom(src => new NutrientDto
            {
                KCal = (float)src.MealFoods.Sum(mf => mf.Food.KCal.GetValueOrDefault() * mf.Quantity / 100),
                Protein = (float)src.MealFoods.Sum(mf => mf.Food.Protein.GetValueOrDefault() * mf.Quantity / 100),
                Fat = (float)src.MealFoods.Sum(mf => mf.Food.Fat.Saturated.GetValueOrDefault() * mf.Quantity / 100),
                Carbohydrate = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Fiber.GetValueOrDefault() * mf.Quantity / 100)
            }))
            // Ingredients mapping
            .ForMember(dest => dest.MealFoods, opt => opt.MapFrom(src => src.MealFoods));

        }
    }
}
