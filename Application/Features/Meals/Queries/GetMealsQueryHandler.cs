using Application.Contracts.Persistence;
using Application.Features.Meals.Dtos;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Features.Meals.Queries
{
    public class GetMealsQueryHandler : IRequestHandler<GetMealsQuery, List<MealDto>>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public GetMealsQueryHandler(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<List<MealDto>> Handle(GetMealsQuery request, CancellationToken cancellationToken)
        {
            var meals = await _mealRepository.GetMealsWithIngredientsAsync();
            var mealList = _mapper.Map<List<MealDto>>(meals);
            return mealList;
        }
    }
}
