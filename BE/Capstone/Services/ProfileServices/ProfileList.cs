using CapstoneModels;
using Services.CommonServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfileServices
{
   public partial class Profile : IProfile
    {

        #region Nation

        public List<Nation> GetNationList(Nation T)
        {
            try
            {
                using (Context context = new Context())
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
            ICommon c = new Common();
            try
            {
                Nation tobj = new Nation();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Nation", "QG");
                tobj.Status = -1;
                tobj.Note = T.Note;
                using (Context context = new Context())
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
                using (Context context = new Context())
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
                using (Context context = new Context())
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
                using (Context context = new Context())
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
                using (Context context = new Context())
                {
                    List<Province> list = context.Provinces.Where(x=>x.NationID==ID).ToList();
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
            ICommon c = new Common();
            try
            {
                Province tobj = new Province();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Province", "T/TP");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.NationID = T.NationID;
                using (Context context = new Context())
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
                using (Context context = new Context())
                {
                    Province tobj = context.Provinces.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.NationID = T.NationID;
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
                using (Context context = new Context())
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
                using (Context context = new Context())
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
                using (Context context = new Context())
                {
                    List<District> list = context.Districts.Where(x => x.ProvinceID == ID).ToList();
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
            ICommon c = new Common();
            try
            {
                District tobj = new District();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("District", "QH");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.ProvinceID = T.ProvinceID;
                using (Context context = new Context())
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
                using (Context context = new Context())
                {
                    District tobj = context.Districts.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.ProvinceID = T.ProvinceID;
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
                using (Context context = new Context())
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
                using (Context context = new Context())
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
                using (Context context = new Context())
                {
                    List<Ward> list = context.Wards.Where(x => x.DistrictID == ID).ToList();
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
            ICommon c = new Common();
            try
            {
                Ward tobj = new Ward();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Ward", "X/P");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.DistrictID = T.DistrictID;
                using (Context context = new Context())
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
                using (Context context = new Context())
                {
                    Ward tobj = context.Wards.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.DistrictID = T.DistrictID;
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
                using (Context context = new Context())
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
                using (Context context = new Context())
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
        public List<Contract_Type> GetContractTypeList(Contract_Type T){
            try
            {
                using (Context context = new Context())
                {
                    List<Contract_Type> list = context.ContractTypes.ToList();
                    if (T.Status.HasValue)
                    {
                        list = list.Where(x => x.Status == T.Status).ToList();
                    }
                    return list;
                }
            }
            catch
            {
                return new List<Contract_Type>();
            }
        }
        public bool InsertContractType(Contract_Type T){
            ICommon c = new Common();
            try
            {
                Contract_Type tobj = new Contract_Type();
                tobj.Name = T.Name;
                tobj.Code = c.autoGenCode3character("Contract_Type", "LHD");
                tobj.Status = -1;
                tobj.Note = T.Note;
                tobj.BHTN = T.BHTN;
                tobj.BHXH = T.BHXH;
                tobj.BHYT = T.BHYT;
                using (Context context = new Context())
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
        public bool ModifyContractType(Contract_Type T){
            try
            {
                using (Context context = new Context())
                {
                    Contract_Type tobj = context.ContractTypes.Where(x => x.Id == T.Id).FirstOrDefault();
                    tobj.Name = T.Name;
                    tobj.Note = T.Note;
                    tobj.BHTN = T.BHTN;
                    tobj.BHXH = T.BHXH;
                    tobj.BHYT = T.BHYT;
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
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        Contract_Type tobj = new Contract_Type();
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
                using (Context context = new Context())
                {
                    foreach (var item in list)
                    {
                        Contract_Type tobj = new Contract_Type();
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
