using BroadwayReview.Application.DTO;
using BroadwayReview.Application.Logging;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.Application.UseCases.Queries;
using BroadwayReview.Application;
using BroadwayReview.Implementations.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BroadwayReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IApplicationUser _user;
        private UseCaseHandler _handler;

        public UsersController(IApplicationUser user, UseCaseHandler handler)
        {
            _user = user;
            _handler = handler;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_user);
        }
        [HttpPut]
        [AllowAnonymous]
        public IActionResult Put([FromBody] UpdateUserUseCaseDTO dto,
            [FromServices] IUpdateUserUseCaseCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpGet("logs")]
        public IActionResult GetLogs([FromQuery] UseCaseLogSearch dto, [FromServices] IGetUseCaseLogsQuery query)
        {
            return Ok(_handler.HandleQuery(query, dto));
        }
    }
}
