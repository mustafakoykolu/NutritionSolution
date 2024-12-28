using Application.Contracts.Persistence;
using Application.Features.Foods.Dtos;
using Application.Features.Meals.Dtos;
using AutoMapper;
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
            var mealDtos = meals.Select(meal => new MealDto
            {
                Name = meal.Name,
                Description = meal.Description,
                Recipe = meal.Recipe,
                ImagePath = meal.ImagePath,
                History = meal.History,
                TotalNutrients = new NutrientDto
                {
                    KCal = (float)meal.MealFoods.Sum(mf => mf.Food.KCal.GetValueOrDefault() * mf.Quantity / 100),
                    Protein = (float)meal.MealFoods.Sum(mf => mf.Food.Protein.GetValueOrDefault() * mf.Quantity / 100),
                    Fat = (float)meal.MealFoods.Sum(mf => mf.Food.Fat.Saturated.GetValueOrDefault() * mf.Quantity / 100),
                    Carbohydrate = (float)meal.MealFoods.Sum(mf => mf.Food.Carbohydrate.Fiber.GetValueOrDefault() * mf.Quantity / 100)
                },
                Ingredients = _mapper.Map<List<MealFoodDto>>(meal.MealFoods)
            }).ToList();

            return mealDtos;
        }
    }
}
