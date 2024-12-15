using Application.Features.Foods.Dtos;
using MediatR;

namespace Application.Features.Foods.Queries
{
    public class GetFoodByIdQuery : IRequest<FoodsDto>
    {
        public int Id { get; set; }
    }
}
