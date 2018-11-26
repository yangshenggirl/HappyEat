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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            string doorid = textBox1.Text;
            string jiaoyidan = textBox8.Text;
            string mysqlCon = "Host =localhost;Database=eating;Username=root;Password=123456;pooling=false;charset=utf8;port=3306";
            if (doorid == ""&&jiaoyidan =="")
            {
                MessageBox.Show("请先输入要删除的桌号和交易单号");
            }
            else
            {
                MySqlConnection myconn = new MySqlConnection(mysqlCon);
                myconn.Open();
                MySqlCommand mycom = new MySqlCommand(mysqlCon, myconn);
                mycom = myconn.CreateCommand();
                mycom.CommandText = "select 交易单号 from bill where 交易单号 ='" + jiaoyidan + "'";
                MySqlDataReader read = mycom.ExecuteReader();
                if (read.Read())
                {
                    read.Close();
                    mycom = myconn.CreateCommand();
                    mycom.CommandText = "delete from bill where 交易单号 ='" + jiaoyidan  + "'";
                    MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    myconn.Close();
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("此交易不存在");
                    myconn.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
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
            mycom.CommandText = "SELECT * FROM bill";
            MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            MySqlDataReader sdr = mycom.ExecuteReader();
            myconn.Close();
        }
        //添加
        private void button4_Click(object sender, EventArgs e)
        {
            string doorid = textBox1.Text;
            string foodid = textBox2.Text;
            string foodname = textBox3.Text;
            string foodprice = textBox4.Text;
            string foodamount = textBox5.Text;
            string foodzongjia = textBox6.Text;
            string worker = textBox7.Text;
            string jiaoyidan = textBox8.Text;

            if (doorid == "" || foodid == "" || foodname == "" || foodprice == "" || foodamount == "" || foodzongjia == "" || worker == "" || jiaoyidan  == "")
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
                mycom.CommandText = "select 交易单号 from bill where 交易单号 ='" + textBox8 .Text  + "'";
                MySqlDataReader read = mycom.ExecuteReader();
                if (read.Read())
                {
                    read.Close();
                    MessageBox.Show("此交易已存在");
                    myconn.Close();
                }
                else
                {
                    read.Close();
                    mycom.CommandText =  "insert into bill values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";
                    MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    myconn.Close();
                    MessageBox.Show("添加成功");
                }
               
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        //查询
        private void button5_Click(object sender, EventArgs e)
        {
            string doorid = textBox1.Text;
            string mysqlCon = "Host =localhost;Database=eating;Username=root;Password=123456;pooling=false;charset=utf8;port=3306";
            MySqlConnection myconn = new MySqlConnection(mysqlCon);
            if (doorid == "" )
            {
                MessageBox.Show("请先输入要查找的桌号");
            }
            else
            {
                myconn.Open();
                MySqlCommand mycom = new MySqlCommand(mysqlCon, myconn);
                mycom = myconn.CreateCommand();
                mycom.CommandText = "SELECT * FROM bill where 桌号='" + textBox1.Text + "'";
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
                    MessageBox.Show("未存在此桌号信息");
                }
                myconn.Close();
            }   
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
        }
    }
}