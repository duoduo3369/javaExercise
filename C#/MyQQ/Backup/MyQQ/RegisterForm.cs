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
    /// ע�����
    /// </summary>
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        // �������ʱ�����������Ѫ����Ͽ��е���
        private void ApplyForm_Load(object sender, EventArgs e)
        {
            // ��ѯ�����õ�sql���
            string sql = "SELECT Star FROM Star";

            bool error = false;   // ��ʶ�������ݿ��Ƿ�����

            try
            {
                // ���������Ͽ��е���                
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                SqlDataReader reader = command.ExecuteReader();  // ִ�в�ѯ

                while (reader.Read())
                {
                    cboStar.Items.Add((string)reader[0]);
                }
                reader.Close();

                // ���Ѫ����Ͽ��е���
                sql = "SELECT BloodType FROM BloodType";  // �޸Ĳ�ѯ��䣬��ѯѪ��
                command.CommandText = sql;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cboBloodType.Items.Add((string)reader[0]);
                }
                reader.Close();
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
                MessageBox.Show("�����������������","��Ǹ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        // ���ȡ�����رմ���
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ���ע�ᣬ�����ݿ���Ӽ�¼
        private void btnRegist_Click(object sender, EventArgs e)
        {
            // ������֤ͨ�����Ͳ����¼�����ݿ�
            if (ValidateInput())
            {
                int myQQNum = 0;     // QQ����
                string message;      // ��������Ϣ
                string sex = rdoMale.Checked ? rdoMale.Text : rdoFemale.Text; // ���ѡ�е��Ա�
                string sql = "";     // ��ѯ�õ�SQL���
                int starId;          // ����Id
                int bloodTypeId;     // Ѫ��Id   
                bool error = false;  // �������ݿ��Ƿ����
                
                // ����������Ѫ�͵�ѡ���������ȷ��SQL���
                if (cboStar.Text != "" && cboBloodType.Text != "")
                {
                    // ���������Id
                    starId = GetStarId();
                    // ���Ѫ�͵�Id
                    bloodTypeId = GetBloodType();
                    sql = string.Format("INSERT INTO Users (LoginPwd, NickName, Sex, Age, Name, StarId, BloodTypeId) values ('{0}','{1}','{2}',{3},'{4}',{5},{6})",
                        txtLoginPwd.Text.Trim(), txtNickName.Text.Trim(), sex, int.Parse(txtAge.Text.Trim()), txtName.Text.Trim(), starId, bloodTypeId);
                }
                else if (cboStar.Text != "" && cboBloodType.Text == "")
                {
                    // ���������Id
                    starId = GetStarId();
                    sql = string.Format("INSERT INTO Users (LoginPwd, NickName, Sex, Age, Name, StarId) values ('{0}','{1}','{2}',{3},'{4}', {5})",
                            txtLoginPwd.Text.Trim(), txtNickName.Text.Trim(), sex, int.Parse(txtAge.Text.Trim()), txtName.Text.Trim(),starId);
                }
                else if (cboStar.Text == "" && cboBloodType.Text != "")
                {
                    // ���Ѫ�͵�Id
                    bloodTypeId = GetBloodType();
                    sql = string.Format("INSERT INTO Users (LoginPwd, NickName, Sex, Age, Name, BloodTypeId) values ('{0}','{1}','{2}',{3},'{4}', {5})",
                            txtLoginPwd.Text.Trim(), txtNickName.Text.Trim(), sex, int.Parse(txtAge.Text.Trim()), txtName.Text.Trim(), bloodTypeId);
                }
                else
                {
                    sql = string.Format("INSERT INTO Users (LoginPwd, NickName, Sex, Age, Name) values ('{0}','{1}','{2}',{3},'{4}')",
                                txtLoginPwd.Text.Trim(), txtNickName.Text.Trim(), sex, int.Parse(txtAge.Text.Trim()), txtName.Text.Trim());
                }
                
                try
                {
                    // ���� Command ����
                    SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                    DBHelper.connection.Open();             // �����ݿ�����
                    int result = command.ExecuteNonQuery(); // ִ�в�������
                    if (result == 1)
                    {
                        sql = "SELECT @@Identity FROM Users";  // ��ѯ�����ӵļ�¼�ı�ʶ��
                        command.CommandText = sql;             // ����ָ�� Command ����� SQL ���
                        myQQNum = Convert.ToInt32(command.ExecuteScalar());  // ǿ������ת�������
                        message = string.Format("ע��ɹ������MyQQ������{0}", myQQNum);
                    }
                    else
                    {
                        message = "ע��ʧ�ܣ������ԣ�";                        
                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    message = "��������������������Ժ����ԣ�";
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    DBHelper.connection.Close();  // �ر����ݿ�����
                }

                // ��ʾע����
                if (error)
                {
                    MessageBox.Show(message, "ע��ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                }
                else
                {
                    MessageBox.Show(message, "ע����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
        }

        /// <summary>
        /// ��֤�û�������
        /// </summary>        
        private bool ValidateInput()
        {
            if (txtNickName.Text.Trim() == "")
            {
                MessageBox.Show("�������ǳƣ�","������ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtNickName.Focus();
                return false;
            }
            if (txtAge.Text.Trim() == "")
            {
                MessageBox.Show("���������䣡", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAge.Focus();
                return false;
            }
            if (!rdoMale.Checked && !rdoFemale.Checked)
            {
                MessageBox.Show("��ѡ���Ա�", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSex.Focus();
                return false;
            }
            if (txtLoginPwd.Text.Trim() == "")
            {
                MessageBox.Show("���������룡", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginPwd.Focus();
                return false;
            }
            if (txtLoginPwdAgain.Text.Trim() == "")
            {
                MessageBox.Show("������ȷ�����룡", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginPwdAgain.Focus();
                return false;
            }
            if (txtLoginPwd.Text.Trim() != txtLoginPwdAgain.Text.Trim())
            {
                MessageBox.Show("������������벻һ����", "������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoginPwdAgain.Focus();
                return false;
            }
            return true;
        }        

        /// <summary>
        /// ȡ�������� Id
        /// </summary>        
        private int GetStarId()
        {
            int starId = -1;  // ����ֵ
            // ��ѯ����Id�� SQL ���
            string sql = string.Format("SELECT Id FROM Star WHERE Star = '{0}'", cboStar.Text);
            try
            {
                // ���� Command ����
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();  // �����ݿ�����
                starId = Convert.ToInt32(command.ExecuteScalar());                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }

            if (starId > 0)
            {
                return starId;
            }
            else
            {
                return -1;
            }                 
        }

        /// <summary>
        /// ȡ��Ѫ�͵� Id
        /// </summary>        
        private int GetBloodType()
        {
            int bloodTypeId = -1;  // ����ֵ

            // ��ѯ����Id�� SQL ���
            string sql = string.Format("SELECT Id FROM BloodType WHERE BloodType = '{0}'", cboBloodType.Text);
            try
            {
                // ���� Command ����
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();  // �����ݿ�����
                bloodTypeId = Convert.ToInt32(command.ExecuteScalar());                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }
            if (bloodTypeId > 0)
            {
                return bloodTypeId;
            }
            else
            {
                return -1;
            }          
        }
    }
}