using Application.Features.Foods.Commands;
using Application.Features.Foods.Dtos;
using Application.Features.Foods.Queries;
using Application.Features.UserType.Commands.CreateUserType;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Boss,Admin,User")]
    public class FoodController : Controller
    {
        private readonly IMediator _mediator;
        public FoodController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("GetFoods")]
        public async Task<ActionResult<List<FoodsDto>>> GetFoods()
        {
            var result = await _mediator.Send(new GetFoodsQuery());
            return Ok(result);
        }

        [HttpGet("GetFoodById")]
        public async Task<ActionResult<FoodsDto>> GetFoodById(int id)
        {
            var result = await _mediator.Send(new GetFoodByIdQuery() { Id = id });
            return Ok(result);
        }
        [HttpPost("CreateFood")]
        public async Task<ActionResult<FoodsDto>> CreateFood([FromForm]CreateFoodCommand createFoodRq)
        {
            var result = await _mediator.Send(createFoodRq);
            return Ok(result);
        }
    }
}
