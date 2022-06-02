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
        #region OTher_list
        public List<Other_List> GetOther_ListsCombo(string code)
        {
            try
            {
                using (Context context = new Context())
                {
                    Other_List_Type type = context.Other_Lists_Types.Where(x => x.Code.Trim().ToLower().Equals(code)).FirstOrDefault();
                    List<Other_List> list = context.Other_Lists.Where(x => x.TypeID == type.Id && x.Status == -1).ToList();
                    return list;
                }
            }
            catch
            {
                return new List<Other_List>();
            }
        }
        public bool InsertOther_List(Other_List T)
        {
            ICommon c = new Common();
            try
            {
                Other_List tobj = new Other_List();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode4character("Other_List", "TSHT");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.Atribute1 = T.Atribute1;
                tobj.Atribute2 = T.Atribute2;
                tobj.Atribute3 = T.Atribute3;
                using (Context context = new Context())
                {
                    context.Other_Lists.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyOther_List(Other_List T)
        {
            try
            {
                using (Context context = new Context())
                {
                    Other_List tobj = context.Other_Lists.Where(x => x.Id == T.Id).FirstOrDefault();
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
        public bool DeleteOther_List(List<int> list)
        {
            try
            {
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        Other_List tobj = new Other_List();
                        tobj = context.Other_Lists.Where(x => x.Id == item).FirstOrDefault();
                        context.Other_Lists.Remove(tobj);
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
        public bool ActiveOrDeActiveOther_List(List<int> list, int status)
        {
            try
            {
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        Other_List tobj = new Other_List();
                        tobj = context.Other_Lists.Where(x => x.Id == item).FirstOrDefault();
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

        #region"Title"
        public List<Title> GetAllTitle(int index, int size)
        {
            try
            {
                using (Context context = new Context())
                {
                    List<Title> list = context.Titles.ToList().Skip(index * size).Take(size).ToList();
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
             ICommon c = new Common();
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

        public List<Position> GetAllPosition(int index, int size)
        {
            try
            {
                using (Context context = new Context())
                {
                    List<Position> list = (List<Position>)context.Positions.ToList().Skip(index * size).Take(size);
                    foreach (var item in list)
                    {
                        item.Title = context.Titles.Where(x => x.Id == item.TitleID).FirstOrDefault();
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
             ICommon c = new Common();
            try
            {
                Position tobj = new Position();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Position", "VTCV");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.TitleID = T.TitleID;
                tobj.OtherSkill = T.OtherSkill;
                tobj.FormWorking = T.FormWorking;
                tobj.BasicSalary = T.BasicSalary;
                tobj.Learning_level = T.Learning_level;
                tobj.year_exp = T.year_exp;
                tobj.majorGroup = T.majorGroup;
                tobj.language = T.language;
                tobj.language_level = T.language_level;
                tobj.Information_level = T.Information_level;
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
                    tobj.OtherSkill = T.OtherSkill;
                    tobj.FormWorking = T.FormWorking;
                    tobj.BasicSalary = T.BasicSalary;
                    tobj.Learning_level = T.Learning_level;
                    tobj.year_exp = T.year_exp;
                    tobj.majorGroup = T.majorGroup;
                    tobj.language = T.language;
                    tobj.language_level = T.language_level;
                    tobj.Information_level = T.Information_level;
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



    }
}
