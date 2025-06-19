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
    public partial class UserModuleForm : Form
    {
        OracleConnection con;
        public UserModuleForm()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserModuleForm_Load(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            string conStr = @"DATA SOURCE = localhost:1521/xe; User ID=IMS;PASSWORD=123";
            con = new OracleConnection(conStr);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void customerButton6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCnfPass.Text != txtPass.Text)
            {
                MessageBox.Show("Password Not Matched!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Save this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                OracleCommand insrt = con.CreateCommand();
                insrt.CommandText = "INSERT INTO tbUser VALUES(:username, :fullname, :password, :phone, :role)";
                insrt.Parameters.Add(new OracleParameter("username", txtUserName.Text));
                insrt.Parameters.Add(new OracleParameter("fullname", txtFullName.Text));
                insrt.Parameters.Add(new OracleParameter("role", txtRole.Text));
                insrt.Parameters.Add(new OracleParameter("password", txtPass.Text));
                insrt.Parameters.Add(new OracleParameter("phone", txtPhone.Text));
                insrt.CommandType = CommandType.Text;
                try
                {
                    int row = insrt.ExecuteNonQuery();
                    if (row > 0)
                        MessageBox.Show("User has been saved sucessfully.");
                    con.Close();
                    clear();
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 1)
                    {
                        MessageBox.Show("Sorry, but same User already exist in the table");
                    }
                    else
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
  
        public void clear()
        {
            txtUserName.Clear();
            txtFullName.Clear();
            txtPass.Clear();
            txtCnfPass.Clear();
            txtPhone.Clear();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCnfPass.Text != txtPass.Text)
            {
                MessageBox.Show("Password Not Matched!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure you want to Update this user?", "Updating Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                OracleCommand upd = con.CreateCommand();
                upd.CommandText = "UPDATE tbUser SET username = :username, FullName = :fullname, Password = :password WHERE Phone = :phone";
                upd.CommandType = CommandType.Text;
                upd.Parameters.Add(new OracleParameter("username", txtUserName.Text));
                upd.Parameters.Add(new OracleParameter("fullname", txtFullName.Text));
                upd.Parameters.Add(new OracleParameter("password", txtPass.Text));
                upd.Parameters.Add(new OracleParameter("phone", txtPhone.Text));
                int row = upd.ExecuteNonQuery();
                if (row > 0)
                    MessageBox.Show("User has been updated successfully.");
                else
                    MessageBox.Show("Username not matched in the table");
                con.Close();
                this.Dispose();
            }
        }
    }
}
