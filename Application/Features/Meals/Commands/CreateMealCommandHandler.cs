using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Meals.Commands
{
    public class CreateMealCommandHandler : IRequestHandler<CreateMealCommand, int>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public CreateMealCommandHandler(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            var uploadFolder = Path.Combine("C:\\", "images", "meals");

            // Dizin oluşturma (yoksa)
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // Benzersiz dosya adı oluşturma
            var fileExtension = Path.GetExtension(request.Meal.Image.FileName);
            var imageGuid = Guid.NewGuid();
            request.Meal.ImageName = $"{imageGuid}{fileExtension}";
            var uploadPath = Path.Combine(uploadFolder, request.Meal.ImageName);

            // Resmi kaydetme
            using (var stream = new FileStream(uploadPath, FileMode.Create))
            {
                await request.Meal.Image.CopyToAsync(stream);
            }

            // 2. Dto -> Entity Dönüşümü
            var meal = _mapper.Map<Domain.Entity.Meal>(request.Meal);

            // 3. Veritabanına Kaydetme
            await _mealRepository.AddAsync(meal);

            // 4. Yeni Yemeğin ID'sini Döndürme
            return meal.Id;
        }
    }
}


//{
//    "name": "Sebzeli Tavuk Yemeği",
//    "description": "Sağlıklı ve dengeli bir yemek.",
//    "recipe": "Tüm malzemeleri karıştır ve fırına ver.",
//    "imageName": "dummy-image.jpg",
//    "history": "Geleneksel bir Türk yemeği.",
//    "ingredients": [
//        {
//        "foodId": 15,
//            "quantity": 150
//        },
//        {
//        "foodId": 16,
//            "quantity": 200
//        }
//    ]
//}