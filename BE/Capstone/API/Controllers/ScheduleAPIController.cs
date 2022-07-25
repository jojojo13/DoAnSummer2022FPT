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
        [Authorize]
        [HttpPost("DeleteSchedule")]
        public IActionResult DeleteSchedule(List<int> listID)
        {
            try
            {
                var check = schedule.DeleteSchedule(listID);
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

        [HttpPost("InsertSchedule")]
        public IActionResult InsertSchedule([FromBody] ScheduleResponse T)
        {

            try
            {
                Account a = GetCurrentUser();
                RcRequestSchedu tobj = new RcRequestSchedu();
                tobj.CreateBy = a.Employee?.FullName;
                tobj.DiaDiem = T.DiaDiem;
                tobj.Note = T.Note;
                tobj.StatusContact = T.StatusContact;
                tobj.IsInteview = T.IsInteview;
                tobj.IsExam = T.IsExam;
                if (T.ExamId != 0)
                {
                    tobj.ExamId = T.ExamId;
                }
                if (T.InterViewId != 0)
                {
                    tobj.InterViewId = T.InterViewId;
                }
                if (T.Date.Value.Year != 1000)
                {
                    tobj.Date = T.Date;
                }
                if (T.HinhThuc != 0)
                {
                    tobj.HinhThuc = T.HinhThuc;
                }
                if (T.CandidateId != 0)
                {
                    tobj.CandidateId = T.CandidateId;
                }
                if (T.ExpectedCost != 0)
                {
                    tobj.ExpectedCost = T.ExpectedCost;
                }
                if (T.EndHourExam.Value.Year != 1000)
                {
                    tobj.EndHourExam = T.EndHourExam;
                }
                if (T.StartHourExam.Value.Year != 1000)
                {
                    tobj.StartHourExam = T.StartHourExam;
                }
                if (T.DateNotify.Value.Year != 1000)
                {
                    tobj.DateNotify = T.DateNotify;
                }
                if (T.GioPv.Value.Year!=1000)
                {
                    tobj.GioPv = T.GioPv;
                }
                if (T.IdNguoiPv != 0)
                {
                    tobj.IdNguoiPv = T.IdNguoiPv;
                }
                var check = schedule.InsertSchedule(T.listID, tobj);
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


        [HttpPost("ModifySchedule")]
        public IActionResult ModifySchedule([FromBody] ScheduleResponse T)
        {

            try
            {
                Account a = GetCurrentUser();
                RcRequestSchedu tobj = new RcRequestSchedu();
                tobj.Id = T.Id;
                tobj.UpdateBy = a.Employee?.FullName;
                tobj.DiaDiem = T.DiaDiem;
                tobj.Note = T.Note;
                tobj.StatusContact = T.StatusContact;
                tobj.IsInteview = T.IsInteview;
                tobj.IsExam = T.IsExam;
                if (T.ExamId != 0)
                {
                    tobj.ExamId = T.ExamId;
                }
                if (T.InterViewId != 0)
                {
                    tobj.InterViewId = T.InterViewId;
                }
                if (T.Date.Value.Year != 1000)
                {
                    tobj.Date = T.Date;
                }
                if (T.HinhThuc != 0)
                {
                    tobj.HinhThuc = T.HinhThuc;
                }
                if (T.CandidateId != 0)
                {
                    tobj.CandidateId = T.CandidateId;
                }
                if (T.ExpectedCost != 0)
                {
                    tobj.ExpectedCost = T.ExpectedCost;
                }
                if (T.EndHourExam.Value.Year != 1000)
                {
                    tobj.EndHourExam = T.EndHourExam;
                }
                if (T.StartHourExam.Value.Year != 1000)
                {
                    tobj.StartHourExam = T.StartHourExam;
                }
                if (T.DateNotify.Value.Year != 1000)
                {
                    tobj.DateNotify = T.DateNotify;
                }
                if (T.GioPv.Value.Year != 1000)
                {
                    tobj.GioPv = T.GioPv;
                }
                if (T.IdNguoiPv != 0)
                {
                    tobj.IdNguoiPv = T.IdNguoiPv;
                }
                var check = schedule.ModifySchedule(tobj);
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



        #region "Thiêt lập môn thi"
        [Authorize]
        [HttpPost("ActiveExam")]
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
        [HttpPost("DeleteExam")]
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
        [HttpPost("DeActiveExam")]
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
