using CapstoneModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonAPIController : ControllerBase
    {
        private ICommon p = new Common();
        [AllowAnonymous]
        [HttpGet("GetOtherListType")]
        public IActionResult GetOtherListType()
        {
            List<Other_List_Type> list = new List<Other_List_Type>();
            list = p.GetOtherListType();
            if (list.Count > 0)
            {
                return Ok(new
                {
                    Status = true,
                    Data = list
                });
            }
            return StatusCode(200, "List is Null");
        }

    }
}
