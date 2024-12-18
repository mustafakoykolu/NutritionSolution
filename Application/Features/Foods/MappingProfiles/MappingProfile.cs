using Application.Features.Foods.Dtos;
using AutoMapper;


namespace Application.Features.Foods.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entity.Food, FoodsDto>();
        }
    }
}
