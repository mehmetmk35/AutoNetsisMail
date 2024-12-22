using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEMail.Infrastructur
{
    static class Configuration
    {
        static public string Rest_RestUrl
        {
            get
            {
                var path = Environment.CurrentDirectory;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager?.GetSection("Rest")["RestUrl"];
            }

        }
        static public string Company
        {
            get
            {
                var path = Environment.CurrentDirectory;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager?.GetSection("Rest")["DbName"];
            }
        }
        static public string RestPassword
        {
            get
            {
                var path = Environment.CurrentDirectory;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager?.GetSection("Rest")["password"];
            }
        }
        static public string RestUsername
        {
            get
            {
                var path = Environment.CurrentDirectory;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager?.GetSection("Rest")["username"];
            }
        }



    }
}
