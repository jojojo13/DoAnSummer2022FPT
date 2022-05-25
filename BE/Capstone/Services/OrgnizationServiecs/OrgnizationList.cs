using CapstoneModels;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrgnizationServiecs
{
    public partial class Orgnization : IOrgnization
    {
        #region "List"

        #region"Title"
        public List<Title> GetAllTitle(Title T, int index, int size)
        {
            try
            {
                using (Context context = new Context())
                {
                    List<Title> list = context.Titles.ToList().Skip(index*size).Take(size).ToList();
                    if (!T.Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Name.ToLower().Contains(T.Name.Trim().ToLower())).ToList();
                    }
                    if (!T.Code.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Code.ToLower().Contains(T.Code.Trim().ToLower())).ToList();
                    }
                    if (T.Status.HasValue)
                    {
                        list = list.Where(x => x.Status== T.Status).ToList();
                    }
                    if (!T.Note.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Note.ToLower().Contains(T.Note.Trim().ToLower())).ToList();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<Title>();
            }
        }
        public bool InsertTitle(Title T)
        {
            Common c = new Common();
            try
            {
                Title tobj = new Title();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Title", "CD");
                tobj.Status = -1;
                tobj.Note = T.Note;
                using (Context context = new Context())
                {
                    context.Titles.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyTitle(Title T)
        {
            try
            {
                using (Context context = new Context())
                {
                    Title tobj = context.Titles.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteTitle(List<int> list)
        {
            try
            {
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        Title tobj = new Title();
                        tobj = context.Titles.Where(x => x.Id == item).FirstOrDefault();
                        context.Titles.Remove(tobj);
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
        public bool ActiveOrDeActiveTitle(List<int> list, int status)
        {
            try
            {
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        Title tobj = new Title();
                        tobj = context.Titles.Where(x => x.Id == item).FirstOrDefault();
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
        #endregion



        #region"Position"

        public List<Position> GetAllPosition(Position T, int index, int size)
        {
            try
            {
                using (Context context = new Context())
                {
                    List<Position> list = (List<Position>)context.Positions.ToList().Skip(index * size).Take(size);
                    foreach(var item in list)
                    {
                        item.Title = context.Titles.Where(x => x.Id == item.TitleID).FirstOrDefault();
                        item.Organization = context.ORgnizations.Where(x => x.Id == item.OrgID).FirstOrDefault();
                    }

                    if (!T.Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Name.ToLower().Contains(T.Name.Trim().ToLower())).ToList();
                    }
                    if (!T.Code.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Code.ToLower().Contains(T.Code.Trim().ToLower())).ToList();
                    }
                    if (T.Status.HasValue)
                    {
                        list = list.Where(x => x.Status == T.Status).ToList();
                    }
                    if (!T.Note.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Note.ToLower().Contains(T.Note.Trim().ToLower())).ToList();
                    }
                    if (!T.OtherSkill.Trim().Equals(""))
                    {
                        list = list.Where(x => x.OtherSkill.ToLower().Contains(T.OtherSkill.Trim().ToLower())).ToList();
                    }
                    if (T.BasicSalary.HasValue)
                    {
                        list = list.Where(x => x.BasicSalary == T.BasicSalary).ToList();
                    }
                    if (T.FormWorking.HasValue)
                    {
                        list = list.Where(x => x.FormWorking == T.FormWorking).ToList();
                    }
                    if (!T.Title.Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Title.Name.ToLower().Contains(T.Title.Name.Trim().ToLower())).ToList();
                    }
                    if (!T.Organization.Name.Trim().Equals(""))
                    {
                        list = list.Where(x => x.Organization.Name.ToLower().Contains(T.Organization.Name.Trim().ToLower())).ToList();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<Position>();
            }
        }

        public bool InsertPosition(Position T)
        {
            Common c = new Common();
            try
            {
                Position tobj = new Position();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Position", "VTCV");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.OrgID = T.OrgID;
                tobj.TitleID = T.TitleID;
                tobj.OtherSkill = T.OtherSkill;
                tobj.FormWorking = T.FormWorking;
                tobj.BasicSalary = T.BasicSalary;
                using (Context context = new Context())
                {
                    context.Positions.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyPosition(Position T)
        {
            try
            {
                using (Context context = new Context())
                {
                    Position tobj = context.Positions.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.TitleID = T.TitleID;
                    tobj.OtherSkill = T.OtherSkill;
                    tobj.FormWorking = T.FormWorking;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeletePosition(List<int> list)
        {
            try
            {
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        Position tobj = new Position();
                        tobj = context.Positions.Where(x => x.Id == item).FirstOrDefault();
                        context.Positions.Remove(tobj);
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
        public bool ActiveOrDeActivePosition(List<int> list, int status)
        {
            try
            {
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        Position tobj = new Position();
                        tobj = context.Positions.Where(x => x.Id == item).FirstOrDefault();
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
        #endregion


        #endregion
    }
}
