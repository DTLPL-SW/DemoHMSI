using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplicationHMSI.PL
{
    public class ItemMasterModel
    {
        public string SiteCode { get; set; }
        public string IDNO { get; set; }
        public string InHousePartNo { get; set; }
        public string CustPartNo { get; set; }
        public string CustCode { get; set; }
        public string PackingType { get; set; }
        public int PackSize { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
       
    }
}