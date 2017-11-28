using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TruckAPI.JWT;

namespace TruckAPI.Controllers
{
    [Route("api/[controller]")]
    public class TokenController
    {
        private readonly IConfiguration _config;

        public TokenController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpPost("")]
        [AllowAnonymous]
        public JsonResult Login(AuthRequest authUserRequest)
        {
            if (authUserRequest.UserName == "username" && authUserRequest.Password == "password")
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VERY LONG KEY MOCKED HERE SHOULD BE in config"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, authUserRequest.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                issuer: "http://truckmonitor.azurewebsites.net",
                audience: "http://truckmonitor.azurewebsites.net",
               claims: claims,
               expires: DateTime.Now.AddMinutes(120),
               signingCredentials: creds);

                return new JsonResult(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return new JsonResult("Could not create token");
        }
    }
}
