﻿using API.ResponseModel.Candidate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelAuto.Models;
using Services.CandidateService;
using Services.CommonServices;
using Services.ResponseModel.CandidateModel;
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
                                 id = l.Id
                             };

            return Ok(new
            {
                Data = listReturn
            });

        }



        [HttpPost("InsertRcCandidate")]
        public IActionResult InsertRcCandidate([FromBody] Candidate T)
        {
            string code1 = "";
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
                code1 = code;
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
                cv.Skype = T.Skype;
                cv.Website = T.Website;


                cv.NoiO = T.NoiO;
                if (T.NationLive != null)
                {
                    cv.NationLive = T.NationLive;
                }
                if (T.PorvinceLive != null)
                {
                    cv.PorvinceLive = T.PorvinceLive;
                }
                //cv.DistrictLive = T.DistrictLive;
                //cv.WardLive = T.WardLive;
                check = rc.AddRcCandidateCV(cv);
                // rccandidate Edu
                RcCandidateEdu edu = new RcCandidateEdu();
                edu.CandidateId = candidate1.Id;
                edu.Major1 = T.Major;
                if(T.Graduate.Value.Year != 1000)
                {
                    edu.Graduate1 = T.Graduate;
                }
                
                edu.School1 = T.School;
                if (T.Gpa != 0)
                {
                    edu.Gpa1 = T.Gpa;
                }

                edu.Awards1 = T.Awards;
                check = rc.AddRcCandidateEdu(edu);

                // rccandidate skill
                if (T.listSkill != null)
                {
                    List<RcCandidateSkill> list = new List<RcCandidateSkill>();
                    foreach (Skill item in T.listSkill)
                    {

                        RcCandidateSkill skill = new RcCandidateSkill();
                        skill.RcCandidateId = candidate1.Id;
                        if (item.TypeSkill != null)
                        {
                            skill.TypeSkill = item.TypeSkill;
                        }
                        if (item.Type != null)
                        {
                            skill.Type = item.Type;
                        }
                        if (item.Level != null)
                        {
                            skill.Level = item.Level;
                        }

                        skill.Goal = item.Goal;
                        list.Add(skill);
                    }
                    check = rc.AddRcCandidateSkill(list);
                }


                //insert experience + domain
                if (T.listExp != null)
                {
                    List<RcCandidateExp> list1 = new List<RcCandidateExp>();
                    foreach (Exp item in T.listExp)
                    {
                        RcCandidateExp exp = new RcCandidateExp();
                        exp.RcCandidate = candidate1.Id;
                        exp.Firm = item.Firm;
                        if (item.TypeID != 0)
                        {
                            exp.TypeId = item.TypeID;
                        }
                        if (item.Positiob != "")
                        {
                            exp.Position = item.Positiob;
                        }
                        if (item.Time != "")
                        {
                            exp.Time = item.Time;
                        }
                        exp.CreateDate = DateTime.Now;
                        exp.CreateBy = a.Id.ToString();

                        list1.Add(exp);
                    }
                    check = rc.AddRcCandidateExp(list1);
                }


                return Ok(new
                {
                    Status = check,
                    Code= code1
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

        [HttpPost("GetAllCandidate")]
        public IActionResult GetAllCandidate(int index, int size)
        {
            List<CandidateResponeServices> list1 = rc.GetAllCandidate(index, size, 1);
            foreach (var item in list1)
            {
                if (item.positionList.Count > 0)
                {
                    item.lastestPosition = item.positionList.Last().name;
                    item.experience = item.positionList.Last().time;
                }
                string lang = "";
                foreach (var item2 in item.languageList)
                {
                    lang += item2.name + ", ";
                }
                item.language = lang;
            }

            if (list1.ToList().Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Rc_Candidate", false),
                    Data = list1
                });
            }
            return StatusCode(200, "List is Null");

        }

        [HttpPost("GetAllCandidateDraff")]
        public IActionResult GetAllCandidateDraff(int index, int size)
        {
            List<CandidateResponeServices> list1 = rc.GetAllCandidate(index, size, 0);
            if (list1.ToList().Count > 0)
            {
                return Ok(new
                {
                    TotalItem = c.getTotalRecord("Rc_Candidate", false),
                    Data = list1
                });
            }
            return StatusCode(200, "List is Null");
        }


        [HttpPost("GetAllCandidateByFillter")]
        public IActionResult GetAllCandidateByFillter([FromBody] CandidateFillter obj)
        {
            int totalItem = 0;
            List<CandidateResponeServices> list1 = rc.GetAllCandidateByFillter(obj.index, obj.size, obj.name, obj.yob, obj.phone, obj.email, obj.location, obj.position, obj.yearExp, obj.language, obj.status, ref totalItem);
            foreach (var item in list1)
            {
                if (item.positionList.Count > 0)
                {
                    item.lastestPosition = item.positionList.Last().name;
                    item.experience = item.positionList.Last().time;
                }
                string lang = "";
                if (item.languageList.Count > 0)
                {
                    foreach (var item2 in item.languageList)
                    {
                        lang += item2.name + "  ";
                    }
                }
                item.language = lang;
            }
            if (list1.ToList().Count > 0)
            {
                return Ok(new
                {
                    TotalItem = totalItem,
                    Data = list1
                });
            }
            return StatusCode(200, "List is Null");

        }

        [HttpPost("GetOneInforCandidate")]
        public IActionResult GetOneInforCandidate(int id)
        {
            RcCandidate c = rc.GetCandidateByID(id);
            if (c != null)
            {
                List<RcCandidate> list = new List<RcCandidate>();
                list.Add(c);
                var list1 = from b in list
                            let cv = rc.GetCandidateCVbyID(b.Id)
                            let edu = rc.GetCandidateEdubyID(b.Id)
                            select new
                            {
                                ID = c.Id,
                                Code=c.Code,
                                FullName = c.FullName,
                                Dob = cv == null ?"": cv.Dob.Value.Year.ToString(),
                                Phone = cv == null ? "" : cv.Phone,
                                Email = cv == null ? "" : cv.Email,
                                Gender = cv == null ? "" : cv.Gender.ToString(),
                                Address = cv == null ? "" : cv.NoiO,
                                NationLive = rc.GetNation(cv.NationLive) == null ? "" : rc.GetNation(cv.NationLive).Name,
                                ProvinceLive = rc.GetLocation(cv.PorvinceLive) == null ? "" : rc.GetLocation(cv.PorvinceLive).Name,
                                Zalo = cv == null ? "" : cv.Zalo,
                                Facebook= cv == null ? "" : cv.Facebook,
                                Skype= cv == null ? "" : cv.Skype,
                                Website= cv == null ? "" : cv.Website,
                                Awards= edu== null ?"": edu.Awards1,
                                School = edu == null ? "" : edu.School1,
                                Major = edu == null ? "" : edu.Major1,
                                Score = edu == null ? "" : edu.Gpa1.ToString(),
                                Graduate = edu == null ? "" : edu.Graduate1.ToString(),
                                Language = from a in rc.GetCandidateLanguagebyID(b.Id)
                                           group a by a.TypeSkill into g
                                           select new
                                           {
                                               Id = rc.GetOtherListTypesCandidate((int)g.Key).Id,
                                               TypeSkill = rc.GetOtherListTypesCandidate((int)g.Key).Name,
                                               Child = from d in g.ToList()
                                                       group d by d.Type into i
                                                       select new
                                                       {
                                                           Type = rc.GetOtherListCandidate((int)i.Key).Name,
                                                           Child = from k in i.ToList()
                                                                   group k by k.Level into k1
                                                                   select new
                                                                   {
                                                                       Level = rc.GetOtherListCandidate((int)k1.Key).Name,
                                                                       Goal = k1.ToList().Find(x => x.Level == k1.Key).Goal

                                                                   }
                                                       }

                                           },

                                SkillSheet = from a in rc.GetCandidateSkillbyID(b.Id)
                                             group a by a.TypeSkill into g
                                             select new
                                             {
                                                 Id = rc.GetOtherListTypesCandidate((int)g.Key).Id,
                                                 TypeSkill = rc.GetOtherListTypesCandidate((int)g.Key).Name,
                                                 Child = from d in g.ToList()
                                                         group d by d.Type into i
                                                         select new
                                                         {
                                                             Type = rc.GetOtherListCandidate((int)i.Key).Name,
                                                             Child = from k in i.ToList()
                                                                     group k by k.Level into k1
                                                                     select new
                                                                     {
                                                                         Level = rc.GetOtherListCandidate((int)k1.Key).Name,
                                                                         Goal = k1.ToList().Find(x => x.Level == k1.Key).Goal

                                                                     }
                                                         }

                                             },


                            Domain = from a in rc.GetExpOneCandidate(b.Id,82)
                                     select new
                                     {
                                         Firm = a.Firm,
                                         Positiob = a.Position,
                                         Time= a.Time
                                     },
                            OutSource= from a in rc.GetExpOneCandidate(b.Id, 81)
                                       select new
                                       {
                                           Firm = a.Firm,
                                           Positiob = a.Position,
                                           Time = a.Time
                                       }
                            };

                return Ok(new
                {
                    Status = true,
                    Data = list1
                });
            }
            else
            {
                return Ok(new
                {
                    Status = false,
                    Data = "Dont find"
                });
            }

        }

        [HttpPost("CheckDuplicateCandidate")]
        public IActionResult CheckDuplicateCandidate([FromBody] CheckDuplicateCandidateModel obj)
        {
                return Ok(new
                {
                    Data = rc.checkDuplicateCandidate(obj)
                });
        }

        [HttpPost("DeleteCandidate")]
        public IActionResult DeleteCandidate(List<int> ListID)
        {
            return Ok(new
            {
                Status = rc.deleteCandidate(ListID)
            });
        }

        [HttpPost("ActiveCandidate")]
        public IActionResult ActiveCandidate(List<int> ListID)
        {
            return Ok(new
            {
                Status = rc.activeCandidate(ListID)
            });
        }
        [HttpPost("DeActiveCandidate")]
        public IActionResult DeActiveCandidate(List<int> ListID)
        {
            return Ok(new
            {
                Status = rc.deactiveCandidate(ListID)
            });
        }



        #region Matching Candidate

        [HttpPost("MatchingCandidate")]
        public IActionResult MatchingCandidate([FromBody] MatchingResponse obj)
        {
            try
            {
                return Ok(new
                {
                    Status = rc.MatchingCandidate(obj.RequestID, obj.lstCandidateID)
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

        [HttpPost("CheckQuantity")]
        public IActionResult CheckQuantity([FromBody] MatchingResponse obj)
        {
            try
            {
                return Ok(new
                {
                    Status = rc.CheckQuantity(obj.RequestID, obj.lstCandidateID)
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

        [HttpPost("DeleteCandidateRequest")]
        public IActionResult DeleteCandidateRequest([FromBody] List<int> listID)
        {
            try
            {
                return Ok(new
                {
                    Status = rc.DeleteCandidateRequest(listID)
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

        [HttpPost("GetCandidateByRequest")]
        public IActionResult GetCandidateByRequest([FromBody] CandidateFillter obj)
        {
            int totalItem = 0;
            List<CandidateResponeServices> list1 = rc.GetCandidateByRequest(obj.requestID??0,obj.index, obj.size, obj.name, obj.yob, obj.phone, obj.email, obj.location, obj.position, obj.yearExp, obj.language, obj.status, ref totalItem);
            foreach (var item in list1)
            {
                if (item.positionList.Count > 0)
                {
                    item.lastestPosition = item.positionList.Last().name;
                    item.experience = item.positionList.Last().time;
                }
                string lang = "";
                if (item.languageList.Count > 0)
                {
                    foreach (var item2 in item.languageList)
                    {
                        lang += item2.name + "  ";
                    }
                }
                item.language = lang;
            }
            if (list1.ToList().Count > 0)
            {
                return Ok(new
                {
                    TotalItem = totalItem,
                    Data = list1
                });
            }
            return StatusCode(200, "List is Null");
        }

        [HttpPost("CheckDuplicateMatching")]
        public IActionResult CheckDuplicateMatching(List<int>lstCandidateID, int requestID)
        {
            string mess = "";
            return Ok(new
            {
                Status = rc.CheckDuplicateMatching(requestID, lstCandidateID, ref mess),
                mess = mess
            });
        }


        #endregion
    }
}
