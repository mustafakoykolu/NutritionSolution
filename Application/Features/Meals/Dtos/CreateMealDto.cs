using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Meals.Dtos
{
    public class CreateMealDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public string ImageName { get; set; }
        public string History { get; set; }
        public IFormFile? Image { get; set; }
        public List<CreateMealFoodDto> Ingredients { get; set; }
    }
}
