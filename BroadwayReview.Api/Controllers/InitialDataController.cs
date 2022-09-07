using BroadwayReview.Application.Exceptions;
using BroadwayReview.Application.Seeders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BroadwayReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitialDataController : ControllerBase
    {
        // GET: api/<InitialDataController>
        [HttpGet]
        public IActionResult Get([FromServices] ISeedFakeData request)
        {
            try
            {
                request.Seed();
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is UseCaseConflictException)
                {
                    return StatusCode(StatusCodes.Status409Conflict);
                    var obj = new { Error = ex.Message };

                }
                var msg = ex.InnerException;
                return StatusCode(500);

            }

        }
    }
}
