using Code9.API.Models;
using Code9.Domain.Commands;
using Code9.Domain.Models;
using Code9.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Code9.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all-cinemas")]
        public async Task<ActionResult<List<Cinema>>> GetAllCinema()
        {
            var query = new GetAllCinemaQuery();
            var cinemas = await _mediator.Send(query);

            return Ok(cinemas);
        }

        [HttpPost("insert-cinema")]
        public async Task<ActionResult<Cinema>> AddCinema(AddCinemaRequest addCinemaRequest)
        {
            var addCinemaCommand = new AddCinemaCommand
            {
                Name = addCinemaRequest.Name,
                City = "Novi Sad",
                Street = addCinemaRequest.Street,
                NumberOfAuditoriums = addCinemaRequest.NumberOfAuditoriums
            };

            var cinema = await _mediator.Send(addCinemaCommand);
            return Ok(cinema);
        }

        [HttpPut("update-cinema/{id}")]
        public async Task<ActionResult<Cinema>> UpdateCinema([FromRoute] Guid id, UpdateCinemaRequest request)
        {

            var updateCinemaCommand = new UpdateCinemaCommand
            {

                Id = id,
                cinema = new Cinema
                {
                    Name = request.Name,
                    City = request.City,
                    Street = request.Street,
                    NumberOfAuditoriums = request.NumberOfAuditoriums
                }
            };
            
            return await _mediator.Send(updateCinemaCommand);
        }
        
    }
}
