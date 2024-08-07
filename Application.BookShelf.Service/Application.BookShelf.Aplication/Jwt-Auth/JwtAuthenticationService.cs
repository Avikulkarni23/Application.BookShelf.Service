using Application.BookShelf.Core;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.BookShelf.Aplication.Jwt_Auth
{
    public class JwtAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public JwtAuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        /// <summary>
        /// Private method to generate a JWT token using the user's data.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string IssueToken(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var claims = new List<Claim>
            {

                new Claim("Myapp_User_Id", user.Id.ToString()),

                new Claim(ClaimTypes.NameIdentifier, user.EmailAddress),

                new Claim(ClaimTypes.Email, user.EmailAddress),

                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            // Adds a role claim for each role associated with the user.
            claims.Add(new Claim(ClaimTypes.Role, user.Role));
           // user.Role.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));


            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
