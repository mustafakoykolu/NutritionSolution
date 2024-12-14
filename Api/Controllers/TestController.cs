using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Boss")]
    public class TestController:ControllerBase
    {
        [HttpGet("Ex1")]
        [Authorize(Roles = "Boss")]
        public string Ex1()
        {
            return "Just Boss";
        }

        [HttpGet("Ex2")]
        [Authorize(Roles = "Boss,User")]
        public string Ex2()
        {
            return "Boss and User";
        }

        [HttpGet("Ex3")]
        [Authorize(Roles = "User")]
        public string Ex3()
        {
            return "Just User";
        }
    }
}
