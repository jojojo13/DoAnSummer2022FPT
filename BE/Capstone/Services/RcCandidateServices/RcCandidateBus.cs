using ModelAuto.Models;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RcCandidateServices
{
    internal class RcCandidateBus : IRcCandidate
    {
        ICommon c = new CommonImpl();
        public bool AddRcCandidate(RcCandidate r)
        {
            try
            {


                using (var context = new CapstoneProject2022Context())
                {
                    RcCandidate r1 = new RcCandidate();
                    r1.Code = c.autoGenCode3character("Rc_Candidate", "CA");
                    r1.FullName = r.FullName;
                    r1.StepCv = 1;
                    r1.CreateDate= DateTime.Now;
                    r1.CreateBy = r.CreateBy;
                    context.RcCandidates.Add(r1);
                    context.SaveChanges();
                }
                return true;    

            }
            catch
            {
                return false;
            }
        }

        public bool AddRcCandidateCV(RcCandidateCv r)
        {
            try
            {
                using (var context= new CapstoneProject2022Context())
                {
                    RcCandidateCv r1 = new RcCandidateCv();
                    r1.CandidateId= r.CandidateId;
                    r1.Dob = r.Dob;
                    r1.Gender = r.Gender;
                    r1.Phone = r.Phone;
                    r1.Zalo = r.Zalo;
                    r1.Email = r.Email;
                    r1.LinkedIn = r.LinkedIn;
                    r1.Facebook = r.Facebook;
                    r1.Twiter = r.Twiter;
                    r1.NoiO = r.NoiO;
                    r1.NationLive = r.NationLive;
                    r1.PorvinceLive = r.PorvinceLive;
                    r1.DistrictLive = r.DistrictLive;
                    r1.WardLive= r.WardLive;
                    r1.CreateDate = DateTime.Now;
                    r1.CreateBy = r.CreateBy;
                    context.RcCandidateCvs.Add(r1);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddRcCandidateEdu(RcCandidateEdu r)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    RcCandidateEdu r1 = new RcCandidateEdu();
                    r1.CandidateId= r.CandidateId;
                    r1.Major1 = r.Major1;
                    r1.Graduate1 = r.Graduate1;
                    r1.School1 = r.School1;
                    r1.Gpa1 = r.Gpa1;
                    r1.Awards1= r.Awards1;
                    r1.CreateDate = DateTime.Now;
                    r1.CreateBy = r.CreateBy;
                    context.RcCandidateEdus.Add(r1);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool UpdateStepCandidate(RcCandidate r)
        {
            throw new NotImplementedException();
        }
    }
}
