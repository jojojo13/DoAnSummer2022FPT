using ModelAuto;
using ModelAuto.Models;
using Services.ResponseModel.ProfileModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        public List<EmployeeResponseServices> GetListEmployeeByOrgID(int OrgID, int index, int size)
        {
            List<EmployeeResponseServices> list = new List<EmployeeResponseServices>();
            DataTable dt = DAOContext.GetListEmployeeByOrgID(OrgID, index, size);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                EmployeeResponseServices o = new EmployeeResponseServices
                {
                    FullName = row["FullName"].ToString(),
                    Code = row["Code"].ToString(),
                    ID = Convert.ToInt32(row["Id"].ToString()),
                    OrgId = Convert.ToInt32(row["OrgnizationID"].ToString()),
                    PositionId = Convert.ToInt32(row["PositionID"].ToString()),
                    StatusName = row["StatusName"].ToString(),
                    OrgnizationName = row["ORG_NAME"].ToString(),
                    PositionName = row["PositionName"].ToString(),
                    TitleName = row["TitleName"].ToString(),
                    ContractNo = row["ContractNo"].ToString(),
                    JoinDate= Convert.ToDateTime(row["JoinDate"].ToString()).ToString("dd/MM/yyyy"),
                    StatusId= Convert.ToInt32(row["StatusId"].ToString()),
                    TitleId= Convert.ToInt32(row["TitleId"].ToString()),

                };
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

        public EmployeeCv GetEmployeeCvByEmpID(int? ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    EmployeeCv e = context.EmployeeCvs.Where(x => x.EmployeeId == ID).FirstOrDefault();
                    if (e != null)
                        return e;
                    else
                        return new EmployeeCv();
                }
            }
            catch
            {
                return new EmployeeCv();
            }
        }

        public EmployeeEdu GetEmployeeEduByEmpID(int? ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    EmployeeEdu e = context.EmployeeEdus.Where(x => x.EmployeeId == ID).FirstOrDefault();
                    if (e != null)
                        return e;
                    else
                        return new EmployeeEdu();
                }
            }
            catch
            {
                return new EmployeeEdu();
            }
        }

        public List<EmployeeContract> GetListEmployeeContractByEmpID(int? ID)
        {
            try
            {
                using (CapstoneProject2022Context context = new CapstoneProject2022Context())
                {
                    List<EmployeeContract> listContract = context.EmployeeContracts.Where(x => x.EmployeeId == ID).ToList();
                    return listContract;
                }
            }
            catch
            {
                return new List<EmployeeContract>();
            }
        }

    }
}
