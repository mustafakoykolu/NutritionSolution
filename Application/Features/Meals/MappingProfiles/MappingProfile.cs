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
            CreateMap<Meal, MealDto>();
            CreateMap<MealIngredient, MealIngredientDto>()
               .ForMember(dest => dest.Food, opt => opt.MapFrom(src => src.Food));
            CreateMap<MealIngredientDto, MealIngredient>();
            CreateMap<CreateMealCommand, Meal>()
                .ForMember(dest => dest.MealIngredients, opt => opt.MapFrom(src => src.MealIngredients));
        }
    }
}
