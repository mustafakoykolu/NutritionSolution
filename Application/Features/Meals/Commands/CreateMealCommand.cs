using Application.Features.Meals.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Meals.Commands
{
    public class CreateMealCommand:IRequest<int>
    {
        public CreateMealDto Meal { get; set; }

        public CreateMealCommand(CreateMealDto meal)
        {
            Meal = meal;
        }
    }
}
