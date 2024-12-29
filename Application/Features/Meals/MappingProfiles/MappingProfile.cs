
using Application.Features.Foods.Dtos;
using Application.Features.Meals.Commands;
using Application.Features.Meals.Dtos;
using AutoMapper;
using Domain.Entity;



namespace Application.Features.Meals.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateMealCommand, Meal>()
                .ForMember(dest => dest.MealFoods, opt => opt.MapFrom(src => src.Ingredients));
            // Meal -> MealDto
            CreateMap<Meal, MealDto>()
                .ForMember(dest => dest.TotalNutrients, opt => opt.Ignore()); // Toplam besin değerlerini hesaplayacağız

            // MealFood -> MealFoodDto
            CreateMap<MealFood, MealFoodDto>()
                .ForMember(dest => dest.Food, opt => opt.MapFrom(src => src.Food)) // Food -> FoodDto
                .ForMember(dest => dest.Portion, opt => opt.MapFrom(src => src.Portion))
                .ForMember(dest => dest.PortionUnit, opt => opt.MapFrom(src => src.PortionUnit));

            // Food -> FoodsDto
            CreateMap<Food, FoodsDto>();

            // CreateMealDto -> Meal
            CreateMap<CreateMealDto, Meal>()
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImageName))
                .ForMember(dest => dest.MealFoods, opt => opt.MapFrom(src => src.Ingredients)); // Ingredients -> MealFoods

            // CreateMealFoodDto -> MealFood
            CreateMap<CreateMealFoodDto, MealFood>();
            CreateMap<Meal, MealDto>()
            // Total Nutrient mapping

            .ForMember(dest => dest.TotalNutrients, opt => opt.MapFrom(src => new NutrientDto
            {
                KCal = (float)src.MealFoods.Sum(mf => mf.Food.KCal.GetValueOrDefault() * mf.Portion / 100),
                Protein = (float)src.MealFoods.Sum(mf => mf.Food.Protein.GetValueOrDefault() * mf.Portion / 100),
                Water = (float)src.MealFoods.Sum(mf => mf.Food.Water.GetValueOrDefault() * mf.Portion / 100),
                Nitrogen = (float)src.MealFoods.Sum(mf => mf.Food.Nitrogen.GetValueOrDefault() * mf.Portion / 100),
                Caffeine = (float)src.MealFoods.Sum(mf => mf.Food.Caffeine.GetValueOrDefault() * mf.Portion / 100),
                Vitamin = new Vitamin
                {
                    VitaminA = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminA.GetValueOrDefault() * mf.Portion / 100),
                    VitaminB1 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB1.GetValueOrDefault() * mf.Portion / 100),
                    VitaminB2 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB2.GetValueOrDefault() * mf.Portion / 100),
                    VitaminB3 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB3.GetValueOrDefault() * mf.Portion / 100),
                    VitaminB5 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB5.GetValueOrDefault() * mf.Portion / 100),
                    VitaminB6 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB6.GetValueOrDefault() * mf.Portion / 100),
                    VitaminB7 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB7.GetValueOrDefault() * mf.Portion / 100),
                    VitaminB9 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB9.GetValueOrDefault() * mf.Portion / 100),
                    VitaminB12 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB12.GetValueOrDefault() * mf.Portion / 100),
                    VitaminC = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminC.GetValueOrDefault() * mf.Portion / 100),
                    VitaminD = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminD.GetValueOrDefault() * mf.Portion / 100),
                    VitaminE = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminE.GetValueOrDefault() * mf.Portion / 100),
                    VitaminK = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminK.GetValueOrDefault() * mf.Portion / 100),
                    VitaminA1 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminA1.GetValueOrDefault() * mf.Portion / 100),
                    VitaminA2 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminA2.GetValueOrDefault() * mf.Portion / 100),
                    VitaminD3 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminD3.GetValueOrDefault() * mf.Portion / 100),
                },
                Fat = new Lipid
                {
                    Saturated = (float)src.MealFoods.Sum(mf => mf.Food.Fat.Saturated.GetValueOrDefault() * mf.Portion / 100),
                    Unsaturated = (float)src.MealFoods.Sum(mf => mf.Food.Fat.Unsaturated.GetValueOrDefault() * mf.Portion / 100),
                    Cholesterol = (float)src.MealFoods.Sum(mf => mf.Food.Fat.Cholesterol.GetValueOrDefault() * mf.Portion / 100),
                    Trans = (float)src.MealFoods.Sum(mf => mf.Food.Fat.Trans.GetValueOrDefault() * mf.Portion / 100),
                },
                Carbohydrate = new Carbohydrate
                {
                    Fiber = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Fiber.GetValueOrDefault() * mf.Portion / 100),
                    Starch = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Starch.GetValueOrDefault() * mf.Portion / 100),
                    Sugar = new Sugar
                    {
                        Sucrose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Sucrose.GetValueOrDefault() * mf.Portion / 100),
                        Glucose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Glucose.GetValueOrDefault() * mf.Portion / 100),
                        Fructose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Fructose.GetValueOrDefault() * mf.Portion / 100),
                        Lactose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Lactose.GetValueOrDefault() * mf.Portion / 100),
                        Maltose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Maltose.GetValueOrDefault() * mf.Portion / 100),
                        Galactose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Galactose.GetValueOrDefault() * mf.Portion / 100)
                    }
                },
                Mineral = new Mineral
                {
                    Calcium = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Calcium.GetValueOrDefault() * mf.Portion / 100),
                    Iron = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Iron.GetValueOrDefault() * mf.Portion / 100),
                    Magnesium = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Magnesium.GetValueOrDefault() * mf.Portion / 100),
                    Phosphorus = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Phosphorus.GetValueOrDefault() * mf.Portion / 100),
                    Potassium = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Potassium.GetValueOrDefault() * mf.Portion / 100),
                    Sodium = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Sodium.GetValueOrDefault() * mf.Portion / 100),
                    Zinc = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Zinc.GetValueOrDefault() * mf.Portion / 100),
                    Copper = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Copper.GetValueOrDefault() * mf.Portion / 100),
                    Manganese = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Manganese.GetValueOrDefault() * mf.Portion / 100),
                    Selenium = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Selenium.GetValueOrDefault() * mf.Portion / 100),
                }
            }))
            // Ingredients mapping
            .ForMember(dest => dest.MealFoods, opt => opt.MapFrom(src => src.MealFoods));

        }
    }
}
