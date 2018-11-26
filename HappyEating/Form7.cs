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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        //查询
        private void button3_Click(object sender, EventArgs e)
        {
            string doorid = textBox1.Text;
            string jiaoyidan = textBox4.Text;
            string mysqlCon = "Host =localhost;Database=eating;Username=root;Password=123456;pooling=false;charset=utf8;port=3306";
            MySqlConnection myconn = new MySqlConnection("Host =localhost;Database=eating;Username=root;Password=123456;pooling=false;charset=utf8;port=3306");
            if (doorid == ""&&jiaoyidan =="")
            {
                MessageBox.Show("请先输入要查找的桌号和交易单号");
            }
            else
            {
                myconn.Open();
                MySqlCommand mycom = new MySqlCommand(mysqlCon, myconn);
                mycom = myconn.CreateCommand();
                mycom.CommandText = "SELECT * FROM bill where 桌号='" + textBox1.Text + "' or 交易单号='" + textBox4.Text + "'";
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
                    MessageBox.Show("未存在此交易信息");
                }
                myconn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }
    }
}