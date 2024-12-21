﻿using Application.Contracts.Persistence;
using Application.Features.Foods.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Foods.Queries
{
    public class GetFoodsQueryHandler : IRequestHandler<GetFoodsQuery, FoodsDtoPaging>
    {
        private readonly IGenericRepository<Domain.Entity.Food> _foodsRepository;
        private readonly IMapper _mapper;

        public GetFoodsQueryHandler(IGenericRepository<Domain.Entity.Food> foodsRepository, IMapper mapper)
        {
            _foodsRepository = foodsRepository;
            _mapper = mapper;
        }

        public async Task<FoodsDtoPaging> Handle(GetFoodsQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await _foodsRepository.GetCountAsync();
            var foods = await _foodsRepository.GetPagedAsync(request.PageNumber, request.PageSize);
            var foodList= _mapper.Map<List<FoodsDto>>(foods);
            var result = new FoodsDtoPaging() { Data = foodList, TotalCount= totalCount,DataCount=foodList.Count, PageNumber=request.PageNumber,PageSize=request.PageSize};
            return result;
        }
    }
}
