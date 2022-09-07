using BroadwayReview.Application.DTO;
using BroadwayReview.Application.DTO.Searches;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.Application.UseCases.Queries;
using BroadwayReview.Implementations.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BroadwayReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaysController : ControllerBase
    {
        private readonly UseCaseHandler _handler;
        public PlaysController(UseCaseHandler handler)
        {
            _handler = handler;
        }


        // GET: api/<PlaysController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetPlaysQuery query, [FromQuery] BasePagedSearch dto)
        {
            return Ok(_handler.HandleQuery(query, dto));
        }

        // GET api/<PlaysController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IFindPlayQuery query, int id)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<PlaysController>
        [HttpPost]
        public IActionResult Post([FromBody] CreatePlayDTO dto, [FromServices] ICreatePlayCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<PlaysController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePlayDTO dto, [FromServices] IUpdatePlayCommand command)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<PlaysController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePlayCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
