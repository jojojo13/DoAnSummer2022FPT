using API.ResponseModel.Candidate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAuto.Models;
using Services.CandidateService;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateAPIController : AuthorizeByIDController
    {
        private ICandidate rc = new CandidateImpl();
        private ICommon c = new CommonImpl();
        [HttpPost("GetSkillSheet")]
        public IActionResult GetSkillSheet(string code1)
        {
            List<OtherList> list = new List<OtherList>();
            list = c.GetOtherList(code1, 0, Int32.MaxValue);
            if (code1.Equals("LANGUAGE"))
            {
                var listReturn = from l in list
                                 select new
                                 {
                                     name = l.Name,
                                     code = l.Code,
                                     note = l.Note,
                                     statusName = l.Status == -1 ? "Active" : "Deactive",
                                     id = l.Id,
                                     ListSkill = from skill in (rc.GetOtherListByAttribute(l.Id))
                                                 select new
                                                 {
                                                     name = skill.Name,
                                                     code = skill.Code,
                                                     note = skill.Note,
                                                     statusName = skill.Status == -1 ? "Active" : "Deactive",
                                                     id = skill.Id,
                                                 }
                                 };

                return Ok(new
                {
                    Data = listReturn
                });
            }
            else
            {
                var listReturn = from l in list
                                 select new
                                 {
                                     name = l.Name,
                                     code = l.Code,
                                     note = l.Note,
                                     statusName = l.Status == -1 ? "Active" : "Deactive",
                                     id = l.Id,
                                     ListSkill = from skill in (c.GetOtherList(l.Type.Level, 0, Int32.MaxValue))
                                                 select new
                                                 {
                                                     name = skill.Name,
                                                     code = skill.Code,
                                                     note = skill.Note,
                                                     statusName = skill.Status == -1 ? "Active" : "Deactive",
                                                     id = skill.Id,
                                                 }
                                 };
                return Ok(new
                {
                    Data = listReturn
                });

            }
        }


        [HttpPost("GetTypeSkill")]
        public IActionResult GetTypeSkill()
        {
            List<OtherListType> list = new List<OtherListType>();
            list = rc.GetSkillType(2);
            var listReturn = from l in list
                             select new
                             {
                                 name = l.Name,
                                 code = l.Code,
                                 id= l.Id
                             };

            return Ok(new
            {
                Data = listReturn
            });

        }



        [HttpPost("InsertRcCandidate")]
        public IActionResult InsertRcCandidate([FromBody] Candidate T)
        {

            try
            {
                bool check;
                Account a = GetCurrentUser();
                // rccandidate
                RcCandidate candidate = new RcCandidate();
                candidate.FullName = T.FullName;
                candidate.CreateBy = a.Employee?.FullName;
                candidate.RecordStatus = T.RecordStatus;
                string code = rc.AddRcCandidate(candidate);
                RcCandidate candidate1 = rc.GetCandidateByCode(code);



                // rccandidateCV
                RcCandidateCv cv = new RcCandidateCv();
                cv.CandidateId = candidate1.Id;
                cv.Dob = T.Dob;
                cv.Gender = T.Gender;
                cv.Phone = T.Phone;
                cv.Zalo = T.Zalo;
                cv.Email = T.Email;
                cv.LinkedIn = T.LinkedIn;
                cv.Facebook = T.Facebook;
                cv.Twiter = T.Twiter;
                cv.NoiO = T.NoiO;
                cv.NationLive = T.NationLive;
                cv.PorvinceLive = T.PorvinceLive;
                cv.DistrictLive = T.DistrictLive;
                cv.WardLive = T.WardLive;
                check = rc.AddRcCandidateCV(cv);

                // rccandidate Edu
                RcCandidateEdu edu = new RcCandidateEdu();
                edu.CandidateId = candidate1.Id;
                edu.Major1 = T.Major;
                edu.Graduate1 = T.Graduate;
                edu.School1 = T.School;
                edu.Gpa1 = T.Gpa;
                edu.Awards1 = T.Awards;
                check = rc.AddRcCandidateEdu(edu);
                // rccandidate skill
                foreach (Skill item in T.listSkill)
                {
                    RcCandidateSkill skill = new RcCandidateSkill();
                    skill.RcCandidateId = candidate1.Id;
                    skill.TypeSkill = item.TypeSkill;
                    skill.Type = item.Type;
                    skill.Level = item.Level;
                    skill.Goal = item.Goal;
                    check = rc.AddRcCandidateSkill(skill);
                }


                //insert experience + domain

                foreach (Exp item in T.listExp)
                {
                    RcCandidateExp exp = new RcCandidateExp();
                    exp.RcCandidate = candidate1.Id;
                    exp.TypeId = item.TypeID;
                    exp.Firm = item.Firm;
                    exp.Position = item.Positiob;
                    exp.Time = item.Time;
                    check = rc.AddRcCandidateExp(exp);
                }


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

        [HttpPost("GetAllCandidate")]
        public IActionResult GetAllCandidate(int index, int size)
        {
            List<RcCandidate> list1 = rc.GetAllCandidate(index, size);
            List<Candidate> list = new List<Candidate>();
            foreach (RcCandidate item in list1)
            {
                RcCandidateCv T= rc.GetCandidateCVbyID(item.Id);
                RcCandidateEdu edu = rc.GetCandidateEdubyID(item.Id);
                List<RcCandidateSkill> skill= rc.GetCandidateSkillbyID(item.Id);
                List<RcCandidateExp> exp= rc.GetCandidateExpbyID(item.Id);

                Candidate c = new Candidate();
                c.FullName= item.FullName;
                // get  cv
                c.Dob = T.Dob;
                c.Gender = T.Gender;
                c.Phone = T.Phone;
                c.Zalo = T.Zalo;
                c.Email = T.Email;
                c.LinkedIn = T.LinkedIn;
                c.Facebook = T.Facebook;
                c.Twiter = T.Twiter;
                c.NoiO = T.NoiO;
                c.NationLive = T.NationLive;
                c.PorvinceLive = T.PorvinceLive;
                c.DistrictLive = T.DistrictLive;
                c.WardLive = T.WardLive;
                // get edu
               c.Major = edu.Major1;
                c.Graduate = edu.Graduate1;
                c.School = edu.School1;
                c.Gpa = edu.Gpa1;
                c.Awards = edu.Awards1;
                // get lít skill
                List<Skill> skills = new List<Skill>(); 
                foreach(RcCandidateSkill i1 in skill)
                {
                    skills.Add(new Skill { TypeSkill = i1.TypeSkill, Type = i1.Type, Level= i1.Level , Goal= i1.Goal }) ;
                }
                c.listSkill= skills ;
                // get list exp 
                List<Exp> exps = new List<Exp>();   
                foreach(RcCandidateExp i in exp)
                {
                    exps.Add( new Exp { TypeID = i.TypeId, Firm= i.Firm, Positiob= i.Position, Time= i.Time});
                }
                c.listExp= exps ;

                list.Add(c);





            }

            if (list.Count > 0)
            {
                return Ok(new
                {
                    TotalItem = list.Count,
                    Data = list
                }) ;
            }
            return StatusCode(200, "List is Null");
        }


    }
}
