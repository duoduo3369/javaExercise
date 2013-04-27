using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace MyQQ
{
    /// <summary>
    /// 聊天窗体
    /// </summary>
    public partial class ChatForm : Form
    {
        public int friendId;     // 当前聊天的好友号码
        public string nickName;  // 当前聊天的好友昵称
        public int faceId;       // 当前聊天的好友头像Id        

        public ChatForm()
        {
            InitializeComponent();
            
        }

        // 窗体加载时的动作
        private void ChatForm_Load(object sender, EventArgs e)
        {
            // 设置窗体标题
            this.Text = string.Format("与{0}聊天中", nickName);

            // 设置窗体顶部显示的好友信息
            picFace.Image = ilFaces.Images[faceId];
            lblFriend.Text = string.Format("{0}({1})", nickName, friendId);
            txtChat.Focus();
            // 读取所有的未读消息，显示在窗体中
            ShowMessage(true);
            
        }

        // 关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 发送消息
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtChat.Text.Trim() == "") // 不能发送空消息
            {
                MessageBox.Show("不能发送空消息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtChat.Text.Trim().Length > 50)
            {
                MessageBox.Show("消息内容过长，请分为几条发送！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else  // 发送消息，写入数据库
            {
                // MessageTypeId:1-表示聊天消息，为简化操作没有读取数据表，到S2可以用常量或者枚举实现
                // MessageState:0-表示消息状态是未读
                int result = -1; // 表示操作数据库的结果
                string sql = string.Format(
                    "INSERT INTO Messages (FromUserId, ToUserId, Message, MessageTypeId, MessageState) VALUES ({0},{1},'{2}',{3},{4})",
                    UserHelper.loginId, friendId, txtChat.Text.Trim(), 1, 0);
                try
                {
                    // 执行命令
                    DbCommand command = DBHelper.GetCommand(sql, DBHelper.GetConnection());
                    DBHelper.OpenConnection();
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    DBHelper.ColseConnection();
                }
                if (result != 1)
                {
                    MessageBox.Show("服务器出现意外错误！", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtChat.Text = "";  // 输入消息清空
                //this.Close();
                ShowMessage(false);
                txtChat.Focus();
            }
        }

        /// <summary>
        /// 读取所有的未读消息，显示在窗体中
        /// </summary>
        public void ShowMessage(bool flag)
        {
            string messageIdsString = "";  // 消息的Id组成的字符串
            string message;         // 消息内容
            string messageTime;     // 消息发出的时间

            // 读取消息的SQL语句
            string sql;
            if (flag)
            {
                sql = string.Format(
                    "SELECT Id, Message,MessageTime From Messages WHERE FromUserId={0} AND ToUserId={1} AND MessageTypeId=1 AND MessageState=0",
                    friendId, UserHelper.loginId);
            }
            else
            {
                sql = string.Format(
                    "SELECT top 1 Id, Message,MessageTime From Messages WHERE FromUserId={0} AND ToUserId={1} AND MessageTypeId=1 AND MessageState=0 order by id desc",
                    UserHelper.loginId, friendId);
            }
            try
            {
                DbCommand command = DBHelper.GetCommand(sql, DBHelper.GetConnection());
                DBHelper.OpenConnection();
                DbDataReader reader = command.ExecuteReader();

                // 循环将消息添加到窗体上

                while (reader.Read())
                {
                    messageIdsString += Convert.ToString(reader["Id"]) + "_";
                    message = Convert.ToString(reader["Message"]);
                    messageTime = Convert.ToDateTime(reader["MessageTime"]).ToString(); // 转换为日期类型，告诉学员

                    lblMessages.Text += string.Format("\r\n{0}  {1}\r\n  {2}\r\n", nickName, messageTime, message);
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.ColseConnection();
            }
            // 把显示出的消息置为已读
            if (messageIdsString.Length > 1 && flag)
            {
                messageIdsString.Remove(messageIdsString.Length - 1);
                SetMessageRead(messageIdsString, '_');
            }
        }

        /// <summary>
        /// 把显示出的消息置为已读
        /// </summary>        
        private void SetMessageRead(string messageIdsString, char separator)
        {
            string[] messageIds = messageIdsString.Split(separator);     // 分割出每个消息Id
            string sql = "Update Messages SET MessageState=1 WHERE Id="; // 更新状态的SQL语句的固定部分
            string updateSql;  // 执行的SQL语句
            try
            {
                DbCommand command = DBHelper.GetCommand();     // 创建Command对象
                command.Connection = DBHelper.GetConnection();  // 指定数据库连接
                DBHelper.OpenConnection();                // 打开数据库连接
                foreach (string id in messageIds)
                {
                    if (id != "")
                    {
                        updateSql = sql + id;              // 补充完整的SQL语句
                        command.CommandText = updateSql;   // 指定要执行的SQL语句
                        int result = command.ExecuteNonQuery();  // 执行命令
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.ColseConnection();
            }
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dictionary<String, ChatForm> chatForms = MainForm.GetChatFormDictionary();
            chatForms.Remove(Convert.ToString(friendId));
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            Size tS = TextRenderer.MeasureText(tb.Text, tb.Font);
            bool Hsb = tb.ClientSize.Height < tS.Height + Convert.ToInt32(tb.Font.Size);
            bool Vsb = tb.ClientSize.Width < tS.Width;

            if (Hsb && Vsb)
                tb.ScrollBars = ScrollBars.Both;
            else if (!Hsb && !Vsb)
                tb.ScrollBars = ScrollBars.None;
            else if (Hsb && !Vsb)
                tb.ScrollBars = ScrollBars.Vertical;
            else if (!Hsb && Vsb)
                tb.ScrollBars = ScrollBars.Horizontal;

            this.lblMessages.SelectionStart = this.lblMessages.Text.Length;
            this.lblMessages.SelectionLength = 0;
            this.lblMessages.ScrollToCaret(); 
        }
    }
}