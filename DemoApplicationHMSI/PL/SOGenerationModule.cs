using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplicationHMSI.PL
{
    public class SOGenerationModule
    {
        public string SiteCode { get; set; }
        public string IDNO { get; set; }
        public string InHousePartNo { get; set; }
        public string CustPartNo { get; set; }
        public string CustCode { get; set; }
        public int SOQTY { get; set; } = 0;
    }
}
