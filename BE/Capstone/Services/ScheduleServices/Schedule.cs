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
                        RcRequestSchedu tobj = new RcRequestSchedu();
                        tobj = context.RcRequestSchedus.Where(x => x.Id == item).FirstOrDefault();
                        context.RcRequestSchedus.Remove(tobj);
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


        public bool InsertSchedule(List<int> listCandidate, RcRequestSchedu T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in listCandidate)
                    {
                        RcRequestSchedu tobj = new RcRequestSchedu();
                        tobj.IsInteview = T.IsInteview;
                        tobj.IsExam = T.IsExam;
                        tobj.ExamId = T.ExamId;
                        tobj.InterViewId = T.InterViewId;
                        tobj.Date = T.Date;
                        tobj.DiaDiem = T.DiaDiem;
                        tobj.HinhThuc = T.HinhThuc;
                        tobj.CandidateId = T.CandidateId;
                        tobj.Note = T.Note;
                        tobj.ExpectedCost = T.ExpectedCost;
                        tobj.StatusContact = T.StatusContact;
                        tobj.EndHourExam = T.EndHourExam;
                        tobj.StartHourExam = T.StartHourExam;
                        tobj.DateNotify = T.DateNotify;
                        tobj.GioPv = T.GioPv;
                        tobj.IdNguoiPv = T.IdNguoiPv;
                        tobj.CreateBy = T.CreateBy;
                        tobj.CreateDate = DateTime.UtcNow;
                        context.RcRequestSchedus.Add(tobj);
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


        public bool ModifySchedule(RcRequestSchedu T)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    RcRequestSchedu tobj = context.RcRequestSchedus.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.IsInteview = T.IsInteview;
                    tobj.IsExam = T.IsExam;
                    tobj.ExamId = T.ExamId;
                    tobj.InterViewId = T.InterViewId;
                    tobj.Date = T.Date;
                    tobj.DiaDiem = T.DiaDiem;
                    tobj.HinhThuc = T.HinhThuc;
                    tobj.CandidateId = T.CandidateId;
                    tobj.Note = T.Note;
                    tobj.ExpectedCost = T.ExpectedCost;
                    tobj.StatusContact = T.StatusContact;
                    tobj.EndHourExam = T.EndHourExam;
                    tobj.StartHourExam = T.StartHourExam;
                    tobj.DateNotify = T.DateNotify;
                    tobj.GioPv = T.GioPv;
                    tobj.IdNguoiPv = T.IdNguoiPv;
                    tobj.UpdateBy = T.UpdateBy;
                    tobj.UpdateDate = DateTime.UtcNow;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }




        public bool ActiveExam(List<int> listID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in listID)
                    {
                        RcRequestExam tobj = new RcRequestExam();
                        tobj = context.RcRequestExams.Where(x => x.Id == item).FirstOrDefault();
                        tobj.Status = -1;
                        context.SaveChanges();
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

        public bool DeactiveExam(List<int> listID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in listID)
                    {
                        RcRequestExam tobj = new RcRequestExam();
                        tobj = context.RcRequestExams.Where(x => x.Id == item).FirstOrDefault();
                        tobj.Status = 0;
                        context.SaveChanges();
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

        public bool DeleteExam(List<int> listID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in listID)
                    {
                        RcRequestExam tobj = new RcRequestExam();
                        tobj = context.RcRequestExams.Where(x => x.Id == item).FirstOrDefault();
                        context.RcRequestExams.Remove(tobj);
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

        public bool ModifyExam(RcRequestExam T)
        {
            try
            {

                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    RcRequestExam tobj = context.RcRequestExams.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.HeDiem = T.HeDiem;
                    tobj.DiemQua = T.DiemQua;
                    tobj.RequestId = T.RequestId;
                    tobj.UpdateBy = T.CreateBy;
                    tobj.UpdateDate = DateTime.UtcNow;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool InsertExam(RcRequestExam T)
        {
            ICommon c = new CommonImpl();
            try
            {
                RcRequestExam tobj = new RcRequestExam();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Rc_Request_Exam", "EXM");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.HeDiem = T.HeDiem;
                tobj.DiemQua = T.DiemQua;
                tobj.RequestId = T.RequestId;
                tobj.CreateBy = T.CreateBy;
                tobj.CreateDate = DateTime.UtcNow;
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.RcRequestExams.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
