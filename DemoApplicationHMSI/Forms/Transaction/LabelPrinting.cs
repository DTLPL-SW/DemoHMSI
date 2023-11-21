using DemoApplicationHMSI.BusinessLayer;
using DemoApplicationHMSI.DataLayer;
using DemoApplicationHMSI.PL;
using DTPLLogs;
using MaterialSkin.Controls;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace DemoApplicationHMSI.Forms.Transaction
{
    public partial class LabelPrinting : MaterialForm
    {
        DataTable dtPostData = new DataTable();
        DL_LabelPrinting obj = new DL_LabelPrinting();
        string sIsPrint = ConfigurationManager.AppSettings["Setting2"].ToString();
        int BinCount = 0;
        public LabelPrinting(string sModuleName)
        {
            InitializeComponent();
            if (sModuleName == "BinMapping")
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        public void BindLine()
        {
            try
            {
                DataTable dt = obj.BindLine();
                if (dt.Rows.Count > 0)
                {
                    blCommon.FillComboBox(cmbLineCode, dt, true);
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        public void BindItem()
        {
            try
            {
                DataTable dt = obj.BINDITEM();
                if (dt.Rows.Count > 0)
                {
                    blCommon.FillComboBox(cmbItemCode, dt, true);
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        public void BindPrinter()
        {
            try
            {
                DataTable dt = blCommon.getInstalledPrinters();
                if (dt.Rows.Count > 0)
                {
                    blCommon.FillComboBox(cmbUsbPrinter, dt, true);
                }
            }
            catch (Exception ex)
            {
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        #region Form Event
        private void LabelPrinting_Load(object sender, EventArgs e)
        {
            try
            {
                txtCustomerCode.Text = String.Empty;
                txtCustomerPartNo.Text = String.Empty;
                txtInHousePartNo.Text = String.Empty;
                txtPackingType.Text = String.Empty;
                txtPackSize.Text = String.Empty;
                cmbShiftCode.SelectedIndex = 0;
                dtPostData.Columns.Add("ImageData", typeof(byte[]));
                BindLine();
                BindItem();
                BindPrinter();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }
        private void LabelPrinting_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            }
        }

        #endregion

        #region Button Event

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCustomerCode.Text = String.Empty;
            txtCustomerPartNo.Text = String.Empty;
            txtInHousePartNo.Text = String.Empty;
            txtPackingType.Text = String.Empty;
            txtPackSize.Text = String.Empty;
            BindLine();
            BindItem();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var foldername = "KanbanData";
                if (!Directory.Exists(Application.StartupPath + "/" + foldername))
                    Directory.CreateDirectory(Application.StartupPath + "/" + foldername);
                if (cmbItemCode.Items.Count == 0)
                {
                    blCommon.ShowMessage("Please select item code", 3);
                    cmbItemCode.Focus();
                    return;
                }
                if (cmbItemCode.SelectedIndex == 0)
                {
                    blCommon.ShowMessage("Please select item code", 3);
                    cmbItemCode.Focus();
                    return;
                }
                if (cmbLineCode.Items.Count == 0)
                {
                    blCommon.ShowMessage("Please select line", 3);
                    cmbItemCode.Focus();
                    return;
                }
                if (cmbLineCode.SelectedIndex == 0)
                {
                    blCommon.ShowMessage("Please select line", 3);
                    cmbItemCode.Focus();
                    return;
                }
                if (cmbUsbPrinter.SelectedIndex == 0)
                {
                    blCommon.ShowMessage("Please select printer", 3);
                    cmbUsbPrinter.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtNoOfPrints.Text))
                {
                    blCommon.ShowMessage("Please enter no of prints", 3);
                    txtNoOfPrints.Focus();
                    return;
                }
                if (txtNoOfPrints.Text == "0")
                {
                    blCommon.ShowMessage("Please enter valid no of prints", 3);
                    txtNoOfPrints.Text = string.Empty;
                    txtNoOfPrints.Focus();
                    return;
                }
                PLKanbonPrinting plobj = new PLKanbonPrinting();
                plobj.KanbonBarcode = "";
                plobj.IDNO = cmbItemCode.Text;
                plobj.ShiftCode = cmbShiftCode.Text;
                plobj.ProductionDate = System.DateTime.Now;
                plobj.InHousePartNo = txtInHousePartNo.Text;
                plobj.BinType = txtPackingType.Text;
                plobj.Qty = Convert.ToInt32(txtPackSize.Text);
                plobj.CustPartNo = txtCustomerPartNo.Text;
                plobj.CustCode = txtCustomerCode.Text;
                plobj.LineCode = cmbLineCode.Text;
                blClsPrint objclsprint = new blClsPrint();

                Cursor = Cursors.WaitCursor;

                lblMessage.Text = "Printing is in process";
                bool result = objclsprint.PrinterCheck(cmbUsbPrinter.Text); // Check Printer Connectivity
                if (result == true)
                {
                    for (int i = 0; i < Convert.ToInt32(txtNoOfPrints.Text); i++)
                    {
                        DataTable dt = obj.SaveData(plobj);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0][0].ToString().StartsWith("SUCCESS"))
                            {   //Total Count
                                BinCount = BinCount + 1;
                                LblCount.Text = BinCount.ToString();
                                plobj.KanbonBarcode = dt.Rows[0][0].ToString().Split('~')[2];
                                string[] arr = new string[1];
                                ListViewItem item;

                                //Add first item
                                arr[0] = plobj.KanbonBarcode;
                                item = new ListViewItem(arr);
                                lv.Items.Add(item);
                                int count = (lv.Items.Count);
                                if (count == 11)
                                {
                                    lv.Items.Clear();
                                    arr[0] = plobj.KanbonBarcode;
                                    item = new ListViewItem(arr);
                                    lv.Items.Add(item);
                                }
                                //END

                                dtPostData.Rows.Clear();
                                plobj.KanbonBarcode = dt.Rows[0][0].ToString().Split('~')[2];
                                DataTable dtPrintData = obj.GetPrintingDetails(plobj.KanbonBarcode);
                                if (dtPrintData.Rows.Count > 0)
                                {
                                    
                                    
                                }
                            }
                            lblMessage.Text = "Label has been printed successfully";
                            Thread.Sleep(100);
                        }
                    }
                }
                else
                {
                    Cursor = Cursors.Default;
                    blCommon.ShowMessage("Printer is not in network", 3);
                }
                Cursor = Cursors.Default;
                Thread.Sleep(100);

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        

        #endregion
        private void cmbUsbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCustomerCode.Text = String.Empty;
                txtCustomerPartNo.Text = String.Empty;
                txtInHousePartNo.Text = String.Empty;
                txtPackingType.Text = String.Empty;
                txtPackSize.Text = String.Empty;
                if (cmbItemCode.SelectedIndex > 0)
                {
                    DataTable dt = obj.GetItemDetails(cmbItemCode.Text);
                    if (dt.Rows.Count > 0)
                    {
                        txtCustomerCode.Text = dt.Rows[0]["CustCode"].ToString();
                        txtCustomerPartNo.Text = dt.Rows[0]["CustPartNo"].ToString();
                        txtInHousePartNo.Text = dt.Rows[0]["InHousePartNo"].ToString();
                        txtPackingType.Text = dt.Rows[0]["PackingType"].ToString();
                        txtPackSize.Text = dt.Rows[0]["PackSize"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void txtNoOfPrints_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                blCommon.OnlyNumeric(e);
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
