using ModelAuto;
using ModelAuto.Models;
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
        public bool ActiveOrDeActiveRequest(List<int> list, int status)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        List<int> ListRCID = new List<int>();
                        ListRCID = GetListRequestByID(item).Select(x => x.Id).ToList();
                        foreach(var rcId in ListRCID)
                        {
                            RcRequest tobj = new RcRequest();
                            tobj = context.RcRequests.Where(x => x.Id == rcId).FirstOrDefault();
                            tobj.Status = status;
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
                    List<RcRequest> list = context.RcRequests.Where(x=>x.Rank==1).ToList().OrderByDescending(x => x.Id).Skip(index * size).Take(size).OrderBy(x => x.Id).ToList();
                    foreach(var item in list)
                    {
                        item.Position = context.Positions.Where(x => x.Id == item.PositionId).FirstOrDefault();
                        item.TypeNavigation = context.OtherLists.Where(x => x.Id == item.Type).FirstOrDefault();
                        item.ProjectNavigation = context.OtherLists.Where(x => x.Id == item.Project).FirstOrDefault();
                        item.Orgnization = context.Orgnizations.Where(x => x.Id == item.OrgnizationId).FirstOrDefault();
                        item.Sign = context.Employees.Where(x => x.Id == item.SignId).FirstOrDefault();
                        item.RequestLevelNavigation = context.OtherLists.Where(x => x.Id == item.RequestLevel).FirstOrDefault();
                        item.LevelNavigation = context.OtherLists.Where(x => x.Id == item.Level).FirstOrDefault();
                        item.HrInchangeNavigation = context.Employees.Where(x => x.Id == item.HrInchange).FirstOrDefault();
                    }
                    return list;
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
                        item.TypeNavigation = context.OtherLists.Where(x => x.Id == item.Type).FirstOrDefault();
                        item.ProjectNavigation = context.OtherLists.Where(x => x.Id == item.Project).FirstOrDefault();
                        item.Orgnization = context.Orgnizations.Where(x => x.Id == item.OrgnizationId).FirstOrDefault();
                        item.Sign = context.Employees.Where(x => x.Id == item.SignId).FirstOrDefault();
                        item.RequestLevelNavigation = context.OtherLists.Where(x => x.Id == item.RequestLevel).FirstOrDefault();
                        item.LevelNavigation = context.OtherLists.Where(x => x.Id == item.Level).FirstOrDefault();
                        item.HrInchangeNavigation = context.Employees.Where(x => x.Id == item.HrInchange).FirstOrDefault();
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
                    item.RequestLevelNavigation = context.OtherLists.Where(x => x.Id == item.RequestLevel).FirstOrDefault();
                    item.LevelNavigation = context.OtherLists.Where(x => x.Id == item.Level).FirstOrDefault();
                    item.HrInchangeNavigation = context.Employees.Where(x => x.Id == item.HrInchange).FirstOrDefault();
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
            if (rc.ParentId!=null && rc.ParentId>0)
            {
                rc.Rank = GetRequestByID((int)rc.ParentId).Rank + 1;
            }
            else
            {
                rc.Rank = 1;
            }
            rc.Code = c.autoGenCode("Rc_Request", rc.Rank, "Rank",  rc.ParentId);
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
        public List<RcRequest> GetListRequestByID(int ID)
        {
            List<RcRequest> list = new List<RcRequest>();
            DataTable dt = DAOContext.GetListRequestByID(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                RcRequest o = new RcRequest();
                DataRow row = dt.Rows[i];
                o.Id = Convert.ToInt32(row["ID"].ToString());
                o.Number= Convert.ToInt32(row["Number"].ToString());
                list.Add(o);
            }
            return list;
        }

        public int getTotalRequestRecord(string column, int? signID)
        {
            string query= "select count(*) COUNT from RC_Request where Rank=1 and "+ column + " = "+signID;
            DataTable dt = DAOContext.GetDataBySql(query);
            DataRow lastRow = dt.Rows[0];
            int COUNT = Convert.ToInt32(lastRow["COUNT"]);
            return COUNT;
        }
    }
}
