using DemoApplicationHMSI.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DemoApplicationHMSI.DataLayer
{
    public class DL_LineMaster
    {
        Common obj = new Common();
        SqlCommand cmd = null;
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LINEMASTER";
                cmd.Parameters.AddWithValue("@type", "GETLINE");
                cmd.Parameters.AddWithValue("@SITECODE", PCommon.SiteCode);
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
        public DataTable Save(LineMasterModel request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LINEMASTER";
                cmd.Parameters.AddWithValue("@type", "SAVE");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@LINECODE", request.LineCode);
                cmd.Parameters.AddWithValue("@LINENAME", request.LineName);
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
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
        public DataTable Update(LineMasterModel request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LINEMASTER";
                cmd.Parameters.AddWithValue("@type", "UPDATE");
                cmd.Parameters.AddWithValue("@LINECODE", request.LineCode);
                cmd.Parameters.AddWithValue("@LINENAME", request.LineName);
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@CreatedBy", PCommon.UserID);
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
        public DataTable Delete(LineMasterModel request)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_LINEMASTER";
                cmd.Parameters.AddWithValue("@type", "DELETE");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@LINECODE", request.LineCode);
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
