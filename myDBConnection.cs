using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AutoDigdaApplication
{
    class myDBConnection
    {
        public MySqlConnection cn;
        public void Connect()
        {
            try
            {
                cn = new MySqlConnection("Server=127.0.0.1;Port=3307;Database=autodigda;Uid=root;Pwd=;");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
