using Graduation_Project.Application.CQRS.ReservationFeature.AddMedicalAdvisorReservation;
using Graduation_Project.Application.CQRS.ReservationFeature.AddReservation;
using Graduation_Project.Application.CQRS.ReservationFeature.GetAllReservation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllReservationIQuery());

            return Ok(result);
        }

        // GET api/<ReservationController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ReservationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddReservationCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost("MedicalReservation")]
        public async Task<IActionResult> Post([FromBody] AddMedicalAdvisorReservationCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }


        // PUT api/<ReservationController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ReservationController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
