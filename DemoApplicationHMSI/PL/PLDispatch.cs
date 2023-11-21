using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApplicationHMSI.PL
{
    public class PLDispatch
    {
        public string SONO { get; set; }
        public string CustCode { get; set; }
        public string BinKanban { get; set; }
        public string CustKanban { get; set; }
        public string Remarks { get; set; }
        public string IDNO { get; set; }
        public int SOQty { get; set; }
        public int KanbanQty { get; set; }

        public string BinType { get; set; }
        public int BinSize { get; set; } 

        public Image DataImage { get; set; }

    }
}
