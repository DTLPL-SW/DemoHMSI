using DemoApplicationHMSI.PL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplicationHMSI.DataLayer
{
    public class DL_CheckPointList
    {
        Common obj = new Common();
        SqlCommand cmd = null;

        public DataTable BINDDATA()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_CheckPointListMaster";
                cmd.Parameters.AddWithValue("@type", "BINDDATA");
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
        public DataTable SaveData(DataTable dtData,string sMachineNo,string sMachineName,string sLine)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_CheckPointListMaster";
                cmd.Parameters.AddWithValue("@type", "SAVEDATA");
                cmd.Parameters.AddWithValue("@details", dtData);
                cmd.Parameters.AddWithValue("@insertedBy", PCommon.UserID);
                cmd.Parameters.AddWithValue("@MCNo", sMachineNo);
                cmd.Parameters.AddWithValue("@MCName", sMachineName);
                cmd.Parameters.AddWithValue("@LineCode", sLine);
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
