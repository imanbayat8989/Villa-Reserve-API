using Microsoft.AspNetCore.Mvc;

namespace Villa_Web.Controllers
{
	public class VillaNumberController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
