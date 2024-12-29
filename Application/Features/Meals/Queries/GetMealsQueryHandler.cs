using Application.Common.Dtos;
using Application.Contracts.Persistence;
using Application.Features.Foods.Dtos;
using Application.Features.Meals.Dtos;
using AutoMapper;
using Domain.Entity;
using MediatR;

namespace Application.Features.Meals.Queries
{
    public class GetMealsQueryHandler : IRequestHandler<GetMealsQuery, DataDtoPaging>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public GetMealsQueryHandler(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<DataDtoPaging> Handle(GetMealsQuery request, CancellationToken cancellationToken)
        {
            var totalCount = await _mealRepository.GetCountAsync();
            var meals = await _mealRepository.GetMealsPagedAsync(request.PageNumber,request.PageSize);
            var mealList = _mapper.Map<List<MealDto>>(meals);
            var result = new DataDtoPaging() { Data = mealList, TotalCount = totalCount, DataCount = mealList.Count, PageNumber = request.PageNumber, PageSize = request.PageSize }; 
            return result;

        }
    }
}
