using Application.Features.Meals.Commands;
using Application.Features.Meals.Dtos;
using Application.Features.Meals.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : Controller
    {
        private readonly IMediator _mediator;

        public MealController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("GetMealById")]
        public async Task<ActionResult<MealDto>> GetMealById(int id)
        {
            var query = new GetMealByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("GetMeals")]
        public async Task<ActionResult<List<MealDto>>> GetMeals([FromQuery] GetMealsQuery getMealsQuery  )
        {
            var result = await _mediator.Send(getMealsQuery);
            return Ok(result);
        }
        [Authorize(Roles = "Boss,Admin,User")]
        [HttpPost("CreateMeal")]
        public async Task<ActionResult<int>> CreateMeal([FromForm] CreateMealDto createMealRq)
        {
            var command = new CreateMealCommand
            {
                Name = createMealRq.Name,
                Recipe = createMealRq.Recipe,
                History = createMealRq.History,
                Benefits = createMealRq.Benefits,
                Image = createMealRq.Image,
                ImageName = createMealRq.ImageName,
                Ingredients = JsonConvert.DeserializeObject<List<CreateMealFoodDto>>(createMealRq.Ingredients)
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
