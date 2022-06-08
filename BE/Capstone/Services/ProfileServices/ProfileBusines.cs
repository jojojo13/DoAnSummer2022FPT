using ModelAuto;
using ModelAuto.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Services.ProfileServices
{
    public partial class ProfileImpl : IProfile
    {
      public List<Position> GetListPositionByOrgID(int ID)
        {
            List<Position> list = new List<Position>();
            DataTable dt = DAOContext.GetListPositionByOrgID(ID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Position o = new Position();
                DataRow row = dt.Rows[i];
                o.Name = row["Name"].ToString();
                o.Code = row["Code"].ToString();
                o.Id = Convert.ToInt32(row["PositionID"].ToString());
                list.Add(o);
            }
            return list;
        }

    }
}
