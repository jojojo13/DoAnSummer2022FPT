using CapstoneModels;
using Services.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommonServices
{
   public interface ICommon
    {
        #region AUtoGen code
         string autoGenCode3character(string tableName, string firstCode);
         string autoGenCode4character(string tableName, string firstCode);
        #endregion

        #region GetByID
         ORgnization getOrgByID(int id);
         Title getTitleByID(int id);
         Position getPositionByID(int id);
        #endregion

        #region other_list
        bool InsertOther_List(Other_List T);
        bool ModifyOther_List(Other_List T);
        bool DeleteOther_List(List<int> list);
        bool ActiveOrDeActiveOther_List(List<int> list, int status);
        List<Other_List_Type> GetOtherListType();
        List<Other_List> GetOther_ListsCombo(string code);
        #endregion

        #region sendmail
        bool sendMail(MailDTO mail);
        #endregion

        #region "Ma hoa mat khau"
        string sha256_hash(string pass);
        #endregion

    }
}
