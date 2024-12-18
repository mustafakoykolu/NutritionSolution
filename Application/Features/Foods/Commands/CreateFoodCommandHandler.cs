using Application.Contracts.Persistence;
using Application.Features.UserType.Commands.CreateUserType;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Foods.Commands
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, int>
    {
       
        private readonly IMapper _mapper;
        private readonly IFoodRepository _foodRepository;

        public CreateFoodCommandHandler(IMapper mapper, IFoodRepository foodRepository)
        {
            _mapper = mapper;
            _foodRepository = foodRepository;
        }
        public async Task<int> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = _mapper.Map<Food>(request);
            await _foodRepository.CreateAsync(food);
            return food.Id;
            throw new NotImplementedException();
        }

    }
}
