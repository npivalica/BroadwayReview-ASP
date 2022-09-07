using BroadwayReview.Application.DTO;
using BroadwayReview.Application.DTO.Searches;
using BroadwayReview.Application.UseCases.Commands;
using BroadwayReview.Application.UseCases.Queries;
using BroadwayReview.Implementations.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BroadwayReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private UseCaseHandler _handler;

        public GenresController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        // GET: api/<GenresController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetGenresQuery command, [FromQuery] BasePagedSearch dto)
        {
            return Ok(_handler.HandleQuery(command, dto));
        }

        // GET api/<GenresController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromServices] IFindGenreQuery query, int id)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        // POST api/<GenresController>
        [HttpPost]
        public IActionResult Post([FromServices] ICreateGenreCommand command, [FromForm] CreateGenreDTO dto)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<GenresController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromServices] IUpdateGenreCommand command, [FromForm] CreateGenreDTO dto)
        {
            dto.Id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<GenresController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGenreCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
