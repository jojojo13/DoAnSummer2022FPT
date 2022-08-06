using ModelAuto.Models;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ScheduleServices
{
    public class ScheduleImpl : ISchedule
    {


        public bool DeleteSchedule(List<int> listID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in listID)
                    {
                        RcEvent tobj = new RcEvent();
                        tobj = context.RcEvents.Where(x => x.Id == item).FirstOrDefault();
                        context.RcEvents.Remove(tobj);
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool InsertSchedule(RcEvent T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    RcEvent tobj = new RcEvent();
                    tobj.Classname = T.Classname;
                    tobj.Title = T.Title;
                    tobj.RequestId = T.RequestId;
                    tobj.StartHour = T.StartHour;
                    tobj.EndHour = T.EndHour;
                    context.RcEvents.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool ModifySchedule(RcEvent T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    RcEvent tobj = context.RcEvents.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Classname = T.Classname;
                    tobj.Title = T.Title;
                    tobj.RequestId = T.RequestId;
                    tobj.StartHour = T.StartHour;
                    tobj.EndHour = T.EndHour;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<RcEvent> getSchedule(int requestId, int candidateId)
        {
            List<RcEvent> list = new List<RcEvent>();
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    list = context.RcEvents.Where(x => x.RequestId == requestId && x.CandidateId == candidateId).ToList();
                }
            }
            catch
            {

            }
            return list;
        }

    }
}
