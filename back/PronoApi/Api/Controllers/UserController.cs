using Interfaces;
using Interfaces.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDetailDto>> Get(int id)
        {
            var response = await _userServices.GetUserDetail(id);

            if (response.Type == ResponseType.Success)
                return Ok(response.Data);

            if (response.Type == ResponseType.NotFound)
                return NotFound(response.ErrMgs);

            return BadRequest(response.ErrMgs);

        }
    }
}
