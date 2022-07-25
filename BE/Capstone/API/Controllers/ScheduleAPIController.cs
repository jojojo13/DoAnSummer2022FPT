using API.ResponseModel.Schedule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAuto.Models;
using Services.ScheduleServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleAPIController : AuthorizeByIDController
    {
        private ISchedule schedule = new ScheduleImpl();
        #region "Schedule"

        #endregion



        #region "Thiêt lập môn thi"
        [Authorize]
        [HttpPut("ActiveExam")]
        public IActionResult ActiveExam(List<int> listID)
        {
            try
            {
                var check = schedule.ActiveExam(listID);
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

        [Authorize]
        [HttpPut("DeleteExam")]
        public IActionResult DeleteExam(List<int> listID)
        {
            try
            {
                var check = schedule.DeleteExam(listID);
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

        [Authorize]
        [HttpPut("DeActiveExam")]
        public IActionResult DeActiveExam(List<int> listID)
        {
            try
            {
                var check = schedule.DeactiveExam(listID);
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


        [HttpPost("InsertExam")]
        public IActionResult InsertExam([FromBody] ExamResponse T)
        {

            try
            {
                Account a = GetCurrentUser();
                RcRequestExam tobj = new RcRequestExam();
                tobj.Name = T.Name;
                tobj.Status = -1;
                tobj.Note = T.Note;
                if (T.HeDiem != 0)
                {
                    tobj.HeDiem = T.HeDiem;
                }
                if (T.DiemQua != 0)
                {
                    tobj.DiemQua = T.DiemQua;
                }
                if (T.RequestId != 0)
                {
                    tobj.RequestId = T.RequestId;
                }
                tobj.CreateBy = a.Employee?.FullName;
                var check = schedule.InsertExam(tobj);
                return Ok(new
                {
                    Status = check
                });

            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }
        }

        [HttpPost("ModifyExam")]
        public IActionResult ModifyExam([FromBody] ExamResponse T)
        {

            try
            {
                Account a = GetCurrentUser();
                RcRequestExam tobj = new RcRequestExam();
                tobj.Id = T.Id;
                tobj.Name = T.Name;
                tobj.Status = -1;
                tobj.Note = T.Note;
                if (T.HeDiem != 0)
                {
                    tobj.HeDiem = T.HeDiem;
                }
                if (T.DiemQua != 0)
                {
                    tobj.DiemQua = T.DiemQua;
                }
                if (T.RequestId != 0)
                {
                    tobj.RequestId = T.RequestId;
                }
                tobj.UpdateBy = a.Employee?.FullName;
                var check = schedule.ModifyExam(tobj);
                return Ok(new
                {
                    Status = check
                });

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
