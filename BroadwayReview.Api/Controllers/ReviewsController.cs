using BroadwayReview.Application.DTO;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.Application.UseCases.Queries;
using BroadwayReview.Implementations.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BroadwayReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private UseCaseHandler _handler;

        public ReviewsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        [HttpGet("play/{id}")]
        public IActionResult Get(int id, [FromServices] IFindPlayReviewsQuery query)
        {

            return Ok(_handler.HandleQuery(query, id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] ReviewDTO dto, [FromServices] ICreateReviewCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public IActionResult Post(int id, [FromServices] IDeleteReviewCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
