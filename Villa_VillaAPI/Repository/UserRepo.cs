using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Villa_VillaAPI.Data;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Models.DTO;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Repository
{
	public class UserRepo : IUserRepo
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private string secretKey;
		private readonly IMapper _mapper;
		public UserRepo(ApplicationDbContext db, IConfiguration configuration,
			UserManager<ApplicationUser> userManager, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
			_userManager = userManager;
			secretKey = configuration.GetValue<string>("ApiSettings:Secret");
		}

		public bool IsUniqueUser(string username)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(x => x.UserName == username);
			if (user == null)
			{
				return true;
			}
			return false;
		}

		public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
		{
			var user = _db.ApplicationUsers
				.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());

			bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

			if (user == null || isValid == false) 
			{
				return new LoginResponseDTO()
				{
					Token = "",
					User = null

				};
			}
            var roles = await _userManager.GetRolesAsync(user);
            var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id.ToString()),
					new Claim(ClaimTypes.Role, roles.FirstOrDefault())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
			{
				Token = tokenHandler.WriteToken(token),
				User = _mapper.Map<UserDTO>(user),
				Role = roles.FirstOrDefault()
			};
			return loginResponseDTO;
		}

		public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
		{
			ApplicationUser user = new()
			{
				UserName = registrationRequestDTO.UserName,
				Email=registrationRequestDTO.UserName,
				NormalizedEmail=registrationRequestDTO.UserName.ToUpper(),
				Name = registrationRequestDTO.Name,
			};

			try
			{
				var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, "admin");
					var userToReturn = _db.ApplicationUsers
						.FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName);
					return _mapper.Map<UserDTO>(userToReturn);
				}
			}
			catch (Exception ex) 
			{

			}

			return new UserDTO();
		}
	}
}
