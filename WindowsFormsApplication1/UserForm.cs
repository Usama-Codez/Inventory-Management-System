using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApplication1
{
    public partial class UserForm : Form
    {
        OracleConnection con;

        public UserForm()
        {
            InitializeComponent();
        }
        private void UserForm_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; User ID=IMS;PASSWORD=123";
            con = new OracleConnection(conStr);
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            con.Open();
            OracleCommand getUsers = con.CreateCommand();
            getUsers.CommandText = "Select * From tbUser";
            getUsers.CommandType = CommandType.Text;
            OracleDataReader uDR = getUsers.ExecuteReader();
            while (uDR.Read())
            {
                i++;
                dgvUser.Rows.Add(i, uDR[0].ToString(), uDR[1].ToString(), uDR[2].ToString(), uDR[3].ToString());
            }
            uDR.Close();
            con.Close();
        }

        private void customerButton1_Click(object sender, EventArgs e)
        {
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;
            userModule.ShowDialog();
            LoadUser();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm();
                userModule.txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtFullName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtPass.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                userModule.btnSave.Enabled = false;
                userModule.btnUpdate.Enabled = true;
                userModule.ShowDialog();
                LoadUser();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure to delete this User?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    OracleCommand cmnd = con.CreateCommand();
                    cmnd.CommandText = "DELETE From tbUser WHERE username LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                    cmnd.CommandType = CommandType.Text;

                    int rows = cmnd.ExecuteNonQuery();
                    if (rows > 0)
                        MessageBox.Show("User has Deleted Successfully!");

                    con.Close();
                }
            }
            LoadUser();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
