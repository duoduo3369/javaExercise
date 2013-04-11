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
    /// 登录窗体
    /// </summary>
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        // 取消按钮的事件处理
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 打开申请号码界面
        private void llbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        // 登录按钮事件处理
        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool error = false;   // 标志在执行数据库操作的过程中是否出错

            // 如果输入验证成功，就验证身份，并转到相应的窗体
            if (ValidateInput())
            {
                int num = 0;  // 数据库操作结果              

                try
                {
                    // 查询用的sql语句
                    string sql = string.Format("SELECT COUNT(*) FROM Users WHERE Id={0} AND LoginPwd = '{1}'",
                        int.Parse(txtLoginId.Text.Trim()), txtLoginPwd.Text.Trim());
                    // 创建Command 对象
                    SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                    DBHelper.connection.Open();  // 打开数据库连接
                    num = Convert.ToInt32(command.ExecuteScalar());                    
                }
                catch (Exception ex)
                {
                    error = true;
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    DBHelper.connection.Close();  // 关闭数据库连接
                }

                if (!error && (num == 1))  // 验证通过
                {
                    // 设置登录的用户号码
                    UserHelper.loginId = int.Parse(txtLoginId.Text.Trim());
                    // 创建主窗体
                    MainForm mainForm = new MainForm();
                    mainForm.Show();  // 显示窗体
                    this.Visible = false;  // 当前窗体不可见
                }
                else
                {
                    MessageBox.Show("输入的用户名或密码有误！", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }        
        
        // 忘记密码标签
        private void llblFogetPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("该功能尚未开通！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        // 用户输入验证
        private bool ValidateInput()
        {
            // 验证用户输入
            if (txtLoginId.Text.Trim() == "")
            {
                MessageBox.Show("请输入登录的号码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginId.Focus();
                return false;
            }            
            else if (txtLoginPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginPwd.Focus();
                return false;
            }
            return true;
        }
    }
}