using DemoApplicationHMSI.BusinessLayer;
using DemoApplicationHMSI.Forms.Masters;
using DemoApplicationHMSI.Forms.Transaction;
using DemoApplicationHMSI.PL;
using DemoApplicationHMSI.Reports;
using DTPLLogs;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;


namespace DemoApplicationHMSI
{
    public partial class MainWindow : MaterialForm
    {
        DataLayer.DL_UserLogin obj = new DataLayer.DL_UserLogin();
        static DataTable DTTEMP = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            int x = (pnlHeader.Size.Width - lblHeader.Size.Width) / 2;
            lblHeader.Location = new Point(x, lblHeader.Location.Y);
            lblConnection.Text = "Database Name :  " + PCommon.sDbDataBaseName + ", Login User :  " + PCommon.UserID + ", " +
                "Login Time :  " + DateTime.Now.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
                string processName = "PRI_Scanning.exe".Replace(".exe", "");
                foreach (Process process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            }

        }

        private void siteMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.BlanchedAlmond, ButtonBorderStyle.Solid);
            Panel panel = (Panel)sender;
            float width = (float)4.0;
            Pen pen = new Pen(SystemColors.ControlDark, width);
            pen.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(pen, 0, 0, 0, panel.Height - 0);
            e.Graphics.DrawLine(pen, 0, 0, panel.Width - 0, 0);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, 0, panel.Height - 1);
            e.Graphics.DrawLine(pen, panel.Width - 1, panel.Height - 1, panel.Width - 1, 0);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ChangePassword obj = new ChangePassword();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }


        private void userMasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                UserMaster obj = new UserMaster();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }        

        private void MainWindow_Load(object sender, EventArgs e)
        {
            try
            {
                UserMasterModel plobj = new UserMasterModel();
                if (PCommon.UserType.ToUpper() != "ADMIN")
                {
                    userRightstoformDisable();
                    DataTable dt = new DataTable();
                    dt = obj.GetUserRights(PCommon.UserID);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int iCount = 0;
                            string strControlVal = dt.Rows[i].ItemArray[0].ToString();
                            foreach (ToolStripMenuItem item in menuStrip1.Items)
                            {
                                for (int k = 0; k < item.DropDown.Items.Count; k++)
                                {
                                    if (strControlVal.ToUpper() == item.DropDown.Items[k].Text.ToUpper())
                                    {
                                        item.DropDown.Items[k].Visible = true;
                                        iCount++;
                                        break;
                                    }
                                }
                                if (iCount == 1)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        blCommon.ShowMessage("You does not have right to access, Please contact to admin.", 3);
                        Application.Exit();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        private void userRightstoformDisable()
        {
            try
            {
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    for (int k = 0; k < item.DropDown.Items.Count; k++)
                    {
                        item.DropDown.Items[k].Visible = false;
                        if (item.DropDown.Items[k].Text.ToUpper().Trim() == "CHANGE PASSWORD")
                        {
                            item.DropDown.Items[k].Visible = true;
                        }
                        if (item.DropDown.Items[k].Text.ToUpper().Trim() == "LOGOUT")
                        {
                            item.DropDown.Items[k].Visible = true;
                        }
                        if (item.DropDown.Items[k].Text.ToUpper().Trim() == "EXIT")
                        {
                            item.DropDown.Items[k].Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }        

        private void groupRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UserRight obj = new UserRight();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }


        private void pritinbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CheckPointStore obj = new CheckPointStore();
                obj.Show();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                LineMaster obj = new LineMaster();
                obj.Show();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                AdvicsLoginScreen obj = new AdvicsLoginScreen();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }


        private void itemTrackingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AssemblyLineMappingReport obj = new AssemblyLineMappingReport();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
    }
}
