using DemoApplicationHMSI.BusinessLayer;
using DemoApplicationHMSI.DataLayer;
using DTPLLogs;
using iTextSharp.text.pdf.qrcode;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DemoApplicationHMSI.Reports
{
    public partial class AssemblyLineMappingReport : Form
    {
        DL_Report objDL_Report = new DL_Report();
        public AssemblyLineMappingReport()
        {
            InitializeComponent();
        }
        private void btnGetReport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = objDL_Report.GetITEMTRACKINGReport(Datefromdate.Text, DateTodate.Text);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        byte[] b = null;                        
                        if (dt.Rows[i][13].ToString().Length > 0)
                        {
                            b = (Byte[])dt.Rows[i][13];
                            Image x = (Bitmap)((new ImageConverter()).ConvertFrom(b));
                            dgvData.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(),
                               dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString()
                               , dt.Rows[i][5].ToString()
                               , dt.Rows[i][6].ToString()
                               , dt.Rows[i][7].ToString()
                               , dt.Rows[i][8].ToString()
                               , dt.Rows[i][9].ToString()
                               , dt.Rows[i][10].ToString()
                               , dt.Rows[i][11].ToString()
                               , dt.Rows[i][12].ToString()
                               , x
                               , dt.Rows[i][14].ToString()
                               );
                        }
                        else
                        {
                            dgvData.Rows.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(),
                                dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString()
                                , dt.Rows[i][5].ToString()
                                , dt.Rows[i][6].ToString()
                                , dt.Rows[i][7].ToString()
                                , dt.Rows[i][8].ToString()
                                , dt.Rows[i][9].ToString()
                                , dt.Rows[i][10].ToString()
                                , dt.Rows[i][11].ToString()
                                , dt.Rows[i][12].ToString()
                                , null
                                , dt.Rows[i][14].ToString()
                                );
                        }

                    }
                }
                else
                {
                    blCommon.ShowMessage("No result found", 3);
                }
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                blCommon.ShowMessage(ex.Message, 3);
            }

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            //if (ReceivingGrid.Rows.Count >= 1)
            //{
            //    try
            //    {
            //        Cursor = Cursors.WaitCursor;
            //        SaveFileDialog saveFileDialog = new SaveFileDialog();
            //        saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            //        if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //        {
            //            DataTable dt = (DataTable)ReceivingGrid.DataSource;
            //            string sFilePath = saveFileDialog.FileName;
            //            blCommon.exportToExcel1(dt, sFilePath);
            //            blCommon.ShowMessage("File export successfull", 1);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            //        blCommon.ShowMessage(ex.Message, 3);
            //    }
            //    finally
            //    {
            //        Cursor = Cursors.Default;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No Record to Export !");

            //}
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //ReceivingGrid.DataSource = null;
        }

        private void btnPDFExport_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (ReceivingGrid.Rows.Count > 0)
            //    {
            //        Cursor = Cursors.WaitCursor;
            //        DataTable dt = (DataTable)ReceivingGrid.DataSource;
            //        SaveFileDialog saveFileDialog = new SaveFileDialog();
            //        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            //        if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //        {
            //            string sFilePath = saveFileDialog.FileName;
            //            blCommon.ExportToPdf(dt, sFilePath, "Assembly Line Mapping Report");
            //            blCommon.ShowMessage("File export successfull", 1);
            //        }
            //    }
            //    else
            //    {
            //        blCommon.ShowMessage("No data found to export", 2);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
            //    blCommon.ShowMessage(ex.Message, 3);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
