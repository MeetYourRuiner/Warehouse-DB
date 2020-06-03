using DBServer.Data;
using DBServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace DBServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly WarehouseContext _context;
        private readonly ILogger _logger;

        public AuthController(WarehouseContext context, ILogger<AuthController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("/api/auth")]
        public IActionResult Token(User user)
        {
            user.Login = user.Login.Trim();
            user.Password = user.Password.Trim();
            _logger.LogInformation($"{user.Login} пытается войти");
            User _user = _context.Users
                .Include(u => u.Employee)
                    .ThenInclude(e => e.Position)
                .FirstOrDefault(x => x.Login == user.Login && x.Password == user.Password);
            if (_user == null)
            {
                return BadRequest("Неверный логин или пароль");
            }

            _user.Password = null;

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, _user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, _user.Employee?.Position?.Name ?? "")
                };
            var identity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                _user
            };

            return new OkObjectResult(response);
        }
    }
}