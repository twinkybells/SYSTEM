using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appsdev_System.Connection
{
    internal class Connection
    {
        public static OleDbConnection conn;
        private static string dbconnect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\APPSDEV Twinky\\Appsdev-System\\Appsdev-System\\bin\\Debug\\Database1.accdb\"";
        public static void DB()
        {
            try
            {
                conn = new OleDbConnection(dbconnect);
                conn.Open();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
