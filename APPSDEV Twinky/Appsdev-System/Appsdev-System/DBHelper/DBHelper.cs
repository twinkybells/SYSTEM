using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace Appsdev_System.DBHelper
{
    internal class DBHelper
    {
        //used for database transaction
        public static string gen = "";
        public static OleDbConnection conn;
        public static OleDbCommand command;
        public static OleDbDataReader reader;
        public static void fill(string q, DataGridView dgv)
        {
            try
            {
                Connection.Connection.DB();
                DataTable dt = new DataTable();
                OleDbDataAdapter data = null;
                OleDbCommand command = new OleDbCommand(q, Connection.Connection.conn);
                data = new OleDbDataAdapter(command);
                data.Fill(dt);
                dgv.DataSource = dt;
                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                Connection.Connection.conn.Close();
                MessageBox.Show(ex.Message, "Error FillDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
