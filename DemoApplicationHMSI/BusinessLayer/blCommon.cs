using DTPLLogs;
using DemoApplicationHMSI.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DemoApplicationHMSI.BusinessLayer
{
    public static class blCommon
    {
        public static string strLogFile = Application.StartupPath + "\\Log\\";
        public static string sMessageBox = "ADVICS WMS APPLICATION [VER : - " + Application.ProductVersion + " ]";
        public static void FillComboBox(ComboBox cbo, DataTable dt, bool isSelect)
        {
            try
            {
                if (isSelect)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "--Select--";
                    dr[1] = "";
                    dt.Rows.InsertAt(dr, 0);
                }
                cbo.DisplayMember = dt.Columns[0].ToString();
                cbo.ValueMember = dt.Columns[1].ToString();
                cbo.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void FillSingleColumnCombo(ComboBox cbo, DataTable dt, bool isSelect)
        {
            try
            {
                if (isSelect)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "--Select--";
                    dt.Rows.InsertAt(dr, 0);
                }
                cbo.DisplayMember = dt.Columns[0].ToString();
                cbo.ValueMember = dt.Columns[0].ToString();
                cbo.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ShowMessage(string sMessage, int iWhich)
        {
            switch (iWhich)
            {
                case 1:
                    MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 3:
                    MessageBox.Show(sMessage, sMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 4:
                    break;
            }
        }
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            // Create the result table, and gather all properties of a T        
            DataTable table = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Add the properties as columns to the datatable
            foreach (var prop in props)
            {
                Type propType = prop.PropertyType;

                // Is it a nullable type? Get the underlying type 
                if (propType.IsGenericType && propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    propType = new NullableConverter(propType).UnderlyingType;

                table.Columns.Add(prop.Name, propType);
            }

            // Add the property values per T as rows to the datatable
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                    values[i] = props[i].GetValue(item, null);

                table.Rows.Add(values);
            }

            return table;
        }

        public static void OnlyNumeric(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public static void OnlyChar(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)13 && e.KeyChar != (char)8 && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        public static void DecimalValidation(KeyPressEventArgs e, object sender)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
        public static void txtForIP(KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();

                if (str != "")
                {
                    string[] rows = str.Split(',');

                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        public static string ExportToCSVFile(DataTable dtTable)
        {
            StringBuilder sbldr = new StringBuilder();
            try
            {
                if (dtTable.Columns.Count != 0)
                {
                    foreach (DataColumn col in dtTable.Columns)
                    {
                        sbldr.Append(col.ColumnName + ',');
                    }
                    sbldr.Append("\r\n");
                    foreach (DataRow row in dtTable.Rows)
                    {
                        foreach (DataColumn column in dtTable.Columns)
                        {
                            sbldr.Append(row[column].ToString() + ',');
                        }
                        sbldr.Append("\r\n");
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return sbldr.ToString();
        }

        public static DataTable getInstalledPrinters()
        {
            DataTable dtPrinters = new DataTable();
            dtPrinters.Columns.Add("Display");
            dtPrinters.Columns.Add("Value");
            for (int i = 0; i <= System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1; i++)
            {
                DataRow drRow = dtPrinters.NewRow();
                drRow["Display"] = System.Drawing.Printing.PrinterSettings.InstalledPrinters[i].ToString();
                drRow["Value"] = System.Drawing.Printing.PrinterSettings.InstalledPrinters[i].ToString();
                dtPrinters.Rows.Add(drRow);
            }

            return dtPrinters;
        }
        public static string GetPrn()
        {
            string sPrn = string.Empty;
            try
            {
                string sPath = System.Windows.Forms.Application.StartupPath + "\\ZCASEBOTTLELABEL.PRN";
                if (!File.Exists(sPath))
                {
                    return sPrn = "ERROR~Prn not found";
                }
                StreamReader sr = new StreamReader(sPath);
                sPrn = string.Empty;
                sPrn = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                throw ex;
            }
            return sPrn;
        }
        public static string SendCommandToPrinter(string sCaseNo, string sPrinterIP, int iPrinterPort,
            string sPrn
            )
        {
            string sResult = string.Empty;
            TcpClient client = new TcpClient(sPrinterIP, iPrinterPort);
            NetworkStream stream = client.GetStream();
            try
            {

                PCommon.mAppLog.WriteLog("Socket Connect", DTPLLogsWrite.LogType.Information, MethodBase.GetCurrentMethod());
                byte[] sendData = Encoding.ASCII.GetBytes(sPrn);
                PCommon.mAppLog.WriteLog("Command Send", DTPLLogsWrite.LogType.Information, MethodBase.GetCurrentMethod());
                stream.Write(sendData, 0, sendData.Length);
                sResult = "Success";
            }
            catch (SocketException ex)
            {
                PCommon.mAppLog.WriteLog(ex.Message, DTPLLogsWrite.LogType.Error, MethodBase.GetCurrentMethod());
                sResult = "ERROR~" + ex.Message;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (client != null)
                {
                    client.Close();
                }
            }
            return sResult;
        }

        public static void ExportToPdf(System.Data.DataTable dt, string strFilePath, string sFileName)
        {
            Document document = new Document();
            Paragraph paragraph = new Paragraph(sFileName);
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.SpacingAfter = 1f;
            paragraph.SpacingAfter = 10f;
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(strFilePath, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + "\\ClientLogo.png");
            jpg.ScaleToFit(120f, 100f);

            //Give space before image

            jpg.SpacingBefore = 10f;

            //Give some space after the image

            jpg.SpacingAfter = 1f;

            jpg.Alignment = Element.ALIGN_LEFT;
            document.Add(jpg);
            document.Add(paragraph);
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
                widths[i] = 4f;

            table.SetWidths(widths);

            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";


            PdfPCell cell = new PdfPCell(new Phrase("Products"));

            cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {
                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int h = 0; h < dt.Columns.Count; h++)
                    {
                        table.AddCell(new Phrase(r[h].ToString(), font5));
                    }
                }
            }
            document.Add(table);
            document.Close();
        }

        public static void ExportToExcel(DataTable dt, string strFilePath, string sFileName)
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = false;
            excel.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range excelCellrange;
            sheet1.Name = sFileName;
            int StartCol = 1;
            int StartRow = 1;
            int j = 0, i = 0;


            excelCellrange = sheet1.Range[sheet1.Cells[1, 1], sheet1.Cells[dt.Rows.Count, dt.Columns.Count]];
            excelCellrange.EntireColumn.AutoFit();
            Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;

            //Write Headers
            for (j = 0; j < dt.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dt.Columns[j].ToString();
            }
            StartRow++;
            //Write datagridview content
            for (i = 0; i < dt.Rows.Count; i++)
            {
                for (j = 0; j < dt.Columns.Count; j++)
                {
                    try
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = dt.Rows[j][i].ToString() == null ? "" : dt.Rows[j][i].ToString();
                    }
                    catch
                    {
                        ;
                    }
                }
            }
            sheet1.SaveAs(strFilePath + "\\" + sFileName, ".xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            workbook.Close();
        }

        public static void exportToExcel1(DataTable dt,string sFilePath)
        {

            /*Set up work book, work sheets, and excel application*/
            Microsoft.Office.Interop.Excel.Application oexcel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                object misValue = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Workbook obook = oexcel.Workbooks.Add(misValue);
                Microsoft.Office.Interop.Excel.Worksheet osheet = new Microsoft.Office.Interop.Excel.Worksheet();
                //  obook.Worksheets.Add(misValue);

                osheet = (Microsoft.Office.Interop.Excel.Worksheet)obook.Sheets["Sheet1"];
                int colIndex = 0;
                int rowIndex = 1;

                foreach (DataColumn dc in dt.Columns)
                {
                    colIndex++;
                    osheet.Cells[1, colIndex] = dc.ColumnName;
                }
                foreach (DataRow dr in dt.Rows)
                {
                    rowIndex++;
                    colIndex = 0;

                    foreach (DataColumn dc in dt.Columns)
                    {
                        colIndex++;
                        osheet.Cells[rowIndex, colIndex] = dr[dc.ColumnName];
                    }
                }

                osheet.Columns.AutoFit();
                string filepath = sFilePath;

                //Release and terminate excel

                obook.SaveAs(filepath);
                obook.Close();
                oexcel.Quit();
                releaseObject(osheet);

                releaseObject(obook);

                releaseObject(oexcel);
                GC.Collect();
            }
            catch (Exception ex)
            {
                oexcel.Quit();
            }
        }
        private static void releaseObject(object o)
        {
            try
            {
                while
                    (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0) { }
            }
            catch { }
            finally { o = null; }
        }
    }
}
