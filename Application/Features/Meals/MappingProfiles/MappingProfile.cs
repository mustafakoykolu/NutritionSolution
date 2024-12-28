
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

            // MealFoods -> FoodDto (GetFoods ile aynı yapıya sahip)
            CreateMap<MealFood, FoodsDto>()
                .ForMember(dest => dest.KCal, opt => opt.MapFrom(src => src.Food.KCal))
                .ForMember(dest => dest.Protein, opt => opt.MapFrom(src => src.Food.Protein))
                .ForMember(dest => dest.Fat, opt => opt.MapFrom(src => src.Food.Fat))
                .ForMember(dest => dest.Carbohydrate, opt => opt.MapFrom(src => src.Food.Carbohydrate));
        }
    }
}
