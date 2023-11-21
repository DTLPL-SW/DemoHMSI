using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoApplicationHMSI.PL
{
    public class Common
    {
        public DataSet ExecuteDataset(SqlCommand cmd) 
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = PCommon.StrSqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public DataTable ExecuteDatatable(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = PCommon.StrSqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            return ds.Tables[0];
        }
    }
}