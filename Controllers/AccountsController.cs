using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DTOs;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManger;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<User> userManager , IMapper mapper)
        {
            _mapper = mapper;
            _userManger = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDTO userForRegistration)
        {
            
            if (userForRegistration is null)
                return BadRequest();
            
            
            var user = _mapper.Map<User>(userForRegistration);
            var result = await _userManger.CreateAsync(user, userForRegistration.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDTO { Errors = errors });
            }
            return StatusCode(201);
        }
    }
}
