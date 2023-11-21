using DemoApplicationHMSI.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DemoApplicationHMSI.DataLayer
{
    public class DL_LabelPrinting
    {
        Common obj = new Common();
        SqlCommand cmd = null;
        public DataTable BindLine()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_KANBONPRINTING";
                cmd.Parameters.AddWithValue("@type", "BINDLINE");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
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
        public DataTable BINDITEM()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_KANBONPRINTING";
                cmd.Parameters.AddWithValue("@type", "BINDITEM");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
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
        public DataTable GetItemDetails(string sIDNO)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_KANBONPRINTING";
                cmd.Parameters.AddWithValue("@type", "GETITEMDETAILS");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@IDNO", sIDNO);
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
        public DataTable GetPrintingDetails(string sKanbonBarcode)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_KANBONPRINTING";
                cmd.Parameters.AddWithValue("@type", "GETPRINTDETAILS");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@KANBONBARCODE", sKanbonBarcode);
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

        public DataTable SaveData(PLKanbonPrinting plobj)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "USP_KANBONPRINTING";
                cmd.Parameters.AddWithValue("@type", "PRINTBARCODE");
                cmd.Parameters.AddWithValue("@SiteCode", PCommon.SiteCode);
                cmd.Parameters.AddWithValue("@KANBONBARCODE", plobj.KanbonBarcode);
                cmd.Parameters.AddWithValue("@SHIFTCODE", plobj.ShiftCode);
                cmd.Parameters.AddWithValue("@PRODUCTIONDATE", plobj.ProductionDate);
                cmd.Parameters.AddWithValue("@IDNO", plobj.IDNO);
                cmd.Parameters.AddWithValue("@LINECODE", plobj.LineCode);
                cmd.Parameters.AddWithValue("@INHOUSEPARTNO", plobj.InHousePartNo);
                cmd.Parameters.AddWithValue("@CUSTPARTNO", plobj.CustPartNo);
                cmd.Parameters.AddWithValue("@CustCode", plobj.CustCode);
                cmd.Parameters.AddWithValue("@BINTYPE", plobj.BinType);
                cmd.Parameters.AddWithValue("@QTY", plobj.Qty);
                cmd.Parameters.AddWithValue("@PrintedBy", PCommon.UserID);
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
