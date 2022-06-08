using API.Atributes;
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
                            CODE = l.Code,
                            NAME= l.Name
                        };
            List<RequestResponse> list2 = new List<RequestResponse>();
            if (list.Count > 0)
            {
                return Ok(new
                {
                    TotalPage = c.getTotalRecord("Rc_Request"),
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
                rc.EffectDate = T.EffectDate;
                rc.ExpireDate = T.ExpireDate;
                rc.Number = T.Number;
                rc.OrgnizationId = T.OrgnizationId;
                rc.SignId = T.SignId;
                rc.Note = T.Note;
                rc.Number = T.Number;
                rc.YearExperience = T.YearExperience;
                rc.Project = T.Project;
                rc.PositionID = T.PositionID;
                rc.Type = T.Type;
                rc.Comment = T.Comment;
                rc.ParentID = T.ParentID;
                rc.Level = T.Level;
                rc.Budget = T.Budget;
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
                rc.ExpireDate = T.ExpireDate;
                rc.Number = T.Number;
                rc.OrgnizationId = T.OrgnizationId;
                rc.SignId = T.SignId;
                rc.Note = T.Note;
                rc.Number = T.Number;
                rc.YearExperience = T.YearExperience;
                rc.Project = T.Project;
                rc.PositionID = T.PositionID;
                rc.Type = T.Type;
                rc.Comment = T.Comment;
                rc.ParentID = T.ParentID;
                rc.Level = T.Level;
                rc.Budget = T.Budget;
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
