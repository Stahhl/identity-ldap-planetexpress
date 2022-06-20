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
        private readonly CoffeeShopService coffeeShopService;

		public CoffeeShopController(CoffeeShopService coffeeShopService)
		{
			this.coffeeShopService = coffeeShopService;
		}

		[HttpGet]
		public IActionResult List()
		{
			var coffeeShops = coffeeShopService.List();
			return Ok(coffeeShops);
		}
	}
}
