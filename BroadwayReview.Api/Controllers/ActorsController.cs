using BroadwayReview.Application.DTO;
using BroadwayReview.Application.DTO.Searches;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.Application.UseCases.Queries;
using BroadwayReview.Implementations.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BroadwayReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActorsController : ControllerBase
    {
        private readonly UseCaseHandler _handler;

        public ActorsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // GET: api/<ActorsController>
        [HttpGet]
        public IActionResult Get([FromQuery] BasePagedSearch dto, [FromServices] IGetActorsQuery query)
        {
            return Ok(_handler.HandleQuery(query, dto));
        }

        // GET api/<ActorsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IFindActorQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<ActorsController>
        [HttpPost]
        public IActionResult Post([FromBody] ActorDTO dto, [FromServices] ICreateActorCommand command)
        {
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        // PUT api/<ActorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateActorDTO dto, [FromServices] IUpdateActorCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<ActorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteActorCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
