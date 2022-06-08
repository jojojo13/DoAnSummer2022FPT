﻿using ModelAuto.Models;
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
        bool InsertRequest(RcRequest T);
        bool ModifyRequest(RcRequest T);
        bool DeleteRequest(List<int> list);
        bool ActiveOrDeActiveRequest(List<int> list, int status);
        RcRequest GetRequestByID(int ID);
        #endregion
    }
}
