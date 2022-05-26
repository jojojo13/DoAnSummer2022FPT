using CapstoneModels;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrgnizationServiecs
{
    partial class Orgnization : IOrgnization
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

        public List<ORgnization> GetAllORgnization(ORgnization T)
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
    }
}
