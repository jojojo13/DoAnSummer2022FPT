using CapstoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.OrgnizationServiecs
{
    public interface IOrgnization
    {
        #region List

        #region"Title"
         List<Title> GetAllTitle(Title T, int index, int size);
         bool InsertTitle(Title T);
         bool ModifyTitle(Title T);
         bool DeleteTitle(List<int> list);
         bool ActiveOrDeActiveTitle(List<int> list, int status);
        #endregion

        #region"Position"
         List<Position> GetAllPosition(Position T, int index, int size);
         bool InsertPosition(Position T);
         bool ModifyPosition(Position T);
         bool DeletePosition(List<int> list);
         bool ActiveOrDeActivePosition(List<int> list, int status);
        #endregion

        #region OTherList
        List<Other_List> GetOther_ListsCombo(string code);
        bool InsertOther_List(Other_List T);
        bool ModifyOther_List(Other_List T);
        bool DeleteOther_List(List<int> list);
        bool ActiveOrDeActiveOther_List(List<int> list, int status);
        #endregion


        #endregion

        #region business
        #region"Org"
        List<ORgnization> GetAllORgnization(ORgnization T);
         bool InsertOrg(ORgnization T);
         bool ModifyOrg(ORgnization T);
         bool DeleteOrg(int orgID);
         bool ActiveOrDeActiveOrg(int orgID, int status);

        #endregion
        #endregion
    }
}
