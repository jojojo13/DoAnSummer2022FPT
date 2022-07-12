using ModelAuto;
using ModelAuto.Models;
using Services.CommonModel;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestServices
{
    public class Request : IRequest
    {
        private ICommon c = new CommonImpl();
        public bool ActiveOrDeActiveRequest(List<int> list, int status, string actionBy)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        List<int> ListRCID = new List<int>();
                        ListRCID = GetListRequestByID(item).Select(x => x.Id).ToList();
                        foreach (var rcId in ListRCID)
                        {
                            RcRequest tobj = new RcRequest();
                            tobj = context.RcRequests.Where(x => x.Id == rcId).FirstOrDefault();
                            tobj.Status = status;
                            if (status == 4 || status == 5)
                            {
                                EmployeeCv em = context.EmployeeCvs.Where(x => x.EmployeeId == tobj.SignId).FirstOrDefault();
                                ICommon c = new CommonImpl();
                                if (em.EmailWork != "")
                                {
                                    MailDTO mailDTO = new MailDTO();
                                    string statusName = status == 4 ? "Approved" : status == 5 ? "Rejected" : "";
                                    mailDTO.content = "Your Request '" + tobj.Name + "' has been " + statusName + " by " + actionBy + " If there is feedback, please give feedback to the manager";
                                    mailDTO.subject = "Notice the status of your recruitment request";
                                    mailDTO.fromMail = "aisolutionssum22@gmail.com";
                                    mailDTO.pass = "miztlfnbereqmeko";
                                    mailDTO.listCC = new List<string>();
                                    mailDTO.listBC = new List<string>();
                                    mailDTO.tomail = em?.EmailWork;
                                    c.sendMail(mailDTO);
                                }

                            }
                        }
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

        public bool DeleteRequest(List<int> list)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        RcRequest tobj = new RcRequest();
                        tobj = context.RcRequests.Where(x => x.Id == item).FirstOrDefault();
                        context.RcRequests.Remove(tobj);
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

        public List<RcRequest> GetAllRequest(int index, int size)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<RcRequest> list = context.RcRequests.Where(x => x.Rank == 1).ToList().OrderByDescending(x => x.Id).Skip(index * size).Take(size).OrderBy(x => x.Id).ToList();
                    foreach (var item in list)
                    {
                        item.Position = context.Positions.Where(x => x.Id == item.PositionId).FirstOrDefault();
                        item.Orgnization = context.Orgnizations.Where(x => x.Id == item.OrgnizationId).FirstOrDefault();
                        item.Sign = context.Employees.Where(x => x.Id == item.SignId).FirstOrDefault();
                        item.HrInchangeNavigation = context.Employees.Where(x => x.Id == item.HrInchange).FirstOrDefault();
                        item.OtherSkillNavigation = context.OtherLists.Where(x => x.Id == item.OtherSkill).FirstOrDefault();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<RcRequest>();
            }
        }



        public List<RcRequest> GetAllRequestByFillter(int index, int size, string Code, string Name, string OrgName, string PositionName, int Quantity, string Status, string HrInchange, DateTime CreateOn, DateTime DeadLine)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<RcRequest> list = context.RcRequests.Where(x => x.Rank == 1).ToList().OrderByDescending(x => x.Id).OrderBy(x => x.Id).ToList();
                    foreach (var item in list)
                    {
                        item.Position = context.Positions.Where(x => x.Id == item.PositionId).FirstOrDefault();
                        item.Orgnization = context.Orgnizations.Where(x => x.Id == item.OrgnizationId).FirstOrDefault();
                        item.Sign = context.Employees.Where(x => x.Id == item.SignId).FirstOrDefault();
                        item.HrInchangeNavigation = context.Employees.Where(x => x.Id == item.HrInchange).FirstOrDefault();
                        item.OtherSkillNavigation = context.OtherLists.Where(x => x.Id == item.OtherSkill).FirstOrDefault();
                    }
                   
                    if (!Code.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Code.Contains(Code)).ToList();
                    }
                    if (!Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Name.Contains(Name)).ToList();
                    }
                    if (!OrgName.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Orgnization.Name.Contains(OrgName)).ToList();
                    }
                    if (!PositionName.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Position.Name.Contains(PositionName)).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("draft"))
                    {
                        list = list.Where(x => x.Status == 1).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("submited"))
                    {
                        list = list.Where(x => x.Status == 2).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("cancel"))
                    {
                        list = list.Where(x => x.Status == 3).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("approved"))
                    {
                        list = list.Where(x => x.Status == 4).ToList();
                    }
                    if (Status.Trim().ToLower().Equals("rejected"))
                    {
                        list = list.Where(x => x.Status == 5).ToList();
                    }
                    if (!HrInchange.Trim().Equals(""))
                    {
                        list = list.Where(x => x.HrInchange != null).ToList();
                        list = list.Where(x => x.HrInchangeNavigation.FullName.Contains(HrInchange)).ToList();
                    }
                    if (Quantity!=0)
                    {
                        list = list.Where(x => x.Number== Quantity).ToList();
                    }
                    if (CreateOn.Year!=1000)
                    {
                        list = list.Where(x => x.EffectDate?.ToString("dd/MM/YYYY")==CreateOn.ToString("dd/MM/YYYY")).ToList();
                    }
                    if (DeadLine.Year != 1000)
                    {
                        list = list.Where(x => x.ExpireDate?.ToString("dd/MM/YYYY") == DeadLine.ToString("dd/MM/YYYY")).ToList();
                    }
                    return list.Skip(index * size).Take(size).ToList();
                }
            }
            catch
            {
                return new List<RcRequest>();
            }
        }

        public List<RcRequest> GetChildRequestById(int ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<RcRequest> list = context.RcRequests.Where(x => x.ParentId == ID).OrderBy(x => x.Id).ToList();
                    foreach (var item in list)
                    {
                        item.Position = context.Positions.Where(x => x.Id == item.PositionId).FirstOrDefault();
                        item.Orgnization = context.Orgnizations.Where(x => x.Id == item.OrgnizationId).FirstOrDefault();
                        item.Sign = context.Employees.Where(x => x.Id == item.SignId).FirstOrDefault();
                        item.HrInchangeNavigation = context.Employees.Where(x => x.Id == item.HrInchange).FirstOrDefault();
                        item.OtherSkillNavigation = context.OtherLists.Where(x => x.Id == item.OtherSkill).FirstOrDefault();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<RcRequest>();
            }
        }

        public RcRequest GetRequestByID(int ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    RcRequest item = new RcRequest();
                    item = context.RcRequests.Where(x => x.Id == ID).FirstOrDefault();
                    item.Position = context.Positions.Where(x => x.Id == item.PositionId).FirstOrDefault();
                    item.TypeNavigation = context.OtherLists.Where(x => x.Id == item.Type).FirstOrDefault();
                    item.ProjectNavigation = context.OtherLists.Where(x => x.Id == item.Project).FirstOrDefault();
                    item.Orgnization = context.Orgnizations.Where(x => x.Id == item.OrgnizationId).FirstOrDefault();
                    item.Sign = context.Employees.Where(x => x.Id == item.SignId).FirstOrDefault();
                    item.LevelNavigation = context.OtherLists.Where(x => x.Id == item.Level).FirstOrDefault();
                    item.HrInchangeNavigation = context.Employees.Where(x => x.Id == item.HrInchange).FirstOrDefault();
                    item.OtherSkillNavigation = context.OtherLists.Where(x => x.Id == item.OtherSkill).FirstOrDefault();
                    return item;
                }
            }
            catch
            {
                return new RcRequest();
            }
        }

        public bool InsertRequest(RcRequest T)
        {
            RcRequest rc = new RcRequest();
            rc.Name = T.Name;
            rc.EffectDate = T.EffectDate;
            rc.ExpireDate = T.ExpireDate;
            rc.Number = T.Number;
            rc.OrgnizationId = T.OrgnizationId;
            rc.SignId = T.SignId;
            rc.Note = T.Note;
            rc.Number = T.Number;
            rc.YearExperience = T.YearExperience;
            rc.Project = T.Project;
            rc.PositionId = T.PositionId;
            rc.Type = T.Type;
            rc.Comment = T.Comment;
            rc.ParentId = T.ParentId;
            rc.Level = T.Level;
            rc.RequestLevel = T.RequestLevel;
            rc.Budget = T.Budget;
            rc.Status = T.Status;
            rc.Comment = T.Comment;
            rc.CreateDate = DateTime.Now;
            rc.CreateBy = T.CreateBy;
            rc.OtherSkill = T.OtherSkill;
            if (rc.ParentId != null && rc.ParentId > 0)
            {
                rc.Rank = GetRequestByID((int)rc.ParentId).Rank + 1;
            }
            else
            {
                rc.Rank = 1;
            }
            rc.Code = c.autoGenCode("Rc_Request", rc.Rank, "Rank", rc.ParentId);
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.RcRequests.Add(rc);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ModifyRequest(RcRequest T)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {

                    RcRequest rc = context.RcRequests.Where(x => x.Id == T.Id).FirstOrDefault();
                    rc.Name = T.Name;
                    rc.EffectDate = T.EffectDate;
                    rc.ExpireDate = T.ExpireDate;
                    rc.Number = T.Number;
                    rc.OrgnizationId = T.OrgnizationId;
                    rc.SignId = T.SignId;
                    rc.Note = T.Note;
                    rc.Number = T.Number;
                    rc.YearExperience = T.YearExperience;
                    rc.Project = T.Project;
                    rc.PositionId = T.PositionId;
                    rc.Type = T.Type;
                    rc.Comment = T.Comment;
                    rc.Level = T.Level;
                    rc.Budget = T.Budget;
                    rc.CreateDate = DateTime.Now;
                    rc.CreateBy = T.UpdateBy;
                    rc.HrInchange = T.HrInchange;
                    rc.OtherSkill = T.OtherSkill;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool SendComment(RcRequest T)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {

                    RcRequest rc = context.RcRequests.Where(x => x.Id == T.Id).FirstOrDefault();

                    rc.Comment = T.Comment;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool setHrInchange(RcRequest T)
        {

            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {

                    RcRequest rc = context.RcRequests.Where(x => x.Id == T.Id).FirstOrDefault();

                    rc.HrInchange = T.HrInchange;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<RcRequest> GetListRequestByID(int ID)
        {
            List<RcRequest> list = new List<RcRequest>();
            DataTable dt = DAOContext.GetListRequestByID(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RcRequest o = new RcRequest();
                DataRow row = dt.Rows[i];
                o.Id = Convert.ToInt32(row["ID"].ToString());
                o.Number = Convert.ToInt32(row["Number"].ToString());
                list.Add(o);
            }
            return list;
        }

        public int getTotalRequestRecord(string column, int? signID)
        {
            string query = "select count(*) COUNT from RC_Request where Rank=1 and " + column + " = " + signID;
            DataTable dt = DAOContext.GetDataBySql(query);
            DataRow lastRow = dt.Rows[0];
            int COUNT = Convert.ToInt32(lastRow["COUNT"]);
            return COUNT;
        }
    }
}
