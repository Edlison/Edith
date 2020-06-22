using Edith.controller;
using Edith.Forms;
using Edith.result;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetDimension.WinForm;

namespace Edith
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginController loginController = new LoginController();

            SystemResult res = loginController.SignIn(textBox1.Text, textBox2.Text);
            //SystemResult res = loginController.SignIn("Edlison", "000000");

            if (res.getCode() == 0)
            {
                Main main = new Main();
                main.Show();
                // this.Close();
            } 
            else
            {
                MessageBox.Show(res.getDesc());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginController loginController = new LoginController();

            SystemResult res = loginController.SignUp(textBox1.Text, textBox2.Text);

            if (res.getCode() == 0)
            {
                MessageBox.Show(res.getDesc());
            }
            else
            {
                MessageBox.Show(res.getDesc());
            }
        }
    }
}
