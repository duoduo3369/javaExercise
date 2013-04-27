using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Aptech.UI;
using System.Data.SqlClient;
using System.Media;
using System.Data.Common;
using MyQQ.dbmanagers.sqlDbManagers.sqlDbManagers;
using System.Linq;
using System.Data.EntityClient;
using MyQQ.dbmanagers.sqlDbManagers.entityManagers;

namespace MyQQ
{
    /// <summary>
    /// ��¼���������
    /// </summary>
    public partial class MainForm : Form
    {
        int fromUserId;  ��// ��Ϣ�ķ�����
        int friendFaceId;  // ����Ϣ�ĺ��ѵ�ͷ��Id  

        int messageImageIndex = 0;  // �������е���Ϣͼ�������
        private static Dictionary<String, ChatForm> chatForms = new Dictionary<string, ChatForm>();
        public static Dictionary<String, ChatForm> GetChatFormDictionary()
        {
            return chatForms;
        }
        public MainForm()
        {
            InitializeComponent();
            tmrChatForm.Start();
        }

        // �������ʱ����
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ����������Ϣͼ��
            tsbtnMessageReading.Image = ilMessage.Images[0];

            // ��ʾ���˵���Ϣ            
            ShowSelfInfo();

            // ��� SideBar ��������
            sbFriends.AddGroup("�ҵĺ���");
            sbFriends.AddGroup("İ����");

            // ���ҵĺ�����������ҵĺ����б�
            ShowFriendList();
        }

        // ����رպ��˳�Ӧ�ó���
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UserInfo userinfo = DBHelper.GetEntities().UserInfoes.First<UserInfo>(item => item.userId == UserHelper.loginId);
            userinfo.isLogin = "F";
            DBHelper.GetEntities().SaveChanges();
            Application.Exit();
        }

        // ��ʾ������Ϣ����
        private void tsbtnPersonalInfo_Click(object sender, EventArgs e)
        {
            PersonalInfoForm personalInfoForm = new PersonalInfoForm();
            personalInfoForm.mainForm = this;  // ����ǰ���屾����������Ϣ����
            personalInfoForm.Show();
        }

        // ��ʾ���Һ��Ѵ���
        private void tsbtnSearchFriend_Click(object sender, EventArgs e)
        {
            //SearchFriendForm searchFriendForm = new SearchFriendForm();
            //searchFriendForm.Show();
        }
        public void upDateChatForms() 
        {
            foreach(KeyValuePair<String,ChatForm> chatForm in chatForms)
            {
                ChatForm form = chatForm.Value;
                form.ShowMessage(true);
            }
        }

        // ˫��һ��������촰��        
        private void sbFriends_ItemDoubleClick(SbItemEventArgs e)
        {
            // ��Ϣtimerֹͣ����
            if (tmrChatRequest.Enabled == true)
            {
                tmrChatRequest.Stop();
                e.Item.ImageIndex = this.friendFaceId;
            }
            ChatForm chatForm = null;
            String friendId = Convert.ToString(e.Item.Tag);
            // ��ʾ���촰��
            if (!chatForms.ContainsKey(friendId))
            {
                chatForms.Add(friendId, new ChatForm());
            }
            chatForm = chatForms[friendId]; 
            chatForm.friendId = Convert.ToInt32(e.Item.Tag); // ����
            chatForm.nickName = e.Item.Text;  // �ǳ�
            chatForm.faceId = e.Item.ImageIndex;  // ͷ��
            chatForm.Show();
        }

        // ���ˢ�º����б�
        private void tsbtnUpdateFriendList_Click(object sender, EventArgs e)
        {
            ShowFriendList();
        }

        // ��ʱɨ�����ݿ⣬�ҵ�δ����Ϣ
        private void tmrMessage_Tick(object sender, EventArgs e)
        {
            ShowFriendList();       // ˢ�º����б�
            int messageTypeId = 1;  // ��Ϣ����
            int messageState = 1;   // ��Ϣ״̬

            // �ҳ�δ����Ϣ��Ӧ�ĺ���Id
            string sql = string.Format(
                "SELECT Top 1 FromUserId, MessageTypeId, MessageState FROM Messages WHERE ToUserId={0} AND MessageState=0", UserHelper.loginId);
            DbCommand command;

            // ��Ϣ���������ͣ�������Ϣ����Ӻ�����Ϣ
            try
            {
                command = command = DBHelper.GetCommand(sql, DBHelper.GetConnection());
                DBHelper.OpenConnection();
                DbDataReader dataReader = command.ExecuteReader();

                // ѭ������һ��δ����Ϣ
                if (dataReader.Read())
                {
                    this.fromUserId = (int)dataReader["FromUserId"];
                    messageTypeId = (int)dataReader["MessageTypeId"];
                    messageState = (int)dataReader["MessageState"];
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.ColseConnection();
            }

            // �ж���Ϣ���ͣ��������Ӻ�����Ϣ������������timer����С������˸
            if (messageTypeId == 2 && messageState == 0)
            {
                SoundPlayer player = new SoundPlayer("system.wav");
                player.Play();
                tmrAddFriend.Start();
            }
            // �����������Ϣ������������timer���ú���ͷ����˸
            else if (messageTypeId == 1 && messageState == 0)
            {
                // ��÷���Ϣ���˵�ͷ��Id
                sql = "SELECT FaceId FROM Users WHERE Id=" + this.fromUserId;
                try
                {
                    command = DBHelper.GetCommand(sql, DBHelper.GetConnection());
                    DBHelper.OpenConnection();
                    this.friendFaceId = Convert.ToInt32(command.ExecuteScalar());   // ���÷���Ϣ�ĺ��ѵ�ͷ������
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    DBHelper.ColseConnection();
                }

                // �������Ϣ����û�����б��о���ӵ�İ�����б���
                if (!HasShowUser(fromUserId))
                {
                    UpdateStranger(fromUserId);
                }
                SoundPlayer player = new SoundPlayer("msg.wav");
                player.Play();
                tmrChatRequest.Start();  // ������˸ͷ��ʱ��
            }
        }

        // ����������˸
        private void tmrAddFriend_Tick(object sender, EventArgs e)
        {
            // �����޸�����ͼ��
            messageImageIndex = messageImageIndex == 0 ? 1 : 0;
            tsbtnMessageReading.Image = ilMessage.Images[messageImageIndex];
        }

        // ����ʱ��ʾ���������Ϣ����
        private void tsbtnMessageReading_Click(object sender, EventArgs e)
        {
            tmrAddFriend.Stop();  // ��Ϣtimerֹͣ���� 
            // ͼƬ�ָ�����
            messageImageIndex = 0;
            tsbtnMessageReading.Image = ilMessage.Images[messageImageIndex];

            // ��ʾϵͳ��Ϣ����
            RequestForm requestForm = new RequestForm();
            requestForm.Show();
        }

        // ����Ӧ�ĺ���ͷ����˸
        private void tmrChatRequest_Tick(object sender, EventArgs e)
        {
            // ѭ�������б��������е�ÿ��item���ҵ�����Ϣ�ĺ��ѣ�������ͷ����˸
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < sbFriends.Groups[i].Items.Count; j++)
                {
                    if (Convert.ToInt32(sbFriends.Groups[i].Items[j].Tag) == this.fromUserId)
                    {
                        if (sbFriends.Groups[i].Items[j].ImageIndex < 100)
                        {
                            sbFriends.Groups[i].Items[j].ImageIndex = 100;// ����Ϊ100��ͼƬ��һ���հ�ͼƬ
                        }
                        else
                        {
                            sbFriends.Groups[i].Items[j].ImageIndex = this.friendFaceId;
                        }
                        sbFriends.Invalidate();  // ���»��ƣ�ֻҪ����ѧ����Ҫ��仰����������˸ͷ�����
                    }
                }
            }
        }

        // ��ʾ�Ҽ��˵�ʱ��������Щ�˵����ɼ�
        private void cmsFriendList_Opening(object sender, CancelEventArgs e)
        {
            // ���û��ѡ�е���
            if (sbFriends.SeletedItem == null)
            {
                tsmiDelete.Visible = false;
            }
            else
            {
                tsmiDelete.Visible = true;
            }

            // ���ѡ�е���İ���ˣ���ʾ��Ϊ���Ѳ˵�
            if (sbFriends.SeletedItem != null && sbFriends.SeletedItem.Parent == sbFriends.Groups[1])
            {
                tsmiAddFriend.Visible = true;
            }
            else
            {
                tsmiAddFriend.Visible = false;
            }
        }

        // ��ʾ��Сͷ����ͼ�л�
        private void tsmiView_Click(object sender, EventArgs e)
        {
            if (sbFriends.View == SbView.LargeIcon)
            {
                sbFriends.View = SbView.SmallIcon;
                tsmiView.Text = "��ʾ��ͷ��";
            }
            else if (sbFriends.View == SbView.SmallIcon)
            {
                sbFriends.View = SbView.LargeIcon;
                tsmiView.Text = "��ʾСͷ��";
            }
        }

        // ɾ������
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            DialogResult result;   // �Ի�����
            int deleteResult = 0;  // �������
            if (sbFriends.SeletedItem != null)
            {
                result = MessageBox.Show("ȷʵҪɾ���ú�����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // ȷ��ɾ��
                {
                    if (sbFriends.VisibleGroup == sbFriends.Groups[0])
                    {
                        string sql = string.Format(
                            "DELETE FROM Friends WHERE HostId={0} AND FriendId={1}",
                            UserHelper.loginId, Convert.ToInt32(sbFriends.SeletedItem.Tag));

                        try
                        {
                            DbCommand command = DBHelper.GetCommand(sql, DBHelper.GetConnection());
                            DBHelper.OpenConnection();
                            deleteResult = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            DBHelper.ColseConnection();
                        }
                        if (deleteResult == 1)
                        {
                            MessageBox.Show("������ɾ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("������ɾ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);
                    }
                }
            }
        }

        // ��ѡ�е��˼�Ϊ����              
        private void tsmiAddFriend_Click(object sender, EventArgs e)
        {
            int result = 0;  // �������
            string sql = string.Format(
                "INSERT INTO Friends (HostId, FriendId) VALUES({0},{1})",
                UserHelper.loginId, Convert.ToInt32(sbFriends.SeletedItem.Tag));

            try
            {
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
            if (result == 1)
            {
                MessageBox.Show("��ӳɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);
                ShowFriendList();   // ���º����б�             
            }
            else
            {
                MessageBox.Show("���ʧ�ܣ����Ժ����ԣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // �˳�
        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ȷʵҪ�˳���", "����ȷ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // �ɼ��鷢���仯ʱ����������
        private void sbFriends_VisibleGroupChanged(SbGroupEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("folder.wav");
            player.Play();
        }

        /// <summary>
        /// ��¼����ʾ���˵���Ϣ
        /// </summary>
        public void ShowSelfInfo()
        {
            string nickName = "";  // �ǳ�
            int faceId = 0;        // ͷ������
            bool error = false;    // ��ʶ�Ƿ���ִ���

            // ȡ�õ�ǰ�û����ǳơ�ͷ��
            string sql = string.Format(
                "SELECT NickName, FaceId FROM Users WHERE Id={0}",
                UserHelper.loginId);
            try
            {
                // ��ѯ
                DbCommand command = DBHelper.GetCommand(sql, DBHelper.GetConnection());
                DBHelper.OpenConnection();
                DbDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (!(dataReader["NickName"] is DBNull))  // �ж����ݿ������Ƿ�Ϊ��
                    {
                        nickName = Convert.ToString(dataReader["NickName"]);
                    }
                    faceId = Convert.ToInt32(dataReader["FaceId"]);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                error = true;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.ColseConnection();
            }

            // ���ݲ������ݿ������в�ͬ�Ĳ���
            if (error)
            {
                MessageBox.Show("����������ʧ�ܣ������µ�¼��", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                // �ڴ��������ʾ��¼���ǳơ�����
                this.Text = UserHelper.loginId.ToString();
                this.picFace.Image = ilFaces.Images[faceId];
                this.lblLoginId.Text = string.Format("{0}({1})", nickName, UserHelper.loginId.ToString());
            }
        }

        /// <summary>
        /// ���ҵĺ�����������ҵĺ����б�
        /// </summary>
        private void ShowFriendList()
        {
            Console.WriteLine("Mainform.cs ShowFriendList");
            // ���ԭ�����б�
            sbFriends.Groups[0].Items.Clear();

            bool error = false;   // ��ʶ���ݿ��Ƿ����

            // ��������Щ����
            string sql = string.Format(
                "SELECT FriendId,NickName,FaceId FROM Users,Friends WHERE Friends.HostId={0} AND Users.Id=Friends.FriendId",
                UserHelper.loginId);
            try
            {
                DbConnection connection = DBHelper.GetConnection();
                DbCommand command = DBHelper.GetCommand(sql, connection);
                DBHelper.OpenConnection();
                DbDataReader dataReader = command.ExecuteReader();
                UserInfo userinfo;
                int frindId;
                // ѭ����Ӻ����б�
                MyQQEntities entities = DBHelper.GetNewEntities();
                while (dataReader.Read())
                {
                    // ����һ��SideBar��
                    frindId = (int)dataReader["FriendId"];
                    userinfo = entities.UserInfoes.First<UserInfo>(item => item.userId == frindId);
                    if (userinfo.isLogin.Equals("T"))
                    {
                        Console.WriteLine("userinfo:T  " + userinfo.isLogin + " id" + userinfo.userId);
                        SbItem sbitem = new SbItem((string)dataReader["NickName"], (int)dataReader["FaceId"]);

                        sbitem.Tag = (int)dataReader["FriendId"]; // ���������Tag������

                        // SideBar�е������ͨ������ķ�ʽ���ʣ�������ӵ�˳��������0��ʼ
                        // Groups[0]��ʾSideBar�еĵ�һ���飬Ҳ���ǡ��ҵĺ��ѡ���
                        sbFriends.Groups[0].Items.Add(sbitem); // ��SideBar�ġ��ҵĺ��ѡ����������
                    }
                    else
                    {
                        SbItem sbitem = new SbItem((string)dataReader["NickName"], 101);

                        sbitem.Tag = (int)dataReader["FriendId"]; // ���������Tag������

                        // SideBar�е������ͨ������ķ�ʽ���ʣ�������ӵ�˳��������0��ʼ
                        // Groups[0]��ʾSideBar�еĵ�һ���飬Ҳ���ǡ��ҵĺ��ѡ���
                        sbFriends.Groups[0].Items.Add(sbitem); // ��SideBar�ġ��ҵĺ��ѡ����������
                    }
                }

                dataReader.Close();
            }
            catch (Exception ex)
            {
                error = true;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.ColseConnection();
            }
            // ������
            if (error)
            {
                MessageBox.Show("������������������볢�����µ�¼", "��Ǹ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// �жϷ���Ϣ�����Ƿ����б���
        /// </summary>        
        private bool HasShowUser(int loginId)
        {
            bool find = false;  // ��ʾ�Ƿ��ڵ�ǰ��ʾ�����û��б����ҵ��˸��û�

            // ѭ�� SideBar �е�2���飬Ѱ�ҷ���Ϣ�����Ƿ����б���
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < sbFriends.Groups[i].Items.Count; j++)
                {
                    if (Convert.ToInt32(sbFriends.Groups[i].Items[j].Tag) == loginId)
                    {
                        find = true;
                    }
                }
            }
            return find;
        }

        /// <summary>
        /// ����İ�����б�
        /// </summary>        
        private void UpdateStranger(int loginId)
        {
            // ѡ������˵Ļ�����Ϣ
            string sql = "SELECT NickName, FaceId FROM Users WHERE Id=" + loginId;
            bool error = false; // ������ʶ�Ƿ���ִ���
            try
            {
                DbCommand command = DBHelper.GetCommand(sql, DBHelper.GetConnection());
                DBHelper.OpenConnection();
                DbDataReader dataReader = command.ExecuteReader(); // ��ѯ
                if (dataReader.Read())
                {
                    SbItem item = new SbItem((string)dataReader["NickName"], (int)dataReader["FaceId"]);
                    item.Tag = this.fromUserId;           // ��Id��¼��Tag������
                    sbFriends.Groups[1].Items.Add(item);  // ��İ�������������
                }
                sbFriends.VisibleGroup = sbFriends.Groups[1];  // �趨İ������Ϊ�ɼ���
            }
            catch (Exception ex)
            {
                error = true;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.ColseConnection();
            }

            // ������
            if (error)
            {
                MessageBox.Show("�����������������", "��Ǹ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmrChatForm_Tick(object sender, EventArgs e)
        {
            upDateChatForms();
        }
    }
}