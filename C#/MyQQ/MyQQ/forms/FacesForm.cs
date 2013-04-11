using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyQQ
{
    /// <summary>
    /// 头像选择窗体
    /// </summary>
    public partial class FacesForm : Form
    {
        public PersonalInfoForm personalInfoForm;  // 个人信息窗体
        
        public FacesForm()
        {
            InitializeComponent();
        }        

        // 窗体加载时显示头像图片
        private void FacesForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < ilFaces.Images.Count; i++)
            {
                lvFaces.Items.Add(i.ToString());
                lvFaces.Items[i].ImageIndex = i;
            }            
        }       

        // 确定选择头像
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lvFaces.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择一个头像！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int faceId = lvFaces.SelectedItems[0].ImageIndex;  // 获得当前选中的头像的索引
                personalInfoForm.ShowFace(faceId);  // 设置个人信息窗体中显示的头像
                this.Close(); 
            }            
        }

        // 双击时选择头像
        private void lvIcons_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int faceId = lvFaces.SelectedItems[0].ImageIndex;  // 获得当前选中的头像的索引
            personalInfoForm.ShowFace(faceId);  // 设置个人信息窗体中显示的头像
            this.Close();
        }

        // 关闭窗体
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}