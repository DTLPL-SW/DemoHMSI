using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplicationHMSI.BusinessLayer
{
    public class blClsPrint
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct DOCINFO
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDataType;
        }

        class PrintBarcode
        {
            [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
            public static extern long OpenPrinter(string pPrinterName, ref IntPtr phPrinter, int pDefault);
            [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
            public static extern long StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFO pDocInfo);
            [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern long StartPagePrinter(IntPtr hPrinter);
            [DllImport("winspool.drv", CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern long WritePrinter(IntPtr hPrinter, string data, int buf, ref int pcWritten);
            [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern long EndPagePrinter(IntPtr hPrinter);
            [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern long EndDocPrinter(IntPtr hPrinter);
            [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern long ClosePrinter(IntPtr hPrinter);
        }

        public static int PrintCommand(string strLabel, string PrinterName)
        {
            int iResult = 0;
            System.IntPtr lhPrinter = new System.IntPtr();
            DOCINFO di = new DOCINFO();
            int pcWritten = 0;
            int iprinter = 0;
            for (int i = 0; i <= System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1; i++)
            {
                if (System.Drawing.Printing.PrinterSettings.InstalledPrinters[i].ToString() == PrinterName)
                {
                    iprinter = 1;
                    //PrintDocument1.PrinterSettings.PrinterName = "Zebra TLP2844" 
                    break; // TODO: might not be correct. Was : Exit For 
                }
            }

            if (iprinter == 1)
            {
                Console.WriteLine(PrinterName);
                PrintBarcode.OpenPrinter(PrinterName, ref lhPrinter, 0);
                if (lhPrinter == IntPtr.Zero)
                {
                    Console.WriteLine("Printer Not found");
                    //Console.ReadLine();
                    iResult = 0;
                }
                //PrintDirect.OpenPrinter("LPT:", ref lhPrinter, 0); 
                PrintBarcode.StartDocPrinter(lhPrinter, 1, ref di);
                PrintBarcode.StartPagePrinter(lhPrinter);
                PrintBarcode.WritePrinter(lhPrinter, strLabel, strLabel.Length, ref pcWritten);
                PrintBarcode.EndPagePrinter(lhPrinter);
                PrintBarcode.EndDocPrinter(lhPrinter);
                PrintBarcode.ClosePrinter(lhPrinter);

                //PCommon.mAppLog.LogMessage(EventNotice.EventTypes.evtInfo, MethodBase.GetCurrentMethod().Name, strLabel + " and printer name is" + PrinterName );
                iResult = 1;
            }
            return iResult;
        }
        public bool PrinterCheck(string _sPrinterName)
        {
            bool _printerCheck = false;
            try
            {
                // Set management scope
                ManagementScope scope = new ManagementScope(@"\root\cimv2");
                scope.Connect();
                // Select Printers from WMI Object Collections
                ManagementObjectSearcher searcher = new
                ManagementObjectSearcher("SELECT * FROM Win32_Printer");

                string printerName = "";
                foreach (ManagementObject printer in searcher.Get())
                {
                    printerName = printer["Name"].ToString().ToLower();
                    if (printerName.ToUpper().Equals(_sPrinterName.ToUpper()))
                    {
                        Console.WriteLine("Printer = " + printer["Name"]);
                        if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
                        {
                            // printer is offline by user
                            _printerCheck = false;
                        }
                        else
                        {
                            // printer is not offline
                            _printerCheck = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _printerCheck;
        }

    }
}
