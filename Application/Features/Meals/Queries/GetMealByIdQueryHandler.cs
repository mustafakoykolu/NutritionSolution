using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Meals.Dtos;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Features.Meals.Queries
{
    public class GetMealByIdQueryHandler : IRequestHandler<GetMealByIdQuery, MealDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Meal> _mealRepository;

        public GetMealByIdQueryHandler(IMapper mapper, IGenericRepository<Meal> mealRepository)
        {
            _mapper = mapper;
            _mealRepository = mealRepository;
        }

        public async Task<MealDto> Handle(GetMealByIdQuery request, CancellationToken cancellationToken)
        {
            var meal = await _mealRepository.GetByIdAsync(request.Id);
            return _mapper.Map<MealDto>(meal);
        }
    }
}
