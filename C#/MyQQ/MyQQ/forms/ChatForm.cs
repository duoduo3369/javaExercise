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
    /// ���촰��
    /// </summary>
    public partial class ChatForm : Form
    {
        public int friendId;     // ��ǰ����ĺ��Ѻ���
        public string nickName;  // ��ǰ����ĺ����ǳ�
        public int faceId;       // ��ǰ����ĺ���ͷ��Id        

        public ChatForm()
        {
            InitializeComponent();
            
        }

        // �������ʱ�Ķ���
        private void ChatForm_Load(object sender, EventArgs e)
        {
            // ���ô������
            this.Text = string.Format("��{0}������", nickName);

            // ���ô��嶥����ʾ�ĺ�����Ϣ
            picFace.Image = ilFaces.Images[faceId];
            lblFriend.Text = string.Format("{0}({1})", nickName, friendId);
            txtChat.Focus();
            // ��ȡ���е�δ����Ϣ����ʾ�ڴ�����
            ShowMessage(true);
            
        }

        // �رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ������Ϣ
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtChat.Text.Trim() == "") // ���ܷ��Ϳ���Ϣ
            {
                MessageBox.Show("���ܷ��Ϳ���Ϣ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtChat.Text.Trim().Length > 50)
            {
                MessageBox.Show("��Ϣ���ݹ��������Ϊ�������ͣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else  // ������Ϣ��д�����ݿ�
            {
                // MessageTypeId:1-��ʾ������Ϣ��Ϊ�򻯲���û�ж�ȡ���ݱ���S2�����ó�������ö��ʵ��
                // MessageState:0-��ʾ��Ϣ״̬��δ��
                int result = -1; // ��ʾ�������ݿ�Ľ��
                string sql = string.Format(
                    "INSERT INTO Messages (FromUserId, ToUserId, Message, MessageTypeId, MessageState) VALUES ({0},{1},'{2}',{3},{4})",
                    UserHelper.loginId, friendId, txtChat.Text.Trim(), 1, 0);
                try
                {
                    // ִ������
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
                    MessageBox.Show("�����������������", "��Ǹ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtChat.Text = "";  // ������Ϣ���
                //this.Close();
                ShowMessage(false);
                txtChat.Focus();
            }
        }

        /// <summary>
        /// ��ȡ���е�δ����Ϣ����ʾ�ڴ�����
        /// </summary>
        public void ShowMessage(bool flag)
        {
            string messageIdsString = "";  // ��Ϣ��Id��ɵ��ַ���
            string message;         // ��Ϣ����
            string messageTime;     // ��Ϣ������ʱ��

            // ��ȡ��Ϣ��SQL���
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

                // ѭ������Ϣ��ӵ�������

                while (reader.Read())
                {
                    messageIdsString += Convert.ToString(reader["Id"]) + "_";
                    message = Convert.ToString(reader["Message"]);
                    messageTime = Convert.ToDateTime(reader["MessageTime"]).ToString(); // ת��Ϊ�������ͣ�����ѧԱ

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
            // ����ʾ������Ϣ��Ϊ�Ѷ�
            if (messageIdsString.Length > 1 && flag)
            {
                messageIdsString.Remove(messageIdsString.Length - 1);
                SetMessageRead(messageIdsString, '_');
            }
        }

        /// <summary>
        /// ����ʾ������Ϣ��Ϊ�Ѷ�
        /// </summary>        
        private void SetMessageRead(string messageIdsString, char separator)
        {
            string[] messageIds = messageIdsString.Split(separator);     // �ָ��ÿ����ϢId
            string sql = "Update Messages SET MessageState=1 WHERE Id="; // ����״̬��SQL���Ĺ̶�����
            string updateSql;  // ִ�е�SQL���
            try
            {
                DbCommand command = DBHelper.GetCommand();     // ����Command����
                command.Connection = DBHelper.GetConnection();  // ָ�����ݿ�����
                DBHelper.OpenConnection();                // �����ݿ�����
                foreach (string id in messageIds)
                {
                    if (id != "")
                    {
                        updateSql = sql + id;              // ����������SQL���
                        command.CommandText = updateSql;   // ָ��Ҫִ�е�SQL���
                        int result = command.ExecuteNonQuery();  // ִ������
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