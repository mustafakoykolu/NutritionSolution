using Application.Features.Meals.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Meals.Queries
{
    public class GetMealByIdQuery:IRequest<MealDto>
    {
        public int Id { get; set; }

        public GetMealByIdQuery(int id)
        {
            Id = id;
        }
    }
}
