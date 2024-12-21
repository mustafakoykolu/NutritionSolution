using Application.Features.Foods.Commands;
using Application.Features.Foods.Dtos;
using Application.Features.Foods.Queries;
using Application.Features.UserType.Commands.CreateUserType;
using Domain.Common;
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
        public async Task<ActionResult<FoodsDtoPaging>> GetFoods([FromQuery]GetFoodsQuery getFoodsQuery)
        {
            var result = await _mediator.Send(getFoodsQuery);
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
        [HttpGet("SearchFood")]
        public async Task<ActionResult<FoodsDto>> SearchFood([FromQuery] SearchFoodQuery searchFoodQuery)
        {
            var result = await _mediator.Send(searchFoodQuery);
            return Ok(result);
        }
    }
}
