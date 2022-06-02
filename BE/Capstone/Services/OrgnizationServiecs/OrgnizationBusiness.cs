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
        #region"Org"
        public bool InsertOrg(ORgnization o)
        {
            ICommon c = new Common();
            try
            {
                ORgnization obj = new ORgnization();
                obj.Name = o.Name;
                obj.Code = c.autoGenCode3character("ORgnization", "ORG");
                obj.ParentID = o.ParentID;
                if (!o.ParentID.HasValue)
                {
                    obj.Level = c.getOrgByID((int)o.ParentID).Level + 1;
                }
                else
                {
                    obj.Level = 1;
                }
                obj.CreateDate = o.CreateDate;
                obj.DissolutionDate = o.DissolutionDate;
                obj.Status = o.Status;
                obj.Note = o.Note;
                obj.Fax = o.Fax;
                obj.Email = o.Email;
                obj.Mobile = o.Mobile;
                obj.NumberBussines = o.NumberBussines;
                obj.Address = o.Address;
                obj.DistrictID = o.DistrictID;
                obj.WardID = o.WardID;
                obj.ProvinceID = o.ProvinceID;
                obj.NationID = o.NationID;
                obj.ManagerID = o.ManagerID;
                using (Context context = new Context())
                {
                    context.ORgnizations.Add(obj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyOrg(ORgnization o)
        {
            try
            {
                using (Context context = new Context())
                {
                    ORgnization obj = context.ORgnizations.Where(x => x.Id == o.Id).FirstOrDefault();
                    obj.Name = o.Name;
                    obj.CreateDate = o.CreateDate;
                    obj.DissolutionDate = o.DissolutionDate;
                    obj.Status = o.Status;
                    obj.Note = o.Note;
                    obj.Fax = o.Fax;
                    obj.Email = o.Email;
                    obj.Mobile = o.Mobile;
                    obj.NumberBussines = o.NumberBussines;
                    obj.Address = o.Address;
                    obj.DistrictID = o.DistrictID;
                    obj.WardID = o.WardID;
                    obj.ProvinceID = o.ProvinceID;
                    obj.NationID = o.NationID;
                    obj.ManagerID = o.ManagerID;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteOrg(int orgID)
        {
            try
            {
                using (Context context = new Context())
                {
                    ORgnization tobj = new ORgnization();
                    tobj = context.ORgnizations.Where(x => x.Id == orgID).FirstOrDefault();
                    context.ORgnizations.Remove(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ActiveOrDeActiveOrg(int orgID, int status)
        {
            try
            {
                using (Context context = new Context())
                {
                    ORgnization tobj = new ORgnization();
                    tobj = context.ORgnizations.Where(x => x.Id == orgID).FirstOrDefault();
                    tobj.Status = status;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<ORgnization> GetAllORgnization()
        {
            try
            {
                using (Context context = new Context())
                {
                    List<ORgnization> list = context.ORgnizations.ToList();
                    return list;
                }
            }
            catch
            {
                return new List<ORgnization>();
            }
        }

        #endregion

        #region Thiet lap vi tri cong viec cho phong ban

        public List<PositionOrg> GetAllPositionOrg( int index, int size)
        {
            try
            {
                using (Context context = new Context())
                {
                    List<PositionOrg> list = (List<PositionOrg>)context.PositionOrgs.ToList().Skip(index * size).Take(size);
                    foreach (var item in list)
                    {
                        item.oRgnization = context.ORgnizations.Where(x => x.Id == item.OrgID).FirstOrDefault();
                        item.position = context.Positions.Where(x => x.Id == item.positionID).FirstOrDefault();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<PositionOrg>();
            }
        }
        public bool InsertPositionOrg(PositionOrg T)
        {
            try
            {
                PositionOrg tobj = new PositionOrg();
                tobj.positionID = T.positionID;
                tobj.Status = -1;
                tobj.OrgID = T.OrgID;
                using (Context context = new Context())
                {
                    context.PositionOrgs.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyPositionOrg(PositionOrg T)
        {
            try
            {
                using (Context context = new Context())
                {
                    PositionOrg tobj = context.PositionOrgs.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.positionID = T.positionID;
                    tobj.OrgID = T.OrgID;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeletePositionOrg(List<int> list)
        {
            try
            {
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        PositionOrg tobj = new PositionOrg();
                        tobj = context.PositionOrgs.Where(x => x.Id == item).FirstOrDefault();
                        context.PositionOrgs.Remove(tobj);
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
        public bool ActiveOrDeActivePositionOrg(List<int> list, int status)
        {
            try
            {
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        PositionOrg tobj = new PositionOrg();
                        tobj = context.PositionOrgs.Where(x => x.Id == item).FirstOrDefault();
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
