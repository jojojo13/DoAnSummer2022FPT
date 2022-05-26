using API.ResponseModel;
using CapstoneModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAPIController : ControllerBase
    {
        private IProfile p = new Profile();
        [HttpPost("GetAccount")]
        public IActionResult Get([FromBody] AccountResponse accountResponse)
        {
            Account a = new Account();
            a.UserName = accountResponse.username;
            a.Pass = accountResponse.password;
            Account account = p.GetAccount(a);
            if(account != null){

            }

            return Ok(account);
        }
    }
}
