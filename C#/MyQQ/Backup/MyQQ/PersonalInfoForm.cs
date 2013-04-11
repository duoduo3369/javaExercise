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
    /// ��������ҳ��
    /// </summary>
    public partial class PersonalInfoForm : Form
    {
        public MainForm mainForm;  // ������

        private string[] stars = new string[12];      // ����Id����
        private string[] bloodTypes = new string[4];  // Ѫ��Id����

        public PersonalInfoForm()
        {
            InitializeComponent();
        }

        // ������أ������ݿ��ȡ��Ϣ��ʾ
        private void PersonalInfoForm_Load(object sender, EventArgs e)
        {
            // �ø�������Panel�ɼ�����ȫ����Panel���ɼ�
            pnlDetails.Visible = true;
            pnlSecurity.Visible = false;

            // ���������������ͼƬ��ť��ͼƬ
            picDetails.Image = ilLink.Images[1];  // ѡ�е�
            picSecurity.Image = ilLink.Images[2]; // δѡ�е�
            
            int starId = -1;             // ����Id
            int bloodTypeId = -1;        // Ѫ��Id
            int faceId = 0;              // ͷ��Id
            int friendshipPolicyId = 0;  // ���Ѳ���Id

            bool error = false;          // ������ʶ�������ݿ��Ƿ����

            // ��ѯ�õ�sql���
            string sql = string.Format(
                "SELECT * FROM Users WHERE id={0}",UserHelper.loginId);
            try
            {
                // ִ�в�ѯ
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();               
                SqlDataReader reader = command.ExecuteReader();
                
                // �������������ʾ�ڴ�����
                if (reader.Read())
                {
                    this.txtLoginId.Text = Convert.ToString(reader["Id"]);        // ����
                    this.txtNickName.Text = Convert.ToString(reader["NickName"]); // �ǳ�
                    this.cboSex.Text = Convert.ToString(reader["Sex"]) == "��" ? "��" : "Ů"; // �Ա�
                    
                    if (!(reader["Name"] is DBNull))  // Ҫ����ѧ������ж�
                    {
                        this.txtName.Text = reader["Name"].ToString(); // ��ʵ����
                    }                    
                    this.txtAge.Text = Convert.ToString(reader["Age"]);   // ����
                    this.txtOldPwd.Text = Convert.ToString(reader["LoginPwd"]);  // ����

                    if (!(reader["StarId"] is DBNull))
                    {
                        starId = Convert.ToInt32(reader["StarId"]);  // ����Id
                    }
                    if (!(reader["BloodTypeId"] is DBNull))
                    {
                        bloodTypeId = Convert.ToInt32(reader["BloodTypeId"]);  // Ѫ��Id
                    }                    
                    faceId = Convert.ToInt32(reader["FaceId"]);  // ͷ��Id
                    friendshipPolicyId = Convert.ToInt32(reader["FriendshipPolicyId"]); // ���Ѳ���Id
                }
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

            // ������
            if (error)
            {
                MessageBox.Show("��ʾ������Ϣ����", "��Ǹ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // ����������Ͽ�
                FillStarsComboBox(starId);

                // ����Ѫ����Ͽ�
                FillBloodTypesComboBox(bloodTypeId);

                // ����ͷ����ʾ
                ShowFace(faceId);

                // ������Ѳ���
                switch (friendshipPolicyId)
                {
                    case 1:
                        rdoAnybody.Checked = true;
                        break;
                    case 2:
                        rdoValidation.Checked = true;
                        break;
                    case 3:
                        rdoNobody.Checked = true;
                        break;
                    default:
                        rdoAnybody.Checked = true;
                        break;
                }
            }            
        }

        // ���������Ϣ����ʾ������ϢPanel��������Panel���ɼ�
        private void picDetails_Click(object sender, EventArgs e)
        {
            pnlDetails.Visible = true;      // ������Ϣ���ֿɼ�
            pnlSecurity.Visible = false;    // ��ȫ���ò��ֲ��ɼ�

            // ��ർ����ť��ͼƬ
            picDetails.Image = ilLink.Images[1];
            picSecurity.Image = ilLink.Images[2];
        }

        // ��ʾ��ȫ����Panel
        private void picSecurity_Click(object sender, EventArgs e)
        {
            pnlSecurity.Location = pnlDetails.Location;
            pnlSecurity.Visible = true;     // ��ȫ���ò��ֲ��ɼ�
            pnlDetails.Visible = false;     // ������Ϣ���ֲ��ɼ�  
          
            // ������ർ����ť��ͼƬ
            picDetails.Image = ilLink.Images[0];
            picSecurity.Image = ilLink.Images[3];
        }

        // ѡ��ͷ��
        private void btnShowFaces_MouseClick(object sender, MouseEventArgs e)
        {
            FacesForm facesForm = new FacesForm();
            facesForm.personalInfoForm = this;
            facesForm.Show();
        }
       
        // ���ȷ�����������ݵ����ݿ�
        private void btnOK_Click(object sender, EventArgs e)
        {
            // ������֤
            if (ValidataInput())
            {
                string sql = GetSQL();  // ��ȡ�����õ� SQL ��� 
                int result = -1;        // ���ݿ�������
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

                // ����ִ�н������ʾ��ͬ����Ϣ
                if (result == 1)
                {
                    MessageBox.Show("�������Ѿ������������", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("����������ʧ�ܣ�", "�������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                mainForm.ShowSelfInfo();  // �����������еĸ�����Ϣ
                this.Close(); // �رմ���
            }
        }

        // ���ȡ�����رմ���
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
        
        /// <summary>
        /// ��������Ͽ�����ʾ����
        /// </summary>
        private void FillStarsComboBox(int currentStarId)
        {
            string sql = "SELECT * FROM Star";  // ��ѯ�� SQL ���
            try
            {
                // ���� Command ����
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                // ��ʼ����������
                int i = 0;
                while (dataReader.Read())
                {
                    // ���������������������
                    this.stars[i] = Convert.ToString(dataReader["Star"]);
                    i++;
                }

                // �����������е�������ӵ�������Ͽ���
                for (i = 0; i < stars.Length; i++)
                {
                    cboStar.Items.Add(stars[i]);
                    if (currentStarId == i + 1)
                    {
                        cboStar.SelectedIndex = i;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("����������");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }
        }
        
        /// <summary>
        /// ��Ѫ����Ͽ�����ʾ����
        /// </summary>
        private void FillBloodTypesComboBox(int currentBloodTypeId)
        {
            string sql = "SELECT * FROM BloodType";  // ��ѯ�� SQL ���
            try
            {
                // ���� Command ����
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                // ��ʼ��Ѫ������
                int i = 0;
                while (dataReader.Read())
                {
                    // ��Ѫ�ʹ����Ѫ��������
                    this.bloodTypes[i] = Convert.ToString(dataReader["BloodType"]);
                    i++;
                }
                // ��Ѫ�������е�Ѫ����ӵ�Ѫ����Ͽ���
                for (i = 0; i < bloodTypes.Length; i++)
                {
                    cboBloodType.Items.Add(bloodTypes[i]);
                    if (currentBloodTypeId == i + 1)
                    {
                        cboBloodType.SelectedIndex = i;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("��Ѫ�ͳ���");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }
        }

        /// <summary>
        /// ������ʾ��ͷ��
        /// </summary>
        public void ShowFace(int currentFaceId)
        {
            picFace.Image = ilFaces.Images[currentFaceId];
            picFace.Tag = currentFaceId;
        }        

        /// <summary>
        /// ��֤�û��Ƿ���д�˱�����Ϣ�������Ƿ�һ��
        /// </summary>
        /// <returns></returns>
        private bool ValidataInput()
        {
            if (txtNickName.Text.Trim() == "")  // �ǳƲ���Ϊ��
            {
                MessageBox.Show("������д�ǳ��ˣ�","������ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtNickName.Focus();
                return false;
            }
            if (txtAge.Text.Trim() == "")  // ���䲻��Ϊ��
            {
                MessageBox.Show("������д�����ˣ�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAge.Focus();
                return false;
            }
            if (cboSex.Text.Trim() == "")   // �Ա��ѡ
            {
                MessageBox.Show("������ѡ�Ա��ˣ�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboSex.Focus();
                return false;
            }
            if (txtNewPwd.Text.Trim() != txtNewPwdAgain.Text.Trim())  // ��������������Ƿ�һ��
            {
                MessageBox.Show("�������ȷ�����벻һ�£�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPwdAgain.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// ��ø������ݿ��SQL���
        /// </summary>
        /// <returns></returns>
        private string GetSQL()
        {
            // �����õ�sql��䣬�ֳɶ�ƴ��
            string sql = string.Format("UPDATE Users SET NickName='{0}', FaceId={1},Sex='{2}',Age={3}",
                txtNickName.Text.Trim(), Convert.ToInt32(picFace.Tag), cboSex.Text.Trim(), Convert.ToInt32(txtAge.Text.Trim()));
            if (txtNewPwd.Text.Trim() != "")  // ����޸�������͸��������ֶ�
            {
                sql = string.Format("{0} ,LoginPwd='{1}' ", sql, txtNewPwd.Text.Trim());
            }

            // ��Ӻ��Ѳ��ԣ��ж��ĸ���ѡ��ť��ѡ��
            int friendshipPolicyId = 0;
            if (rdoAnybody.Checked)
            {
                friendshipPolicyId = Convert.ToInt32(rdoAnybody.Tag);
            }
            else if (rdoValidation.Checked)
            {
                friendshipPolicyId = Convert.ToInt32(rdoValidation.Tag);
            }
            else if (rdoNobody.Checked)
            {
                friendshipPolicyId = Convert.ToInt32(rdoNobody.Tag);
            }

            // ������sql
            sql = string.Format("{0},FriendshipPolicyId={1},Name='{2}',starId={3},BloodTypeId={4} WHERE Id={5}",
                sql, friendshipPolicyId, txtName.Text.Trim(), cboStar.SelectedIndex + 1, cboBloodType.SelectedIndex + 1, UserHelper.loginId);

            return sql;
        }
    }
}