using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace project
{
    public partial class Form3 : Form
    {

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form3()
        {
            InitializeComponent();
        }
        

        private void user() 
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM login WHERE usern =\"{usernname.Text}\"AND passw =\"{password.Text}\"";

            MySqlDataReader row = cmd.ExecuteReader();
            row.Read();
            if (row.HasRows)
            {
                Program.checkstatus = row.GetString("status");
                if (Program.checkstatus == "USER") { 
                    MessageBox.Show("เข้าสู่ระบบสำเร็จ");
                Form4 f4 = new Form4();
                this.Hide();
                f4.Show();
                }
                else
                {
                    MessageBox.Show("เข้าสู่ระบบสำเร็จ");
                    Form6 f6 = new Form6();
                    this.Hide();
                    f6.Show();

                }
            }
            else { MessageBox.Show("เข้าสู่ระบบไม่สำเร็จ เนื่องจากชื่อผู้ใช้งานหรือรหัสผ่านไม่ถูกต้อง "); }
            usernname.Clear();
            password.Clear();
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e) 
        {
            user();

        }

        private void usernname_KeyPress(object sender, KeyPressEventArgs e) //ไม่ให้กรอกไทย
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
