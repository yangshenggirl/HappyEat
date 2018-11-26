using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HappyEating
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //循环播放            
            axWindowsMediaPlayer1.settings.setMode("loop", true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.skinEngine1.SkinFile = "WarmColor1.ssk";
            //窗口启动时就开始播放。            
            axWindowsMediaPlayer1.URL = "洛天依 - 洛天依投食歌.mp3"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = this.textBox1.Text;//获取用户名
            String password = this.textBox2.Text;//获取密码
           // string shenfen = comboBox1.SelectedItem;//身份验证
            if (name.Equals("dianzhu") && password.Equals("123") && comboBox1.SelectedItem.Equals("店主")) //判断账号密码
            {
                this.Hide();
                Form2 form = new Form2();
                form.Show();
            }
            else if (name.Equals("fuwuyuan") && password.Equals("456") && comboBox1.SelectedItem.Equals("服务员")) //判断账号密码
            {
                this.Hide();
                Form4 form = new Form4();
                form.Show();
            }
            else if (name.Equals("") || password.Equals("") || comboBox1.SelectedItem.Equals(""))
            {
                MessageBox.Show("请将信息输入完整！");
            }
            else {
                MessageBox.Show("您输入的信息不符！");
                textBox1.Text = "";
                textBox2.Text = "";
            }
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}