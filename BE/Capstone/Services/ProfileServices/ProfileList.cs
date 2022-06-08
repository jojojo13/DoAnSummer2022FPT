using ModelAuto.Models;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfileServices
{
    public partial class ProfileImpl : IProfile
    {

        #region Nation

        public List<Nation> GetNationList(Nation T)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<Nation> list = context.Nations.ToList();
                    if (T.Status.HasValue)
                    {
                        list = list.Where(x => x.Status == T.Status).ToList();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<Nation>();
            }
        }
        public bool InsertNation(Nation T)
        {
            ICommon c = new CommonImpl();
            try
            {
                Nation tobj = new Nation();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Nation", "QG");
                tobj.Status = -1;
                tobj.Note = T.Note;
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.Nations.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyNation(Nation T)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Nation tobj = context.Nations.Where(x => x.Id == T.Id).FirstOrDefault();
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
        public bool DeleteNation(List<int> list)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Nation tobj = new Nation();
                        tobj = context.Nations.Where(x => x.Id == item).FirstOrDefault();
                        context.Nations.Remove(tobj);
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
        public bool ActiveOrDeActiveNation(List<int> list, int status)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Nation tobj = new Nation();
                        tobj = context.Nations.Where(x => x.Id == item).FirstOrDefault();
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

        #region Province

        public List<Province> GetProvinceListByNationID(Province T, int ID)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<Province> list = context.Provinces.Where(x=>x.NationId==ID).ToList();
                    if (T.Status.HasValue)
                    {
                        list = list.Where(x => x.Status == T.Status).ToList();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<Province>();
            }
        }
        public bool InsertProvince(Province T)
        {
            ICommon c = new CommonImpl();
            try
            {
                Province tobj = new Province();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Province", "T/TP");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.NationId = T.NationId;
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.Provinces.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyProvince(Province T)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Province tobj = context.Provinces.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.NationId = T.NationId;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteProvince(List<int> list)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Province tobj = new Province();
                        tobj = context.Provinces.Where(x => x.Id == item).FirstOrDefault();
                        context.Provinces.Remove(tobj);
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
        public bool ActiveOrDeActiveProvince(List<int> list, int status)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Province tobj = new Province();
                        tobj = context.Provinces.Where(x => x.Id == item).FirstOrDefault();
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

        #region District

        public List<District> GetDistrictListByProvinceID(District T, int ID)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<District> list = context.Districts.Where(x => x.ProvinceId == ID).ToList();
                    if (T.Status.HasValue)
                    {
                        list = list.Where(x => x.Status == T.Status).ToList();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<District>();
            }
        }

        public bool InsertDistrict(District T)
        {
            ICommon c = new CommonImpl();
            try
            {
                District tobj = new District();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("District", "QH");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.ProvinceId = T.ProvinceId;
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.Districts.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyDistrict(District T)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    District tobj = context.Districts.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.ProvinceId = T.ProvinceId;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteDistrict(List<int> list)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        District tobj = new District();
                        tobj = context.Districts.Where(x => x.Id == item).FirstOrDefault();
                        context.Districts.Remove(tobj);
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
        public bool ActiveOrDeActiveDistrict(List<int> list, int status)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        District tobj = new District();
                        tobj = context.Districts.Where(x => x.Id == item).FirstOrDefault();
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

        #region Ward

        public List<Ward> GetWardListByDistrictID(Ward T, int ID)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<Ward> list = context.Wards.Where(x => x.DistrictId == ID).ToList();
                    if (T.Status.HasValue)
                    {
                        list = list.Where(x => x.Status == T.Status).ToList();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<Ward>();
            }
        }
        public bool InsertWard(Ward T)
        {
            ICommon c = new CommonImpl();
            try
            {
                Ward tobj = new Ward();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Ward", "X/P");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.DistrictId = T.DistrictId;
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.Wards.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyWard(Ward T)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    Ward tobj = context.Wards.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.DistrictId = T.DistrictId;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteWard(List<int> list)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Ward tobj = new Ward();
                        tobj = context.Wards.Where(x => x.Id == item).FirstOrDefault();
                        context.Wards.Remove(tobj);
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
        public bool ActiveOrDeActiveWard(List<int> list, int status)
        {
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        Ward tobj = new Ward();
                        tobj = context.Wards.Where(x => x.Id == item).FirstOrDefault();
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

        #region DM loai hop dong
        public List<ContractType> GetContractTypeList(ContractType T){
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<ContractType> list = context.ContractTypes.ToList();
                    if (T.Status.HasValue)
                    {
                        list = list.Where(x => x.Status == T.Status).ToList();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<ContractType>();
            }
        }
        public bool InsertContractType(ContractType T){
            ICommon c = new CommonImpl();
            try
            {
                ContractType tobj = new ContractType();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("ContractType", "LHD");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.Bhtn = T.Bhtn;
                tobj.Bhxh = T.Bhxh;
                tobj.Bhyt = T.Bhyt;
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    context.ContractTypes.Add(tobj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ModifyContractType(ContractType T){
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    ContractType tobj = context.ContractTypes.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.Bhtn = T.Bhtn;
                    tobj.Bhxh = T.Bhxh;
                    tobj.Bhyt = T.Bhyt;
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteContractType(List<int> list){
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        ContractType tobj = new ContractType();
                        tobj = context.ContractTypes.Where(x => x.Id == item).FirstOrDefault();
                        context.ContractTypes.Remove(tobj);
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
        public bool ActiveOrDeActiveContractType(List<int> list, int status){
            try
            {
                 using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    foreach (var item in list)
                    {
                        ContractType tobj = new ContractType();
                        tobj = context.ContractTypes.Where(x => x.Id == item).FirstOrDefault();
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
