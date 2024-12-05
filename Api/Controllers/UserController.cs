using Application.Features.UserType.Commands.CreateUserType;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<int> Post(CreateUserTypeCommand userType)
        {
            var response = await _mediator.Send(userType);
            return response;
        }       
    }
}
