using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEMailDesign
{
    static class Configuration
    {
        static public string Db_Connection
        {
            get
            {
                var path = Environment.CurrentDirectory;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager?.GetSection("ConnectionStrings")["SQLConnection"];
            }

        }

        static public string Netsis_Mail
        {
            get
            {
                var path = Environment.CurrentDirectory;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager?.GetSection("Mail")["CompanyMail"];
            }

        }
        static public string ServerHostName
        {
            get
            {
                var path = Environment.CurrentDirectory;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager?.GetSection("Mail")["ServerHostName"];
            }

        }
        static public string MailSubject
        {
            get
            {
                var path = Environment.CurrentDirectory;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager?.GetSection("Mail")["Subject"];
            }

        }
        static public int Port
        {
            get
            {
                var path = Environment.CurrentDirectory;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return Convert.ToInt32(configurationManager?.GetSection("Mail")["Port"]);
            }

        }

        static public int DesignNumber
        {
            get
            {
                var path = Environment.CurrentDirectory;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return Convert.ToInt32(configurationManager?.GetSection("Mail")["DesignNumber"]);
            }

        }
        static public string PdfName
        {
            get
            {
                var path = Environment.CurrentDirectory;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return  configurationManager?.GetSection("Mail")["PdfName"];
            }

        }
    }
}
