using Microsoft.AspNetCore.Mvc;
using WebApplication_api.Data;
using WebApplication_api.Repository.Models.Auth;
using WebApplication_api.Services.Service.Auth;

namespace WebApplication_api.Controllers.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly JWTService _jwtService;

        public AuthController(AppDbContext context, IConfiguration configuration, JWTService jWTService)
        {
            _context = context;
            _configuration = configuration;
            _jwtService = jWTService;
        }

        [HttpPost("register")]
        public ActionResult<string> Register([FromBody] RegisterRequestModel registerRequest)
        {

            Console.WriteLine($"Attempting registration for user: {registerRequest.Username}");

            var isRegistered = _jwtService.Register(registerRequest);

            if (!isRegistered)
            {
                return BadRequest(new { message = "Registration failed. Username or email already exists." });
            }

            return Ok(new { message = "User registered successfully. Please login." });
        }

        [HttpPost("login")]
        public ActionResult<LoginResponseModel> Login([FromBody] LoginRequestModel loginRequest)
        {
            Console.WriteLine($"Attempting login for user: {loginRequest.Username}");
            var response = _jwtService.Authenticate(loginRequest);

            if (response == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
            return Ok(response);
        }
    }
}
