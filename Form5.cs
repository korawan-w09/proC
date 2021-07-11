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
    public partial class Form5 : Form
    {

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Form5()
        {
            InitializeComponent();
        }

        private List<Class1> allbook = new List<Class1>();



        private void basket_stock() //เป็นคำสั่งที่ไว้เรียกใช้เวลาแสดงรายการสินค้าที่สั่งซื้อ
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT usern,name,รุ่น_DC,ราคา,จำนวน,time,รหัสสินค้า FROM basket_stock ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            databasket.DataSource = ds.Tables[0].DefaultView;



        }

        string a_stocks;
        private void select_a_stocks_70() // ดึงค่า amount จาก stock
        {
            String name1 = label_name.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT จำนวน FROM stock_70 WHERE รหัสสินค้า  ='" + label_code.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            
            MySqlDataReader dr = cmd.ExecuteReader();
            

            if (dr.Read())
            {
                a_stocks = dr.GetValue(0).ToString();
            }
        }

        private void select_a_stocks_95() // ดึงค่า amount จาก stock
        {
            String name1 = label_name.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT จำนวน FROM stock_95 WHERE รหัสสินค้า  ='" + label_code.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            MySqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                a_stocks = dr.GetValue(0).ToString();
            }
        }

        string a_carts;
        private void select_a_carts() // ดึง amount จาก cart
        {
            String name1 = label_name.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT จำนวน FROM basket_stock WHERE รหัสสินค้า  ='" + label_code.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a_carts = dr.GetValue(0).ToString();
            }

        }

        string a_stock;
        string a_stock1;
        string a_stock2;

        private void select_a_stock_70()
        {
            String name1 = label_name.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT จำนวน FROM stock_70 WHERE name =\"{ name1}\" AND รหัสสินค้า  ='" + label_code.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a_stock = dr.GetValue(0).ToString();
            }
        }

        private void select_a_stock_95()
        {
            String name1 = label_name.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT จำนวน FROM stock_95 WHERE name =\"{ name1}\" AND รหัสสินค้า  ='" + label_code.Text + "' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a_stock = dr.GetValue(0).ToString();
            }
        }
        private void select_a_stock1() // name
        {
            String name1 = label_name.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT จำนวน FROM sale_info WHERE name =\"{ name1}\"";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                a_stock1 = dr.GetValue(0).ToString();
            }
        }

        private void select_a_stock_70_2()
        {

            String name1 = label_name2.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT จำนวน FROM stock_70 WHERE name =\"{ name1}\"AND รหัสสินค้า =\"{label_code.Text}\"";;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;            
            MySqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {
                a_stock2 = dr.GetValue(0).ToString();

            }

        }

        private void select_a_stock_95_2()
        {

            String name1 = label_name2.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT จำนวน FROM stock_95 WHERE name =\"{ name1}\"AND รหัสสินค้า =\"{label_code.Text}\""; ;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                a_stock2 = dr.GetValue(0).ToString();

            }

        }

        //private void showraka() //โชว์ราคาในTexbox3อัน
        //{

        //    MySqlConnection conn = databaseConnection();
        //    conn.Open();
        //    MySqlCommand cmd;
        //    cmd = conn.CreateCommand();
        //    cmd.CommandText = "SELECT COALESCE(sum(รวม),0)  FROM basket_stock ";
        //    MySqlDataReader rowss = cmd.ExecuteReader();
        //    rowss.Read();
        //    Program.check = rowss.GetString("COALESCE(sum(รวม),0)");
        //    totaltext.Text = Program.check;





        //}

        private void show_total_price()
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT SUM(ราคา) FROM basket_stock ";
            object sum = cmd.ExecuteScalar();
            if (Convert.ToString(sum) == "")
            {
                totaltext.Text = "0";

            }
            else
            {
                totaltext.Text = Convert.ToString(sum);

            }

        }

        private void show_basket_stock()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM basket_stock WHERE usern = '" + Program.usern + "'";
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.Fill(ds);
            conn.Close();
            databasket.DataSource = ds.Tables[0].DefaultView;

        }

        string all_prices;
        private void select_all_price()
        {

            String name1 = label_code.Text;
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string sql = $"SELECT ราคา FROM stock_70 WHERE รหัสสินค้า = \"{name1}\"";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                all_prices = dr.GetValue(0).ToString();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Add("รุ่นDC70");
            //comboBox1.Items.Add("รุ่นDC95");
            show_total_price();
            basket_stock();



        }

        private void databasket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //คำสั่งที่เลือกรุ่นในcombobox
        {
            if (comboBox1.Text == "รุ่นDC70")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ลำดับ, name, รุ่น_DC,ราคา,จำนวน,รหัสสินค้า,image FROM stock_70 ";

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(ds);
                conn.Close();
                datastock.DataSource = ds.Tables[0].DefaultView;




            }
            else if (comboBox1.Text == "รุ่นDC95")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ลำดับ,name,รุ่น_DC,ราคา,จำนวน,รหัสสินค้า,image FROM stock_95 ";

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                conn.Close();
                datastock.DataSource = ds.Tables[0].DefaultView;

            }
        }

        private void show_stock_70_update()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ลำดับ, name, รุ่น_DC,ราคา,จำนวน,รหัสสินค้า,image FROM stock_70 ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(ds);
            conn.Close();
            datastock.DataSource = ds.Tables[0].DefaultView;
        }

        private void show_stock_95_update()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ลำดับ,name,รุ่น_DC,ราคา,จำนวน,รหัสสินค้า,image FROM stock_95 ";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            datastock.DataSource = ds.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)//ปุ่มเพิ่มสินค้า
        {
            //int code2 = int.Parse(code.Text);
            //MySqlConnection conn = databaseConnection();

            //String sql = "INSERT INTO basket_stock(รหัสสินค้า,name,รุ่น_DC,ราคา,จำนวน,รวม,image) VALUES('" + code.Text + "','" + name.Text + "' ,'" + Program.DC + "',' " + price.Text + "','" + textBox1.Text + "','" + total.Text + "','"+ pictureBox1 +"')";
            //MySqlCommand cmd = new MySqlCommand(sql, conn);

            //conn.Open();
            //int rows = cmd.ExecuteNonQuery();
            //conn.Close();
            //if (rows > 0)
            //{

            //    basket_stock();//เรียกแสดงข้อมูลใหม่
            //    showraka();

            //}

            int nu_amount = int.Parse(numericUpDown1.Text);
            int ch_amount = int.Parse(label_จำนวน.Text);

            if (nu_amount > ch_amount)
            {
                MessageBox.Show("ไม่สามารถเลือกสินค้าเกินจำนวนที่มีได้", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string connectionStingl = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
                MySqlConnection connl = new MySqlConnection(connectionStingl);
                connl.Open();
                using (MySqlCommand cmdl = new MySqlCommand("SELECT รหัสสินค้า FROM basket_stock WHERE รหัสสินค้า ='" + label_code.Text + "' ", connl)) // Check สินค้าในตะกร้าว่ามีซ้ำไหม
                {
                    MySqlDataReader dr = cmdl.ExecuteReader();
                    if (dr.Read())
                    {                               // กรณีที่เลือกสินค้าซ้ำ
                        //select_a_stocks_70();
                        //select_a_stocks_95();

                        if(comboBox1.Text == "รุ่นDC70")
                        {
                            select_a_stock_70();
                            select_a_carts();
                        }
                        else if(comboBox1.Text == "รุ่นDC95")
                        {
                            select_a_stocks_95();
                            select_a_carts();
                        }

                        
                        int A_CART = int.Parse(a_carts); // a สินค้าในตะกร้า
                        int A_NU_SELECT = int.Parse(numericUpDown1.Text); //สินค้าที่เลือก (แก้ไขสินค้า)
                                                                          //if (A_NU_SELECT > A_CART)
                                                                          //{
                                                                          //    MessageBox.Show("สินค้าใน stock มีไม่เพียงพอ");

                        //}

                        int ALL_AMOUNT = A_CART + A_NU_SELECT; //จำนวนทั้งหมด
                        string ALL_PRICE = (int.Parse(price.Text) * ALL_AMOUNT).ToString(); //ราคาทั้งหมด
                        string ALL_AMOUNTS = ALL_AMOUNT.ToString();
                        string connectionsn = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;"; // UPDATE ตะกร้า
                        MySqlConnection connss = new MySqlConnection(connectionsn);
                        String sqlsn = "UPDATE basket_stock SET จำนวน ='" + ALL_AMOUNTS + "' , ราคา = '" + ALL_PRICE + "' WHERE รหัสสินค้า ='" + label_code.Text + "'";   // UPDATE ตะกร้าสินค้า
                        MySqlCommand cmds = new MySqlCommand(sqlsn, connss);
                        connss.Open();
                        int row = cmds.ExecuteNonQuery();
                        if (row > 0)
                        {
                            select_a_stock_70();
                            select_a_stock_95();   //คัดลอกจำนวนจาก stock


                            int amount_stock = int.Parse(a_stock); // จำนวนจาก stock
                            int nu_updown = int.Parse(numericUpDown1.Text); // จำนวนที่เลือก
                            string amount_update = (amount_stock - nu_updown).ToString();
                            if (comboBox1.Text == "รุ่นDC70")
                            {
                                string connection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
                                MySqlConnection conn2 = new MySqlConnection(connection2);
                                String sql2 = "UPDATE stock_70 SET จำนวน = '" + amount_update + "' WHERE รหัสสินค้า = '" + label_code.Text + "' "; // UPDATE สินค้าใน stock
                                MySqlCommand cmd2 = new MySqlCommand(sql2, conn2);
                                conn2.Open();
                                int rows2 = cmd2.ExecuteNonQuery();
                                if (rows2 > 0)
                                {
                                    basket_stock();
                                    show_total_price();

                                    if (comboBox1.Text == "รุ่นDC70")
                                    {
                                        show_stock_70_update();
                                        if (comboBox1.Text == "เลือกรุ่นDC")
                                        {
                                            show_stock_70_update();
                                        }
                                    }
                                    else if (comboBox1.Text == "รุ่นDC95")
                                    {
                                        show_stock_95_update();
                                        if (comboBox1.Text == "เลือกรุ่นDC")
                                        {
                                            show_stock_95_update();
                                        }
                                    }

                                }
                            }
                            else if (comboBox1.Text == "รุ่นDC95")
                            {
                                string connection3 = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
                                MySqlConnection conn3 = new MySqlConnection(connection3);
                                String sql3 = "UPDATE stock_95 SET จำนวน = '" + amount_update + "' WHERE รหัสสินค้า = '" + label_code.Text + "' "; // UPDATE สินค้าใน stock
                                MySqlCommand cmd3 = new MySqlCommand(sql3, conn3);
                                conn3.Open();
                                int rows3 = cmd3.ExecuteNonQuery();
                                if (rows3 > 0)
                                {
                                    basket_stock();
                                    show_total_price();

                                    if (comboBox1.Text == "รุ่นDC70")
                                    {
                                        show_stock_70_update();
                                        if (comboBox1.Text == "เลือกรุ่นDC")
                                        {
                                            show_stock_70_update();
                                        }
                                    }
                                    else if (comboBox1.Text == "รุ่นDC95")
                                    {
                                        show_stock_95_update();
                                        if (comboBox1.Text == "เลือกรุ่นDC")
                                        {
                                            show_stock_95_update();
                                        }
                                    }

                                }
                            }

                        }

                    }
                    else     //     กรณีที่เลือกสินค้าไม่ซ้ำ
                    {
                        select_a_stocks_70();  //คัดลอกจำนวนสินค้าใน stock
                        select_a_stocks_95();
                        select_a_carts();    //คัดลอกสินค้าใน ตะกร้าสินค้า
                        int A_CART = int.Parse(a_stocks); // a สินค้าในตะกร้า
                        int A_NU_SELECT = int.Parse(numericUpDown1.Text); // จำนวนที่เลือก
                        if (A_NU_SELECT > A_CART)
                        {
                            MessageBox.Show("สินค้าใน stock มีไม่เพียงพอ");

                        }
                        else
                        {
                            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
                            MySqlConnection conn = new MySqlConnection(connection);
                            conn.Open();
                            string pri = (int.Parse(price.Text) * int.Parse(numericUpDown1.Text)).ToString();
                            string time = System.DateTime.Now.ToString("dd / MM / yyyy");
                            String sql = $"INSERT INTO basket_stock(รหัสสินค้า,name,รุ่น_DC,ราคา,จำนวน,time) VALUES(\"{code.Text}\",\"{name.Text}\",\"{Program.DC}\",\"{pri}\",\"{numericUpDown1.Text}\",\"{time}\")";

                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                select_a_stock_70();
                                select_a_stock_95();


                                int amount_stock = int.Parse(a_stock);     // จำนวนสินค้าจาก stock
                                int nu_updown = int.Parse(numericUpDown1.Text); // จำนวนที่เลือก
                                string amount_update = (amount_stock - nu_updown).ToString(); // สินค้าคงเหลือ

                                if(comboBox1.Text == "รุ่นDC70")
                                {
                                    string connection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
                                    MySqlConnection conn2 = new MySqlConnection(connection2);
                                    String sql2 = "UPDATE stock_70 SET จำนวน = '" + amount_update + "' WHERE รหัสสินค้า = '" + label_code.Text + "' ";  // UPDATE จำนวนสินค้าเข้า stock
                                    MySqlCommand cmds = new MySqlCommand(sql2, conn2);
                                    conn2.Open();
                                    int rows2 = cmds.ExecuteNonQuery();
                                    if (rows2 > 0)
                                    {
                                        basket_stock();
                                        show_total_price();

                                        if (comboBox1.Text == "รุ่นDC70")
                                        {
                                            show_stock_70_update();

                                        }
                                        else if (comboBox1.Text == "รุ่นDC95")
                                        {
                                            show_stock_95_update();

                                        }
                                    }
                                }
                                else if(comboBox1.Text == "รุ่นDC95")
                                {
                                    string connection2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
                                    MySqlConnection conn2 = new MySqlConnection(connection2);
                                    String sql2 = "UPDATE stock_95 SET จำนวน = '" + amount_update + "' WHERE รหัสสินค้า = '" + label_code.Text + "' ";  // UPDATE จำนวนสินค้าเข้า stock
                                    MySqlCommand cmds = new MySqlCommand(sql2, conn2);
                                    conn2.Open();
                                    int rows2 = cmds.ExecuteNonQuery();
                                    if (rows2 > 0)
                                    {
                                        basket_stock();
                                        show_total_price();

                                        if (comboBox1.Text == "รุ่นDC70")
                                        {
                                            show_stock_70_update();

                                        }
                                        else if (comboBox1.Text == "รุ่นDC95")
                                        {
                                            show_stock_95_update();

                                        }
                                    }
                                }

                                
                            }
                        }


                    }


                }
            }


        }

        private void datastock_CellClick(object sender, DataGridViewCellEventArgs e)//นำข้อมูลไปใส่Textbox
        {
            try
            {
                byte[] img = (byte[])datastock.CurrentRow.Cells["image"].Value;
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);

                datastock.CurrentRow.Selected = true;
                code.Text = datastock.Rows[e.RowIndex].Cells["รหัสสินค้า"].FormattedValue.ToString();
                name.Text = datastock.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                price.Text = datastock.Rows[e.RowIndex].Cells["ราคา"].FormattedValue.ToString();
                Program.DC = datastock.Rows[e.RowIndex].Cells["รุ่น_DC"].FormattedValue.ToString();

                label_name.Text = datastock.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                label_code.Text = datastock.Rows[e.RowIndex].Cells["รหัสสินค้า"].FormattedValue.ToString();
                label_จำนวน.Text = datastock.Rows[e.RowIndex].Cells["จำนวน"].FormattedValue.ToString();
                label_name2.Text = datastock.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            }
            catch (Exception) { }

            

            //x_txt.Text = datastock.Rows[e.RowIndex].Cells["x"].FormattedValue.ToString();
            //total.Text = datastock.Rows[e.RowIndex].Cells["ราคา"].FormattedValue.ToString();
        }

        private void total_Click(object sender, EventArgs e)//คำนวณราคาสินค้า
        {
            //int price2 = int.Parse(price.Text);
            //int amount = int.Parse(numericUpDown1.Text);
            //int sum = price2 * amount;
            //total.Text = sum.ToString();
        }

        private void databasket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                databasket.CurrentRow.Selected = true;
                x_txt.Text = databasket.Rows[e.RowIndex].Cells["รหัสสินค้า"].FormattedValue.ToString();
                textBox5.Text = databasket.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
                amount_edit.Text = databasket.Rows[e.RowIndex].Cells["จำนวน"].FormattedValue.ToString();

                label_check_รุ่น.Text = databasket.Rows[e.RowIndex].Cells["รุ่น_DC"].FormattedValue.ToString();
            }
            catch (Exception) { }
            
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox3.Text);
            int b = int.Parse(totaltext.Text);
            textBox4.Text = (a - b).ToString();
        }

        private void button2_Click(object sender, EventArgs e)//ปุ่มลบรายการ
        {
            //DialogResult dialogResult = MessageBox.Show("คุณต้องการลบข้อมูลใช่หรือไม่??", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation); //เงื่อนไขปุ่มลบ
            //if (dialogResult == DialogResult.Yes)
            //{
            //    int selectRow = databasket.CurrentCell.RowIndex;
            //    int deleteId = Convert.ToInt32(databasket.Rows[selectRow].Cells["รหัสสินค้า"].Value);

            //    MySqlConnection conn = databaseConnection();

            //    string sql = "DELETE FROM basket_stock WHERE รหัสสินค้า='" + deleteId + "'";
            //    MySqlCommand cmd = new MySqlCommand(sql, conn);
            //    conn.Open();

            //    int rows = cmd.ExecuteNonQuery();
            //    conn.Close();

            //    if (rows > 0)
            //    {
            //        MessageBox.Show("ลบข้อมูลสำเร็จ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        basket_stock();
            //        show_total_price();

            //    }
            //}
            //else
            //{ }



            select_a_carts();
            select_a_stock_70();
            select_a_stock_95();

            if (label_check_รุ่น.Text == "70")
            {
                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
                MySqlConnection conn = new MySqlConnection(connection);
                String sql = "DELETE FROM basket_stock WHERE รหัสสินค้า = '" + label_code.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    show_basket_stock();
                    show_total_price();
                    int all_aad = int.Parse(a_stock);
                    int all_a = int.Parse(a_carts);
                    int all_amo = all_a + all_aad;
                    string all_amount = all_amo.ToString();
                    string connectionsn = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
                    MySqlConnection connss = new MySqlConnection(connectionsn);
                    String sqlsn = "UPDATE stock_70 SET จำนวน ='" + all_amount + "' WHERE รหัสสินค้า ='" + label_code.Text + "'";
                    MySqlCommand cmds = new MySqlCommand(sqlsn, connss);
                    connss.Open();
                    int row = cmds.ExecuteNonQuery();
                    if (row > 0)
                    {
                        show_basket_stock();
                        show_total_price();
                        show_stock_70_update();
                        //get_monney_txt.Clear();
                    }
                }
                
            }
            else if (label_check_รุ่น.Text == "95")
            {
                string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
                MySqlConnection conn = new MySqlConnection(connection);
                String sql = "DELETE FROM basket_stock WHERE รหัสสินค้า = '" + label_code.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (rows > 0)
                {
                    show_basket_stock();
                    show_total_price();
                    int all_aad = int.Parse(a_stock);
                    int all_a = int.Parse(a_carts);
                    int all_amo = all_a + all_aad;
                    string all_amount = all_amo.ToString();
                    string connectionsn = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;";
                    MySqlConnection connss = new MySqlConnection(connectionsn);
                    String sqlsn = "UPDATE stock_95 SET จำนวน ='" + all_amount + "' WHERE รหัสสินค้า ='" + label_code.Text + "'";
                    MySqlCommand cmds = new MySqlCommand(sqlsn, connss);
                    connss.Open();
                    int row = cmds.ExecuteNonQuery();
                    if (row > 0)
                    {
                        show_basket_stock();
                        show_total_price();
                        show_stock_95_update();
                        //get_monney_txt.Clear();
                    }
                }
            }


        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (amount_edit.Text == "0")
            {
                MessageBox.Show("กรุณาสินค้าที่ต้องการแก้ไข");
            }
            else
            {
                select_all_price(); // คัดลอกราคาจาก stock
                select_a_carts(); //คัดลอกจำนวนจาก ตะกร้า cart
                int price_stock = int.Parse(all_prices); //ราคาจาก stock
                string new_price = (int.Parse(amount_edit.Text) * price_stock).ToString(); //ราคารวมของสินค้าในตะกร้า
                show_basket_stock();
                show_total_price();
                select_a_stock_70(); // คัดลอกจำนวนจาก stock
                select_a_stock_95();
                int A_cart = int.Parse(a_carts); //จำนวนในตะกร้า cart
                int amount_update = int.Parse(amount_edit.Text); //จำนวนที่ต้องการแก้ไข
                int no_amount = A_cart - amount_update; //จำนวนสินค้าที่ยกเลิก
                int A_stock = int.Parse(a_stock); //จำนวนสินค้าใน stock
                string Up_Stock = (A_stock + no_amount).ToString(); //จำนวนสินค้าที่จะเพิ่มเข้า stock

                if (amount_update > A_cart) //เลือกกมากกว่ามีอยู่ใน cart
                {
                    MessageBox.Show("จำนวนมีมากกว่าในตะกร้าสินค้าที่เลือก\n ถ้าต้องการเพิ่มสินค้ากรุณาสั่งเพิ่ม");
                }
                else
                {
                    string connectionsn = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;"; // UPDATE ตะกร้า
                    MySqlConnection connss = new MySqlConnection(connectionsn);
                    String sqlsn = "UPDATE basket_stock SET จำนวน ='" + amount_edit.Text + "' ,ราคา = '" + new_price + "' WHERE รหัสสินค้า ='" + label_code.Text + "'";
                    MySqlCommand cmds = new MySqlCommand(sqlsn, connss);
                    connss.Open();
                    int row = cmds.ExecuteNonQuery();
                    if (row > 0)
                    {
                        string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=kubota;"; //UPDATE stock
                        MySqlConnection conn = new MySqlConnection(connection);
                        String sql = "UPDATE stock_70 SET จำนวน ='" + Up_Stock + "' WHERE รหัสสินค้า ='" + label_code.Text + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        conn.Open();
                        int row2 = cmd.ExecuteNonQuery();
                        if (row2 > 0)
                        {
                            //show_basket_stock();
                            show_total_price();
                            show_stock_70_update();

                        }
                    }
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
                //Image logo = Image.FromFile(@"C:\Users\qqx99\Documents\Angkun_C#\project\image\name2.png");
                //e.Graphics.DrawImage(logo, new PointF(50, 50));
                e.Graphics.DrawString("ใบเสร็จ", new Font("TH SarabunPSK", 26, FontStyle.Bold), Brushes.Black, new PointF(350, 80));
                e.Graphics.DrawString("           ร้าน ขายอะไหล่รถเกี่ยว ", new Font("TH SarabunPSK", 20, FontStyle.Bold), Brushes.Black, new PointF(240, 120));
                //e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 160));
                e.Graphics.DrawString("ข้อมูลร้าน :  84/17 บ้านหนองขุ่น ตำบลมิตรภาพ อำเภอแกดำ จังหวัดมหาสารคาม 44190 ", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 180));
                //e.Graphics.DrawString("หน่วยงาน/คณะ " + Program.facutyadmin, new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(400, 192));
                e.Graphics.DrawString("วันที่และเวลา :  " + System.DateTime.Now.ToString("dd / MM / yyyy   HH : mm : ss น."), new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 215));
                //e.Graphics.DrawString("พิมพ์โดย " + Program.admin, new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(400, 215));
                e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 240));
                e.Graphics.DrawString("ลำดับ", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(60, 255));
                e.Graphics.DrawString("ชื่อสินค้า", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(150, 255));
                e.Graphics.DrawString("ราคา(บาท)", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(330, 255));
                e.Graphics.DrawString("รุ่น_DC", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(470, 255));
                e.Graphics.DrawString("จำนวน", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(650, 255));
                e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Bold), Brushes.Black, new PointF(50, 265));
                int y = 290;
                allbook.Clear();

                loaddata();
                foreach (var i in allbook)
                {
                    e.Graphics.DrawString(i.id, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(80, y));
                    e.Graphics.DrawString(i.name, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(140, y));
                    e.Graphics.DrawString(i.price, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(360, y));
                    e.Graphics.DrawString(i.generation, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(495, y));
                    e.Graphics.DrawString(i.amount, new Font("TH SarabunPSK", 16, FontStyle.Regular), Brushes.Black, new PointF(680, y));
                    y = y + 20;


                }
                e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------------------", new Font("TH SarabunPSK", 18, FontStyle.Regular), Brushes.Black, new Point(50, y + 0));
                e.Graphics.DrawString("รวมทั้งสิ้น    " + totaltext.Text + "          บาท", new Font("TH SarabunPSK", 18, FontStyle.Regular), Brushes.Black, new Point(570, (y + 50) + 45));
                //e.Graphics.DrawString("ชื่อผู้ให้บริการ    " + Program.userid.ToString(), new Font("DB Helvethaica X v3.2", 16, FontStyle.Bold), Brushes.Black, new Point(80, (y + 30) + 45));
                e.Graphics.DrawString("รับเงิน        " + textBox3.Text + "           บาท", new Font("TH SarabunPSK", 18, FontStyle.Regular), Brushes.Black, new Point(570, ((y + 30) + 45) + 60));
                e.Graphics.DrawString("เงินทอน      " + textBox4.Text + "              บาท", new Font("TH SarabunPSK", 18, FontStyle.Regular), Brushes.Black, new Point(570, (((y + 30) + 45) + 45) + 60));
                e.Graphics.DrawString("      ร้าน ขายอะไหล่รถเกี่ยว", new Font("TH SarabunPSK", 18, FontStyle.Regular), Brushes.Black, new Point(290, ((((y + 30) + 115) + 45) + 45) + 60));
                e.Graphics.DrawString("       ขอบคุณที่ใช้บริการ      ", new Font("TH SarabunPSK", 18, FontStyle.Regular), Brushes.Black, new Point(290, (((((y + 30) + 115) + 45) + 45) + 45) + 60));

            }
            private void loaddata()
            {
                MySqlConnection conn = databaseConnection();

                conn.Open();





                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM basket_stock  ", conn);
                MySqlDataReader adapter = cmd.ExecuteReader();

                while (adapter.Read())
                {
                    Program.id = adapter.GetString("ลำดับ");
                    Program.name = adapter.GetString("name");
                    Program.price = adapter.GetString("ราคา");
                    Program.generation = adapter.GetString("รุ่น_DC");
                    Program.amount = adapter.GetString("จำนวน");
                    Class1 item = new Class1()
                    {
                        id = Program.id,
                        name = Program.name,
                        price = Program.price,
                        generation = Program.generation,
                        amount = Program.amount

                    };
                    allbook.Add(item);
                }
                conn.Close();

            }

        private void button4_Click(object sender, EventArgs e)
        {
            allbook.Clear();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void datastock_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void databasket_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
    
}
