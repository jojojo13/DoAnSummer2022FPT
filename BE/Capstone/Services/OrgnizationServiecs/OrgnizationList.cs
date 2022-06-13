
using ModelAuto.Models;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrgnizationServiecs
{
    public partial class OrgnizationImpl : IOrgnization
    {


        #region"Title"
        public List<Title> GetAllTitle(int index, int size)
        {
            try
            {
                  using (CapstoneProject2022Context context = new CapstoneProject2022Context())
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
             ICommon c = new CommonImpl();
            try
            {
                Title tobj = new Title();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Title", "CD");
                tobj.Status = -1;
                tobj.Note = T.Note;
                  using (CapstoneProject2022Context context = new CapstoneProject2022Context())
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
                  using (CapstoneProject2022Context context = new CapstoneProject2022Context())
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
                  using (CapstoneProject2022Context context = new CapstoneProject2022Context())
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
                  using (CapstoneProject2022Context context = new CapstoneProject2022Context())
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
                  using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<Position> list = (List<Position>)context.Positions.ToList().Skip(index * size).Take(size);
                    foreach (var item in list)
                    {
                        item.Title = context.Titles.Where(x => x.Id == item.TitleId).FirstOrDefault();
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
             ICommon c = new CommonImpl();
            try
            {
                Position tobj = new Position();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Position", "VTCV");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.TitleId = T.TitleId;
                tobj.OtherSkill = T.OtherSkill;
                tobj.FormWorking = T.FormWorking;
                tobj.BasicSalary = T.BasicSalary;
                tobj.LearningLevel = T.LearningLevel;
                tobj.YearExperience = T.YearExperience;
                tobj.MajorGroup = T.MajorGroup;
                tobj.Language = T.Language;
                tobj.LanguageLevel = T.LanguageLevel;
                tobj.InformationLevel = T.InformationLevel;
                  using (CapstoneProject2022Context context = new CapstoneProject2022Context())
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
                  using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Position tobj = context.Positions.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.TitleId = T.TitleId;
                    tobj.OtherSkill = T.OtherSkill;
                    tobj.FormWorking = T.FormWorking;
                    tobj.OtherSkill = T.OtherSkill;
                    tobj.FormWorking = T.FormWorking;
                    tobj.BasicSalary = T.BasicSalary;
                    tobj.LearningLevel = T.LearningLevel;
                    tobj.YearExperience = T.YearExperience;
                    tobj.MajorGroup = T.MajorGroup;
                    tobj.Language = T.Language;
                    tobj.LanguageLevel = T.LanguageLevel;
                    tobj.InformationLevel = T.InformationLevel;
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
                  using (CapstoneProject2022Context context = new CapstoneProject2022Context())
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
                  using (CapstoneProject2022Context context = new CapstoneProject2022Context())
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
