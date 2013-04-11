﻿namespace MyQQ
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblId = new System.Windows.Forms.Label();
            this.tsOperation = new System.Windows.Forms.ToolStrip();
            this.tsbtnPersonalInfo = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSearchFriend = new System.Windows.Forms.ToolStripButton();
            this.tsbtnUpdateFriendList = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMessageReading = new System.Windows.Forms.ToolStripButton();
            this.tsbtnExit = new System.Windows.Forms.ToolStripButton();
            this.ilFaces = new System.Windows.Forms.ImageList(this.components);
            this.picFace = new System.Windows.Forms.PictureBox();
            this.lblLoginId = new System.Windows.Forms.Label();
            this.sbFriends = new Aptech.UI.SideBar();
            this.cmsFriendList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddFriend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrMessage = new System.Windows.Forms.Timer(this.components);
            this.tmrAddFriend = new System.Windows.Forms.Timer(this.components);
            this.tmrChatRequest = new System.Windows.Forms.Timer(this.components);
            this.ilMessage = new System.Windows.Forms.ImageList(this.components);
            this.tsOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).BeginInit();
            this.cmsFriendList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(5, 9);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 12);
            this.lblId.TabIndex = 1;
            // 
            // tsOperation
            // 
            this.tsOperation.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsOperation.BackgroundImage")));
            this.tsOperation.CanOverflow = false;
            this.tsOperation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsOperation.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsOperation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnPersonalInfo,
            this.tsbtnSearchFriend,
            this.tsbtnUpdateFriendList,
            this.tsbtnMessageReading,
            this.tsbtnExit});
            this.tsOperation.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsOperation.Location = new System.Drawing.Point(0, 389);
            this.tsOperation.Name = "tsOperation";
            this.tsOperation.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsOperation.Size = new System.Drawing.Size(201, 25);
            this.tsOperation.TabIndex = 2;
            this.tsOperation.Text = "toolStrip1";
            // 
            // tsbtnPersonalInfo
            // 
            this.tsbtnPersonalInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPersonalInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPersonalInfo.Image")));
            this.tsbtnPersonalInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPersonalInfo.Name = "tsbtnPersonalInfo";
            this.tsbtnPersonalInfo.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPersonalInfo.Text = "个人信息";
            this.tsbtnPersonalInfo.Click += new System.EventHandler(this.tsbtnPersonalInfo_Click);
            // 
            // tsbtnSearchFriend
            // 
            this.tsbtnSearchFriend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSearchFriend.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSearchFriend.Image")));
            this.tsbtnSearchFriend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSearchFriend.Name = "tsbtnSearchFriend";
            this.tsbtnSearchFriend.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSearchFriend.Text = "查找好友";
            this.tsbtnSearchFriend.Click += new System.EventHandler(this.tsbtnSearchFriend_Click);
            // 
            // tsbtnUpdateFriendList
            // 
            this.tsbtnUpdateFriendList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnUpdateFriendList.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUpdateFriendList.Image")));
            this.tsbtnUpdateFriendList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUpdateFriendList.Name = "tsbtnUpdateFriendList";
            this.tsbtnUpdateFriendList.Size = new System.Drawing.Size(23, 22);
            this.tsbtnUpdateFriendList.Text = "更新好友列表";
            this.tsbtnUpdateFriendList.Click += new System.EventHandler(this.tsbtnUpdateFriendList_Click);
            // 
            // tsbtnMessageReading
            // 
            this.tsbtnMessageReading.BackColor = System.Drawing.Color.Transparent;
            this.tsbtnMessageReading.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tsbtnMessageReading.BackgroundImage")));
            this.tsbtnMessageReading.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMessageReading.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMessageReading.Image")));
            this.tsbtnMessageReading.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMessageReading.Name = "tsbtnMessageReading";
            this.tsbtnMessageReading.Size = new System.Drawing.Size(23, 22);
            this.tsbtnMessageReading.Text = "系统消息";
            this.tsbtnMessageReading.Click += new System.EventHandler(this.tsbtnMessageReading_Click);
            // 
            // tsbtnExit
            // 
            this.tsbtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExit.Image")));
            this.tsbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnExit.Name = "tsbtnExit";
            this.tsbtnExit.Size = new System.Drawing.Size(23, 22);
            this.tsbtnExit.Text = "退出";
            this.tsbtnExit.Click += new System.EventHandler(this.tsbtnExit_Click);
            // 
            // ilFaces
            // 
            this.ilFaces.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilFaces.ImageStream")));
            this.ilFaces.TransparentColor = System.Drawing.Color.Empty;
            this.ilFaces.Images.SetKeyName(0, "1");
            this.ilFaces.Images.SetKeyName(1, "2");
            this.ilFaces.Images.SetKeyName(2, "3");
            this.ilFaces.Images.SetKeyName(3, "4");
            this.ilFaces.Images.SetKeyName(4, "5");
            this.ilFaces.Images.SetKeyName(5, "6");
            this.ilFaces.Images.SetKeyName(6, "7");
            this.ilFaces.Images.SetKeyName(7, "8");
            this.ilFaces.Images.SetKeyName(8, "9");
            this.ilFaces.Images.SetKeyName(9, "10");
            this.ilFaces.Images.SetKeyName(10, "11");
            this.ilFaces.Images.SetKeyName(11, "12");
            this.ilFaces.Images.SetKeyName(12, "13");
            this.ilFaces.Images.SetKeyName(13, "14");
            this.ilFaces.Images.SetKeyName(14, "15");
            this.ilFaces.Images.SetKeyName(15, "16");
            this.ilFaces.Images.SetKeyName(16, "17");
            this.ilFaces.Images.SetKeyName(17, "18");
            this.ilFaces.Images.SetKeyName(18, "19");
            this.ilFaces.Images.SetKeyName(19, "20");
            this.ilFaces.Images.SetKeyName(20, "21");
            this.ilFaces.Images.SetKeyName(21, "22");
            this.ilFaces.Images.SetKeyName(22, "23");
            this.ilFaces.Images.SetKeyName(23, "24");
            this.ilFaces.Images.SetKeyName(24, "25");
            this.ilFaces.Images.SetKeyName(25, "26");
            this.ilFaces.Images.SetKeyName(26, "27");
            this.ilFaces.Images.SetKeyName(27, "28");
            this.ilFaces.Images.SetKeyName(28, "29");
            this.ilFaces.Images.SetKeyName(29, "30");
            this.ilFaces.Images.SetKeyName(30, "31");
            this.ilFaces.Images.SetKeyName(31, "32");
            this.ilFaces.Images.SetKeyName(32, "33");
            this.ilFaces.Images.SetKeyName(33, "34");
            this.ilFaces.Images.SetKeyName(34, "35");
            this.ilFaces.Images.SetKeyName(35, "36");
            this.ilFaces.Images.SetKeyName(36, "37");
            this.ilFaces.Images.SetKeyName(37, "38");
            this.ilFaces.Images.SetKeyName(38, "39");
            this.ilFaces.Images.SetKeyName(39, "40");
            this.ilFaces.Images.SetKeyName(40, "41");
            this.ilFaces.Images.SetKeyName(41, "42");
            this.ilFaces.Images.SetKeyName(42, "43");
            this.ilFaces.Images.SetKeyName(43, "44");
            this.ilFaces.Images.SetKeyName(44, "45");
            this.ilFaces.Images.SetKeyName(45, "46");
            this.ilFaces.Images.SetKeyName(46, "47");
            this.ilFaces.Images.SetKeyName(47, "48");
            this.ilFaces.Images.SetKeyName(48, "49");
            this.ilFaces.Images.SetKeyName(49, "50");
            this.ilFaces.Images.SetKeyName(50, "51");
            this.ilFaces.Images.SetKeyName(51, "52");
            this.ilFaces.Images.SetKeyName(52, "53");
            this.ilFaces.Images.SetKeyName(53, "54");
            this.ilFaces.Images.SetKeyName(54, "55");
            this.ilFaces.Images.SetKeyName(55, "56");
            this.ilFaces.Images.SetKeyName(56, "57");
            this.ilFaces.Images.SetKeyName(57, "58");
            this.ilFaces.Images.SetKeyName(58, "59");
            this.ilFaces.Images.SetKeyName(59, "60");
            this.ilFaces.Images.SetKeyName(60, "61");
            this.ilFaces.Images.SetKeyName(61, "62");
            this.ilFaces.Images.SetKeyName(62, "63");
            this.ilFaces.Images.SetKeyName(63, "64");
            this.ilFaces.Images.SetKeyName(64, "65");
            this.ilFaces.Images.SetKeyName(65, "66");
            this.ilFaces.Images.SetKeyName(66, "67");
            this.ilFaces.Images.SetKeyName(67, "68");
            this.ilFaces.Images.SetKeyName(68, "69");
            this.ilFaces.Images.SetKeyName(69, "70");
            this.ilFaces.Images.SetKeyName(70, "71");
            this.ilFaces.Images.SetKeyName(71, "72");
            this.ilFaces.Images.SetKeyName(72, "73");
            this.ilFaces.Images.SetKeyName(73, "74");
            this.ilFaces.Images.SetKeyName(74, "75");
            this.ilFaces.Images.SetKeyName(75, "76");
            this.ilFaces.Images.SetKeyName(76, "77");
            this.ilFaces.Images.SetKeyName(77, "78");
            this.ilFaces.Images.SetKeyName(78, "79");
            this.ilFaces.Images.SetKeyName(79, "80");
            this.ilFaces.Images.SetKeyName(80, "81");
            this.ilFaces.Images.SetKeyName(81, "82");
            this.ilFaces.Images.SetKeyName(82, "83");
            this.ilFaces.Images.SetKeyName(83, "84");
            this.ilFaces.Images.SetKeyName(84, "85");
            this.ilFaces.Images.SetKeyName(85, "86");
            this.ilFaces.Images.SetKeyName(86, "87");
            this.ilFaces.Images.SetKeyName(87, "88");
            this.ilFaces.Images.SetKeyName(88, "89");
            this.ilFaces.Images.SetKeyName(89, "90");
            this.ilFaces.Images.SetKeyName(90, "91");
            this.ilFaces.Images.SetKeyName(91, "92");
            this.ilFaces.Images.SetKeyName(92, "93");
            this.ilFaces.Images.SetKeyName(93, "94");
            this.ilFaces.Images.SetKeyName(94, "95");
            this.ilFaces.Images.SetKeyName(95, "96");
            this.ilFaces.Images.SetKeyName(96, "97");
            this.ilFaces.Images.SetKeyName(97, "98");
            this.ilFaces.Images.SetKeyName(98, "99");
            this.ilFaces.Images.SetKeyName(99, "100");
            this.ilFaces.Images.SetKeyName(100, "back.bmp");
            // 
            // picFace
            // 
            this.picFace.BackColor = System.Drawing.Color.Transparent;
            this.picFace.Location = new System.Drawing.Point(7, 9);
            this.picFace.Name = "picFace";
            this.picFace.Size = new System.Drawing.Size(40, 40);
            this.picFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFace.TabIndex = 3;
            this.picFace.TabStop = false;
            this.picFace.Click += new System.EventHandler(this.tsbtnPersonalInfo_Click);
            // 
            // lblLoginId
            // 
            this.lblLoginId.AutoSize = true;
            this.lblLoginId.BackColor = System.Drawing.Color.Transparent;
            this.lblLoginId.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginId.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblLoginId.Location = new System.Drawing.Point(60, 24);
            this.lblLoginId.Name = "lblLoginId";
            this.lblLoginId.Size = new System.Drawing.Size(0, 23);
            this.lblLoginId.TabIndex = 4;
            // 
            // sbFriends
            // 
            this.sbFriends.AllowDragItem = false;
            this.sbFriends.BackColor = System.Drawing.Color.AliceBlue;
            this.sbFriends.ContextMenuStrip = this.cmsFriendList;
            this.sbFriends.FlatStyle = Aptech.UI.SbFlatStyle.Normal;
            this.sbFriends.GroupHeaderBackColor = System.Drawing.Color.LightSkyBlue;
            this.sbFriends.GroupTextColor = System.Drawing.Color.Black;
            this.sbFriends.ImageList = this.ilFaces;
            this.sbFriends.ItemContextMenuStrip = null;
            this.sbFriends.ItemStyle = Aptech.UI.SbItemStyle.PushButton;
            this.sbFriends.ItemTextColor = System.Drawing.Color.Navy;
            this.sbFriends.Location = new System.Drawing.Point(0, 55);
            this.sbFriends.Name = "sbFriends";
            this.sbFriends.RadioSelectedItem = null;
            this.sbFriends.Size = new System.Drawing.Size(201, 331);
            this.sbFriends.TabIndex = 5;
            this.sbFriends.View = Aptech.UI.SbView.LargeIcon;
            this.sbFriends.VisibleGroup = null;
            this.sbFriends.VisibleGroupIndex = -1;
            this.sbFriends.VisibleGroupChanged += new Aptech.UI.SbGroupEventHandler(this.sbFriends_VisibleGroupChanged);
            this.sbFriends.ItemDoubleClick += new Aptech.UI.SbItemEventHandler(this.sbFriends_ItemDoubleClick);
            // 
            // cmsFriendList
            // 
            this.cmsFriendList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiView,
            this.tsmiAddFriend,
            this.tsmiDelete});
            this.cmsFriendList.Name = "cmsFriendList";
            this.cmsFriendList.Size = new System.Drawing.Size(119, 70);
            this.cmsFriendList.Opening += new System.ComponentModel.CancelEventHandler(this.cmsFriendList_Opening);
            // 
            // tsmiView
            // 
            this.tsmiView.Name = "tsmiView";
            this.tsmiView.Size = new System.Drawing.Size(118, 22);
            this.tsmiView.Text = "小头像";
            this.tsmiView.Click += new System.EventHandler(this.tsmiView_Click);
            // 
            // tsmiAddFriend
            // 
            this.tsmiAddFriend.Name = "tsmiAddFriend";
            this.tsmiAddFriend.Size = new System.Drawing.Size(118, 22);
            this.tsmiAddFriend.Text = "加为好友";
            this.tsmiAddFriend.Visible = false;
            this.tsmiAddFriend.Click += new System.EventHandler(this.tsmiAddFriend_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(118, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Visible = false;
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tmrMessage
            // 
            this.tmrMessage.Enabled = true;
            this.tmrMessage.Interval = 2000;
            this.tmrMessage.Tick += new System.EventHandler(this.tmrMessage_Tick);
            // 
            // tmrAddFriend
            // 
            this.tmrAddFriend.Interval = 500;
            this.tmrAddFriend.Tick += new System.EventHandler(this.tmrAddFriend_Tick);
            // 
            // tmrChatRequest
            // 
            this.tmrChatRequest.Interval = 500;
            this.tmrChatRequest.Tick += new System.EventHandler(this.tmrChatRequest_Tick);
            // 
            // ilMessage
            // 
            this.ilMessage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMessage.ImageStream")));
            this.ilMessage.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMessage.Images.SetKeyName(0, "MessageReading.gif");
            this.ilMessage.Images.SetKeyName(1, "Message.gif");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(201, 414);
            this.Controls.Add(this.lblLoginId);
            this.Controls.Add(this.sbFriends);
            this.Controls.Add(this.tsOperation);
            this.Controls.Add(this.picFace);
            this.Controls.Add(this.lblId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(800, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tsOperation.ResumeLayout(false);
            this.tsOperation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).EndInit();
            this.cmsFriendList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.ToolStrip tsOperation;
        private System.Windows.Forms.ToolStripButton tsbtnPersonalInfo;
        private System.Windows.Forms.ToolStripButton tsbtnSearchFriend;
        private System.Windows.Forms.ImageList ilFaces;
        private System.Windows.Forms.PictureBox picFace;
        private System.Windows.Forms.Label lblLoginId;
        private Aptech.UI.SideBar sbFriends;
        private System.Windows.Forms.ToolStripButton tsbtnUpdateFriendList;
        private System.Windows.Forms.Timer tmrMessage;
        private System.Windows.Forms.ToolStripButton tsbtnMessageReading;
        private System.Windows.Forms.Timer tmrAddFriend;
        private System.Windows.Forms.Timer tmrChatRequest;
        private System.Windows.Forms.ContextMenuStrip cmsFriendList;
        private System.Windows.Forms.ToolStripMenuItem tsmiView;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddFriend;
        private System.Windows.Forms.ToolStripButton tsbtnExit;
        private System.Windows.Forms.ImageList ilMessage;
    }
}