using ModelAuto.Models;
using Services.CommonServices;
using System;
using System.Collections.Generic;
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
                        RcRequest tobj = new RcRequest();
                        tobj = context.RcRequests.Where(x => x.Id == item).FirstOrDefault();
                        tobj.Status = status;
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
                    List<RcRequest> list = context.RcRequests.ToList().Skip(index * size).Take(size).ToList();
                    foreach(var item in list)
                    {
                        item.Position = context.Positions.Where(x => x.Id == item.PositionId).FirstOrDefault();
                        item.TypeNavigation = context.OtherLists.Where(x => x.Id == item.Type).FirstOrDefault();
                        item.ProjectNavigation = context.OtherLists.Where(x => x.Id == item.Project).FirstOrDefault();
                        item.Orgnization = context.Orgnizations.Where(x => x.Id == item.OrgnizationId).FirstOrDefault();
                        item.Sign = context.Employees.Where(x => x.Id == item.SignId).FirstOrDefault();
                        item.RequestLevelNavigation = context.OtherLists.Where(x => x.Id == item.RequestLevel).FirstOrDefault();
                        item.LevelNavigation = context.OtherLists.Where(x => x.Id == item.Level).FirstOrDefault();
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
                    RcRequest tobj = new RcRequest();
                    tobj = context.RcRequests.Where(x => x.Id == ID).FirstOrDefault();
                    return tobj;
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
            rc.Code = c.autoGenCode3character("RcRequest", "RC");
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
            rc.Budget = T.Budget;
            if (!rc.ParentId.HasValue)
            {
                rc.Rank = c.GetRequestByID((int)rc.ParentId).Rank + 1;
            }
            else
            {
                rc.Rank = 1;
            }
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
