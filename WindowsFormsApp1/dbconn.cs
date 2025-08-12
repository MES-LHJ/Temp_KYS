using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class ConnDatabase
{
    string connString = @"Data Source=DESKTOP-3E4KCVF\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
  
    public SqlConnection conn;

    public void Open()
    {
        try
        {
            conn = new SqlConnection(connString);
            conn.Open();
        }
        catch (Exception ex)
        {
            MessageBox.Show("연결 실패 " + ex.Message);
        }
    }
    public void Close()
    {
        try
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            throw ex;

        }
    }
    //DataSet 객체 리턴
    public DataSet GetDataSet(string sql)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = new SqlCommand(sql, conn);

        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }
    
    public int KK(string sql)
    {
        var aa = new SqlCommand(sql, conn);
        return aa.ExecuteNonQuery();
    }

    public int EE(string sql)
    {
        var aa = new SqlCommand(sql, conn);
        return (int)aa.ExecuteScalar();
    }
}
