using ModelAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestServices
{
   public interface IRequest
    {
        #region RcRequest
        List<RcRequest> GetAllRequest(int index, int size);
        List<RcRequest> GetChildRequestById(int ID);
        bool InsertRequest(RcRequest T);
        bool ModifyRequest(RcRequest T);
        bool DeleteRequest(List<int> list);
        bool ActiveOrDeActiveRequest(List<int> list, int status);
        RcRequest GetRequestByID(int ID);
        int getTotalRequestRecord(string column , int? signID);
        List<RcRequest> GetListRequestByID(int ID);
        bool SendComment(RcRequest T);
        #endregion
    }
}
