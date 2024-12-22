using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEMailDesign.Model
{
    public class EMailDTO
    {
        public string CustomerCode { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string BranchCode { get; set; }
    }
}
