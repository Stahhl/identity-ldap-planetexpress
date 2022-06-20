using API.Models;

namespace API.Services
{
	public class CoffeeShopService
	{
        public List<CoffeeShopModel> List()
        {
            return new List<CoffeeShopModel>
            {
                new()
                {
                    Id = 1,
                    Name = "Name",
                    OpeningHours = "1-2",
                    Address = "Address"
                }
            };
        }
    }
}
