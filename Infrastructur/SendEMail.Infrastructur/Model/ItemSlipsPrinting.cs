using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEMail.Infrastructur.Model
{
    public class ItemSlipsPrinting
    {
        public int DesignNumber { get; set; }
        public bool StreamSupport { get; set; } = true;
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string CustomerCode { get; set; }
        public bool Use64BitService { get; set; } = true;
    }
}
