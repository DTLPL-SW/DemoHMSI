using DemoApplicationHMSI.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
namespace DemoApplicationHMSI.DataLayer
{
    public class DL_Report
    {
        Common obj = new Common();
        SqlCommand cmd = null;

        public DataTable GetITEMTRACKINGReport(string sDatefromdate, string sDateTodate)
        {
            DataTable dt = new DataTable();
            try
            {
                string from1 = Convert.ToDateTime(sDatefromdate).ToString("yyyy-MM-dd HH:mm:ss");
                string to = Convert.ToDateTime(sDateTodate).ToString("yyyy-MM-dd HH:mm:ss");

                cmd = new SqlCommand();
                cmd.CommandText = "USP_CheckPointListMaster";
                cmd.Parameters.AddWithValue("@type", "GETDATA");
                cmd.Parameters.AddWithValue("@FROMDATE", from1);
                cmd.Parameters.AddWithValue("@TODATE", to);
                DataSet ds = obj.ExecuteDataset(cmd);
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogs.DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return dt;
        }
    }
}