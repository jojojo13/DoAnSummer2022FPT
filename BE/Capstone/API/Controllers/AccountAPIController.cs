﻿using API.ResponseModel;
using CapstoneModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAPIController : ControllerBase
    {
        private IConfiguration _config;
        public AccountAPIController(IConfiguration config)
        {
            _config = config;
        }
        private IProfile p = new Profile();
        [AllowAnonymous]
        [HttpPost("GetAccount")]
        public IActionResult Get([FromBody] AccountResponse accountResponse)
        {
            Account a = new Account();
            a.UserName = accountResponse.username;
            a.Pass = accountResponse.password;
            Account account = p.GetAccount(a);
            if (account != null)
            {
                var token = Generate(account);
                string text = JsonSerializer.Serialize(token);
                return Ok(new
                {
                    Status = true,
                    Data = token
                });
            }

            return StatusCode(401, "My error message");
        }
        private string Generate(Account a)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, a.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, a.UserName),
                 new Claim(ClaimTypes.Role, a.Rule.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddHours(2),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}