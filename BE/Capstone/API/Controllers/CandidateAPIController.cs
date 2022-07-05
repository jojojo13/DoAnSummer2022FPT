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
                edu.Gpa1 = decimal.Parse(T.Gpa);
                edu.Awards1 = T.Awards;
                check = rc.AddRcCandidateEdu(edu);
                // rccandidate Skill
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
            List<RcCandidate> list = rc.GetAllCandidate(index, size);
            var ListResponse = from l in list
                               select new
                               {
                                   id = l.Id,
                                   fullname = l.FullName,
                                   code = l.Code,
                                   dateOfBirth = rc.GetCandidateCVbyID(l.Id)?.Dob,
                                   phoneNumber = rc.GetCandidateCVbyID(l.Id)?.Phone,
                                   email = rc.GetCandidateCVbyID(l.Id)?.Email,
                                   location = rc.GetCandidateCVbyID(l.Id)?.NoiO,
                                   status = l.Status == -1 ? "Active" : "Deactive"
                               };

            if (list.Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Rc_Candidate", false),
                    Data = ListResponse
                });
            }
            return StatusCode(200, "List is Null");
        }


    }
}
