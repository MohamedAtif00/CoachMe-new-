using Graduation_Project.Application.CQRS.PlanFeature.AddPlan;
using Graduation_Project.Application.CQRS.PlanFeature.GetAllPlan;
using Graduation_Project.Application.CQRS.PlanFeature.GetPlanByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PlanController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<PlanController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // GET api/<PlanController>/5
        [HttpGet("GetAllPlanForTrainer/{id}")]
        public async Task<IActionResult> GetAllPlanForTrainer(Guid id)
        {
            var result = await _mediator.Send(new GetAllPlanQuery(id));

            return Ok(result);
        }

        // GET api/<PlanController>/5
        //[HttpGet("GetAllPlanByTrainer/{id}")]
        //public async Task<IActionResult> GetAllPlanByTrainer(Guid id)
        //{
        //    var result = await _mediator.Send(new GetPlanByUserIdQuery(id));

        //    return Ok(result);
        //}


        // POST api/<PlanController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPlanCommand request)
        {
            var result = await _mediator.Send(request);
            
            return Ok(result);
        }




        // PUT api/<PlanController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<PlanController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
