
using ModelAuto;
using ModelAuto.Models;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrgnizationServiecs
{
    public partial class OrgnizationImpl : IOrgnization
    {
        #region"Org"
        public bool InsertOrg(Orgnization o)
        {
            ICommon c = new CommonImpl();
            try
            {
                Orgnization obj = new Orgnization();
                obj.Name = o.Name;
                obj.Code = c.autoGenCode3character("Orgnization", "ORG");
                obj.ParentId = o.ParentId;
                if (!o.ParentId.HasValue)
                {
                    obj.Level = c.getOrgByID((int)o.ParentId).Level + 1;
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
                obj.Phone = o.Phone;
                obj.NumberBussines = o.NumberBussines;
                obj.Address = o.Address;
                obj.DistrictId = o.DistrictId;
                obj.WardId = o.WardId;
                obj.ProvinceId = o.ProvinceId;
                obj.NationId = o.NationId;
                obj.ManagerId = o.ManagerId;
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.Orgnizations.Add(obj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyOrg(Orgnization o)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Orgnization obj = context.Orgnizations.Where(x => x.Id == o.Id).FirstOrDefault();
                    obj.Name = o.Name;
                    obj.CreateDate = o.CreateDate;
                    obj.DissolutionDate = o.DissolutionDate;
                    obj.Status = o.Status;
                    obj.Note = o.Note;
                    obj.Fax = o.Fax;
                    obj.Email = o.Email;
                    obj.Phone = o.Phone;
                    obj.NumberBussines = o.NumberBussines;
                    obj.Address = o.Address;
                    obj.DistrictId = o.DistrictId;
                    obj.WardId = o.WardId;
                    obj.ProvinceId = o.ProvinceId;
                    obj.NationId = o.NationId;
                    obj.ManagerId = o.ManagerId;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteOrg(int OrgId)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Orgnization tobj = new Orgnization();
                    tobj = context.Orgnizations.Where(x => x.Id == OrgId).FirstOrDefault();
                    context.Orgnizations.Remove(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ActiveOrDeActiveOrg(int OrgId, int status)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Orgnization tobj = new Orgnization();
                    tobj = context.Orgnizations.Where(x => x.Id == OrgId).FirstOrDefault();
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

        public List<Orgnization> GetAllOrgnization()
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<Orgnization> list = context.Orgnizations.ToList();
                    return list;
                }
            }
            catch
            {
                return new List<Orgnization>();
            }
        }

        public List<Orgnization> GetListOrgByOrgID(int ID)
        {
               
                List<Orgnization> list = new List<Orgnization>();
                DataTable dt = DAOContext.GetListOrgbyOrgID(ID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Orgnization o = new Orgnization();
                    DataRow row = dt.Rows[i];
                    o.Name = row["ORG_NAME"].ToString();
                    o.Code = row["CODE"].ToString();
                    o.Id = Convert.ToInt32(row["ID"].ToString());
                    o.Level= Convert.ToInt32(row["LEVEL_NAME"].ToString());
                    o.ParentId = Convert.ToInt32(row["ParentID"].ToString());
                    list.Add(o);
                }
                return list;

        }

        #endregion

        #region Thiet lap vi tri cong viec cho phong ban

        public List<PositionOrg> GetAllPositionOrg(int index, int size)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<PositionOrg> list = (List<PositionOrg>)context.PositionOrgs.ToList().Skip(index * size).Take(size);
                    foreach (var item in list)
                    {
                        item.Org = context.Orgnizations.Where(x => x.Id == item.OrgId).FirstOrDefault();
                        item.Position = context.Positions.Where(x => x.Id == item.PositionId).FirstOrDefault();
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
                tobj.PositionId = T.PositionId;
                tobj.Status = -1;
                tobj.OrgId = T.OrgId;
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
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
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    PositionOrg tobj = context.PositionOrgs.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.PositionId = T.PositionId;
                    tobj.OrgId = T.OrgId;
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
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
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
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
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
