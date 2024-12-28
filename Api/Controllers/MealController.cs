using Application.Features.Meals.Commands;
using Application.Features.Meals.Dtos;
using Application.Features.Meals.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Boss,Admin,User")]
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

        [HttpPost("CreateMeal")]
        public async Task<ActionResult<int>> CreateMeal([FromBody] CreateMealDto createMealRq)
        {
            var command = new CreateMealCommand(createMealRq);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
