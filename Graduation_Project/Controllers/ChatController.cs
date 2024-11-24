using Graduation_Project.Application.CQRS.ChatFeature.AddChat;
using Graduation_Project.Application.CQRS.ChatFeature.GetAllMessaagesForTrainee;
using Graduation_Project.Application.CQRS.ChatFeature.GetAllMessagesForTrainer;
using Graduation_Project.Application.CQRS.ChatFeature.GetAllMessagesWithTrainee;
using Graduation_Project.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Graduation_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IMediator mediator, IHubContext<ChatHub> hubContext)
        {
            this.mediator = mediator;
            this._hubContext = hubContext;
        }


        [HttpPost("RealTimeChat")]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest request)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", request.User, request.Message);
            return Ok(new { Message = "Message sent" });
        }

        // GET: api/<ChatController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ChatController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpGet("GetAllMessagesForTrainer/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var users = await mediator.Send(new GetAllMessagesForTrainerQuery(id));

            return Ok(users);
        }

        [HttpGet("GetAllMessagesForTrainee/{id}")]
        public async Task<IActionResult> GetChat(Guid id)
        {
            var users = await mediator.Send(new GetAllMessagesForTraineeQuery(id));

            return Ok(users);
        }

        [HttpPost("GetAllMessagesBetweenTrainerAndTrainee")]
        public async Task<IActionResult> Get(GetAllMessagesWithTraineeQuery request)
        { 
            var result = await mediator.Send(request);

            return Ok(result);
        }


        // POST api/<ChatController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddChatCommand request)
        {
            var result = await mediator.Send(request);

            return Ok(result);
        }

        // PUT api/<ChatController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ChatController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

    public class MessageRequest
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}
