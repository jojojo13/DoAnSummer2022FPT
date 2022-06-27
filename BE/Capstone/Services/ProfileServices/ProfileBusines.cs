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

        public List<Employee> GetListEmployeeByOrgID(int OrgID, int index, int size)
        {
            List<Employee> list = new List<Employee>();
            DataTable dt = DAOContext.GetListEmployeeByOrgID( OrgID,  index,  size);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Employee o = new Employee();
                DataRow row = dt.Rows[i];
                o.FullName = row["FullName"].ToString();
                o.Code = row["Code"].ToString();
                o.Id = Convert.ToInt32(row["Id"].ToString());
                o.Orgnization = new Orgnization();
                o.Orgnization.Id= Convert.ToInt32(row["OrgnizationID"].ToString());
                o.Position = new Position();
                o.Position.Id = Convert.ToInt32(row["PositionID"].ToString());
                o.StatusNavigation = new OtherList();
                o.StatusNavigation.Name = row["StatusName"].ToString();
                o.Orgnization.Name = row["ORG_NAME"].ToString();
                o.Position.Name = row["PositionName"].ToString();
                o.Position.Title = new Title();
                o.Position.Title.Name= row["TitleName"].ToString();
                list.Add(o);
            }
            return list;
        }

        public int getTotalEmployee(int OrgID)
        {
            List<Employee> list = new List<Employee>();
            DataTable dt = DAOContext.GetListEmployeeByOrgID(OrgID, 0, Int32.MaxValue);
            return dt.Rows.Count;
        }
    }
}
