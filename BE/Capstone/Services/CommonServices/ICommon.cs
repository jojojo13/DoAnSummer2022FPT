using CapstoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommonServices
{
    interface ICommon
    {
        #region AUtoGen code
        public string autoGenCode3character(string tableName, string firstCode);
        public string autoGenCode4character(string tableName, string firstCode);
        #endregion

        #region GetByID
        public ORgnization getOrgByID(int id);
        public Title getTitleByID(int id);
        public Position getPositionByID(int id);
        #endregion

    }
}
