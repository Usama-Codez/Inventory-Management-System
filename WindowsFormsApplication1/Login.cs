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
    public partial class Login : Form
    {
        OracleConnection con;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/xe; User ID=IMS;PASSWORD=123";
            con = new OracleConnection(conStr);
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void customerButton6_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.Lime;
            TransparencyKey = Color.Lime;
        }

        private void customerButton1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand getLoginInfo = con.CreateCommand();
                getLoginInfo.CommandText = "SELECT * FROM tbUser WHERE username = :username AND password = :password";
                getLoginInfo.Parameters.Add(new OracleParameter("username", txtUsername.Text));
                getLoginInfo.Parameters.Add(new OracleParameter("password", txtPassword.Text));
                getLoginInfo.CommandType = CommandType.Text;
                OracleDataReader dr = getLoginInfo.ExecuteReader();
                if (dr.Read())
                {
                    string role = dr["role"].ToString();
                    mainPageForm mainForm = new mainPageForm(role);
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      

        private void customerButton2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (MessageBox.Show("Are you sure you want to sign up?", "Saving User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    OracleCommand getLoginInfo = con.CreateCommand();
                    getLoginInfo.CommandText = "Select * From tbUser WHERE username LIKE ('admin') OR username LIKE ('Admin') AND password = :txtAdminPass";
                    getLoginInfo.Parameters.Add(new OracleParameter("password", txtAdminPass.Text));
                    getLoginInfo.CommandType = CommandType.Text;
                    OracleDataReader dr = getLoginInfo.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        flag = true;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Admin Password! Only admin can add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearAdimnPass();
                    }
                    con.Close();
                }

                catch (OracleException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (flag)
            {
                if (txtCnfPass.Text != txtPass.Text)
                {
                    MessageBox.Show("Password Not Matched!.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    clear2();
                    return;
                }

                else
                {
                    con.Open();
                    OracleCommand insrt = con.CreateCommand();
                    insrt.CommandText = "INSERT INTO tbUser VALUES(:username, :fullname, :password, :phone, :role)";
                    insrt.Parameters.Add(new OracleParameter("username", txtUname.Text));
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
        }

        public void clearAdimnPass()
        {
            txtAdminPass.Clear();
        }
        public void clear2()
        {
            txtCnfPass.Clear();
        }
        public void clear()
        {
            txtUsername.Clear();
            txtUname.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
            txtPass.Clear();
            txtFullName.Clear();
            txtCnfPass.Clear();
            txtRole.Clear();
            txtAdminPass.Clear();
        }

        private void pb1_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                pb2.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void pb2_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                pb1.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void pb4_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                pb3.BringToFront();
                txtPass.PasswordChar = '*';
            }
        }

        private void pb3_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                pb4.BringToFront();
                txtPass.PasswordChar = '\0';
            }
        }
    }
}
