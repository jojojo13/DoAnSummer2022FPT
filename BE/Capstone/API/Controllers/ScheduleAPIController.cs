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
                List<RcEvent> list = new List<RcEvent>();
                foreach(var item in T.listEvent)
                {
                    RcEvent tobj = new RcEvent();
                    tobj.RequestId = T.requestId;
                    tobj.CandidateId = T.candidateId;
                    tobj.Classname = item.Classname;
                    tobj.Title = item.Title;
                    tobj.StartHour = item.StartHour;
                    tobj.EndHour = item.EndHour;
                    list.Add(tobj);
                }
                return Ok(new
                {
                    Status = schedule.InsertSchedule(list)
                }) ;
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
        public IActionResult ModifySchedule([FromBody] RcEvent T)
        {

            try
            {
                var check = schedule.ModifySchedule(T);
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
