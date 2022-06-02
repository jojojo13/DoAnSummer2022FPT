using API.ResponseModel.Common;
using API.ResponseModel.Request;
using CapstoneModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.RequestServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestAPIController : ControllerBase
    {
        private IRequest p = new Request();


        #region RC_REQUEST
        [AllowAnonymous]
        [HttpPost("GetAllRequest")]
        public IActionResult GetAllRequest(CommonResponse common)
        {
            List<Rc_Request> list = p.GetAllRequest(common.index, common.size);
            List<RequestResponse> list2 = new List<RequestResponse>();

            foreach (var item in list)
            {
                RequestResponse obj = new RequestResponse();
                obj.Code = item.Code;
                obj.Name = item.Name;
                obj.Type = item.Type;
                obj.TypeName = item.Other_List2.Name;
                obj.OrgId = item.OrgId;
                obj.OrgName = item.oRgnization.Name;
                obj.PositionID = item.PositionID;
                obj.Exp = item.Exp;
                obj.Note = item.Note;
                obj.Comment = item.Comment;
                obj.PositionName = item.position.Name;
                obj.Number = item.Number;
                obj.EffectDate = item.EffectDate;
                obj.ExpireDate = item.ExpireDate;
                obj.StatusName = item.Status == -1 ? "Phê duyệt" : item.Status == 0 ? "Không phê duyệt" : "Chờ phê duyệt";
                obj.Id = item.Id;
                obj.Project= item.Project;
                obj.ProjectName = item.Other_List3.Name;
                obj.SignId = item.SignId;
                obj.SignName = item.employee.FullName;
                list2.Add(obj);
            }
           
            if (list.Count > 0)
            {
                return Ok(new
                {
                    Status = true,
                    Data = list2
                });
            }
            return StatusCode(200, "List is Null");
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
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
                rc.OrgId = T.OrgId;
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

        [AllowAnonymous]
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
                rc.OrgId = T.OrgId;
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
