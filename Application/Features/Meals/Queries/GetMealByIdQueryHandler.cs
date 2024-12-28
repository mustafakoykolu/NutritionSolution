using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Meals.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Meals.Queries
{
    internal class GetMealByIdQueryHandler : IRequestHandler<GetMealByIdQuery, MealDto>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public GetMealByIdQueryHandler(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<MealDto> Handle(GetMealByIdQuery request, CancellationToken cancellationToken)
        {
            // Repository'den Meal'ı id'ye göre çekiyoruz
            var meal = await _mealRepository.GetMealsWithIngredientsByIdAsync(request.Id);

            if (meal == null)
                throw new Exception($"Meal with ID {request.Id} not found");

            // AutoMapper ile Meal entity'sini MealDto'ya dönüştürme
            var mealDto = _mapper.Map<MealDto>(meal);

            return mealDto;
        }
    }
}
