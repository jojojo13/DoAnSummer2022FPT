using CapstoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestServices
{
    public class Request : IRequest
    {
        public bool ActiveOrDeActiveRequest(List<int> list, int status)
        {
            try
            {
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        Rc_Request tobj = new Rc_Request();
                        tobj = context.Rc_Requests.Where(x => x.Id == item).FirstOrDefault();
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
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        Rc_Request tobj = new Rc_Request();
                        tobj = context.Rc_Requests.Where(x => x.Id == item).FirstOrDefault();
                        context.Rc_Requests.Remove(tobj);
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

        public List<Rc_Request> GetAllRequest(Rc_Request T, int index, int size)
        {

            try
            {
                using (Context context = new Context())
                {
                    List<Rc_Request> list = context.Rc_Requests.ToList().Skip(index * size).Take(size).ToList();
                    foreach(var item in list)
                    {
                        item.position = context.Positions.Where(x => x.Id == item.PositionID).FirstOrDefault();
                        item.Other_List2 = context.Other_Lists.Where(x => x.Id == item.Type).FirstOrDefault();
                        item.Other_List3 = context.Other_Lists.Where(x => x.Id == item.Project).FirstOrDefault();
                        item.oRgnization = context.ORgnizations.Where(x => x.Id == item.OrgId).FirstOrDefault();
                        item.employee = context.Employees.Where(x => x.Id == item.SignId).FirstOrDefault();
                    }
                    if (!T.Code.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Code.ToLower().Contains(T.Code.ToLower())).ToList();
                    }
                    if (!T.Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Name.ToLower().Contains(T.Name.ToLower())).ToList();
                    }
                    if (T.EffectDate.HasValue)
                    {
                        list = list.Where(x => x.EffectDate== T.EffectDate).ToList();
                    }
                    if (T.ExpireDate.HasValue)
                    {
                        list = list.Where(x => x.ExpireDate == T.ExpireDate).ToList();
                    }
                    if (T.OrgId.HasValue)
                    {
                        list = list.Where(x => x.OrgId == T.OrgId).ToList();
                    }
                    if (T.SignId.HasValue)
                    {
                        list = list.Where(x => x.SignId == T.SignId).ToList();
                    }
                    if (T.SignDate.HasValue)
                    {
                        list = list.Where(x => x.SignDate == T.SignDate).ToList();
                    }
                    if (!T.Note.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Note.ToLower().Contains(T.Note.ToLower())).ToList();
                    }
                    if (!T.Comment.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Comment.ToLower().Contains(T.Comment.ToLower())).ToList();
                    }
                    if (T.Status.HasValue)
                    {
                        list = list.Where(x => x.Status == T.Status).ToList();
                    }
                    if (T.Type.HasValue)
                    {
                        list = list.Where(x => x.Type == T.Type).ToList();
                    }
                    if (!T.Other_List2.Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Other_List2.Name.ToLower().Contains(T.Other_List2.Name.ToLower())).ToList();
                    }
                    if (T.Number.HasValue)
                    {
                        list = list.Where(x => x.Number == T.Number).ToList();
                    }
                    if (!T.Exp.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Exp.ToLower().Contains(T.Exp.ToLower())).ToList();
                    }
                    if (!T.Other_List3.Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Other_List3.Name.ToLower().Contains(T.Other_List3.Name.ToLower())).ToList();
                    }
                    if (T.Project.HasValue)
                    {
                        list = list.Where(x => x.Project == T.Project).ToList();
                    }
                    if (T.PositionID.HasValue)
                    {
                        list = list.Where(x => x.PositionID == T.PositionID).ToList();
                    }
                    if (!T.position.Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.position.Name.ToLower().Contains(T.position.Name.ToLower())).ToList();
                    }
                    if (!T.employee.FullName.Trim().Equals(""))
                    {
                        list = list.Where(x => x.employee.FullName.ToLower().Contains(T.employee.FullName.ToLower())).ToList();
                    }
                    if (!T.oRgnization.Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.oRgnization.Name.ToLower().Contains(T.oRgnization.Name.ToLower())).ToList();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<Rc_Request>();
            }
         
        }

        public Rc_Request GetRequestByID(int ID)
        {
            try
            {
                using (Context context = new Context())
                {
                    Rc_Request tobj = new Rc_Request();
                    tobj = context.Rc_Requests.Where(x => x.Id == ID).FirstOrDefault();
                    return tobj;
                }
            }
            catch
            {
                return new Rc_Request();
            }
        }

        public bool InsertRequest(Rc_Request T)
        {
            Rc_Request rc = new Rc_Request();
            rc.Name = T.Name;
            rc.Code = T.Code;
            rc.EffectDate = T.EffectDate;
            rc.Exp = T.Exp;
            rc.ExpireDate = T.ExpireDate;
            rc.Number = T.Number;
            rc.OrgId = T.OrgId;
            rc.SignId = T.SignId;
            rc.SignDate = T.SignDate;
            rc.Note = T.Note;
            rc.Status = T.Status;
            rc.Number = T.Number;
            rc.Exp = T.Exp;
            rc.Project = T.Project;
            rc.PositionID = T.PositionID;
            rc.Type = T.Type;
            rc.Comment = T.Comment;
            try
            {
                using (Context context = new Context())
                {
                    context.Rc_Requests.Add(rc);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ModifyRequest(Rc_Request T)
        {
           
            try
            {
                using (Context context = new Context())
                {

                    Rc_Request rc = context.Rc_Requests.Where(x => x.Id == T.Id).FirstOrDefault();
                    rc.Name = T.Name;
                    rc.EffectDate = T.EffectDate;
                    rc.Exp = T.Exp;
                    rc.ExpireDate = T.ExpireDate;
                    rc.Number = T.Number;
                    rc.OrgId = T.OrgId;
                    rc.SignId = T.SignId;
                    rc.SignDate = T.SignDate;
                    rc.Note = T.Note;
                    rc.Status = T.Status;
                    rc.Number = T.Number;
                    rc.Exp = T.Exp;
                    rc.Project = T.Project;
                    rc.PositionID = T.PositionID;
                    rc.Type = T.Type;
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
    }
}
