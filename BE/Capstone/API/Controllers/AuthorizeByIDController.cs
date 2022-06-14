using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AuthorizeByIDController : ControllerBase
    {
        protected Account  GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                Account a = new Account();
                a.EmployeeId = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);
                a.Rule = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
                return a;
            }
            return null;
        }
    }
}
