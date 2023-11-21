using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using DemoApplicationHMSI.PL;

namespace DemoApplicationHMSI.DataLayer
{   
    public class DL_UserLogin
    {
        Common obj = new Common();
        SqlCommand cmd = null;

        public DataTable dtCheckVersion(UserMasterModel objUserMasterModel)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_USERLOGIN";
                cmd.Parameters.AddWithValue("@type", "CHECKVERSION");
                cmd.Parameters.AddWithValue("@PASSWORD", objUserMasterModel.ProductVersion);
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
        public DataTable dtGetUserLogin(UserMasterModel objUserMasterModel)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_USERLOGIN";
                cmd.Parameters.AddWithValue("@type", "LOGIN");
                cmd.Parameters.AddWithValue("@USERID", objUserMasterModel.UserID);
                cmd.Parameters.AddWithValue("@PASSWORD", objUserMasterModel.Password);
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
        public DataTable ChangePassword(string sUserID, string sPassword)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_USERLOGIN";
                cmd.Parameters.AddWithValue("@type", "CHANGEPASSWORD");
                cmd.Parameters.AddWithValue("@USERID", sUserID);
                cmd.Parameters.AddWithValue("@PASSWORD", sPassword);
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
        public DataTable GetGroupForRights()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_USERLOGIN";
                cmd.Parameters.AddWithValue("@type", "GETUSERFORMODULE");
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
        public DataTable GetAllModuleList()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_USERLOGIN";
                cmd.Parameters.AddWithValue("@type", "GETALLMODULES");
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
        public DataTable GetUserRights(string sGroupID)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_USERLOGIN";
                cmd.Parameters.AddWithValue("@type", "GETMODULEUSERRIGHTS");
                cmd.Parameters.AddWithValue("@USERID", sGroupID);
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
        public DataTable SaveUserRights(string sUserID,DataTable dtModuleList)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_USERLOGIN";
                cmd.Parameters.AddWithValue("@type", "SAVEUSERRIGHTS");
                cmd.Parameters.AddWithValue("@USERID", sUserID);
                cmd.Parameters.AddWithValue("@details", dtModuleList);
                cmd.Parameters.AddWithValue("@RIGHTSGIVENBY", PCommon.UserID);
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