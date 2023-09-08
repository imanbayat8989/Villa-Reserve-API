using Villa_VillaAPI.Models;
using Villa_VillaAPI.Models.DTO;

namespace Villa_VillaAPI.Repository.IRepository
{
	public interface IUserRepo
	{
		bool IsUniqueUser(string username);
		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
		Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO);
	}
}
