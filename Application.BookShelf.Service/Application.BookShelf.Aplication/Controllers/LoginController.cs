using Application.BookShelf.Aplication.Jwt_Auth;
using Application.BookShelf.Core;
using Application.BookShelf.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.BookShelf.Aplication.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtAuthenticationService _jwtAuthenticationService;

        public LoginController(IUserService userService, JwtAuthenticationService jwtAuthenticationService)
        {
            _userService = userService;
            _jwtAuthenticationService = jwtAuthenticationService;
           

        }

        [Route("api/Login")]
        [HttpPost]
        public async Task <IActionResult> UserLogin([FromBody] LoginModel request)
        {            
            if (ModelState.IsValid)
            {                
                var user = await _userService.getUserByEmailAndPassword(request.Username, request.Password);

                if (user == null)
                {                   
                    return Unauthorized("Invalid user credentials.");
                }
                else
                {
                    var token = _jwtAuthenticationService.IssueToken(user);

                    return Ok(new { Token = token });
                }
            }

            // If the model state is not valid, returns a 400 Bad Request response with a custom message.
            return BadRequest("Invalid Request Body");
        }

       


    }
}
