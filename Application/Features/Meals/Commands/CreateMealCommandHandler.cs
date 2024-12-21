using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Features.Meals.Commands
{
    public class CreateMealCommandHandler : IRequestHandler<CreateMealCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Domain.Entity.Meal> _mealRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMealCommandHandler(IMapper mapper, IGenericRepository<Domain.Entity.Meal> mealRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _mealRepository = mealRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var meal = _mapper.Map<Meal>(request);
                meal.MealIngredients = _mapper.Map<List<MealIngredient>>(request.MealIngredients);

                await _mealRepository.CreateAsync(meal);
                await _unitOfWork.CommitTransactionAsync();
                return meal.Id;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new ApplicationException("An error occurred while creating the meal.", ex);
            }
        }
    }
}
