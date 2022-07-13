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
                //cv.DistrictLive = T.DistrictLive;
                //cv.WardLive = T.WardLive;
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
            List<RcCandidate> list1 = rc.GetAllCandidate(index, size,1);
            var list2 = from c in list1
                        let k1 = rc.GetSkill(c.Id)
                        let cv = rc.GetCandidateCVbyID(c.Id)
                        select new
                        {
                            ID = c.Id,
                            Name = c.FullName,
                            Dob = cv.Dob,
                            Phone = cv.Phone,
                            Email = cv.Email,
                            Location = rc.GetLocation((int)cv.PorvinceLive).Name,
                            Position = rc.Position(c.Id),
                            YearExp = rc.Exp(c.Id),
                            Language = k1
                        };
            if (list1.ToList().Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Rc_Candidate", false),
                    Data = list2
                });
            }
            return StatusCode(200, "List is Null");

        }

        [HttpPost("GetAllCandidateDraff")]
        public IActionResult GetAllCandidateDraff(int index, int size)
        {
            List<RcCandidate> list1 = rc.GetAllCandidate(index, size, 0);
            var list2 = from c in list1
                        let k1 = rc.GetSkill(c.Id)
                        let cv= rc.GetCandidateCVbyID(c.Id)
                        select new
                        {
                            ID = c.Id,
                            Name = c.FullName,
                            Dob = cv.Dob,
                            Phone = cv.Phone,
                            Email = cv.Email,
                            Location = rc.GetLocation((int)cv.PorvinceLive).Name,
                            Position = rc.Position(c.Id),
                            YearExp = rc.Exp(c.Id),
                            Language = k1
                        };
            if (list1.ToList().Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Rc_Candidate", false),
                    Data = list2
                });
            }
            return StatusCode(200, "List is Null");
        }


        [HttpPost("GetAllCandidateByFillter")]
        public IActionResult GetAllCandidateByFillter([FromBody] CandidateFillter obj)
        {
            List<RcCandidate> list1 = rc.GetAllCandidateByFillter(obj.index, obj.size, obj.name,obj.dob, obj.phone, obj.email, obj.location, obj.position, obj.yearExp, obj.language ,obj.status );
            var list2 = from c in list1
                        let k1 = rc.GetSkill(c.Id)
                        let cv = rc.GetCandidateCVbyID(c.Id)
                        select new
                        {
                            ID = c.Id,
                            Name = c.FullName,
                            Dob = cv.Dob,
                            Phone = cv.Phone,
                            Email = cv.Email,
                            Location = rc.GetLocation((int)cv.PorvinceLive).Name,
                            Position = rc.Position(c.Id),
                            YearExp = rc.Exp(c.Id),
                            Language = k1
                        };
            if (list1.ToList().Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Rc_Candidate", false),
                    Data = list2
                });
            }
            return StatusCode(200, "List is Null");

        }

    }                                                                                                                                                                                                                                                                                                   
}
