using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApplicationHMSI.PL
{
    public class PLKanbonPrinting
    {
        public string ShiftCode { get; set; }
        public DateTime ProductionDate { get; set; }
        public string IDNO { get; set; }
        public string LineCode { get; set; }
        public string InHousePartNo { get; set; }
        public string CustPartNo { get; set; }
        public string CustCode { get; set; }
        public string BinType { get; set; }
        public string KanbonBarcode { get; set; }
        public int Qty { get; set; }
        public string PrintedBy { get; set; }

        public string ManualBarcode { get; set; } 

    }
}
