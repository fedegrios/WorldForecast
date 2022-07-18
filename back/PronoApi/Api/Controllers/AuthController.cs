using Interfaces;
using Interfaces.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("api/login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginDto dto)
        {
            var response = await _authServices.LoginUser(dto);

            if (response.Type == ResponseType.Success)
                return Ok(response.Data);

            if (response.Type == ResponseType.NotFound)
                return NotFound(response.ErrMgs);

            return BadRequest(response.ErrMgs);

        }

        [HttpPost("api/register")]
        public async Task<ActionResult<string>> Register([FromBody] UserRegisterDto dto)
        {
            var response = await _authServices.RegisterUser(dto);

            if (response.Type == ResponseType.Success)
                return Ok(response.Data);

            if (response.Type == ResponseType.NotFound)
                return NotFound(response.ErrMgs);

            return BadRequest(response.ErrMgs);

        }
    }
}
