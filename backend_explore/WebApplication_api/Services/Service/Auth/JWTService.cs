
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApplication_api.Data;
using WebApplication_api.Repository.Models.Auth;
using WebApplication_api.Repository.Models.Entities;

namespace WebApplication_api.Services.Service.Auth
{
    public class JWTService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public JWTService(AppDbContext dbContext, IConfiguration configuration)
        {

            _dbContext = dbContext;
            _configuration = configuration;
        }

        public bool Register(RegisterRequestModel registerRequest)
        {
            // checking if user already exists
            if (_dbContext.users.Any(u => u.Username == registerRequest.Username))
            {
                Console.WriteLine($"Registration failed: User {registerRequest.Username} already exists.");
                return false;
            }

            // Check if email already exists
            if (_dbContext.users.Any(u => u.Email == registerRequest.Email))
            {
                Console.WriteLine($"Registration failed: Email {registerRequest.Email} already exists.");
                return false;
            }

            // Create new user
            var newUser = new User
            {
                Id = _dbContext.users.Count + 1,
                Username = registerRequest.Username,
                Email = registerRequest.Email,
                Password = registerRequest.Password, // In production, hash the password!
                Name = registerRequest.Name,
                Role = registerRequest.Role ?? "Customer"
            };

            _dbContext.users.Add(newUser);
            Console.WriteLine($"User registered successfully: {newUser.Username} with role {newUser.Role}");
            return true;
        }

        public LoginResponseModel? Authenticate(LoginRequestModel loginRequest)
        {
            var user = _dbContext.users.FirstOrDefault(u => u.Username == loginRequest.Username);


            if (user == null || user.Password != loginRequest.Password)
            {
                return null; // Authentication failed
            }


            var issuer = _configuration.GetValue<string>("JwtConfig:Issuer");
            var audience = _configuration.GetValue<string>("JwtConfig:Audience");
            string? key = _configuration.GetValue<string>("JwtConfig:Key");

            var validityinMinutes = _configuration.GetValue<int?>("JwtConfig:ValidityInMinutes");


            var tokenExpiry = DateTime.UtcNow.AddMinutes(validityinMinutes ?? 60);
            //Console.WriteLine($"Generating JWT for user: {user.Username}, Issuer: {issuer}, Audience: {audience}, Expiry: {tokenExpiry}");
            //Console.WriteLine($"Generating JWT using KEY--: {key}");
            // this is token descriptor which contains all the information about the token like claims, expiry, signing credentials etc.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                    new Claim(ClaimTypes.Name, user.Username ?? ""),
                    new Claim(ClaimTypes.Role, user.Role ?? "Customer")
                ]),
                Expires = tokenExpiry,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            Console.WriteLine("Security Token: " + securityToken.GetType().Name);
            var accessToken = tokenHandler.WriteToken(securityToken);
            Console.WriteLine("Access Token: " + accessToken.GetType().Name);
            
            Console.WriteLine("User authenticated successfully: " + user.Username);
            return new LoginResponseModel
            {
                AccessToken = accessToken,
                ExpiresIn = (int)tokenExpiry.Subtract(DateTime.UtcNow).TotalSeconds,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };

        }
    }
}
