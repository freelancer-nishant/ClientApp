using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace ClientApplication.DAL.Helper
{
    public class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ClientDataBase"].ConnectionString;
        }
    }
}
