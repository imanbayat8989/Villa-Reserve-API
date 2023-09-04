using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Villa_Utility;
using Villa_Web.Models;
using Villa_Web.Services.IServices;

namespace Villa_Web.Services
{
	public class BaseService : IBaseService
	{
		public APIResponse responseModel { get ; set ; }
		public IHttpClientFactory httpClientFactory { get; set ; }

        public BaseService(IHttpClientFactory httpClientFactory)
        {
			this.responseModel = new();
			this.httpClientFactory = httpClientFactory;
		}

		public async Task<T> SendAsync<T>(APIRequest apiRequest)
		{
			try
			{
				var client = httpClientFactory.CreateClient("VillaAPI");
				HttpRequestMessage message = new HttpRequestMessage();
				message.Headers.Add("Accept", "application/json");
				message.RequestUri = new Uri(apiRequest.Url);
				if (apiRequest.Data != null)
				{
					message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
						Encoding.UTF8, "application/json");
				}
				switch (apiRequest.APIType)
				{
					case SD.ApiType.POST:
						message.Method = HttpMethod.Post;
						break;
					case SD.ApiType.PUT:
						message.Method = HttpMethod.Put;
						break;
					case SD.ApiType.DELETE:
						message.Method = HttpMethod.Delete;
						break;
					default:
						message.Method = HttpMethod.Get;
						break;
				}

				HttpResponseMessage apiResponse = null;

				if (!string.IsNullOrEmpty(apiRequest.Token))
				{
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.Token);
				}

				apiResponse = await client.SendAsync(message);

				var apiContent = await apiResponse.Content.ReadAsStringAsync();
				try
				{
					APIResponse aPIResponse = JsonConvert.DeserializeObject<APIResponse>(apiContent);
					if (apiResponse.StatusCode==System.Net.HttpStatusCode.BadRequest || apiResponse.StatusCode ==
						System.Net.HttpStatusCode.NotFound)
					{
						aPIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
						aPIResponse.IsSuccess = false;
						var res = JsonConvert.SerializeObject(aPIResponse);
						var returnObj = JsonConvert.DeserializeObject<T>(res);
						return returnObj;
					}
				}
				catch (Exception ex)
				{
					var aPIResponse = JsonConvert.DeserializeObject<T>(apiContent);
					return aPIResponse;
				}
				var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
				return APIResponse;
				
				
			}
			catch (Exception ex)
			{
				var dto = new APIResponse
				{
					ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
					IsSuccess = false,
				};
				var res = JsonConvert.SerializeObject(dto);
				var APIResponse = JsonConvert.DeserializeObject<T>(res);
				return APIResponse;
			}
		}
	}
}
