using CapstoneModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CommonServices
{
    public class Common : ICommon
    {
        #region"List"
        public string autoGenCode3character(string tableName, string firstCode)
        {
            try
            {
                string query = "select Code from " + tableName + " order by Id desc";
                DataTable dt = DAOContext.GetDataBySql(query);
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
                string Code = lastRow["Code"].ToString();

                if (Code != null)
                {
                    string number = Code.Substring(Code.Length - 3);
                    return firstCode + (Convert.ToInt32(number) + 1).ToString("000");
                }
                else
                {
                    return firstCode + "001";
                }
            }
            catch
            {
                return firstCode + "001";
            }
        }

        public string autoGenCode4character(string tableName, string firstCode)
        {
            try
            {
                string query = "select Code from " + tableName + " order by Id desc";
                DataTable dt = DAOContext.GetDataBySql(query);
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
                string Code = lastRow["Code"].ToString();

                if (Code != null)
                {
                    string number = Code.Substring(Code.Length - 4);
                    return firstCode + (Convert.ToInt32(number) + 1).ToString("0000");
                }
                else
                {
                    return firstCode + "0001";
                }
            }
            catch
            {
                return firstCode + "0001";
            }
        }
        #endregion


        #region Get by ID
        public ORgnization getOrgByID(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    ORgnization obj = context.ORgnizations.Where(x => x.Id == id).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null;
            }

        }

        public Title getTitleByID(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    Title obj = context.Titles.Where(x => x.Id == id).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null;
            }

        }
        public Position getPositionByID(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    Position obj = context.Positions.Where(x => x.Id == id).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null;
            }

        }
        #endregion

    }
}
