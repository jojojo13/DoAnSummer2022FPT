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

        #region other_list_type
        List<Other_List_Type> GetOtherListType();
        #endregion

        #region sendmail
        bool sendMail(MailDTO mail);
        #endregion

        #region "Ma hoa mat khau"
        string sha256_hash(string pass);
        #endregion

        public int getTotalPage(string tableName, int size);

    }
}
