﻿using ModelAuto.Models;
using Services.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
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
        bool ResetPass(string userName, MailDTO mailobj);

        #endregion


        #region "List"


        #region "DM dia diem, dia chi"
        List<Nation> GetNationList();
        bool InsertNation(Nation T);
        bool ModifyNation(Nation T);
        bool DeleteNation(List<int> list);
        bool ActiveOrDeActiveNation(List<int> list, int status);


        List<Province> GetProvinceListByNationID(int ID);
        bool InsertProvince(Province T);
        bool ModifyProvince(Province T);
        bool DeleteProvince(List<int> list);
        bool ActiveOrDeActiveProvince(List<int> list, int status);


        List<District> GetDistrictListByProvinceID(int ID);
        bool InsertDistrict(District T);
        bool ModifyDistrict(District T);
        bool DeleteDistrict(List<int> list);
        bool ActiveOrDeActiveDistrict(List<int> list, int status);


        List<Ward> GetWardListByDistrictID(int ID);
        bool InsertWard(Ward T);
        bool ModifyWard(Ward T);
        bool DeleteWard(List<int> list);
        bool ActiveOrDeActiveWard(List<int> list, int status);

        #endregion

        #region dm loai HD
        List<ContractType> GetContractTypeList(int index, int size);
        bool InsertContractType(ContractType T);
        bool ModifyContractType(ContractType T);
        bool DeleteContractType(List<int> list);
        bool ActiveOrDeActiveContractType(List<int> list, int status);
        List<ContractType> GetAllContractTypeList(int index, int size);
        #endregion


        #endregion


        #region "Business"

        List<Position> GetListPositionByOrgID(int ID);
        List<Employee> GetListEmployeeByOrgID(int OrgID, int index, int size);
        Employee GetEmployeeByID(int? ID);
        int getTotalEmployee(int OrgID);

        #endregion

    }
}