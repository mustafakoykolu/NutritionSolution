using Application.Features.Foods.Dtos;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Foods.Queries
{
    public class GetFoodsQuery : IRequest<FoodsDtoPaging>, IPaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
