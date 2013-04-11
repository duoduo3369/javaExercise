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
            this.Text = string.Format("��{0}������",nickName);

            // ���ô��嶥����ʾ�ĺ�����Ϣ
            picFace.Image = ilFaces.Images[faceId];
            lblFriend.Text = string.Format("{0}({1})",nickName,friendId);

            // ��ȡ���е�δ����Ϣ����ʾ�ڴ�����
            ShowMessage();
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
                    SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                    DBHelper.connection.Open();
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    DBHelper.connection.Close();
                }
                if (result != 1)
                {
                    MessageBox.Show("�����������������", "��Ǹ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtChat.Text = "";  // ������Ϣ���
                this.Close();
            }
        }

        /// <summary>
        /// ��ȡ���е�δ����Ϣ����ʾ�ڴ�����
        /// </summary>
        private void ShowMessage()
        {
            string messageIdsString = "";  // ��Ϣ��Id��ɵ��ַ���
            string message;         // ��Ϣ����
            string messageTime;     // ��Ϣ������ʱ��

            // ��ȡ��Ϣ��SQL���
            string sql = string.Format(
                "SELECT Id, Message,MessageTime From Messages WHERE FromUserId={0} AND ToUserId={1} AND MessageTypeId=1 AND MessageState=0",
                friendId,UserHelper.loginId);
            try
            {
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // ѭ������Ϣ��ӵ�������
                while (reader.Read())
                {
                    messageIdsString += Convert.ToString(reader["Id"]) + "_";
                    message = Convert.ToString(reader["Message"]);
                    messageTime = Convert.ToDateTime(reader["MessageTime"]).ToString(); // ת��Ϊ�������ͣ�����ѧԱ

                    lblMessages.Text += string.Format("\n{0}  {1}\n  {2}",nickName,messageTime,message);
                }

                reader.Close();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }
            // ����ʾ������Ϣ��Ϊ�Ѷ�
            if (messageIdsString.Length > 1)
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
                SqlCommand command = new SqlCommand();     // ����Command����
                command.Connection = DBHelper.connection;  // ָ�����ݿ�����
                DBHelper.connection.Open();                // �����ݿ�����
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
                DBHelper.connection.Close();
            }
        }
    }
}