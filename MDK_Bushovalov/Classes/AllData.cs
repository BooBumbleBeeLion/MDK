using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MDK_Bushovalov.Windows;

namespace MDK_Bushovalov.Classes
{
    class AllData
    {
        public static MySqlConnection con = new MySqlConnection("pwd = IDDQD; uid = root; database = zoo; server = localhost");
        public static string ID;
        public static Auth auth;
        public static Empl empl;
    }
}
