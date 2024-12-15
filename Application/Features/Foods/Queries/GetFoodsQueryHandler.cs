using Application.Contracts.Persistence;
using Application.Features.Foods.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Foods.Queries
{
    public class GetFoodsQueryHandler : IRequestHandler<GetFoodsQuery, List<FoodsDto>>
    {
        private readonly IGenericRepository<Domain.Entity.Foods> _foodsRepository;
        private readonly IMapper _mapper;

        public GetFoodsQueryHandler(IGenericRepository<Domain.Entity.Foods> foodsRepository, IMapper mapper)
        {
            _foodsRepository = foodsRepository;
            _mapper = mapper;
        }

        public async Task<List<FoodsDto>> Handle(GetFoodsQuery request, CancellationToken cancellationToken)
        {
            var foods = await _foodsRepository.GetAllAsync();
            var foodList= _mapper.Map<List<FoodsDto>>(foods);
            return foodList;
        }
    }
}
