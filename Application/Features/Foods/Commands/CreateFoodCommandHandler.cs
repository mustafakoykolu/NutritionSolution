using Application.Contracts.Persistence;
using Application.Features.Foods.Dtos;
using Application.Features.UserType.Commands.CreateUserType;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Features.Foods.Commands
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, int>
    {
       
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Domain.Entity.Food> _foodRepository;

        public CreateFoodCommandHandler(IMapper mapper, IGenericRepository<Domain.Entity.Food> foodRepository)
        {
            _mapper = mapper;
            _foodRepository = foodRepository;
        }
        public async Task<int> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            //add image
            var uploadPath = Path.Combine("C:\\", "images");

            // Create the directory if it doesn't exist
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Combine the upload path with the file name
            var fileExtension = Path.GetExtension(request.Image.FileName);
            request.ImagePath = Path.Combine(uploadPath, $"{Guid.NewGuid()}{fileExtension}");
                
            // Save the file to the directory
            using (var stream = new FileStream(request.ImagePath, FileMode.Create))
            {
                await request.Image.CopyToAsync(stream);
            }

            var food = _mapper.Map<Food>(request);
            await _foodRepository.CreateAsync(food);
            return food.Id;
        }

    }
}
