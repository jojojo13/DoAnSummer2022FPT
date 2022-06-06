﻿using API.Atributes;
using API.ResponseModel.Common;
using API.ResponseModel.Request;
using CapstoneModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CommonServices;
using Services.RequestServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[CustomAuthorization]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestAPIController : ControllerBase
    {
        private IRequest p = new Request();
        private ICommon c = new Common();

        #region RC_REQUEST
        [HttpPost("GetAllRequest")]
        public IActionResult  GetAllRequest(CommonResponse common)
        {
            List<Rc_Request> list = p.GetAllRequest(common.index, common.size);
            var list3 = from l in list
                        select new
                        {
                            ID = l.Id,
                            CODE = l.Code
                        };

            List<RequestResponse> list2 = new List<RequestResponse>();

            foreach (var item in list)
            {
                RequestResponse obj = new RequestResponse();
                obj.Code = item.Code;
                obj.Name = item.Name;
                obj.Type = item.Type;
                obj.TypeName = item.TypeObj?.Name;
                obj.OrgId = item.OrgnizationId;
                obj.OrgName = item.oRgnization?.Name;
                obj.PositionID = item.PositionID;
                obj.Exp = item.Exp;
                obj.Note = item.Note;
                obj.Comment = item.Comment;
                obj.PositionName = item.position?.Name;
                obj.Number = item.Number;
                obj.EffectDate = item.EffectDate;
                obj.ExpireDate = item.ExpireDate;
                obj.StatusName = item.Status == -1 ? "Phê duyệt" : item.Status == 0 ? "Không phê duyệt" : "Chờ phê duyệt";
                obj.Id = item.Id;
                obj.Project= item.Project;
                obj.ProjectName = item.ProjectObj?.Name;
                obj.SignId = item.SignId;
                obj.SignName = item.Signer?.FullName;
                list2.Add(obj);
            }
            if (list.Count > 0)
            {
                return Ok(new
                {
                    TotalPage = c.getTotalPage("Rc_Request",common.size),
                    Data = list2
                });
            }
            return StatusCode(200, "List is Null");
        }


        [HttpPut("ActiveRequest")]
        public IActionResult ActiveOT([FromBody] string ListID)
        {
            try
            {
                string[] listID = ListID.Split(" ");
                List<int> lst = new List<int>();
                foreach (var item in listID)
                {
                    if (!item.Trim().Equals(""))
                    {
                        lst.Add(Convert.ToInt32(item));
                    }
                }
                var check = p.ActiveOrDeActiveRequest(lst, -1);
                if (check)
                {
                    return Ok(new
                    {
                        Status = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = false
                    });
                }
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }


        [HttpPut("DeActiveRequest")]
        public IActionResult DeActiveOT([FromBody] string ListID)
        {
            try
            {
                string[] listID = ListID.Split(" ");
                List<int> lst = new List<int>();
                foreach (var item in listID)
                {
                    if (!item.Trim().Equals(""))
                    {
                        lst.Add(Convert.ToInt32(item));
                    }
                }
                var check = p.ActiveOrDeActiveRequest(lst, 0);
                if (check)
                {
                    return Ok(new
                    {
                        Status = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = false
                    });
                }
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }


        [HttpPost("DeleteRequest")]
        public IActionResult DeleteOT([FromBody] string ListID)
        {
            try
            {
                string[] listID = ListID.Split(" ");
                List<int> lst = new List<int>();
                foreach (var item in listID)
                {
                    if (!item.Trim().Equals(""))
                    {
                        lst.Add(Convert.ToInt32(item));
                    }
                }
                var check = p.DeleteRequest(lst);
                if (check)
                {
                    return Ok(new
                    {
                        Status = true
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = false
                    });
                }
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }


        [HttpPost("InsertRequest")]
        public IActionResult InsertRequest([FromBody] RequestResponse T)
        {
            try
            {
                Rc_Request rc = new Rc_Request();
                rc.Name = T.Name;
                rc.Code = T.Code;
                rc.EffectDate = T.EffectDate;
                rc.Exp = T.Exp;
                rc.ExpireDate = T.ExpireDate;
                rc.Number = T.Number;
                rc.OrgnizationId = T.OrgId;
                rc.SignId = T.SignId;
                rc.SignDate = T.SignDate;
                rc.Note = T.Note;
                rc.Status = T.Status;
                rc.Number = T.Number;
                rc.Exp = T.Exp;
                rc.Project = T.Project;
                rc.PositionID = T.PositionID;
                rc.Type = T.Type;
                rc.Comment = T.Comment;
                var check = p.InsertRequest(rc);
                return Ok(new
                {
                    Status = check
                }); ;

            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }


        [HttpPut("ModifyOT")]
        public IActionResult ModifyOT([FromBody] RequestResponse T)
        {
            try
            {
                Rc_Request rc = new Rc_Request();
                rc.Name = T.Name;
                rc.EffectDate = T.EffectDate;
                rc.Exp = T.Exp;
                rc.ExpireDate = T.ExpireDate;
                rc.Number = T.Number;
                rc.OrgnizationId = T.OrgId;
                rc.SignId = T.SignId;
                rc.SignDate = T.SignDate;
                rc.Note = T.Note;
                rc.Status = T.Status;
                rc.Number = T.Number;
                rc.Exp = T.Exp;
                rc.Project = T.Project;
                rc.PositionID = T.PositionID;
                rc.Type = T.Type;
                rc.Comment = T.Comment;
                var check = p.InsertRequest(rc);
                return Ok(new
                {
                    Status = check
                }); ;
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }
        #endregion
    }
}
