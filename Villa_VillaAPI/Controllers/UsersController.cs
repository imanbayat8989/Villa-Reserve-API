using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Models.DTO;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Controllers
{
	[Route("api/UsersAuth")]
	[ApiController]
	public class UsersController : Controller
	{
		private readonly IUserRepo _userRepo;
		protected APIResponse _response;
		public UsersController(IUserRepo userRepo) 
		{
			_userRepo = userRepo;
			this._response = new();
		}
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
		{
			var loginResponse = await _userRepo.Login(model);
			if(loginResponse.User==null || string.IsNullOrEmpty(loginResponse.Token))
			{
				_response.StatusCode = HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.ErrorMessages.Add("UserName or Password is incorrect");
				return BadRequest(_response);
			}
			_response.StatusCode=HttpStatusCode.OK;
			_response.IsSuccess=true;
			_response.Result = loginResponse;
			return Ok(_response);
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
		{
			bool ifUserNameUnique = _userRepo.IsUniqueUser(model.UserName);
            if (!ifUserNameUnique)
			{
				_response.StatusCode = HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.ErrorMessages.Add("UserName already exists");
				return BadRequest(_response);
			}

			var user = await _userRepo.Register(model);
			if(user == null) 
			{
				_response.StatusCode = HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.ErrorMessages.Add("Error While Registering");
				return BadRequest(_response);
			}
			_response.StatusCode = HttpStatusCode.OK;
			_response.IsSuccess=true;
			return Ok(_response);
        }
	}
}
