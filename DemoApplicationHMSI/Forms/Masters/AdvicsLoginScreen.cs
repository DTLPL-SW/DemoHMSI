﻿using DTPLLogs;
using DemoApplicationHMSI.BusinessLayer;
using DemoApplicationHMSI.DataLayer;
using DemoApplicationHMSI.PL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace DemoApplicationHMSI
{
    public partial class AdvicsLoginScreen : Form
    {
        DL_UserLogin obj = new DL_UserLogin();
        public AdvicsLoginScreen()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            userLogin();
        }
        public string ReadPortFile(string sPath)
        {
            string _sResult = string.Empty;
            try
            {
                StreamReader sr = new StreamReader(sPath);
                _sResult = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                _sResult = string.Empty;
            }
            return _sResult;
        }
        public string ReadConnectionFile(string sPath)
        {
            string _sResult = string.Empty;
            try
            {
                StreamReader sr = new StreamReader(sPath);
                _sResult = sr.ReadLine();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                _sResult = string.Empty;
            }
            return _sResult;
        }       
        private void LoginScreen_Load(object sender, EventArgs e)
        {
            try
            {
                lblVersion.Text = "Copyright @Dashtech  @ " + Application.ProductVersion;               

                #region Log Write
                //----------------------------- //
                DirectoryInfo _dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Logs");
                if (_dir.Exists == false)
                {
                    _dir.Create();
                }
                PCommon.mAppLog = new DTPLLogsWrite();
                PCommon.mAppLog.iLogDays = 10;
                PCommon.mAppLog.sLogFilePath = AppDomain.CurrentDomain.BaseDirectory;
                PCommon.mAppLog.sLogName = "Dashtech";
                PCommon.mAppLog.WriteLog("Initialize Application", DTPLLogsWrite.LogType.Information, MethodBase.GetCurrentMethod());
                PCommon.mAppLog.WriteLog("Dashtech" + "  ::  Version" + Application.ProductVersion, DTPLLogsWrite.LogType.Information, MethodBase.GetCurrentMethod());

                #endregion

                PCommon.sDBSettingPath = Application.StartupPath + "\\DbSetting.ini";
                PCommon.StrSqlCon = ReadConnectionFile(PCommon.sDBSettingPath);// Get the connection string
                if (!string.IsNullOrEmpty(PCommon.StrSqlCon))
                {
                    PCommon.StrSqlCon = PCommon.StrSqlCon.Replace(PCommon.StrSqlCon.Split(';')[2].Split('~')[1], EncryptDecrptClass.Decrypt_data(PCommon.StrSqlCon.Split(';')[2].Split('~')[1]));
                    PCommon.StrSqlCon = PCommon.StrSqlCon.Replace(PCommon.StrSqlCon.Split(';')[3].Split('~')[1], EncryptDecrptClass.Decrypt_data(PCommon.StrSqlCon.Split(';')[3].Split('~')[1]));
                    PCommon.StrSqlCon = PCommon.StrSqlCon.Replace('~', '=');
                }
                if (PCommon.StrSqlCon == string.Empty)
                {
                    blCommon.ShowMessage("Unable to read DbSetting.ini", 1);
                    Cursor.Current = Cursors.WaitCursor;
                    frmDBSetting objServer = new frmDBSetting();
                    objServer.ShowDialog();
                }
                else
                {
                    try
                    {
                        SqlConnection cn = new SqlConnection(PCommon.StrSqlCon);
                        cn.Open();
                        cn.Close();
                        txtUserID.Focus();
                    }
                    catch (Exception)
                    {
                        blCommon.ShowMessage("Unable to connect with last database setting. Please configure correct database setting.", 1);
                        // open config setting file
                        Cursor.Current = Cursors.WaitCursor;
                        frmDBSetting objServer = new frmDBSetting();
                        objServer.ShowDialog();
                    }        
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                Cursor.Current = Cursors.Default;
                frmDBSetting objServer = new frmDBSetting();
                objServer.ShowDialog();
            }
        }
        public void retriveDatabaseSettingandLogin()
        {
            try
            {
                PCommon.sDbServerName = PCommon.StrSqlCon.Split(';')[0].Split('=')[1];
                PCommon.sDbDataBaseName = PCommon.StrSqlCon.Split(';')[1].Split('=')[1];
                PCommon.sDbUserID = PCommon.StrSqlCon.Split(';')[2].Split('=')[1];
                PCommon.sDbPassword = PCommon.StrSqlCon.Split(';')[3].Split('=')[1];
                PCommon.UserID = txtUserID.Text.Trim();
                PCommon.sHostName = Dns.GetHostName(); // Retrive the Name of HOST
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        public void userLogin()
        {
            try
            {
                string sResult = string.Empty;
                if (string.IsNullOrEmpty(txtUserID.Text.Trim()))
                {
                    blCommon.ShowMessage("Please enter user id", 1);
                    txtUserID.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    blCommon.ShowMessage("Please enter password", 1);
                    txtPassword.Focus();
                    return;
                }
                UserMasterModel plobj = new UserMasterModel();
                #region Check for application version
                DataTable dt = new DataTable();
                obj = new DataLayer.DL_UserLogin();
                plobj.ProductVersion = Application.ProductVersion;
                dt = obj.dtCheckVersion(plobj);
                if (dt.Rows.Count > 0)
                {
                    sResult = dt.Rows[0][0].ToString();
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        if (sResult != Application.ProductVersion)
                        {
                            blCommon.ShowMessage("Application version Changed, Please wait for downloading of new version", 2);
                            return;                           
                        }
                    }
                }
                #endregion

                plobj = new UserMasterModel();
                plobj.UserID = txtUserID.Text.Trim();
                plobj.Password = txtPassword.Text.Trim();
                obj = new DataLayer.DL_UserLogin();
                DataTable dtResult = obj.dtGetUserLogin(plobj);
                if (dtResult.Rows.Count > 0)
                {
                    sResult = dtResult.Rows[0][0].ToString();
                    if (sResult.StartsWith("N~") || sResult.StartsWith("ERROR~"))
                    {
                        blCommon.ShowMessage(sResult.Split('~')[1], 2);
                        txtUserID.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                        txtUserID.Focus();
                        return;
                    }
                    else if (sResult == "0")
                    {
                        blCommon.ShowMessage("Invalid UserID and Password. Please try again", 1);
                        txtUserID.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                        txtUserID.Focus();
                        return;
                    }
                    else if (sResult == string.Empty)
                    {
                        blCommon.ShowMessage("Password is not correct. Please try again", 1);
                        txtPassword.Text = string.Empty;
                        txtPassword.Focus();
                        return;
                    }
                    string sLoginID = txtUserID.Text;
                    PCommon.UserName = dtResult.Rows[0]["UserName"].ToString();
                    PCommon.UserType = dtResult.Rows[0]["UserType"].ToString();
                    PCommon.UserID = sLoginID;
                    string isActive = dtResult.Rows[0][2].ToString();
                    if (isActive == "False" || isActive == "0")
                    {
                        blCommon.ShowMessage("Selected user is not active, Please enter another user id", 1);
                        txtUserID.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                        txtUserID.Focus();
                        return;
                    }  
                    PCommon.sSystemName = Environment.MachineName.ToString();
                    retriveDatabaseSettingandLogin();
                    MainWindow objmenu = new MainWindow();
                    txtUserID.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtUserID.Focus();
                    this.Hide();
                    objmenu.Show();
                    return;
                }
                else
                {
                    blCommon.ShowMessage("UserID and password is not correct. Please try again", 1);
                    txtUserID.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtUserID.Focus();
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            foreach (Process proc in Process.GetProcessesByName("PRI_Scanning"))
            {
                proc.Kill();
            }
            Application.Exit();
        }

        private void txtUserID_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtUserID, "Enter User ID");
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                userLogin();
            }
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != (char)13 && e.KeyChar != (char)8)//e.KeyChar!=(char)Keys.Space)
            {
                e.Handled = true;
            }
            if (txtUserID.Text != string.Empty && e.KeyChar == (char)13)
            {
                txtPassword.Focus();
            }
        }
    }
}
