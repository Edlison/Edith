using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edith.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Edith edith = new Edith();
            edith.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Role role = new Role();
            role.Show();
        }
    }
}
