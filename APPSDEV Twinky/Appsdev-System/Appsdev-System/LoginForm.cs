﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Appsdev_System
{
    public partial class LoginForm : Form
    {
        public static string sendtext = "";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 200)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Stop();
                this.Hide();

                progressBar1.Value = 0;
                sendtext = txtusername.Text;
                Records rec = new Records();
                rec.Show();
            }
        }

       

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Connection.DB();
                DBHelper.DBHelper.gen = "Select * from users where [username] = '" + txtusername.Text + "' and [password] = '" + txtpassword.Text + "'";
                DBHelper.DBHelper.command = new OleDbCommand(DBHelper.DBHelper.gen, Connection.Connection.conn);
                DBHelper.DBHelper.reader = DBHelper.DBHelper.command.ExecuteReader();

                if (DBHelper.DBHelper.reader.HasRows)
                {
                    DBHelper.DBHelper.reader.Read();
                    //database  
                    txtusername.Text = (DBHelper.DBHelper.reader["username"].ToString());
                    txtpassword.Text = (DBHelper.DBHelper.reader["password"].ToString());
                    timer1.Enabled = true;
                    timer1.Start();
                    timer1.Interval = 1;
                    progressBar1.Maximum = 200;
                    timer1.Tick += new EventHandler(timer1_Tick);
                }
                else
                {
                    MessageBox.Show("Invalid Username and Password");

                }
                Connection.Connection.conn.Close();
            }
            catch (Exception ex)
            {
                Connection.Connection.conn.Close();
                MessageBox.Show(ex.Message);

            }
        }
    }
}
