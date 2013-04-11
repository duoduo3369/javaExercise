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
    /// �������������Ϣ����
    /// </summary>
    public partial class RequestForm : Form
    {
        int fromUserId;  // ����������û�Id

        public RequestForm()
        {
            InitializeComponent();
        }

        // �������ʱ��ȡ��������Ϣ��ʾ
        private void RequestForm_Load(object sender, EventArgs e)
        {
            int messageId = 0; // ��Ϣ��Id

            // �ҵ�������ǰ�û���������Ϣ
            string sql = string.Format(
                "SELECT Top 1 Id, FromUserId FROM Messages WHERE ToUserId={0} AND MessageTypeId=2 AND MessageState=0",
                UserHelper.loginId);
            try
            {
                // ����һ��δ����Ϣ
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if(dataReader.Read())                
                {
                    messageId = (int)dataReader["Id"];
                    this.fromUserId = (int)dataReader["FromUserId"];
                }
                dataReader.Close();

                // ����Ϣ״̬��Ϊ�Ѷ�
                sql = "UPDATE Messages SET MessageState =1 WHERE Id="+messageId;
                command.CommandText = sql;
                command.ExecuteNonQuery();

                // ��ȡ�����˵���Ϣ����ʾ�ڴ�����
                sql = "SELECT NickName, FaceId FROM Users WHERE Id="+this.fromUserId;
                command.CommandText = sql;
                dataReader = command.ExecuteReader();
                if (dataReader.Read())
                {
                    int faceId = (int)dataReader["FaceId"];
                    string nickName = (string)dataReader["NickName"];
                    this.picIcon.Image = ilIcons.Images[faceId];
                    this.lblMessage.Text = string.Format("{0}({1})���������Ϊ����",
                        nickName, this.fromUserId);
                    this.btnAllow.Visible = true;
                }
                else
                {
                    this.lblMessage.Text = "û��ϵͳ��Ϣ";
                    this.btnAllow.Visible = false;
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

        // ͬ����Ӻ�������
        private void btnAllow_Click(object sender, EventArgs e)
        {
            // �Ȳ����Ƿ��Ѿ���ӹ��ˣ���ֹ�ظ����
            string sql = string.Format(
                "SELECT COUNT(*) FROM Friends WHERE HostId={0} AND FriendId={1}",
                this.fromUserId, UserHelper.loginId);  
            try
            {
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                int num = Convert.ToInt32(command.ExecuteScalar());

                if (num <= 0)  // û�к��Ѽ�¼
                {
                    sql = string.Format(
                        "INSERT INTO Friends (HostId, FriendId) VALUES({0},{1})",
                        this.fromUserId, UserHelper.loginId);
                    command.CommandText = sql;  // ����ָ��SQL���

                    // ִ����Ӳ���
                    command.ExecuteNonQuery();  
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
            this.Close();  // �رմ���
        }

        // �رմ���
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}