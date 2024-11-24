using Graduation_Project.Application.CQRS.MedicalAdvisorFeature.GetAllMedicalAdvisor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAdvisorController : ControllerBase
    {
        private readonly IMediator mediator;

        public MedicalAdvisorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result =  await mediator.Send(new GetAllMeicalAdvisorQuery());
            return Ok(result);
        }
    }
}
