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

namespace MyQQ
{
    /// <summary>
    /// 登录后的主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        int fromUserId;  　// 消息的发起者
        int friendFaceId;  // 发消息的好友的头像Id  

        int messageImageIndex = 0;  // 工具栏中的消息图标的索引
        
        public MainForm()
        {
            InitializeComponent();
        }

        // 窗体加载时发生
        private void MainForm_Load(object sender, EventArgs e)
        {
            // 工具栏的消息图标
            tsbtnMessageReading.Image = ilMessage.Images[0];
            
            // 显示个人的信息            
            ShowSelfInfo();
            
            // 添加 SideBar 的两个组
            sbFriends.AddGroup("我的好友");
            sbFriends.AddGroup("陌生人");

            // 向我的好友组中添加我的好友列表
            ShowFriendList();
        }

        // 窗体关闭后，退出应用程序
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // 显示个人信息窗体
        private void tsbtnPersonalInfo_Click(object sender, EventArgs e)
        {
            PersonalInfoForm personalInfoForm = new PersonalInfoForm();
            personalInfoForm.mainForm = this;  // 将当前窗体本身传给个人信息窗体
            personalInfoForm.Show();
        }

        // 显示查找好友窗体
        private void tsbtnSearchFriend_Click(object sender, EventArgs e)
        {
            SearchFriendForm searchFriendForm = new SearchFriendForm();
            searchFriendForm.Show();
        }

        // 双击一项，弹出聊天窗体        
        private void sbFriends_ItemDoubleClick(SbItemEventArgs e)
        {
            // 消息timer停止运行
            if (tmrChatRequest.Enabled == true)
            {
                tmrChatRequest.Stop();                
                e.Item.ImageIndex = this.friendFaceId;
            }

            // 显示聊天窗体
            ChatForm chatForm = new ChatForm();
            chatForm.friendId = Convert.ToInt32(e.Item.Tag); // 号码
            chatForm.nickName = e.Item.Text;  // 昵称
            chatForm.faceId = e.Item.ImageIndex;  // 头像
            chatForm.Show();
        }

        // 点击刷新好友列表
        private void tsbtnUpdateFriendList_Click(object sender, EventArgs e)
        {
            ShowFriendList();
        }

        // 定时扫描数据库，找到未读消息
        private void tmrMessage_Tick(object sender, EventArgs e)
        {
            ShowFriendList();       // 刷新好友列表
            int messageTypeId = 1;  // 消息类型
            int messageState = 1;   // 消息状态

            // 找出未读消息对应的好友Id
            string sql = string.Format(
                "SELECT Top 1 FromUserId, MessageTypeId, MessageState FROM Messages WHERE ToUserId={0} AND MessageState=0", UserHelper.loginId);
            SqlCommand command;

            // 消息有两种类型：聊天消息、添加好友消息
            try
            {
                command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                // 循环读出一个未读消息
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
                DBHelper.connection.Close();
            }

            // 判断消息类型，如果是添加好友消息，就启动喇叭timer，让小喇叭闪烁
            if (messageTypeId == 2 && messageState == 0)
            {
                SoundPlayer player = new SoundPlayer("system.wav");
                player.Play();
                tmrAddFriend.Start();
            }
            // 如果是聊天消息，就启动聊天timer，让好友头像闪烁
            else if (messageTypeId == 1 && messageState == 0)
            {
                // 获得发消息的人的头像Id
                sql = "SELECT FaceId FROM Users WHERE Id=" + this.fromUserId;
                try
                {
                    command = new SqlCommand(sql, DBHelper.connection);
                    DBHelper.connection.Open();
                    this.friendFaceId = Convert.ToInt32(command.ExecuteScalar());   // 设置发消息的好友的头像索引
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    DBHelper.connection.Close();
                }

                // 如果发消息的人没有在列表中就添加到陌生人列表中
                if (!HasShowUser(fromUserId))
                {
                    UpdateStranger(fromUserId);
                }
                SoundPlayer player = new SoundPlayer("msg.wav");
                player.Play();
                tmrChatRequest.Start();  // 启动闪烁头像定时器
            }
        }

        // 控制喇叭闪烁
        private void tmrAddFriend_Tick(object sender, EventArgs e)
        {
            // 反复修改它的图像
            messageImageIndex = messageImageIndex == 0 ? 1:0;
            tsbtnMessageReading.Image = ilMessage.Images[messageImageIndex];
        }

        // 单击时显示请求好友消息窗体
        private void tsbtnMessageReading_Click(object sender, EventArgs e)
        {
            tmrAddFriend.Stop();  // 消息timer停止运行 
            // 图片恢复正常
            messageImageIndex = 0;
            tsbtnMessageReading.Image = ilMessage.Images[messageImageIndex];

            // 显示系统消息窗体
            RequestForm requestForm = new RequestForm();
            requestForm.Show();
        }

        // 让相应的好友头像闪烁
        private void tmrChatRequest_Tick(object sender, EventArgs e)
        {
            // 循环好友列表两个组中的每个item，找到发消息的好友，让他的头像闪烁
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < sbFriends.Groups[i].Items.Count; j++)
                {
                    if (Convert.ToInt32(sbFriends.Groups[i].Items[j].Tag) == this.fromUserId)
                    {
                        if (sbFriends.Groups[i].Items[j].ImageIndex < 100)
                        {
                            sbFriends.Groups[i].Items[j].ImageIndex = 100;// 索引为100的图片是一个空白图片
                        }
                        else
                        {
                            sbFriends.Groups[i].Items[j].ImageIndex = this.friendFaceId;
                        }
                        sbFriends.Invalidate();  // 重新绘制，只要告诉学生需要这句话才能正常闪烁头像就行
                    }
                }
            }
        }

        // 显示右键菜单时，控制哪些菜单不可见
        private void cmsFriendList_Opening(object sender, CancelEventArgs e)
        {
            // 如果没有选中的项
            if (sbFriends.SeletedItem == null)
            {
                tsmiDelete.Visible = false;
            }
            else
            {
                tsmiDelete.Visible = true;
            }

            // 如果选中的是陌生人，显示加为好友菜单
            if (sbFriends.SeletedItem != null && sbFriends.SeletedItem.Parent == sbFriends.Groups[1])
            {
                tsmiAddFriend.Visible = true;
            }
            else
            {
                tsmiAddFriend.Visible = false;
            }
        }

        // 显示大、小头像视图切换
        private void tsmiView_Click(object sender, EventArgs e)
        {
            if (sbFriends.View == SbView.LargeIcon)
            {
                sbFriends.View = SbView.SmallIcon;
                tsmiView.Text = "显示大头像";
            }
            else if (sbFriends.View == SbView.SmallIcon)
            {
                sbFriends.View = SbView.LargeIcon;
                tsmiView.Text = "显示小头像";
            }
        }

        // 删除好友
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            DialogResult result;   // 对话框结果
            int deleteResult = 0;  // 操作结果
            if (sbFriends.SeletedItem != null)
            {
                result = MessageBox.Show("确实要删除该好友吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) // 确认删除
                {
                    if (sbFriends.VisibleGroup == sbFriends.Groups[0])
                    {
                        string sql = string.Format(
                            "DELETE FROM Friends WHERE HostId={0} AND FriendId={1}",
                            UserHelper.loginId, Convert.ToInt32(sbFriends.SeletedItem.Tag));

                        try
                        {
                            SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                            DBHelper.connection.Open();
                            deleteResult = command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            DBHelper.connection.Close();
                        }
                        if (deleteResult == 1)
                        {
                            MessageBox.Show("好友已删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);
                        }
                    }
                    else
                    {
                        MessageBox.Show("好友已删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);
                    }                    
                }
            }
        }        

        // 将选中的人加为好友              
        private void tsmiAddFriend_Click(object sender, EventArgs e)
        {
            int result = 0;  // 操作结果
            string sql = string.Format(
                "INSERT INTO Friends (HostId, FriendId) VALUES({0},{1})",
                UserHelper.loginId, Convert.ToInt32(sbFriends.SeletedItem.Tag));

            try
            {
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
            if (result == 1)
            {
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sbFriends.SeletedItem.Parent.Items.Remove(sbFriends.SeletedItem);  
                ShowFriendList();   // 更新好友列表             
            }
            else
            {
                MessageBox.Show("添加失败，请稍候再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 退出
        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确实要退出吗？", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // 可见组发生变化时，发出声音
        private void sbFriends_VisibleGroupChanged(SbGroupEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("folder.wav");
            player.Play();
        }        

        /// <summary>
        /// 登录后显示个人的信息
        /// </summary>
        public void ShowSelfInfo()
        {
            string nickName = "";  // 昵称
            int faceId = 0;        // 头像索引
            bool error = false;    // 标识是否出现错误

            // 取得当前用户的昵称、头像
            string sql = string.Format(
                "SELECT NickName, FaceId FROM Users WHERE Id={0}",
                UserHelper.loginId);
            try
            {
                // 查询
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    if (!(dataReader["NickName"] is DBNull))  // 判断数据库类型是否为空
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
                DBHelper.connection.Close();
            }

            // 根据操作数据库结果进行不同的操作
            if (error)
            {
                MessageBox.Show("服务器请求失败！请重新登录！", "意外错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                // 在窗体标题显示登录的昵称、号码
                this.Text = UserHelper.loginId.ToString();
                this.picFace.Image = ilFaces.Images[faceId];
                this.lblLoginId.Text = string.Format("{0}({1})", nickName, UserHelper.loginId.ToString());
            }            
        }

        /// <summary>
        /// 向我的好友组中添加我的好友列表
        /// </summary>
        private void ShowFriendList()
        {
            // 清空原来的列表
            sbFriends.Groups[0].Items.Clear();

            bool error = false;   // 标识数据库是否出错

            // 查找有哪些好友
            string sql = string.Format(
                "SELECT FriendId,NickName,FaceId FROM Users,Friends WHERE Friends.HostId={0} AND Users.Id=Friends.FriendId",
                UserHelper.loginId);
            try
            {
                // 执行查询
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                // 循环添加好友列表
                while (dataReader.Read())
                {
                    // 创建一个SideBar项
                    SbItem item = new SbItem((string)dataReader["NickName"], (int)dataReader["FaceId"]);
                    item.Tag = (int)dataReader["FriendId"]; // 将号码放在Tag属性中

                    // SideBar中的组可以通过数组的方式访问，按照添加的顺序索引从0开始
                    // Groups[0]表示SideBar中的第一个组，也就是“我的好友”组
                    sbFriends.Groups[0].Items.Add(item); // 向SideBar的“我的好友”组中添加项
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
                DBHelper.connection.Close();
            }
            // 出错了
            if (error)
            {
                MessageBox.Show("服务器发生意外错误！请尝试重新登录", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }        
         
        /// <summary>
        /// 判断发消息的人是否在列表中
        /// </summary>        
        private bool HasShowUser(int loginId)
        {
            bool find = false;  // 表示是否在当前显示出的用户列表中找到了该用户

            // 循环 SideBar 中的2个组，寻找发消息的人是否在列表中
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
        /// 更新陌生人列表
        /// </summary>        
        private void UpdateStranger(int loginId)
        {
            // 选出这个人的基本信息
            string sql = "SELECT NickName, FaceId FROM Users WHERE Id=" + loginId;
            bool error = false; // 用来标识是否出现错误
            try
            {
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();                
                SqlDataReader dataReader = command.ExecuteReader(); // 查询
                if (dataReader.Read())
                {
                    SbItem item = new SbItem((string)dataReader["NickName"], (int)dataReader["FaceId"]);
                    item.Tag = this.fromUserId;           // 将Id记录在Tag属性中
                    sbFriends.Groups[1].Items.Add(item);  // 向陌生人组中添加项
                }
                sbFriends.VisibleGroup = sbFriends.Groups[1];  // 设定陌生人组为可见组
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
                MessageBox.Show("服务器出现意外错误！", "抱歉", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }        
    }
}