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
            var builder = new ConfigurationBuilder().AddJsonFile("jsconfig1.json").Build();
            string ConnectionStr = builder.GetConnectionString("MyDB");
            return new SqlConnection(ConnectionStr);
        }
        public static DataTable GetDataBySql(string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            if (parameters != null || parameters.Length == 0)
                command.Parameters.AddRange(parameters);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

    }
}
