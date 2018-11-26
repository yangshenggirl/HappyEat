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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //全部
        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection myconn = null;
            MySqlCommand mycom = null;

            myconn = new MySqlConnection("Host =localhost;Database=eating;Username=root;Password=123456;pooling=false;charset=utf8;port=3306");
            myconn.Open();
            mycom = myconn.CreateCommand();
            mycom.CommandText = "SELECT * FROM worker";
            MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            MySqlDataReader sdr = mycom.ExecuteReader();

            myconn.Close();


        }
        //查找
        private void button4_Click(object sender, EventArgs e)
        {
            string workerid = textBox1.Text;
            string workername = textBox2.Text;
            string workersex = textBox3.Text;
            string workerage = textBox4.Text;
            string workeraddress = textBox5.Text;
            string mysqlCon = "Host =localhost;Database=eating;Username=root;Password=123456;pooling=false;charset=utf8;port=3306";
            MySqlConnection myconn = new MySqlConnection(mysqlCon);
            if (workerid == ""&& workername =="")
            {
                MessageBox.Show("请先输入要查找的员工编号或姓名");
            }else {
            myconn.Open();
            MySqlCommand mycom = new MySqlCommand(mysqlCon, myconn);
            mycom = myconn.CreateCommand();
            mycom.CommandText = "SELECT * FROM worker where 员工编号='" + workerid + "'or 员工姓名 ='" + workername + "'";
            MySqlDataReader read = mycom.ExecuteReader();
            if (read.Read())
            {
                read.Close();
                MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            else {
                MessageBox.Show("此员工不存在");
            }
            myconn.Close();
            }   
        }

        private void sqlConnection1_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        //插入
        private void button2_Click(object sender, EventArgs e)
        {
            string workerid = textBox1.Text;
            string workername = textBox2.Text;
            string workersex = textBox3.Text;
            string workerage = textBox4.Text;
            string workeraddress = textBox5.Text;
            string workerphone = textBox6.Text;

            if (workerid == "" || workername == "" || workersex == "" || workerage == "" || workeraddress == "" || workerphone == "")
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
                mycom.CommandText = "select 员工编号 from worker where 员工编号 ='" + workerid + "'";
                MySqlDataReader read = mycom.ExecuteReader();
                if (read.Read())
                {
                    read.Close();
                    MessageBox.Show("此员工已存在");
                    myconn.Close();
                }
                else
                {
                    read.Close();
                    mycom.CommandText = "insert into worker values('" + workerid + "','" + workername + "','" + workersex + "','" + workerage + "','" + workeraddress + "','" + workerphone + "')";
                    MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    myconn.Close();
                    MessageBox.Show("添加成功");
                }
               
            }
        }
        //删除
        private void button5_Click(object sender, EventArgs e)
        {
            string workerid = textBox1.Text;
            string mysqlCon = "Host =localhost;Database=eating;Username=root;Password=123456;pooling=false;charset=utf8;port=3306";
            if (workerid == "")
            {
                MessageBox.Show("请先输入要删除的员工编号");
            }
            else
            {
                MySqlConnection myconn = new MySqlConnection(mysqlCon);
                myconn.Open();
                MySqlCommand mycom = new MySqlCommand(mysqlCon, myconn);
                mycom = myconn.CreateCommand();
                mycom.CommandText = "select 员工编号 from worker where 员工编号 ='" + workerid + "'";
                MySqlDataReader read = mycom.ExecuteReader();
                if (read.Read())
                {
                    read.Close();
                    mycom = myconn.CreateCommand();
                    mycom.CommandText = "delete from worker where 员工编号 ='" + workerid + "'";
                    MySqlDataAdapter adap = new MySqlDataAdapter(mycom);
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    myconn.Close();
                    MessageBox.Show("删除成功");
                }
                else {
                    MessageBox.Show("此员工不存在");
                    myconn.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }
    }
}