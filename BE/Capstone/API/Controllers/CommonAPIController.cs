﻿using API.ResponseModel.Orgnization;
using ModelAuto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ResponseModel.Common;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonAPIController : ControllerBase
    {
        private ICommon p = new CommonImpl();


        [HttpPost("autoGenCode3character")]
        public IActionResult autoGenCode3character(AutogenCode3Response obj)
        {
            return Ok(p.autoGenCode3character(obj.table, obj.code));
        }

        [HttpPost("autoGenCode")]
        public IActionResult autoGenCode(AutogenCodeResponse obj)
        {
            return Ok(p.autoGenCode(obj.table, obj.rank, obj.collumName, obj.ParentId));
        }

        [HttpPost("GetOtherListType")]
        public IActionResult GetOtherListType()
        {
            List<OtherListType> list = new List<OtherListType>();
            list = p.GetOtherListType();
            if (list.Count > 0)
                return Ok(new
                {
                    Status = true,
                    Data = list
                });
            else
                return StatusCode(200, "List is Null");
        }

        #region getbyID
        [HttpPost("GetTitleByID")]
        public IActionResult GetTitleByID(int ID)
        {
            Title obj = p.getTitleByID(ID);
            if (obj != null)
                return Ok(new
                {
                    Status = true,
                    Data = obj
                });
            else
                return StatusCode(200, "Obj is Null");
        }
        #endregion


    }
}
