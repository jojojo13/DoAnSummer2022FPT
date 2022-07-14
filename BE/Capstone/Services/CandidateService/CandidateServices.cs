﻿using ModelAuto.Models;
using Services.CommonServices;
using Services.ResponseModel.CandidateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CandidateService
{
    public class CandidateImpl : ICandidate
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
                    r1.Code = c.autoGenCode3character("Rc_Candidate", "UV");
                    r1.FullName = r.FullName;
                    r1.StepCv = 1;
                    r1.CreateDate = DateTime.Now;
                    r1.CreateBy = r.CreateBy;
                    r1.RecordStatus = r.RecordStatus;
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

        public List<RcCandidate> GetAllCandidate(int index, int size, int status)
        {
            List<RcCandidate> list = new List<RcCandidate>();
            try
            {
                using var context = new CapstoneProject2022Context();
                list = context.RcCandidates.Where(x => x.RecordStatus == status).Skip(index * size).Take(size).ToList();
            }
            catch
            {

            }
            return list;
        }

        public List<RcCandidate> GetAllCandidateByFillter(int index, int size, string name, DateTime dob, string phone, string email, string location, string position, string yearExp, string language, int status)
        {
            List<RcCandidate> list = new List<RcCandidate>();
            try
            {
                using var context = new CapstoneProject2022Context();
                list = context.RcCandidates.Where(x => x.RecordStatus == status).ToList();
                var returnList = from c in list
                                 select new
                                 {
                                     //ID = c.Id,
                                     //Name = c.FullName,
                                     //Dob = cv.Dob,
                                     //Phone = cv.Phone,
                                     //Email = cv.Email,
                                     //Location = rc.GetLocation((int)cv.PorvinceLive).Name,
                                     //Position = rc.Position(c.Id),
                                     //YearExp = rc.Exp(c.Id),
                                     //Language = k1
                                 };
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

        public List<OtherListType> GetSkillType(int type)
        {
            List<OtherListType> list = new List<OtherListType>();
            try
            {

                using var context = new CapstoneProject2022Context();
                list = context.OtherListTypes.Where(x => x.TypeSkill == type).ToList();
            }
            catch
            {

            }
            return list;
        }

        public bool AddRcCandidateExp(RcCandidateExp r)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    RcCandidateExp r1 = new RcCandidateExp();
                    r1.RcCandidate = r.RcCandidate;
                    r1.TypeId = r.TypeId;
                    r1.Firm = r.Firm;
                    r1.Position = r.Position;
                    r1.Time = r.Time;
                    r1.CreateBy = r.CreateBy;
                    r1.CreateDate = DateTime.Now;
                    context.RcCandidateExps.Add(r1);
                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<RcCandidateExp> GetCandidateExpbyID(int id)
        {
            List<RcCandidateExp> list = new List<RcCandidateExp>();
            try
            {

                using var context = new CapstoneProject2022Context();
                list = context.RcCandidateExps.Where(x => x.RcCandidate == id).ToList();
            }
            catch
            {

            }
            return list;
        }

        public Province GetLocation(int id)
        {
            Province p = new Province();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    p = context.Provinces.Where(x => x.Id == id).SingleOrDefault();
                    return p;
                }
            }
            catch
            {
                return p;
            }
        }

        public string GetSkill(int candidateID)
        {
            string skill = "";
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    List<RcCandidateSkill> list = context.RcCandidateSkills.Where(x => x.RcCandidateId == candidateID).ToList();
                    foreach (RcCandidateSkill item in list)
                    {
                        item.TypeNavigation = context.OtherLists.Where(x => x.Id == item.Type).SingleOrDefault();
                        if (item.TypeNavigation != null)
                        {
                            skill += item.TypeNavigation.Name + ",";
                        }
                    }
                }
                return skill;

            }
            catch
            {
                return null;
            }
        }

        public string Position(int candidateID)
        {
            string position = "";
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    List<RcCandidateExp> list = context.RcCandidateExps.Where(x => x.RcCandidate == candidateID).ToList();
                    if (list.Count == 0)
                    {
                        position = "";
                    }
                    else
                    {
                        position = list.Take(1).FirstOrDefault().Position;


                    }
                }
            }
            catch
            {
                position = "";
            }
            return position;
        }

        public string Exp(int candidateID)
        {
            string exp = "";
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    List<RcCandidateExp> list = context.RcCandidateExps.Where(x => x.RcCandidate == candidateID).ToList();
                    if (list.Count == 0)
                    {
                        exp = "";
                    }
                    else
                    {
                        exp = list.Take(1).FirstOrDefault().Time;


                    }
                }
            }
            catch
            {
                exp = "";
            }
            return exp;
        }


        #region matching REquesst
        public bool MatchingCandidate(int requestID, List<int> lstCandidateID)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    if (requestID != 0 && lstCandidateID.Count > 0)
                    {
                        foreach (var id in lstCandidateID)
                        {
                            RcRequestCandidate obj = new RcRequestCandidate();
                            obj.CandidateId = id;
                            obj.RequestId = requestID;
                            context.RcRequestCandidates.Add(obj);
                        }
                        context.SaveChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<CandidateResponeServices> GetCandidateByRequest(int requestID, int totalItem)
        {
            List<CandidateResponeServices> returrnList = new List<CandidateResponeServices>();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    if (requestID != 0)
                    {
                        var query = from r in context.RcRequestCandidates.Where(x => x.RequestId == requestID)
                                    from c in context.RcCandidates.Where(x => x.Id == r.CandidateId).DefaultIfEmpty()
                                    from cv in context.RcCandidateCvs.Where(x => x.CandidateId == r.CandidateId).DefaultIfEmpty()
                                    from na in context.Nations.Where(x => x.Id == cv.NationLive).DefaultIfEmpty()
                                    from pr in context.Nations.Where(x => x.Id == cv.PorvinceLive).DefaultIfEmpty()
                                    select new CandidateResponeServices
                                    {
                                        id = c.Id,
                                        name = c.FullName,
                                        code = c.Code,
                                        yob = cv.Dob.Value.Year,
                                        dob = cv.Dob,
                                        dobString = Convert.ToDateTime(cv.Dob).ToString("dd/MM/YYYY"),
                                        phoneNumber = cv.Phone,
                                        email = cv.Email,
                                        nation = na.Name,
                                        province = pr.Name,
                                        nationID = na.Id,
                                        provinceID = pr.Id,
                                        location = na.Name + " - " + pr.Name,
                                        status = c.RecordStatus.ToString(),
                                        statusId = c.RecordStatus,
                                        //positionList = (from lstpo in context.RcCandidateExps.Where(x => x.RcCandidate == r.CandidateId) select new positionObj { name = lstpo.Position }).ToList(),
                                        //languageList = (from lstla in context.RcCandidateSkills.Where(x => x.RcCandidateId == r.CandidateId)
                                        //                from ot in context.OtherLists.Where(x => x.Id == lstla.Type).DefaultIfEmpty()
                                        //                select new languageObj { name = ot.Name }).ToList(),
                                        lastestPosition= (from lstpo in context.RcCandidateExps.Where(x => x.RcCandidate == r.CandidateId) select new positionObj { name = lstpo.Position }).ToList().LastOrDefault().name,
                                        language= GetSkill(r.CandidateId??0)
                                    };
                        totalItem = query.ToList().Count();
                        returrnList = query.ToList();
                    }
                }
                return returrnList;
            }
            catch
            {
                return returrnList;
            }
        }
        public bool CheckQuantity(int requestID, List<int> lstCandidateID)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    if (requestID != 0)
                    {
                        int count = lstCandidateID.Count;
                        int countInList = context.RcRequestCandidates.Where(x => x.RequestId == requestID).Count();
                        RcRequest request = context.RcRequests.Where(x => x.Id == requestID).FirstOrDefault();
                        if (count + countInList > request.Number)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCandidateRequest(List<int> listID)
        {
            try
            {
                using (var context = new CapstoneProject2022Context())
                {

                    foreach (var id in listID)
                    {
                        RcRequestCandidate obj = context.RcRequestCandidates.Where(x => x.Id == id).FirstOrDefault();
                        context.RcRequestCandidates.Remove(obj);
                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public OtherListType GetOtherListTypesCandidate(int id)
        {
            OtherListType other = new OtherListType();
            using (var context = new CapstoneProject2022Context())
            {
                other = context.OtherListTypes.Where(x => x.Id == id).SingleOrDefault();

            }
            return other;
        }

        public OtherList GetOtherListCandidate(int id)
        {
            OtherList other = new OtherList();
            using (var context = new CapstoneProject2022Context())
            {
                other = context.OtherLists.Where(x => x.Id == id).SingleOrDefault();

            }
            return other;
        }

        public Nation GetNation(int id)
        {
            Nation p = new Nation();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    p = context.Nations.Where(x => x.Id == id).SingleOrDefault();
                    return p;
                }
            }
            catch
            {
                return p;
            }
        }

        public District GetDistrict(int id)
        {
            District p = new District();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    p = context.Districts.Where(x => x.Id == id).SingleOrDefault();
                    return p;
                }
            }
            catch
            {
                return p;
            }
        }

        public Ward GetWard(int id)
        {
            Ward p = new Ward();
            try
            {
                using (var context = new CapstoneProject2022Context())
                {
                    p = context.Wards.Where(x => x.Id == id).SingleOrDefault();
                    return p;
                }
            }
            catch
            {
                return p;
            }
        }
        #endregion
    }
}
