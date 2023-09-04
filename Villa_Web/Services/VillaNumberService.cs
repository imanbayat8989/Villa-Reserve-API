using Newtonsoft.Json.Linq;
using Villa_Utility;
using Villa_Web.Models;
using Villa_Web.Models.DTO;
using Villa_Web.Services.IServices;

namespace Villa_Web.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string villaUrl;

        public VillaNumberService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                APIType = SD.ApiType.POST,
                Data = dto,
                Url = villaUrl + "/api/villaNumberAPI/",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                APIType = SD.ApiType.DELETE,
                Url = villaUrl + "/api/villaNumberAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>( string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                APIType = SD.ApiType.GET,
                Url = villaUrl + "/api/villaNumberAPI/",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                APIType = SD.ApiType.GET,
                Url = villaUrl + "/api/villaNumberAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                APIType = SD.ApiType.PUT,
                Data = dto,
                Url = villaUrl + "/api/villaNumberAPI/" + dto.VillaNo,
                Token = token
            });
        }
    }
}
