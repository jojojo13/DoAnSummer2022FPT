using CapstoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrgnizationServiecs
{
    interface IOrgnization
    {
        #region List

        #region"Title"
        public List<Title> GetAllTitle(Title T, int index, int size);
        public bool InsertTitle(Title T);
        public bool ModifyTitle(Title T);
        public bool DeleteTitle(List<int> list);
        public bool ActiveOrDeActiveTitle(List<int> list, int status);
        #endregion

        #region"Position"
        public List<Position> GetAllPosition(Position T, int index, int size);
        public bool InsertPosition(Position T);
        public bool ModifyPosition(Position T);
        public bool DeletePosition(List<int> list);
        public bool ActiveOrDeActivePosition(List<int> list, int status);
        #endregion


        #endregion

        #region business
        #region"Org"

        public List<ORgnization> GetAllORgnization(ORgnization T);
        public bool InsertOrg(ORgnization T);
        public bool ModifyOrg(ORgnization T);
        public bool DeleteOrg(int orgID);
        public bool ActiveOrDeActiveOrg(int orgID, int status);

        #endregion
        #endregion
    }
}
