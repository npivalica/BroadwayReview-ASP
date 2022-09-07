using BroadwayReview.Api.Auth;
using BroadwayReview.Application.DTO;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.Implementations.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BroadwayReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UseCaseHandler _handler;
        private JWTManager _manager;

        public AuthController(UseCaseHandler handler, JWTManager manager)
        {
            _handler = handler;
            _manager = manager;
        }

        [HttpPost]
        public IActionResult Register([FromBody] RegisterUserDTO dto, [FromServices] IRegisterUserCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost("token")]
        public IActionResult Token([FromBody] GenereteTokenDto dto)
        {
            try
            {
                var token = _manager.MakeToken(dto.Email, dto.Password);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        public class GenereteTokenDto
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
