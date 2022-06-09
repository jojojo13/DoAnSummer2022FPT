using ModelAuto.Models;
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
using System.Data;
using Newtonsoft.Json;
using API.ResponseModel.Common;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileAPIController : ControllerBase
    {
        private ICommon p = new CommonImpl();

        private IProfile profile = new ProfileImpl();
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

        [HttpPost("GetListPositionByOrgID")]
        public IActionResult GetListPositionByOrgID(int ID)
        {
            List<Position> list = profile.GetListPositionByOrgID(ID);

            var listReturn = from l in list
                             select new
                             {
                                 Name = l.Name,
                                 Code = l.Code,
                                 ID = l.Id
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = listReturn
                });
            else
                return StatusCode(200, "Obj is Null");
        }

        [HttpPost("GetListEmployeeByOrgID")]
        public IActionResult GetListEmployeeByOrgID(CommonResponseByID common)
        {
            List<Employee> list = profile.GetListEmployeeByOrgID(common.id, common.index, common.size);

            var listReturn = from l in list
                             select new
                             {
                                 FullName = l.FullName,
                                 Code = l.Code,
                                 ID = l.Id,
                                 OrgnizationName= l.Orgnization.Name,
                                 PositionName=l.Position.Name,
                                 OrgId= l.Orgnization.Id,
                                 PositionId=l.Position.Id,
                                 StatusName=l.StatusNavigation.Name,
                                 TitleName=l.Position.Title.Name
                             };
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = listReturn
                });
            else
                return StatusCode(200, "Obj is Null");
        }

        #endregion
    }
}