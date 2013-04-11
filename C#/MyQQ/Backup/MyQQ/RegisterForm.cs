using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyQQ
{
    /// <summary>
    /// 注册界面
    /// </summary>
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        // 窗体加载时，添加星座和血型组合框中的项
        private void ApplyForm_Load(object sender, EventArgs e)
        {
            // 查询星座用的sql语句
            string sql = "SELECT Star FROM Star";

            bool error = false;   // 标识操作数据库是否会出错

            try
            {
                // 添加星座组合框中的项                
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                SqlDataReader reader = command.ExecuteReader();  // 执行查询

                while (reader.Read())
                {
                    cboStar.Items.Add((string)reader[0]);
                }
                reader.Close();

                // 添加血型组合框中的项
                sql = "SELECT BloodType FROM BloodType";  // 修改查询语句，查询血型
                command.CommandText = sql;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cboBloodType.Items.Add((string)reader[0]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                error = true;                
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }

            // 出错了
            if (error)
            {
                MessageBox.Show("服务器出现以外错误！","抱歉",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        // 点击取消，关闭窗体
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 点击注册，向数据库添加记录
        private void btnRegist_Click(object sender, EventArgs e)
        {
            // 输入验证通过，就插入记录到数据库
            if (ValidateInput())
            {
                int myQQNum = 0;     // QQ号码
                string message;      // 弹出的消息
                string sex = rdoMale.Checked ? rdoMale.Text : rdoFemale.Text; // 获得选中的性别
                string sql = "";     // 查询用的SQL语句
                int starId;          // 星座Id
                int bloodTypeId;     // 血型Id   
                bool error = false;  // 操作数据库是否出错
                
                // 根据星座和血型的选择来分情况确定SQL语句
                if (cboStar.Text != "" && cboBloodType.Text != "")
                {
                    // 获得星座的Id
                    starId = GetStarId();
                    // 获得血型的Id
                    bloodTypeId = GetBloodType();
                    sql = string.Format("INSERT INTO Users (LoginPwd, NickName, Sex, Age, Name, StarId, BloodTypeId) values ('{0}','{1}','{2}',{3},'{4}',{5},{6})",
                        txtLoginPwd.Text.Trim(), txtNickName.Text.Trim(), sex, int.Parse(txtAge.Text.Trim()), txtName.Text.Trim(), starId, bloodTypeId);
                }
                else if (cboStar.Text != "" && cboBloodType.Text == "")
                {
                    // 获得星座的Id
                    starId = GetStarId();
                    sql = string.Format("INSERT INTO Users (LoginPwd, NickName, Sex, Age, Name, StarId) values ('{0}','{1}','{2}',{3},'{4}', {5})",
                            txtLoginPwd.Text.Trim(), txtNickName.Text.Trim(), sex, int.Parse(txtAge.Text.Trim()), txtName.Text.Trim(),starId);
                }
                else if (cboStar.Text == "" && cboBloodType.Text != "")
                {
                    // 获得血型的Id
                    bloodTypeId = GetBloodType();
                    sql = string.Format("INSERT INTO Users (LoginPwd, NickName, Sex, Age, Name, BloodTypeId) values ('{0}','{1}','{2}',{3},'{4}', {5})",
                            txtLoginPwd.Text.Trim(), txtNickName.Text.Trim(), sex, int.Parse(txtAge.Text.Trim()), txtName.Text.Trim(), bloodTypeId);
                }
                else
                {
                    sql = string.Format("INSERT INTO Users (LoginPwd, NickName, Sex, Age, Name) values ('{0}','{1}','{2}',{3},'{4}')",
                                txtLoginPwd.Text.Trim(), txtNickName.Text.Trim(), sex, int.Parse(txtAge.Text.Trim()), txtName.Text.Trim());
                }
                
                try
                {
                    // 创建 Command 对象
                    SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                    DBHelper.connection.Open();             // 打开数据库连接
                    int result = command.ExecuteNonQuery(); // 执行插入命令
                    if (result == 1)
                    {
                        sql = "SELECT @@Identity FROM Users";  // 查询新增加的记录的标识号
                        command.CommandText = sql;             // 重新指定 Command 对象的 SQL 语句
                        myQQNum = Convert.ToInt32(command.ExecuteScalar());  // 强制类型转换会出错
                        message = string.Format("注册成功！你的MyQQ号码是{0}", myQQNum);
                    }
                    else
                    {
                        message = "注册失败，请重试！";                        
                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    message = "服务器出现意外错误！请稍候再试！";
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    DBHelper.connection.Close();  // 关闭数据库连接
                }

                // 显示注册结果
                if (error)
                {
                    MessageBox.Show(message, "注册失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                }
                else
                {
                    MessageBox.Show(message, "注册结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
        }

        /// <summary>
        /// 验证用户的输入
        /// </summary>        
        private bool ValidateInput()
        {
            if (txtNickName.Text.Trim() == "")
            {
                MessageBox.Show("请输入昵称！","输入提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtNickName.Focus();
                return false;
            }
            if (txtAge.Text.Trim() == "")
            {
                MessageBox.Show("请输入年龄！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAge.Focus();
                return false;
            }
            if (!rdoMale.Checked && !rdoFemale.Checked)
            {
                MessageBox.Show("请选择性别！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSex.Focus();
                return false;
            }
            if (txtLoginPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginPwd.Focus();
                return false;
            }
            if (txtLoginPwdAgain.Text.Trim() == "")
            {
                MessageBox.Show("请输入确认密码！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginPwdAgain.Focus();
                return false;
            }
            if (txtLoginPwd.Text.Trim() != txtLoginPwdAgain.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不一样！", "输入提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginPwdAgain.Focus();
                return false;
            }
            return true;
        }        

        /// <summary>
        /// 取得星座的 Id
        /// </summary>        
        private int GetStarId()
        {
            int starId = -1;  // 返回值
            // 查询星座Id的 SQL 语句
            string sql = string.Format("SELECT Id FROM Star WHERE Star = '{0}'", cboStar.Text);
            try
            {
                // 创建 Command 对象
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();  // 打开数据库连接
                starId = Convert.ToInt32(command.ExecuteScalar());                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }

            if (starId > 0)
            {
                return starId;
            }
            else
            {
                return -1;
            }                 
        }

        /// <summary>
        /// 取得血型的 Id
        /// </summary>        
        private int GetBloodType()
        {
            int bloodTypeId = -1;  // 返回值

            // 查询星座Id的 SQL 语句
            string sql = string.Format("SELECT Id FROM BloodType WHERE BloodType = '{0}'", cboBloodType.Text);
            try
            {
                // 创建 Command 对象
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();  // 打开数据库连接
                bloodTypeId = Convert.ToInt32(command.ExecuteScalar());                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }
            if (bloodTypeId > 0)
            {
                return bloodTypeId;
            }
            else
            {
                return -1;
            }          
        }
    }
}