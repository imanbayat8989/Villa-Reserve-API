using static Villa_Utility.SD;

namespace Villa_Web.Models
{
	public class APIRequest
	{
		public ApiType APIType { get; set; } = ApiType.GET;
		public string Url { get; set; }
		public object Data { get; set; }
	}
}
