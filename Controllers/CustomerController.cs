using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ShopDbContext _context;

        public CustomerController(ShopDbContext context)
        {
            _context = context;
        }


    }
}
