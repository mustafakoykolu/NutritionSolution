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
            //add image
            var uploadFolder = Path.Combine("C:\\","meals","images");

            // Create the directory if it doesn't exist
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // Combine the upload path with the file name
            var fileExtension = Path.GetExtension(request.Image.FileName);
            var imageGuid = Guid.NewGuid();
            request.ImagePath = $"{imageGuid}{fileExtension}";
            var uploadPath = Path.Combine(uploadFolder, $"{imageGuid}{fileExtension}");

            // Save the file to the directory
            using (var stream = new FileStream(uploadPath, FileMode.Create))
            {
                await request.Image.CopyToAsync(stream);
            }

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
                //todo: delete the image.
                throw new ApplicationException("An error occurred while creating the meal.", ex);
            }
        }
    }
}
