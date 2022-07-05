using ModelAuto.Models;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CandidateService
{
   public class CandidateImpl: ICandidate
    {
        public List<OtherList> GetOtherListByAttribute(int? ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<OtherList> listReturn = context.OtherLists.Where(x => x.Atribute1 == ID.ToString()).ToList();
                    return listReturn;
                }
            }
            catch
            {
                return new List<OtherList>();
            }
        }

        ICommon c = new CommonImpl();
        public string AddRcCandidate(RcCandidate r)
        {
            string code1;
            try
            {


                using (var context = new CapstoneProject2022Context())
                {
                    List<RcCandidate> list = context.RcCandidates.ToList();
                    RcCandidate r1 = new RcCandidate();
                    r1.Code =c.autoGenCode3character("Rc_Candidate", "UV");
                    r1.FullName = r.FullName;
                    r1.StepCv = 1;
                    r1.CreateDate = DateTime.Now;
                    r1.CreateBy = r.CreateBy;
                    context.RcCandidates.Add(r1);
                    context.SaveChanges();
                    code1 = r1.Code;
                }
                return code1;

            }
            catch
            {
                return null;
            }
        }

        public bool AddRcCandidateCV(RcCandidateCv r)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    RcCandidateCv r1 = new RcCandidateCv();
                    r1.CandidateId = r.CandidateId;
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
                    r1.WardLive = r.WardLive;
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
                    r1.CandidateId = r.CandidateId;
                    r1.Major1 = r.Major1;
                    r1.Graduate1 = r.Graduate1;
                    r1.School1 = r.School1;
                    r1.Gpa1 = r.Gpa1;
                    r1.Awards1 = r.Awards1;
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

        public bool AddRcCandidateSkill(RcCandidateSkill r)
        {
            try
            {
                using var context = new CapstoneProject2022Context();
                context.RcCandidateSkills.Add(r);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<RcCandidate> GetAllCandidate(int index, int size)
        {
            List<RcCandidate> list = new List<RcCandidate>();
            try
            {
                using var context = new CapstoneProject2022Context();
                list = context.RcCandidates.Skip(index * size).Take(size).ToList();
            }
            catch
            {

            }
            return list;
        }

        public List<RcCandidate> GetAllCandidateByStep(int step)
        {
            List<RcCandidate> list = new List<RcCandidate>();
            try
            {
                using var context = new CapstoneProject2022Context();
                list = context.RcCandidates.Where(x => x.StepCv == step).ToList();
            }
            catch
            {
            }
            return list;
        }

        public RcCandidate GetCandidateByCode(string code)
        {
            RcCandidate candidate = new RcCandidate();
            try
            {
                using var context = new CapstoneProject2022Context();
                candidate = context.RcCandidates.Where(x => x.Code == code).SingleOrDefault();
            }
            catch
            {

            }
            return candidate;
        }

        public RcCandidate GetCandidateByID(int id)
        {
            RcCandidate candidate = new RcCandidate();
            try
            {
                using var context = new CapstoneProject2022Context();
                candidate = context.RcCandidates.Where(x => x.Id == id).SingleOrDefault();
            }
            catch
            {

            }
            return candidate;
        }

        public RcCandidateCv GetCandidateCVbyID(int id)
        {
            RcCandidateCv cv = new RcCandidateCv();
            try
            {
                using var context = new CapstoneProject2022Context();
                cv = context.RcCandidateCvs.Where(x => x.CandidateId == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return cv;
        }

        public RcCandidateEdu GetCandidateEdubyID(int id)
        {
            RcCandidateEdu edu = new RcCandidateEdu();
            try
            {
                using var context = new CapstoneProject2022Context();
                edu = context.RcCandidateEdus.Where(x => x.CandidateId == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return edu;
        }

        public List<RcCandidateSkill> GetCandidateSkillbyID(int id)
        {
            List<RcCandidateSkill> list = new List<RcCandidateSkill>();
            try
            {

                using var context = new CapstoneProject2022Context();
                list = context.RcCandidateSkills.Where(x => x.RcCandidateId == id).ToList();
            }
            catch
            {

            }
            return list;
        }

        public bool PromoteCandidate(int CandidateID)
        {
            try
            {
                using var context = new CapstoneProject2022Context();


                return true;
            }
            catch
            {
                return false;
            };
        }

        public bool UpdateStepCandidate(RcCandidate r)
        {
            try
            {
                using var context = new CapstoneProject2022Context();


                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ViewFailedCandidate(int CandidateID)
        {
            try
            {
                using var context = new CapstoneProject2022Context();


                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
