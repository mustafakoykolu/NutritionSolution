
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
        }
    }
}
