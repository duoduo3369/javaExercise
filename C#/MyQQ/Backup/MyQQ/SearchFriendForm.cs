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
    /// ���Һ���Ӻ��Ѵ���
    /// </summary>
    public partial class SearchFriendForm : Form
    {
        private DataSet dataSet;  // ���ݼ�
        private SqlDataAdapter dataAdapter;  // ����������
        
        public SearchFriendForm()
        {
            InitializeComponent();
        }

        // �������ʱ��������ݼ�
        private void SearchFriendForm_Load(object sender, EventArgs e)
        {
            // ʵ�������ݼ������������������
            string sql = "SELECT Id, NickName, Age, Sex FROM Users";
            dataAdapter = new SqlDataAdapter(sql, DBHelper.connection);            
            dataSet = new DataSet("MyQQ");
            dataAdapter.Fill(dataSet, "Users");

            // ָ��DataGridView������Դ
            dgvBasicResult.DataSource = dataSet.Tables[0];
            dgvAdvancedResult.DataSource = dataSet.Tables[0];
        }

        // ������Ұ�ťʱ�����ҷ����������û�
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tabSearch.SelectedIndex == 0) // ��������ѡ�Կ�ѡ��
            {
                BasicallySearch();
            }
            else  // �߼�����ѡ�ѡ��
            {
                AdvancedSearch();
            }
        }

        // ��Ӻ���
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int friendshipPolicyId = -1;  // �Է��ĺ��Ѳ���            

            int friendId = GetSelectedFriendId();  // ���ѡ�еĺ��ѵ�Id

            // �Ƿ��п���ӵĺ���
            if (friendId == -1)
            {
                MessageBox.Show("��ѡ��һ�����ѣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (friendId == UserHelper.loginId)
            {
                MessageBox.Show("���ܼ��Լ�Ϊ���ѣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (HasAdded(friendId))  // ȷ���Ƿ���Ҫ��ӣ��Ƿ��Ѿ��Ǻ����ˣ�
            {
                MessageBox.Show("�Է�������ĺ����б��У�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ȷ�϶Է��ܷ񱻼�Ϊ����
            friendshipPolicyId = GetFriendshipPolicyId(friendId);
                        
            if (friendshipPolicyId == 3) // 3��ʾ�������κ�����ӣ���S2����ʹ�ó�����ö��
            {
                MessageBox.Show("�Է��������κ��˼���Ϊ���ѣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (friendshipPolicyId == 2) // 2����ʾ��Ҫ�����֤
            {
                int result = SendRequest(friendId);  // ����֤��Ϣ
                if (result == 1)
                {
                    MessageBox.Show("�Է���Ҫ�����֤���ܱ���Ϊ���ѣ��ѷ�������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("���ʧ�ܣ����Ժ����ԣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }            
            else if (friendshipPolicyId == 1) // 1����ʾ�����κ������Ϊ����
            {
                // ִ����Ӳ���
                int result = AddFriend(friendId);
                if (result == 1)
                {
                    MessageBox.Show("��ӳɹ�����ˢ�º����б�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("���ʧ�ܣ����Ժ����ԣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // ���л�ҳʱ��������ҽ����صĿؼ�������
        private void tabSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlBaseResult.Visible = false;
            pnlAdvancedResult.Visible = false;
            btnAdd.Visible = false;
            btnBack.Visible = false;
        }

        // ���ƾ�ȷ����ѡ���Ƿ�ɼ�
        private void rdoNicetySearch_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNicetySearch.Checked == true)
            {
                grpBaseCondition.Visible = true;
            }
            else
            {
                grpBaseCondition.Visible = false;
            }
        }

        // ���ص���һ��
        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlBaseResult.Visible = false;
            pnlAdvancedResult.Visible = false;
            pnlBaseCondition.Visible = true;
            pnlAdvancedCondition.Visible = true;
            btnBack.Visible = false;
            btnAdd.Visible = false;            
        }

        // �رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void BasicallySearch()
        {
            string sql = "";
            // ��ѯ����ǰ�벿��
            sql = "SELECT Id,NickName,Age,Sex FROM Users";
            
            // ��ȷ����
            if (rdoNicetySearch.Checked == true)
            {
                if (txtLoginId.Text.Trim() == "" && txtNickName.Text.Trim() == "")
                {
                    MessageBox.Show("��û�����ѯ�����أ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // ���ʺŲ���
                else if (txtLoginId.Text.Trim() != "")  
                {
                    sql += string.Format(" WHERE Id={0}", int.Parse(txtLoginId.Text.Trim()));
                }
                // ���ǳƲ���
                else
                {
                    sql += string.Format(" WHERE NickName like '%{0}%'", txtNickName.Text.Trim());
                 }                
            }

            // �������DataSet
            dataSet.Tables[0].Clear();
            dataAdapter.SelectCommand.CommandText = sql;
            dataAdapter.Fill(dataSet,"Users"); 

            // ���ÿؼ��ɼ�������
            // ������ʾ�����panel��λ�ã���������ʾ������Panel��λ����ͬ
            pnlBaseResult.Location = pnlBaseCondition.Location;
            // ʹ��ʾ�����panel�ɼ�
            pnlBaseResult.Visible = true;
            btnAdd.Visible = true;����//����Ϊ���ѡ���ť�ɼ�
            btnBack.Visible = true;   //����һ������ť�ɼ�
        }

        /// <summary>
        /// �߼�����
        /// </summary>
        private void AdvancedSearch()
        {
            string sql = "";
            // ��ѯ����ǰ�벿��
            sql = "SELECT Id,NickName,Age,Sex FROM Users";

            string ageCondition = "";  // ��������
            string sexCondition = cboSex.Text;  // �Ա�����

            // ȷ������ķ�Χ
            switch (cboAge.SelectedIndex)
            { 
                case 1:
                    ageCondition = " Age>=0 AND Age<10";
                    break;
                case 2:
                    ageCondition = " Age>=10 AND Age<20";
                    break;
                case 3:
                    ageCondition = " Age>=20 AND Age<30";
                    break;
                case 4:
                    ageCondition = " Age>=30 AND Age<40";
                    break;
                case 5:
                    ageCondition = " Age>=40 AND Age<50";
                    break;
                case 6:
                    ageCondition = " Age>=50";
                    break;
                default:
                    ageCondition = "";
                    break;
            }

            if (ageCondition == "" && sexCondition == "")
            {
                MessageBox.Show("��û��ѡ���ѯ�����أ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else 
            {
                if (ageCondition != "" && sexCondition == "")
                {
                    sql += string.Format(" WHERE {0}", ageCondition);
                }
                else if (ageCondition == "" && sexCondition != "")
                {
                    sql += string.Format(" WHERE Sex='{0}'", sexCondition);
                }
                else
                { 
                    sql += string.Format(" WHERE {0} AND Sex='{1}'",ageCondition,sexCondition);
                }
            }

            // ��ʼ����
            dataAdapter.SelectCommand.CommandText = sql;
            dataSet.Tables[0].Clear();
            dataAdapter.Fill(dataSet, "Users");

            // ���ÿؼ�������
            pnlAdvancedResult.Location = pnlAdvancedCondition.Location;
            pnlAdvancedResult.Visible = true;                                  
            btnAdd.Visible = true;
            btnBack.Visible = true;
        }        
        
        /// <summary>
        /// ���ѡ�еĺ��ѵ�Id
        /// </summary>        
        private int GetSelectedFriendId()
        {
            int friendId = -1;  // ���ѵĺ���

            // ��������
            if (tabSearch.SelectedIndex == 0)
            {
                // û��ѡ���κ�һ��
                if (dgvBasicResult.SelectedRows.Count == 0)
                {
                    MessageBox.Show("��ѡ��һ�����ѣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // ȷ����һ����Ԫ����ֵ
                else if (dgvBasicResult.SelectedRows[0].Cells[0] != null)  
                {
                    // ���DataGridView��ѡ�е��еĵ�һ����Ԫ���ֵ
                    friendId = int.Parse(dgvBasicResult.SelectedRows[0].Cells[0].Value.ToString());                   
                }
            }
            // �߼�����
            else if (tabSearch.SelectedIndex == 1)
            {
                if (dgvAdvancedResult.SelectedRows.Count == 0)
                {
                    MessageBox.Show("��ѡ��һ�����ѣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dgvAdvancedResult.SelectedRows[0].Cells[0] != null)
                {
                    friendId = int.Parse(dgvAdvancedResult.SelectedRows[0].Cells[0].Value.ToString());
                }
            }

            return friendId;
        }

        /// <summary>
        /// ȷ�϶Է��ܷ񱻼�Ϊ����
        /// </summary>        
        private int GetFriendshipPolicyId(int userId)
        {
            int friendshipPolicyId = 1;  // ���Ѳ���
            string sql = "SELECT FriendshipPolicyId FROM Users WHERE Id=" + userId;
            try
            {
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();

                friendshipPolicyId = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }
            return friendshipPolicyId;
        }

        /// <summary>
        /// ���Һ����Ƿ��ѱ����
        /// </summary>        
        private bool HasAdded(int friendId)
        {
            int result = 0;  // ���ҽ��
            bool returnValue; // ����ֵ
            string sql = string.Format(
                "SELECT COUNT(*) FROM Friends WHERE HostId={0} AND FriendId={1}",
                UserHelper.loginId, friendId);
            try
            {
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                result = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }

            // ���м�¼����
            returnValue = result > 0 ? true : false;
            return returnValue;
        }

        /// <summary>
        /// ִ����Ӻ��ѵĲ���
        /// </summary>        
        private int AddFriend(int friendId)
        {
            int resunlt = 0; // �������
            string sql = string.Format("INSERT INTO FRIENDS (HostId, FriendId) VALUES ({0},{1})",
                UserHelper.loginId, friendId);

            try
            {
                // ִ����Ӳ���
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                resunlt = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }
            return resunlt;
        }

        /// <summary>
        /// ������Ӻ�������
        /// </summary>        
        private int SendRequest(int friendId)
        {
            int resunlt = 0; // �������
            string sql = string.Format("INSERT INTO Messages (FromUserId, ToUserId, MessageTypeId, MessageState) VALUES ({0},{1},{2},{3})",
                UserHelper.loginId, friendId,2,0);

            try
            {
                // ִ����Ӳ���
                SqlCommand command = new SqlCommand(sql, DBHelper.connection);
                DBHelper.connection.Open();
                resunlt = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DBHelper.connection.Close();
            }
            return resunlt;
        }
    }
}