namespace MyQQ
{
    partial class ChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.lblFriend = new System.Windows.Forms.Label();
            this.picFace = new System.Windows.Forms.PictureBox();
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.lblMessages = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ilFaces = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).BeginInit();
            this.pnlMessages.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFriend
            // 
            this.lblFriend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFriend.BackColor = System.Drawing.Color.AliceBlue;
            this.lblFriend.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFriend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFriend.Location = new System.Drawing.Point(30, 0);
            this.lblFriend.Name = "lblFriend";
            this.lblFriend.Size = new System.Drawing.Size(324, 24);
            this.lblFriend.TabIndex = 0;
            this.lblFriend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picFace
            // 
            this.picFace.BackColor = System.Drawing.Color.AliceBlue;
            this.picFace.Location = new System.Drawing.Point(0, 0);
            this.picFace.Name = "picFace";
            this.picFace.Size = new System.Drawing.Size(24, 24);
            this.picFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFace.TabIndex = 1;
            this.picFace.TabStop = false;
            // 
            // pnlMessages
            // 
            this.pnlMessages.BackColor = System.Drawing.Color.White;
            this.pnlMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMessages.Controls.Add(this.lblMessages);
            this.pnlMessages.Controls.Add(this.label1);
            this.pnlMessages.Controls.Add(this.picFace);
            this.pnlMessages.Controls.Add(this.lblFriend);
            this.pnlMessages.Location = new System.Drawing.Point(12, 12);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Size = new System.Drawing.Size(355, 202);
            this.pnlMessages.TabIndex = 2;
            // 
            // lblMessages
            // 
            this.lblMessages.Location = new System.Drawing.Point(-1, 27);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(355, 173);
            this.lblMessages.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(25, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 24);
            this.label1.TabIndex = 2;
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(12, 221);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(355, 101);
            this.txtChat.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSend.BackgroundImage")));
            this.btnSend.Location = new System.Drawing.Point(296, 328);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(71, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.Location = new System.Drawing.Point(219, 328);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(379, 360);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.pnlMessages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ChatForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).EndInit();
            this.pnlMessages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFriend;
        private System.Windows.Forms.PictureBox picFace;
        private System.Windows.Forms.Panel pnlMessages;
        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList ilFaces;
    }
}