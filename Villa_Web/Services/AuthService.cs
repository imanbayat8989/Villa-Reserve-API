using System.Net.Http;
using Villa_Utility;
using Villa_Web.Models;
using Villa_Web.Models.DTO;
using Villa_Web.Services.IServices;

namespace Villa_Web.Services
{
	public class AuthService : BaseService, IAuthService
    {
       private readonly IHttpClientFactory _httpClientFactory;
		private string villaUrl;

	public AuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
	{
		_httpClientFactory = httpClientFactory;
		villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
	}

		public Task<T> LoginAsync<T>(LoginRequestDTO obj)
		{
			return SendAsync<T>(new APIRequest()
			{
				APIType = SD.ApiType.POST,
				Data = obj,
				Url = villaUrl + "/api/UsersAuth/login"
			});
		}

		public Task<T> RegisterAsync<T>(RegistrationRequestDTO obj)
		{
			return SendAsync<T>(new APIRequest()
			{
				APIType = SD.ApiType.POST,
				Data = obj,
				Url = villaUrl + "/api/UsersAuth/register"
			});
		}
	}
}
