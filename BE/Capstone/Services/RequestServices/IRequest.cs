using CapstoneModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestServices
{
   public interface IRequest
    {
        #region RC_REQUEST
        List<Rc_Request> GetAllRequest(int index, int size);
        bool InsertRequest(Rc_Request T);
        bool ModifyRequest(Rc_Request T);
        bool DeleteRequest(List<int> list);
        bool ActiveOrDeActiveRequest(List<int> list, int status);
        Rc_Request GetRequestByID(int ID);
        #endregion
    }
}
