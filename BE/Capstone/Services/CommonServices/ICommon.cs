using CapstoneModels;
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

    }
}
