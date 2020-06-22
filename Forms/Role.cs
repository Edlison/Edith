using MySql.Data.MySqlClient;
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
    public partial class Role : Form
    {
        private String init = "server=192.168.0.101;port=3306;user=root;password=12580ooo;database=edith;";
        private MySqlConnection conn;

        private int col = 0;

        public Role()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Role_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection(init);

                DataSet dataSet = select();

                dataGridView1.DataSource = dataSet.Tables[0];

            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataSet select()
        {
            try
            {
                if (conn != null)
                {
                    conn.Open();
                }

                String sql = "select * from sys_user";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "sys_user");

                col = dataGridView1.Rows.Count;

                return dataSet;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ID = textBox1.Text;
            String Username = textBox2.Text;
            String roleID = textBox4.Text;

            try
            {
                if (conn != null)
                {
                    conn.Open();
                    MessageBox.Show("update conn");
                }

                String sql = String.Format("update sys_user set username = '{0}', role_id = {1} where id = {2}", Username, roleID, ID);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("update success");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String ID = textBox1.Text;

            try
            {
                if (conn != null)
                {
                    conn.Open();
                    MessageBox.Show("delete conn");
                }

                String sql = String.Format("delete from sys_user where id = {0}", ID);

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("delete success");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet dataSet = select();

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        /*private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
                string strcolumn = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;//获取列标题
                string strrow = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//获取焦点触发行的第一个值
                string value = dataGridView1.CurrentCell.Value.ToString();//获取当前点击的活动单元格的值
                string strcomm = "update sys_user set " + strcolumn + "='" + value + "'where id = " + strrow;

                if (conn != null)
                {
                    conn.Open();
                }
                MySqlCommand comm = new MySqlCommand(strcomm, conn);
                comm.ExecuteNonQuery();
                MessageBox.Show("update!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }*/

    }
}
