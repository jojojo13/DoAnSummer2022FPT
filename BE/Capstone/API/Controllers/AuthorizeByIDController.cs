using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AuthorizeByIDController : ControllerBase
    {
        protected int GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int id = 0;
            if (identity != null)
            {
                var userClaims = identity.Claims;

                id = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);

            }
            return id;
        }
    }
}
