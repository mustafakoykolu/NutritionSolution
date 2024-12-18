using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Foods.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Foods.Queries
{
    public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, FoodsDto>
    {
        private readonly IGenericRepository<Domain.Entity.Food> _foodRepository;
        private readonly IMapper _mapper;

        public GetFoodByIdQueryHandler(IGenericRepository<Domain.Entity.Food> foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }

        public async Task<FoodsDto> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
        {
            var food = await _foodRepository.GetByIdAsync(request.Id);
            if (food == null)
            {
                throw new NotFoundException(nameof(Foods), request.Id);
            }

            return _mapper.Map<FoodsDto>(food);
        }
    }
}
