using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Edith.user;
using MySql.Data.MySqlClient;

namespace Edith.mapper
{
    class LoginMapper
    {
        static String init = "server=192.168.0.101;port=3306;user=root;password=12580ooo;database=edith;";
        static MySqlConnection conn = new MySqlConnection(init);
        public static int checkUserNameUnique(String userName)
        {
            String sql = String.Format("select count(*) from `sys_user` where username = '{0}'", userName);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                var res = cmd.ExecuteScalar();
                int c = int.Parse(res.ToString());
                return c;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
        public static int insertUser(User user)
        {
            String sql = String.Format("insert into `sys_user` (username, password, salt, role_id) values ('{0}', '{1}', '{2}', {3});", user.userName, user.password, user.salt, user.roleId);
            MessageBox.Show(sql);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int res = cmd.ExecuteNonQuery();
                return res;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        internal static User selectUserByUserName(string userName)
        {
            String sql = String.Format("select * from `sys_user` where username = '{0}'", userName);
            try
            {
                conn.Open();
                MessageBox.Show("conn open");
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                User user = new User();

                MessageBox.Show("select success");

                reader.Read();
                user.userName = reader.GetString("username");
                user.password = reader.GetString("password");
                user.salt = reader.GetString("salt");
                user.roleId = reader.GetInt32("role_id");

                return user;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
