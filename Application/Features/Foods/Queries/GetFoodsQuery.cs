using Application.Features.Foods.Dtos;
using MediatR;

namespace Application.Features.Foods.Queries
{
    public class GetFoodsQuery : IRequest<List<FoodsDto>>
    {
    }
}
