using CapstoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProfileServices
{
   public interface IProfile
    {
        #region Account

        #endregion

        #region Bussines

        #endregion

        #region list

        #region Nation
         bool InsertNation(Nation T);
         bool ModifyNation(Nation T);
         bool DeleteNation(List<int> list);
         bool ActiveOrDeActiveNation(List<int> list, int status);
        #endregion

        #region Province
         bool InsertProvince(Province T);
         bool ModifyProvince(Province T);
         bool DeleteProvince(List<int> list);
         bool ActiveOrDeActiveProvince(List<int> list, int status);
        #endregion

        #region District
         bool InsertDistrict(District T);
         bool ModifyDistrict(District T);
         bool DeleteDistrict(List<int> list);
         bool ActiveOrDeActiveDistrict(List<int> list, int status);
        #endregion

        #region Ward
         bool InsertWard(Ward T);
         bool ModifyWard(Ward T);
         bool DeleteWard(List<int> list);
         bool ActiveOrDeActiveWard(List<int> list, int status);
        #endregion

        #endregion
    }
}
