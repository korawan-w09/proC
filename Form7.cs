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
using System.IO;

namespace project
{
    public partial class Form7 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        private void showDC95()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ลำดับ,name,รุ่น_DC,ราคา,รหัสสินค้า,จำนวน FROM stock_95 ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        private void showDC70()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ลำดับ,name,รุ่น_DC,ราคา,รหัสสินค้า,จำนวน FROM stock_70 ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) //เพิ่ม
        {
            if (comboBox1.Text == "รุ่นDC_70")
            {
                MySqlConnection conn = databaseConnection();


                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();

                
                string insertQuery = "INSERT INTO kubota.stock_70( name, รุ่น_DC, ราคา, รหัสสินค้า, จำนวน,image) VALUES ( @NAME, @dc, @totel, @ID, @NUM,@IMAGE)";
                conn.Open();

                MySqlCommand command = new MySqlCommand(insertQuery, conn);
               
                //command.Parameters.Add("@ลำดับ", MySqlDbType.Int11);
                command.Parameters.Add("@NAME", MySqlDbType.VarChar);
                command.Parameters.Add("@dc", MySqlDbType.VarChar);
                command.Parameters.Add("@totel", MySqlDbType.Int32);
                command.Parameters.Add("@ID", MySqlDbType.VarChar);
                command.Parameters.Add("@NUM", MySqlDbType.Int24);
                command.Parameters.Add("@IMAGE", MySqlDbType.LongBlob);
                

                //command.Parameters["@ลำดับ"].Value = txtCari.Text;
                command.Parameters["@NAME"].Value = textBox6.Text;
                command.Parameters["@dc"].Value = textBox7.Text;
                command.Parameters["@totel"].Value = textBox8.Text;
                command.Parameters["@ID"].Value = textBox2.Text;
                command.Parameters["@NUM"].Value = textBox9.Text;
                command.Parameters["@IMAGE"].Value = img;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data inserted");
                }

                conn.Close();


            }
            else if (comboBox1.Text == "รุ่นDC_95")
            {
                MySqlConnection conn = databaseConnection();


                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();


                string insertQuery = "INSERT INTO kubota.stock_95( name, รุ่น_DC, ราคา, รหัสสินค้า, จำนวน,image) VALUES ( @NAME, @dc, @totel, @ID, @NUM,@IMAGE)";
                conn.Open();

                MySqlCommand command = new MySqlCommand(insertQuery, conn);

                //command.Parameters.Add("@ลำดับ", MySqlDbType.Int11);
                command.Parameters.Add("@NAME", MySqlDbType.VarChar);
                command.Parameters.Add("@dc", MySqlDbType.VarChar);
                command.Parameters.Add("@totel", MySqlDbType.Int32);
                command.Parameters.Add("@ID", MySqlDbType.VarChar);
                command.Parameters.Add("@NUM", MySqlDbType.Int24);
                command.Parameters.Add("@IMAGE", MySqlDbType.LongBlob);


                //command.Parameters["@ลำดับ"].Value = txtCari.Text;
                command.Parameters["@NAME"].Value = textBox6.Text;
                command.Parameters["@dc"].Value = textBox7.Text;
                command.Parameters["@totel"].Value = textBox8.Text;
                command.Parameters["@ID"].Value = textBox2.Text;
                command.Parameters["@NUM"].Value = textBox9.Text;
                command.Parameters["@IMAGE"].Value = img;

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data inserted");
                }

                conn.Close();


            }

        }

        private void button8_Click(object sender, EventArgs e)//เพิ่มรูป
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; .gif)|.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "รุ่นDC_70")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ลำดับ,name,รุ่น_DC,ราคา,รหัสสินค้า,จำนวน,image FROM stock_70 ";

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(ds);
                conn.Close();
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                textBox7.Text = "70";



            }
            else if (comboBox1.Text == "รุ่นDC_95")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ลำดับ,name,รุ่น_DC,ราคา,รหัสสินค้า,จำนวน,image FROM stock_95 ";

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                textBox7.Text = "95";

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            byte[] img = (byte[])dataGridView1.CurrentRow.Cells["image"].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);

            dataGridView1.CurrentRow.Selected = true;
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["รหัสสินค้า"].FormattedValue.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["รุ่น_DC"].FormattedValue.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["ราคา"].FormattedValue.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["จำนวน"].FormattedValue.ToString();
            
            //x_txt.Text = datastock.Rows[e.RowIndex].Cells["x"].FormattedValue.ToString();
            //total.Text = datastock.Rows[e.RowIndex].Cells["ราคา"].FormattedValue.ToString();

        }
        private void clear()
        {
            textBox2.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)//แก้ไข
        { 
            if (comboBox1.Text == "รุ่นDC_95") { 
                if (textBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("คุณต้องการแก้ไขข้อมูลใช่หรือไม่", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);//เงื่อนไงปุ่มแก้ไข
                if (dialogResult == DialogResult.Yes)
                {

                    int selectRow = dataGridView1.CurrentCell.RowIndex;
                    int editId = Convert.ToInt32(dataGridView1.Rows[selectRow].Cells["ลำดับ"].Value);

                    MySqlConnection conn = databaseConnection();

                    string sql = "UPDATE stock_95 SET รหัสสินค้า='" + textBox2.Text + "',name='" + textBox6.Text + "',รุ่น_DC='" + textBox7.Text + "',ราคา='" + textBox8.Text + "',จำนวน='" + textBox9.Text + "' WHERE ลำดับ ='" + editId + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();

                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rows > 0)
                    {
                        MessageBox.Show("แก้ไขข้อมูลสำเร็จ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showDC95();
                        clear();
                    }
                }
                else
                { }
            }
            else
            {
                MessageBox.Show("กรอกข้อมูลไม่ครบ ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                clear();
            }

        }
            else if (comboBox1.Text == "รุ่นDC_70")
            {
                if (textBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("คุณต้องการแก้ไขข้อมูลใช่หรือไม่", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);//เงื่อนไงปุ่มแก้ไข
                    if (dialogResult == DialogResult.Yes)
                    {

                        int selectRow = dataGridView1.CurrentCell.RowIndex;
                        int editId = Convert.ToInt32(dataGridView1.Rows[selectRow].Cells["ลำดับ"].Value);

                        MySqlConnection conn = databaseConnection();

                        string sql = "UPDATE stock_70 SET รหัสสินค้า='" + textBox2.Text + "',name='" + textBox6.Text + "',รุ่น_DC='" + textBox7.Text + "',ราคา='" + textBox8.Text + "',จำนวน='" + textBox9.Text + "' WHERE ลำดับ ='" + editId + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        conn.Open();

                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (rows > 0)
                        {
                            MessageBox.Show("แก้ไขข้อมูลสำเร็จ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showDC70();
                            clear();
                        }
                    }
                    else
                    { }
                }
                else
                {
                    MessageBox.Show("กรอกข้อมูลไม่ครบ ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clear();
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)//ลบ
        {
            if (comboBox1.Text == "รุ่นDC_95")
            {
                if (textBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("คุณต้องการลบข้อมูลใช่หรือไม่", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);//เงื่อนไงปุ่มแก้ไข
                    if (dialogResult == DialogResult.Yes)
                    {

                        int selectRow = dataGridView1.CurrentCell.RowIndex;
                        int editId = Convert.ToInt32(dataGridView1.Rows[selectRow].Cells["ลำดับ"].Value);

                        MySqlConnection conn = databaseConnection();

                        string sql = "DELETE FROM stock_95  WHERE ลำดับ ='" + editId + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        conn.Open();

                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (rows > 0)
                        {
                            MessageBox.Show("ลบข้อมูลสำเร็จ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showDC95();
                            clear();
                        }
                    }
                    else
                    { }
                }
                else
                {
                    MessageBox.Show("กรอกข้อมูลไม่ครบ ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clear();
                }

            }
            else if (comboBox1.Text == "รุ่นDC_70")
            {
                if (textBox2.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("คุณต้องการลบข้อมูลใช่หรือไม่", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);//เงื่อนไงปุ่มแก้ไข
                    if (dialogResult == DialogResult.Yes)
                    {

                        int selectRow = dataGridView1.CurrentCell.RowIndex;
                        int editId = Convert.ToInt32(dataGridView1.Rows[selectRow].Cells["ลำดับ"].Value);

                        MySqlConnection conn = databaseConnection();

                        string sql = "DELETE FROM stock_70   WHERE ลำดับ ='" + editId + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        conn.Open();

                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();

                        if (rows > 0)
                        {
                            MessageBox.Show("ลบข้อมูลสำเร็จ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showDC70();
                            clear();
                        }
                    }
                    else
                    { }
                }
                else
                {
                    MessageBox.Show("กรอกข้อมูลไม่ครบ ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clear();
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
