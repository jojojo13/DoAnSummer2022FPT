using CapstoneModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CommonServices;
using Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileAPIController : ControllerBase
    {
        private ICommon p = new Common();
        #region list

        [HttpPost("autoGenCode3character")]
        public IActionResult autoGenCode3character()
        {
            return Ok(p.autoGenCode3character("Other_List","OT"));
        }
        #region DM loai HOP DONG

        #endregion

        #endregion
        #region Business
        #endregion
    }
}
