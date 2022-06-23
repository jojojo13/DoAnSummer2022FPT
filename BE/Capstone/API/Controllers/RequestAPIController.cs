using ModelAuto.Models;
using API.ResponseModel.Common;
using API.ResponseModel.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CommonServices;
using Services.RequestServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ResponseModel;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RequestAPIController : AuthorizeByIDController
    {
        private IRequest p = new Request();
        private ICommon c = new CommonImpl();

        #region RC_REQUEST
        [Authorize(Roles = "1,2,3")]
        [HttpPost("GetAllRequest")]
        public IActionResult GetAllRequest(int index, int size)
        {
            Account a = GetCurrentUser();
            List<RcRequest> list = p.GetAllRequest(index, size);
            var listReturn = from x in list
                             select new
                             {
                                 id = x.Id,
                                 code = x.Code,
                                 name = x.Name,
                                 requestLevel = x.RequestLevelNavigation?.Name,
                                 department = x.Orgnization?.Name,
                                 position = x.Position?.Name,
                                 positionID = x.PositionId,
                                 quantity = x.Number,
                                 createdOn = x.EffectDate?.ToString("dd/MM/yyyy"),
                                 Deadline = x.ExpireDate?.ToString("dd/MM/yyyy"),
                                 Office = x.Orgnization?.Address,
                                 StatusID = x.Status,
                                 Status = x.Status == 1 ? "Draft" : x.Status == 2 ? "Submited" : x.Status == 3 ? "Cancel" : x.Status == 4 ? "Approved" : x.Status == 5 ? "Rejected" : "",
                                 parentId = x.ParentId,
                                 rank = x.Rank,
                                 note = x.Note,
                                 comment = x.Comment,
                                 HrInchangeId = x.HrInchange,
                                 HrInchange = x.HrInchangeNavigation?.FullName == null ? "" : x.HrInchangeNavigation?.FullName,
                                 signID = x.SignId,
                                 typeID = x.RequestLevel,
                                 typename = x.RequestLevelNavigation?.Name,
                                 OrgnizationName = x.Orgnization?.Name,
                                 OrgnizationID = x.OrgnizationId,
                                 projectname = x.ProjectNavigation?.Name,
                                 projectID = x.Project,
                                 experience = x.YearExperience,
                                 level = x.Level,
                                 levelName = x.LevelNavigation?.Name,
                                 history = "Create by :" + x.CreateBy + " - " + x.CreateDate?.ToString("dd/MM/yyyy") + " Modify by " + x.UpdateBy + " - " + x.UpdateDate?.ToString("dd/MM/yyyy")
                             };
            if (list.Count > 0)
            {
                //phòng điều hành quản lý sẽ dk view all
                if (a.Rule == 1)
                {
                    return Ok(new
                    {
                        TotalItem = c.getTotalRecord("Rc_Request", true),
                        Data = listReturn.Where(x => x.StatusID == 2).ToList()
                    });
                }
                //view những bản ghi dược phân quyền cho HR
                else if (a.Rule == 3)
                {
                    return Ok(new
                    {
                        TotalItem = p.getTotalRequestRecord("hrInchange", a.EmployeeId),
                        Data = listReturn.Where(x => x.HrInchangeId == a.EmployeeId)
                    });
                }
                //view những bản ghi dược phân quyền cho người tạo bản ghi)
                else
                {
                    return Ok(new
                    {
                        TotalItem = p.getTotalRequestRecord("signID", a.EmployeeId),
                        Data = listReturn.Where(x => x.signID == a.EmployeeId)
                    });

                }

            }
            return StatusCode(200, "List is Null");
        }


        [HttpPost("GetChildRequestById")]
        public IActionResult GetChildRequestById(int parentId)
        {
            List<RcRequest> list = p.GetChildRequestById(parentId);
            var listReturn = from x in list
                             select new
                             {
                                 id = x.Id,
                                 code = x.Code,
                                 name = x.Name,
                                 requestLevel = x.RequestLevelNavigation?.Name,
                                 department = x.Orgnization?.Name,
                                 position = x.Position?.Name,
                                 positionID = x.PositionId,
                                 quantity = x.Number,
                                 createdOn = x.EffectDate?.ToString("dd/MM/yyyy"),
                                 Deadline = x.ExpireDate?.ToString("dd/MM/yyyy"),
                                 Office = x.Orgnization?.Address,
                                 StatusID = x.Status,
                                 Status = x.Status == 1 ? "Draft" : x.Status == 2 ? "Submited" : x.Status == 3 ? "Cancel" : x.Status == 4 ? "Approved" : x.Status == 5 ? "Rejected" : "",
                                 parentId = x.ParentId,
                                 rank = x.Rank,
                                 note = x.Note,
                                 comment = x.Comment,
                                 HrInchangeId = x.HrInchange,
                                 HrInchange = x.HrInchangeNavigation?.FullName == null ? "" : x.HrInchangeNavigation?.FullName,
                                 signID = x.SignId,
                                 typeID = x.RequestLevel,
                                 typename = x.RequestLevelNavigation?.Name,
                                 OrgnizationName = x.Orgnization?.Name,
                                 OrgnizationID = x.OrgnizationId,
                                 projectname = x.ProjectNavigation?.Name,
                                 projectID = x.Project,
                                 experience = x.YearExperience,
                                 level = x.Level,
                                 levelName = x.LevelNavigation?.Name,
                                 history = "Create by :" + x.CreateBy + " - " + x.CreateDate?.ToString("dd/MM/yyyy") + " Modify by " + x.UpdateBy + " - " + x.UpdateDate?.ToString("dd/MM/yyyy")
                             };
            if (list.Count > 0)
            {
                return Ok(new
                {
                    Data = listReturn
                });
            }
            return StatusCode(200, "List is Null");
        }


        [HttpPut("CancelRequest")]
        public IActionResult CancelRequest(List<int> listID)
        {
            try
            {
                var check = p.ActiveOrDeActiveRequest(listID, 3);
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

        [HttpPut("ApproveRequest")]
        public IActionResult ApproveRequest(List<int> listID)
        {
            try
            {
                var check = p.ActiveOrDeActiveRequest(listID, 4);
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


        [HttpPut("RejectRequest")]
        public IActionResult RejectRequest(List<int> listID)
        {
            try
            {
                var check = p.ActiveOrDeActiveRequest(listID, 5);
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

        [HttpPut("SubmitRequest")]
        public IActionResult SubmitRequest(List<int> listID)
        {
            try
            {
                var check = p.ActiveOrDeActiveRequest(listID, 2);
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
        public IActionResult DeleteRequest(List<int> listID)
        {
            try
            {
                var check = p.DeleteRequest(listID);
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
        [Authorize(Roles = "1,2,3")]
        [HttpPost("InsertRequest")]
        public IActionResult InsertRequest([FromBody] RequestResponse T)
        {

            try
            {
                Account a = GetCurrentUser();
                RcRequest rc = new RcRequest();
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
                rc.PositionId = T.PositionID;
                rc.Type = T.Type;
                rc.Comment = T.Comment;
                rc.ParentId = T.ParentID;
                rc.Level = T.Level;
                rc.RequestLevel = T.RequestLevel;
                rc.Budget = T.Budget;
                rc.Status = T.Status;
                rc.CreateDate = DateTime.Now;
                rc.CreateBy = a.Employee?.FullName;
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
        [Authorize(Roles = "1,2,3")]
        [HttpPut("ModifyRequest")]
        public IActionResult ModifyRequest([FromBody] RequestResponse T)
        {
            try
            {
                Account a = GetCurrentUser();
                RcRequest rc = new RcRequest();
                rc.Id = T.Id;
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
                rc.PositionId = T.PositionID;
                rc.Type = T.Type;
                rc.Comment = T.Comment;
                rc.ParentId = T.ParentID;
                rc.Level = T.Level;
                rc.RequestLevel = T.RequestLevel;
                rc.Budget = T.Budget;
                rc.Comment = T.Comment;
                rc.UpdateDate = DateTime.Now;
                rc.UpdateBy = a.Employee?.FullName;
                var check = p.ModifyRequest(rc);
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



        #region "màn Thêm mới request"



        #endregion
    }
}
