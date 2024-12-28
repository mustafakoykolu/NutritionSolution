using Application.Common.Dtos;
using Application.Contracts.Persistence;
using Application.Features.Foods.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Foods.Queries
{
    public class SearchFoodQueryHandler : IRequestHandler<SearchFoodQuery, DataDtoPaging>
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;

        public SearchFoodQueryHandler(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }
        public async Task<DataDtoPaging> Handle(SearchFoodQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await _foodRepository.SearchByNameCount(request.FoodName, request.PageNumber, request.PageSize);
            var foods = await _foodRepository.SearchByName(request.FoodName,request.PageNumber, request.PageSize);
            var foodList = _mapper.Map<List<FoodsDto>>(foods);
            var result = new DataDtoPaging() { Data = foodList, TotalCount = totalCount, DataCount = foodList.Count, PageNumber = request.PageNumber, PageSize = request.PageSize };
            return result;
        }
    }
}
