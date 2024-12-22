using SendEMailDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEMailDesign.Service
{
    abstract public class BaseProvider
    {
        public int Port { get; set; } =Configuration.Port;
        public string ServerHostName { get; set; } = Configuration.ServerHostName;

        public abstract Task Send(MailObject mailObject);
    }
}
