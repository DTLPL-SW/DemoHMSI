using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using System.Data;
using MaterialSkin;
using DemoApplicationHMSI.DataLayer;
using DTPLLogs;
using DemoApplicationHMSI.BusinessLayer;
using System.Reflection;
using DemoApplicationHMSI.PL;

namespace DemoApplicationHMSI.Forms.Masters
{
    public partial class LineMaster : MaterialForm
    {
        DL_LineMaster obj = new DL_LineMaster();
        public LineMaster()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LineMaster_Load(object sender, EventArgs e)
        {
            try
            {
                MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey900, Primary.Blue500,
                Primary.Blue500, Accent.Red100,
                TextShade.WHITE);
                // Loading All data from Database
                setReload();
                _EnableDisableControls(false);
                //btnDelete.Enabled = false;
                btnEdit.Enabled = false;

            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        public void setReload()
        {
            try
            {
                obj = new DL_LineMaster();
                DataTable dt = obj.GetData();
                lblNoOfRecords.Text = "No Of Records :" + dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    PCommon.FillListView(dt, lvUser);
                    lvUser.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    lvUser.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        void _EnableDisableControls(bool bControl)
        {
            txtLineCode.Enabled = bControl;
            txtLineName.Enabled = bControl;
        
        }

        void _ClearControls()
        {
            lvUser.Enabled = true;
            txtLineCode.Text = string.Empty;
            txtLineName.Text = string.Empty;
          
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEdit.Text != "SAVE")
                {
                    btnAdd.Enabled = false;
                    txtLineCode.Enabled = false;
                 
                    txtLineName.Focus();
                    if (txtLineCode.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please select the record from grid", 2);
                        return;
                    }
                }
                else
                {
                    if (txtLineCode.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter line code", 2);
                        txtLineCode.Focus(); return;
                    }
                    if (txtLineName.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter line name", 2);
                        txtLineName.Focus(); return;
                    }
                  
                    LineMasterModel plobj = new LineMasterModel();
                    plobj.LineCode = txtLineCode.Text.Trim();
                    plobj.LineName = txtLineName.Text.Trim();
                   
                    DataTable dt = obj.Update(plobj);
                    if (dt.Rows.Count > 0)
                    {
                        string sResult = dt.Rows[0][0].ToString();
                        if (sResult.StartsWith("SUCCESS~"))
                        {
                            blCommon.ShowMessage("Data saved successfully.", 1);
                        }
                        else
                        {
                            blCommon.ShowMessage(sResult, 2);
                        }
                    }
                    _EnableDisableControls(false);
                    _ClearControls();
                    btnEdit.Text = "EDIT";
                    btnAdd.Enabled = true;
                    //btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
            finally
            {
                setReload();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "ADD")
                {
                    _ClearControls();
                    _EnableDisableControls(true);
                    txtLineCode.Focus();
                    btnAdd.Text = "SAVE";
                }
                else
                {
                    if (txtLineCode.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter line code", 2);
                        txtLineCode.Focus(); return;
                    }
                    if (txtLineName.Text.Trim() == "")
                    {
                        blCommon.ShowMessage("Please enter line name", 2);
                        txtLineName.Focus(); return;
                    }
                    
                    LineMasterModel plobj = new LineMasterModel();
                    plobj.LineCode = txtLineCode.Text.Trim();
                    plobj.LineName = txtLineName.Text.Trim();
                   
                    DataTable dt = obj.Save(plobj);
                    if (dt.Rows.Count > 0)
                    {
                        string sResult = dt.Rows[0][0].ToString();
                        if (sResult.StartsWith("SUCCESS~"))
                        {
                            blCommon.ShowMessage("Data saved successfully.", 1);
                        }
                        else
                        {
                            blCommon.ShowMessage(sResult, 2);
                        }
                    }
                    setReload();
                    _ClearControls();
                    _EnableDisableControls(false);
                    btnAdd.Text = "ADD";
                    btnEdit.Enabled = false;
                    //btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnEdit.Text == "Edit")
                {
                    blCommon.ShowMessage("Please select atleast one record from grid", 2);
                    return;
                }
                DialogResult dr = MessageBox.Show("Do you want to delete the record", blCommon.sMessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
                LineMasterModel plobj = new LineMasterModel();
                plobj.LineCode = txtLineCode.Text.Trim();
                      
                DataTable dt = obj.Delete(plobj);
                if (dt.Rows.Count > 0)
                {
                    string sResult = dt.Rows[0][0].ToString();
                    if (sResult.StartsWith("SUCCESS~"))
                    {
                        blCommon.ShowMessage("Data deleted successfully.", 1);
                    }
                    else
                    {
                        blCommon.ShowMessage(sResult, 2);
                    }
                }
                _ClearControls();
                _EnableDisableControls(false);
                btnEdit.Text = "EDIT";
                btnAdd.Text = "ADD";
                //btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnAdd.Enabled = true;
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
            finally
            {
                setReload();
            }
        }

        private void lvUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem _item in lvUser.Items)
                {
                    if (_item.Selected == true)
                    {
                        _EnableDisableControls(true);
                        btnEdit.Text = "SAVE";
                        btnAdd.Enabled = false;
                        //btnDelete.Enabled = true;
                        btnEdit.Enabled = true;
                        txtLineCode.Text = _item.Text.Trim();
                        txtLineCode.Enabled = false;
                        txtLineName.Text = _item.SubItems[1].Text.Trim();
                      
                        lvUser.Enabled = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _ClearControls();
            _EnableDisableControls(false);
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            //btnDelete.Enabled = false;
            btnEdit.Text = "EDIT";
            btnAdd.Text = "ADD";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }
    }
}
