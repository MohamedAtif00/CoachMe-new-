using Graduation_Project.Application.CQRS.DoctorFeature.AddRating;
using Graduation_Project.Application.CQRS.DoctorFeature.AddDoctor;
using Graduation_Project.Application.CQRS.DoctorFeature.DeleteDoctor;
using Graduation_Project.Application.CQRS.DoctorFeature.GetAllRating;
using Graduation_Project.Application.CQRS.DoctorFeature.GetAllDoctors;
using Graduation_Project.Application.CQRS.DoctorFeature.GetSingleDoctor;
using Graduation_Project.Application.CQRS.DoctorFeature.UpdateDoctor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllDoctorsQuery());

            return Ok(result);
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetSingleDoctorQuery(id));
            return Ok(result);
        }

        // GET api/<DoctorController>/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    var result = await _mediator.Send(new GetSingleDoctorQuery(id));
        //    return Ok(result);
        //}


        // GET api/<DoctorController>/5
        [HttpGet("GetRatingsForDoctor/{id}")]
        public async Task<IActionResult> GetRates(Guid id)
        {
            var result = await _mediator.Send(new GetAllRatingQuery(id));
            return Ok(result);
        }


        // POST api/<DoctorController>
        [HttpPost("AddDoctor")]
        public async Task<IActionResult> Post([FromForm] AddDoctorCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        // POST api/<DoctorController>
        [HttpPost("UpdateDoctor")]
        public async Task<IActionResult> Post([FromForm] UpdateDoctorCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        // POST api/<DoctorController>
        [HttpPost("RateDoctor")]
        public async Task<IActionResult> Post([FromBody] AddRatingCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        // PUT api/<DoctorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( Guid id)
        {
            var result = await _mediator.Send(new DeleteDoctorCommand(id));

            return Ok(result);
        }
    }
}
