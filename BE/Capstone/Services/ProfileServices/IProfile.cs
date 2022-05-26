﻿using CapstoneModels;
using Services.CommonModel;
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
        bool ResetPass(Account a, MailDTO mailDTO);

        #endregion


        #region "List"
        List<Nation> GetNationList(Nation T);
        bool InsertNation(Nation T);
        bool ModifyNation(Nation T);
        bool DeleteNation(List<int> list);
        bool ActiveOrDeActiveNation(List<int> list, int status);


        List<Province> GetProvinceListByNationID(Province T, int ID);
        bool InsertProvince(Province T);
        bool ModifyProvince(Province T);
        bool DeleteProvince(List<int> list);
        bool ActiveOrDeActiveProvince(List<int> list, int status);


        List<District> GetDistrictListByProvinceID(District T, int ID);
        bool InsertDistrict(District T);
        bool ModifyDistrict(District T);
        bool DeleteDistrict(List<int> list);
        bool ActiveOrDeActiveDistrict(List<int> list, int status);


        List<Ward> GetWardListByDistrictID(Ward T, int ID);
        bool InsertWard(Ward T);
        bool ModifyWard(Ward T);
        bool DeleteWard(List<int> list);
        bool ActiveOrDeActiveWard(List<int> list, int status);


        // dm loai HD
        List<Contract_Type> GetContractTypeList(Contract_Type T);
        bool InsertContractType(Contract_Type T);
        bool ModifyContractType(Contract_Type T);
        bool DeleteContractType(List<int> list);
        bool ActiveOrDeActiveContractType(List<int> list, int status);

        #endregion

    }
}