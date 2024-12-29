
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
                KCal = (float)src.MealFoods.Sum(mf => mf.Food.KCal.GetValueOrDefault() * mf.Quantity / 100),
                Protein = (float)src.MealFoods.Sum(mf => mf.Food.Protein.GetValueOrDefault() * mf.Quantity / 100),
                Water = (float)src.MealFoods.Sum(mf => mf.Food.Water.GetValueOrDefault() * mf.Quantity / 100),
                Nitrogen = (float)src.MealFoods.Sum(mf => mf.Food.Nitrogen.GetValueOrDefault() * mf.Quantity / 100),
                Caffeine = (float)src.MealFoods.Sum(mf => mf.Food.Caffeine.GetValueOrDefault() * mf.Quantity / 100),
                Vitamin = new Vitamin
                {
                    VitaminA = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminA.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminB1 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB1.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminB2 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB2.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminB3 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB3.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminB5 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB5.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminB6 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB6.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminB7 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB7.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminB9 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB9.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminB12 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminB12.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminC = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminC.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminD = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminD.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminE = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminE.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminK = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminK.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminA1 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminA1.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminA2 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminA2.GetValueOrDefault() * mf.Quantity / 100),
                    VitaminD3 = (float)src.MealFoods.Sum(mf => mf.Food.Vitamin.VitaminD3.GetValueOrDefault() * mf.Quantity / 100),
                },
                Fat = new Lipid
                {
                    Saturated = (float)src.MealFoods.Sum(mf => mf.Food.Fat.Saturated.GetValueOrDefault() * mf.Quantity / 100),
                    Unsaturated = (float)src.MealFoods.Sum(mf => mf.Food.Fat.Unsaturated.GetValueOrDefault() * mf.Quantity / 100),
                    Cholesterol = (float)src.MealFoods.Sum(mf => mf.Food.Fat.Cholesterol.GetValueOrDefault() * mf.Quantity / 100),
                    Trans = (float)src.MealFoods.Sum(mf => mf.Food.Fat.Trans.GetValueOrDefault() * mf.Quantity / 100),
                },
                Carbohydrate = new Carbohydrate
                {
                    Fiber = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Fiber.GetValueOrDefault() * mf.Quantity / 100),
                    Starch = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Starch.GetValueOrDefault() * mf.Quantity / 100),
                    Sugar = new Sugar
                    {
                        Sucrose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Sucrose.GetValueOrDefault() * mf.Quantity / 100),
                        Glucose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Glucose.GetValueOrDefault() * mf.Quantity / 100),
                        Fructose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Fructose.GetValueOrDefault() * mf.Quantity / 100),
                        Lactose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Lactose.GetValueOrDefault() * mf.Quantity / 100),
                        Maltose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Maltose.GetValueOrDefault() * mf.Quantity / 100),
                        Galactose = (float)src.MealFoods.Sum(mf => mf.Food.Carbohydrate.Sugar.Galactose.GetValueOrDefault() * mf.Quantity / 100)
                    }
                },
                Mineral = new Mineral
                {
                    Calcium = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Calcium.GetValueOrDefault() * mf.Quantity / 100),
                    Iron = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Iron.GetValueOrDefault() * mf.Quantity / 100),
                    Magnesium = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Magnesium.GetValueOrDefault() * mf.Quantity / 100),
                    Phosphorus = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Phosphorus.GetValueOrDefault() * mf.Quantity / 100),
                    Potassium = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Potassium.GetValueOrDefault() * mf.Quantity / 100),
                    Sodium = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Sodium.GetValueOrDefault() * mf.Quantity / 100),
                    Zinc = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Zinc.GetValueOrDefault() * mf.Quantity / 100),
                    Copper = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Copper.GetValueOrDefault() * mf.Quantity / 100),
                    Manganese = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Manganese.GetValueOrDefault() * mf.Quantity / 100),
                    Selenium = (float)src.MealFoods.Sum(mf => mf.Food.Mineral.Selenium.GetValueOrDefault() * mf.Quantity / 100),
                }
            }))
            // Ingredients mapping
            .ForMember(dest => dest.MealFoods, opt => opt.MapFrom(src => src.MealFoods));

        }
    }
}
