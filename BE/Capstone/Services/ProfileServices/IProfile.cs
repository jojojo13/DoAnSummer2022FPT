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

        #region "Account"
        Account GetAccount(Account a);
        bool ChangePass(Account a);
        #endregion



        public bool InsertNation(Nation T);
        public bool ModifyNation(Nation T);
        public bool DeleteNation(List<int> list);
        public bool ActiveOrDeActiveNation(List<int> list, int status);



        public bool InsertProvince(Province T);
        public bool ModifyProvince(Province T);
        public bool DeleteProvince(List<int> list);
        public bool ActiveOrDeActiveProvince(List<int> list, int status);



        public bool InsertDistrict(District T);
        public bool ModifyDistrict(District T);
        public bool DeleteDistrict(List<int> list);
        public bool ActiveOrDeActiveDistrict(List<int> list, int status);



        public bool InsertWard(Ward T);
        public bool ModifyWard(Ward T);
        public bool DeleteWard(List<int> list);
        public bool ActiveOrDeActiveWard(List<int> list, int status);



    }
}
