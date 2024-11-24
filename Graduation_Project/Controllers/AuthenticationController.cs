using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Graduation_Project.Application.Abstraction;
using Graduation_Project.Application.DTOs.Authentication;
using MediatR;
using Graduation_Project.Application.CQRS.UserFeature.AddUser;
using Graduation_Project.Domain.Entity.UserDomain;
using Graduation_Project.Application.CQRS.UserFeature.GetSingleUser;
using Graduation_Project.Application.CQRS.UserFeature.ValidateUser;
using Graduation_Project.Application.CQRS.UserFeature.AddTrainer;
using System.Linq.Expressions;
using Graduation_Project.Application.CQRS.UserFeature.GetAllUsers;
using Graduation_Project.Application.CQRS.TrainerFeature.AddTrainer;
using Asp.Versioning;
using Graduation_Project.Application.CQRS.MedicalAdvisorFeature.AddMedicalAdvisor;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Graduation_Project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public AuthenticationController(IAuthenticationService authenticationService, IMediator mediator, UserManager<IdentityUser<Guid>> userManager)
        {
            _authenticationService = authenticationService;
            _mediator = mediator;
            _userManager = userManager;
        }

        // GET: api/<AuthenticationController>
        [HttpGet]
        public async Task<IActionResult> Getv1()
        {
            var result = await _mediator.Send(new GetAllUserQuery());

            return Ok(result);
        }



        // GET api/<AuthenticationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result  = await _mediator.Send(new GetSingleUserQuery(id));

            return Ok(result);
        }

        


        // POST api/<AuthenticationController>
        [HttpPost("TraineeRegister")]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {
            var result = await _authenticationService.Register($"{request.firstName+request.lastName}", request.email, request.password, "Trainee");

            if (result.Value != null && result.Errors.Count() == 0) await _mediator.Send(new AddUserCommand(result.Value.UserId,
                                                                                                            request.firstName,
                                                                                                            request.lastName,
                                                                                                            request.image,
                                                                                                            request.gender));

            return Ok(result);
        }

        // POST api/<AuthenticationController>
        [HttpPost("TrainerRegister")]
        public async Task<IActionResult> TrainerRegister([FromForm] TrainerRegisterRequest request)
        {
            var result = await _authenticationService.Register($"{request.firstName + request.lastName}", request.email, request.password, "Trainer");

            if (result.Value != null && result.Errors.Count() == 0) await _mediator.Send(new AddUserCommand(result.Value.UserId,
                                                                                                            request.firstName,
                                                                                                            request.lastName,
                                                                                                            request.image,
                                                                                                            request.gender));
            if (result.Value != null && result.Errors.Count() == 0) await _mediator.Send(new AddTrainerCommand(result.Value.UserId,$"{request.firstName+" "+request.lastName }",request.email,request.image,request.about));

                return Ok(result);
        }

        // POST api/<AuthenticationController>
        [HttpPost("MedicalAdvisorRegister")]
        public async Task<IActionResult> MedicalAdvisorRegister([FromForm] TrainerRegisterRequest request)
        {   
            var result = await _authenticationService.Register($"{request.firstName + request.lastName}", request.email, request.password, "MedicalAdvisor");

            if (result.Value != null && result.Errors.Count() == 0) await _mediator.Send(new AddUserCommand(result.Value.UserId,
                                                                                                            request.firstName,
                                                                                                            request.lastName,
                                                                                                            request.image,
                                                                                                            request.gender));
            if (result.Value != null && result.Errors.Count() == 0) await _mediator.Send(new AddMedicalAdvisorCommand(result.Value.UserId, $"{request.firstName + " " + request.lastName}",request.about,request.image, request.email));

            return Ok(result);
        }


        //[HttpPost("AddTrainerToUser")]
        //public async Task<IActionResult> AddTrainer(AddTrainerAndCourtCommand request)
        //{
        //    var result = await _mediator.Send(request);

        //    return Ok(result);
        //}


        //[HttpPost("CheckDate")]
        //public async Task<IActionResult> CheckDate(CheckDateDTO request)
        //{
        //    var result = await _mediator.Send(new ValidateUserQuery(request.startDay, new TimeSession(request.timeSession.Hours, request.timeSession.Minutes, request.timeSession.AmPm)));

        //    return Ok(result);
        //}


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authenticationService.Login(request.email, request.password);

            return Ok(result);
        }

        //[HttpPost("TrainerLogin")]
        //public async Task<IActionResult> TrainerLogin([FromBody] LoginRequest request)
        //{
        //    var result = await _authenticationService.Login(request.email, request.password, "Trainer");

        //    return Ok(result);
        //}

        [HttpPost("LoginAdmin")]
        public async Task<IActionResult> LoginAdmin([FromBody] LoginRequest request)
        {
            var result = await _authenticationService.Login(request.email, request.password);

            return Ok(result);
        }


        [HttpGet("AllowAccess/{token}")]
        public async Task<IActionResult> AllowAccess(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            var claims = jsonToken.Claims;

            var claimIdenity = new ClaimsIdentity(jsonToken.Claims);
            var principle = new ClaimsPrincipal(claimIdenity);
            string userid = claims.FirstOrDefault(x => x.Type == "userid").Value;
            string username = claims.FirstOrDefault(x => x.Type == "username").Value;
            string email = claims.FirstOrDefault(x => x.Type == "email").Value;
            string role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;

            var user = _userManager.FindByNameAsync(username);
            if (user == null) return NotFound("this user is not exist");


            var response = new AllowAccessResponse(userid, username, role, email, token);

            return Ok(response);
        }



    }
}
