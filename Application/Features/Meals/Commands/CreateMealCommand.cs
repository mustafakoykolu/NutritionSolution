using Application.Features.Meals.Dtos;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Meals.Commands
{
    public class CreateMealCommand:IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Recipe { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string History { get; set; } = string.Empty;
        public IFormFile? Image { get; set; }
        public List<MealIngredientDto> MealIngredients { get; set; } = new List<MealIngredientDto>();
    }
}
