

using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using web_api.Data;
using web_api.Data_Transfer_Objects_DTO;
using web_api.models;



namespace web_api.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    class AuthController : ControllerBase{


         private readonly IAuthRepositiry _authRepositiry;
        public AuthController(IAuthRepositiry authRepositiry)
        {
            _authRepositiry = authRepositiry;
        }
        public static User user = new User();
       

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserDto request){

           String passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

           user.Username = request.Username;
           user.PasswordHash = passwordHash;

           return Ok(user);

        }
    }
}