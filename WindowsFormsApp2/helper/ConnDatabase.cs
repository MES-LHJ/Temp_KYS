using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.helper
{
    public class ConnDatabase
    {
        private static ConnDatabase instance;
        private readonly string connectionString = @"Data Source=DESKTOP-3E4KCVF\SQLEXPRESS;Initial Catalog=devexpressproject;Integrated Security=True";

        private ConnDatabase() { }

        public static ConnDatabase Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConnDatabase();
                return instance;
            }
        }

        public int ExecuteNonQuery(string sql, List<SqlParameter> parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int ExecuteScalar(string sql, List<SqlParameter> parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public SqlDataReader ExecuteReader(string sql, List<SqlParameter> parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddRange(parameters.ToArray());
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
