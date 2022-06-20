using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class CoffeeShopController : ControllerBase
	{
        private readonly CoffeeShopService _coffeeShopService;

		public CoffeeShopController(CoffeeShopService coffeeShopService)
		{
			_coffeeShopService = coffeeShopService;
		}

		[HttpGet]
		public IActionResult List()
		{
			var coffeeShops = _coffeeShopService.List();
			return Ok(coffeeShops);
		}
	}
}
