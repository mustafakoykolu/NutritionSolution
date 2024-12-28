using Application.Features.Meals.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Meals.Queries
{
    public class GetMealsQuery:IRequest<List<MealDto>>
    {
    }
}
