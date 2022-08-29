using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAuto
{
    public class DAOContext
    {
        public static SqlConnection GetConnection()
        {
            string ConnectionStr = "Data Source=SQL8004.site4now.net;Initial Catalog=db_a8a353_capstone22;User Id=db_a8a353_capstone22_admin;Password=hung1207;MultipleActiveResultSets=true;";
            return new SqlConnection(ConnectionStr);
        }
        public static DataTable GetDataBySql(string sql, params SqlParameter[] parameters)
        {
            var con = GetConnection();
            con.Open();
            SqlCommand command = new SqlCommand(sql, con);
            if (parameters != null || parameters.Length == 0)
                command.Parameters.AddRange(parameters);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }

        public static DataTable GetListOrgbyOrgID(int OrgID)
        {
            var con = GetConnection();
            con.Open();
            SqlCommand command = new SqlCommand("ORG_RIGHT", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ORGID", SqlDbType.Int).Value = OrgID;
            DataTable dt = new DataTable();

            dt.Load(command.ExecuteReader());
            con.Close();
            return dt;
        }


        public static DataTable GetListPositionByOrgID(int OrgID)
        {
            var con = GetConnection();
            con.Open();
            SqlCommand command = new SqlCommand("GET_POSITION_BY_ORGID", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ORG_ID", SqlDbType.Int).Value = OrgID;
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            con.Close();
            return dt;
        }

        public static DataTable GetListEmployeeByOrgID(int OrgID, int index, int size)
        {
            var con = GetConnection();
            con.Open();
            SqlCommand command = new SqlCommand("GET_EMPLOYEE_BY_ORGID", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ORG_ID", SqlDbType.Int).Value = OrgID;
            command.Parameters.AddWithValue("@PageNumber", SqlDbType.Int).Value = index;
            command.Parameters.AddWithValue("@RowsOfPage", SqlDbType.Int).Value = size;
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            con.Close();
            return dt;
        }



        #region REQUEST
        public static DataTable GetListRequestByID(int id)
        {
            var con = GetConnection();
            con.Open();
            SqlCommand command = new SqlCommand("REQUEST_RIGHT", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id;
            DataTable dt = new DataTable();
            dt.Load(command.ExecuteReader());
            con.Close();
            return dt;
        }
        #endregion
    }
}
