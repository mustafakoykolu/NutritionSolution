using Application.Features.Meals.Dtos;
using MediatR;

namespace Application.Features.Meals.Queries
{
    public class GetMealByIdQuery:IRequest<MealDto>
    {
        public int Id { get; set; }
    }
}
