using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HappyEating
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //全部
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection myconn = null;
            MySqlCommand mycom = null;

            myconn = new MySqlConnection("Host =localhost;Database=eating;Username=root;Password=123456;pooling=false;charset=utf8;port=3306");
            myconn.Open();
            mycom = myconn.CreateCommand();
            mycom.CommandText = "SELECT * FROM food";
            MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            MySqlDataReader sdr = mycom.ExecuteReader();
            myconn.Close();
        }
        //添加
        private void button3_Click(object sender, EventArgs e)
        {
            string foodid = textBox1.Text;
            string foodname = textBox2.Text;
            string foodprice = textBox3.Text;
            string foodtaste = textBox4.Text;

            if (foodid == "" || foodname == "" || foodprice == "" || foodtaste == "")
            {
                MessageBox.Show("您还有信息未输入！");
            }

            else
            {
                string mysqlCon = "Host =localhost;Database=eating;Username=root;Password=123456;pooling=false;charset=utf8;port=3306";
                MySqlConnection myconn = new MySqlConnection(mysqlCon);
                myconn.Open();
                MySqlCommand mycom = new MySqlCommand(mysqlCon, myconn);
                mycom = myconn.CreateCommand();
                mycom.CommandText = "select 菜品编号 from food where 菜品编号 ='" + foodid + "'";
                MySqlDataReader read = mycom.ExecuteReader();
                if (read.Read())
                {
                    read.Close();
                    MessageBox.Show("此菜品已存在");
                    myconn.Close();
                }
                else
                {
                    read.Close();
                    mycom.CommandText = "insert into food values('" + foodid + "','" + foodname + "','" + foodprice + "','" + foodtaste + "')";
                    MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    myconn.Close();
                    MessageBox.Show("添加成功");
                }

            }
        }
        //查询
        private void button4_Click(object sender, EventArgs e)
        {
            string foodid = textBox1.Text;
            string foodname = textBox2.Text;
            string mysqlCon = "Host =localhost;Database=eating;Username=root;Password=123456;pooling=false;charset=utf8;port=3306";
            MySqlConnection myconn = new MySqlConnection(mysqlCon);
            if (foodid == "")
            {
                MessageBox.Show("请先输入要查找的菜品编号");
            }
            else
            {
                myconn.Open();
                MySqlCommand mycom = new MySqlCommand(mysqlCon, myconn);
                mycom = myconn.CreateCommand();
                mycom.CommandText = "SELECT * FROM food where 菜品编号='" + foodid + "'or 菜品名 ='" + foodname + "'";
                MySqlDataReader read = mycom.ExecuteReader();
                if (read.Read())
                {
                    read.Close();
                    MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
                else
                {
                    MessageBox.Show("未存在此菜品信息");
                }
                myconn.Close();
            }
        }
        //删除
        private void button5_Click(object sender, EventArgs e)
        {
            string foodid = textBox1.Text;
            string mysqlCon = "Host =localhost;Database=eating;Username=root;Password=123456;pooling=false;charset=utf8;port=3306";
            if (foodid == "")
            {
                MessageBox.Show("请先输入要删除的菜品编号");
            }
            else
            {
                MySqlConnection myconn = new MySqlConnection(mysqlCon);
                myconn.Open();
                MySqlCommand mycom = new MySqlCommand(mysqlCon, myconn);
                mycom = myconn.CreateCommand();
                mycom.CommandText = "select 菜品编号 from food where 菜品编号 ='" + foodid + "'";
                MySqlDataReader read = mycom.ExecuteReader();
                if (read.Read())
                {
                    read.Close();
                    mycom = myconn.CreateCommand();
                    mycom.CommandText = "delete from food where 菜品编号 ='" + foodid + "'";
                    MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    myconn.Close();
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("此菜品不存在");
                    myconn.Close();
                }
            }
        }
        //返回
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }

    }
}